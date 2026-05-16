using Microsoft.EntityFrameworkCore;
using CenevalApp.Data;
using System.Text.Json.Serialization;
using CenevalApp.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.AllowAnyOrigin() 
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        // ── Migraciones manuales silenciosas ─────────────────────────────────
        // Verificar si la columna existe antes de agregarla para evitar
        // errores de "Duplicate column name" en los logs.
        var dbName = db.Database.GetDbConnection().Database;

        var hasAnsweredIds = db.Database
            .SqlQueryRaw<int>(
                $"SELECT COUNT(*) AS `Value` FROM information_schema.COLUMNS " +
                $"WHERE TABLE_SCHEMA = '{dbName}' AND TABLE_NAME = 'UserProgress' AND COLUMN_NAME = 'AnsweredQuestionsIds'")
            .AsEnumerable().First();
        if (hasAnsweredIds == 0)
            db.Database.ExecuteSqlRaw("ALTER TABLE UserProgress ADD COLUMN AnsweredQuestionsIds VARCHAR(1000) DEFAULT '';");

        var hasLevelUp = db.Database
            .SqlQueryRaw<int>(
                $"SELECT COUNT(*) AS `Value` FROM information_schema.COLUMNS " +
                $"WHERE TABLE_SCHEMA = '{dbName}' AND TABLE_NAME = 'UserProgress' AND COLUMN_NAME = 'LevelUpPending'")
            .AsEnumerable().First();
        if (hasLevelUp == 0)
            db.Database.ExecuteSqlRaw("ALTER TABLE UserProgress ADD COLUMN LevelUpPending TINYINT(1) NOT NULL DEFAULT 0;");

        // ── Columna CurrentEvaluationId en UserProgress ────────────────────
        var hasEvalId = db.Database
            .SqlQueryRaw<int>(
                $"SELECT COUNT(*) AS `Value` FROM information_schema.COLUMNS " +
                $"WHERE TABLE_SCHEMA = '{dbName}' AND TABLE_NAME = 'UserProgress' AND COLUMN_NAME = 'CurrentEvaluationId'")
            .AsEnumerable().First();
        if (hasEvalId == 0)
            db.Database.ExecuteSqlRaw("ALTER TABLE UserProgress ADD COLUMN CurrentEvaluationId INT NULL;");

        // ── Tablas de historial (CREATE IF NOT EXISTS) ─────────────────────
        db.Database.ExecuteSqlRaw(@"
            CREATE TABLE IF NOT EXISTS Evaluations (
                EvaluationId INT PRIMARY KEY AUTO_INCREMENT,
                UserIdInt INT NOT NULL,
                StartDateTime DATETIME DEFAULT CURRENT_TIMESTAMP,
                TotalQuestions INT NOT NULL DEFAULT 0,
                CorrectAnswers INT NOT NULL DEFAULT 0,
                ScorePercentage DECIMAL(5,2) NOT NULL DEFAULT 0,
                CONSTRAINT FK_Evaluations_Users FOREIGN KEY (UserIdInt) REFERENCES Users(Id)
            );");

        db.Database.ExecuteSqlRaw(@"
            CREATE TABLE IF NOT EXISTS EvaluationDetails (
                DetailId INT PRIMARY KEY AUTO_INCREMENT,
                EvaluationId INT NOT NULL,
                QuestionId INT NOT NULL,
                SelectedOptionId INT NOT NULL,
                IsCorrect TINYINT(1) NOT NULL,
                CONSTRAINT FK_Details_Evaluations FOREIGN KEY (EvaluationId) REFERENCES Evaluations(EvaluationId),
                CONSTRAINT FK_Details_Questions FOREIGN KEY (QuestionId) REFERENCES Questions(QuestionId),
                CONSTRAINT FK_Details_Options FOREIGN KEY (SelectedOptionId) REFERENCES Options(OptionId)
            );");

        // Limpiar opciones autogeneradas antiguas
        try {
            db.Database.ExecuteSqlRaw("DELETE FROM Options WHERE Text LIKE 'Opción distractora %' OR Text LIKE 'Opción % (Generada)'");
        } catch { }

        // Ejecutar INSERTS_OPTIONS_FINALES.sql
        var scriptPath = Path.Combine(Directory.GetParent(builder.Environment.ContentRootPath)?.FullName ?? "", "INSERTS_OPTIONS_FINALES.sql");
        if (File.Exists(scriptPath))
        {
            var scriptContent = File.ReadAllText(scriptPath);
            var commands = scriptContent.Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var command in commands)
            {
                var trimmed = command.Trim();
                if (trimmed.StartsWith("INSERT INTO", StringComparison.OrdinalIgnoreCase))
                {
                    try { db.Database.ExecuteSqlRaw(trimmed); } catch { }
                }
            }
        }

        // Ejecutar INSERTS_EASY_QUESTIONS.sql (preguntas de nivel Fácil, Difficulty=3)
        var easyScriptPath = Path.Combine(Directory.GetParent(builder.Environment.ContentRootPath)?.FullName ?? "", "INSERTS_EASY_QUESTIONS.sql");
        if (File.Exists(easyScriptPath))
        {
            var easyScriptContent = File.ReadAllText(easyScriptPath);
            var easyCommands = easyScriptContent.Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var command in easyCommands)
            {
                var trimmed = command.Trim();
                if (trimmed.StartsWith("INSERT INTO", StringComparison.OrdinalIgnoreCase))
                {
                    try { db.Database.ExecuteSqlRaw(trimmed); } catch { }
                }
            }
        }

        // Autocompletar opciones para preguntas que no tienen las 4 opciones
        // Esto arregla el problema de las preguntas que se quedaron con 1 sola opción
        var questionsNeedsOptions = db.Questions.Include(q => q.Options).Where(q => q.Options.Count < 4).ToList();
        if (questionsNeedsOptions.Any())
        {
            int nextOptionId = db.Options.Any() ? db.Options.Max(o => o.OptionId) + 1 : 1;
            foreach (var q in questionsNeedsOptions)
            {
                // Limpiar cualquier opción a medias (ej. si quedó 1 sola opción correcta de una generación previa)
                if (q.Options.Any())
                {
                    db.Options.RemoveRange(q.Options);
                }

                string correctAnswer = string.IsNullOrWhiteSpace(q.Feedback) ? "Respuesta correcta" : q.Feedback;
                
                var seDistractors = new[] { "Integración Continua", "Polimorfismo", "Despliegue Azul-Verde", "Deuda Técnica", "Acoplamiento Fuerte", "Herencia Múltiple", "Programación Extrema", "Diagrama de Casos de Uso", "Patrón Singleton", "Arquitectura Monolítica", "Pruebas de Regresión", "Scrum Master", "Refactorización", "Control de Versiones", "Desarrollo en Cascada", "Patrón Observer", "Mantenimiento Preventivo", "Pruebas de Caja Blanca", "Desarrollo TDD", "Análisis de Requisitos" };
                var dbDistractors = new[] { "Llave Foránea", "Índice Agrupado", "Procedimiento Almacenado", "Normalización 3NF", "Transacción ACID", "Deadlock", "Sentencia UPDATE", "Cláusula HAVING", "Particionamiento Vertical", "Base de Datos NoSQL", "Trigger AFTER INSERT", "Restricción UNIQUE", "Vistas Materializadas", "Join Externo", "Esquema de Estrella", "Motor de Almacenamiento", "Bloqueo de Tabla", "Replicación Master-Slave", "Fragmentación Horizontal", "Consistencia Eventual" };

                var pool = q.TopicId == 1 ? seDistractors : dbDistractors;
                var shuffled = pool.OrderBy(x => Guid.NewGuid()).Take(3).ToList();

                db.Options.AddRange(
                    new Option { OptionId = nextOptionId++, QuestionId = q.QuestionId, Text = correctAnswer, IsCorrect = true },
                    new Option { OptionId = nextOptionId++, QuestionId = q.QuestionId, Text = shuffled[0], IsCorrect = false },
                    new Option { OptionId = nextOptionId++, QuestionId = q.QuestionId, Text = shuffled[1], IsCorrect = false },
                    new Option { OptionId = nextOptionId++, QuestionId = q.QuestionId, Text = shuffled[2], IsCorrect = false }
                );
            }
            db.SaveChanges();
        }
    }
}

app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();