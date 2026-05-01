using Microsoft.EntityFrameworkCore;
using CenevalApp.Models;

namespace CenevalApp.Data.Seeds
{
    public static class OptionSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Option>().HasData(
                // Q1
                new Option { OptionId = 1, QuestionId = 1, IsCorrect = true, Text = "Modelo en Espiral" },
                new Option { OptionId = 2, QuestionId = 1, IsCorrect = false, Text = "Cascada" },
                new Option { OptionId = 3, QuestionId = 1, IsCorrect = false, Text = "RUP" },
                new Option { OptionId = 4, QuestionId = 1, IsCorrect = false, Text = "Prototipado" },
                // Q2
                new Option { OptionId = 5, QuestionId = 2, IsCorrect = true, Text = "Datos" },
                new Option { OptionId = 6, QuestionId = 2, IsCorrect = false, Text = "Contenido" },
                new Option { OptionId = 7, QuestionId = 2, IsCorrect = false, Text = "Temporal" },
                new Option { OptionId = 8, QuestionId = 2, IsCorrect = false, Text = "Lógico" },
                // Q3
                new Option { OptionId = 9, QuestionId = 3, IsCorrect = true, Text = "Microservicios" },
                new Option { OptionId = 10, QuestionId = 3, IsCorrect = false, Text = "Monolítica" },
                new Option { OptionId = 11, QuestionId = 3, IsCorrect = false, Text = "Capas" },
                new Option { OptionId = 12, QuestionId = 3, IsCorrect = false, Text = "P2P" },
                // Q4
                new Option { OptionId = 13, QuestionId = 4, IsCorrect = true, Text = "Patrones de Concurrencia" },
                new Option { OptionId = 14, QuestionId = 4, IsCorrect = false, Text = "Singleton" },
                new Option { OptionId = 15, QuestionId = 4, IsCorrect = false, Text = "Factory" },
                new Option { OptionId = 16, QuestionId = 4, IsCorrect = false, Text = "Facade" },
                // Q5
                new Option { OptionId = 17, QuestionId = 5, IsCorrect = true, Text = "Diagrama de Clases" },
                new Option { OptionId = 18, QuestionId = 5, IsCorrect = false, Text = "Secuencia" },
                new Option { OptionId = 19, QuestionId = 5, IsCorrect = false, Text = "Estados" },
                new Option { OptionId = 20, QuestionId = 5, IsCorrect = false, Text = "Casos de Uso" },
                // Q6
                new Option { OptionId = 21, QuestionId = 6, IsCorrect = true, Text = "Validación de Tipos" },
                new Option { OptionId = 22, QuestionId = 6, IsCorrect = false, Text = "Cifrado" },
                new Option { OptionId = 23, QuestionId = 6, IsCorrect = false, Text = "Tokens" },
                new Option { OptionId = 24, QuestionId = 6, IsCorrect = false, Text = "Firewalls" },
                // Q7
                new Option { OptionId = 25, QuestionId = 7, IsCorrect = true, Text = "Baja Mantenibilidad" },
                new Option { OptionId = 26, QuestionId = 7, IsCorrect = false, Text = "Alta Usabilidad" },
                new Option { OptionId = 27, QuestionId = 7, IsCorrect = false, Text = "Seguridad" },
                new Option { OptionId = 28, QuestionId = 7, IsCorrect = false, Text = "Portabilidad" },
                // Q8
                new Option { OptionId = 29, QuestionId = 8, IsCorrect = true, Text = "Strategy" },
                new Option { OptionId = 30, QuestionId = 8, IsCorrect = false, Text = "Singleton" },
                new Option { OptionId = 31, QuestionId = 8, IsCorrect = false, Text = "Bridge" },
                new Option { OptionId = 32, QuestionId = 8, IsCorrect = false, Text = "Proxy" },
                // Q9
                new Option { OptionId = 33, QuestionId = 9, IsCorrect = true, Text = "Scrum" },
                new Option { OptionId = 34, QuestionId = 9, IsCorrect = false, Text = "Kanban" },
                new Option { OptionId = 35, QuestionId = 9, IsCorrect = false, Text = "Lean" },
                new Option { OptionId = 36, QuestionId = 9, IsCorrect = false, Text = "XP" },
                // Q10
                new Option { OptionId = 37, QuestionId = 10, IsCorrect = true, Text = "Aspectos/Interceptores" },
                new Option { OptionId = 38, QuestionId = 10, IsCorrect = false, Text = "Herencia" },
                new Option { OptionId = 39, QuestionId = 10, IsCorrect = false, Text = "Interfaces" },
                new Option { OptionId = 40, QuestionId = 10, IsCorrect = false, Text = "Stored Procs" },
                // Q11
                new Option { OptionId = 41, QuestionId = 11, IsCorrect = true, Text = "Carga" },
                new Option { OptionId = 42, QuestionId = 11, IsCorrect = false, Text = "Unitaria" },
                new Option { OptionId = 43, QuestionId = 11, IsCorrect = false, Text = "Aceptación" },
                new Option { OptionId = 44, QuestionId = 11, IsCorrect = false, Text = "Humo" },
                // Q12
                new Option { OptionId = 45, QuestionId = 12, IsCorrect = true, Text = "HTTPS/TLS" },
                new Option { OptionId = 46, QuestionId = 12, IsCorrect = false, Text = "FTP" },
                new Option { OptionId = 47, QuestionId = 12, IsCorrect = false, Text = "SSH" },
                new Option { OptionId = 48, QuestionId = 12, IsCorrect = false, Text = "SMTP" },
                // Q13
                new Option { OptionId = 49, QuestionId = 13, IsCorrect = true, Text = "Negociación" },
                new Option { OptionId = 50, QuestionId = 13, IsCorrect = false, Text = "Codificación" },
                new Option { OptionId = 51, QuestionId = 13, IsCorrect = false, Text = "Pruebas" },
                new Option { OptionId = 52, QuestionId = 13, IsCorrect = false, Text = "Diseño" },
                // Q14
                new Option { OptionId = 53, QuestionId = 14, IsCorrect = true, Text = "Observer" },
                new Option { OptionId = 54, QuestionId = 14, IsCorrect = false, Text = "Builder" },
                new Option { OptionId = 55, QuestionId = 14, IsCorrect = false, Text = "Memento" },
                new Option { OptionId = 56, QuestionId = 14, IsCorrect = false, Text = "Iterator" },
                // Q15
                new Option { OptionId = 57, QuestionId = 15, IsCorrect = true, Text = "Singleton" },
                new Option { OptionId = 58, QuestionId = 15, IsCorrect = false, Text = "State" },
                new Option { OptionId = 59, QuestionId = 15, IsCorrect = false, Text = "Command" },
                new Option { OptionId = 60, QuestionId = 15, IsCorrect = false, Text = "Mediator" },
                // Q16
                new Option { OptionId = 61, QuestionId = 16, IsCorrect = true, Text = "3NF" },
                new Option { OptionId = 62, QuestionId = 16, IsCorrect = false, Text = "1NF" },
                new Option { OptionId = 63, QuestionId = 16, IsCorrect = false, Text = "2NF" },
                new Option { OptionId = 64, QuestionId = 16, IsCorrect = false, Text = "BCNF" },
                // Q17
                new Option { OptionId = 65, QuestionId = 17, IsCorrect = true, Text = "No Agrupado" },
                new Option { OptionId = 66, QuestionId = 17, IsCorrect = false, Text = "Agrupado" },
                new Option { OptionId = 67, QuestionId = 17, IsCorrect = false, Text = "XML" },
                new Option { OptionId = 68, QuestionId = 17, IsCorrect = false, Text = "Full-Text" },
                // Q18
                new Option { OptionId = 69, QuestionId = 18, IsCorrect = true, Text = "Atomicidad" },
                new Option { OptionId = 70, QuestionId = 18, IsCorrect = false, Text = "Aislamiento" },
                new Option { OptionId = 71, QuestionId = 18, IsCorrect = false, Text = "Consistencia" },
                new Option { OptionId = 72, QuestionId = 18, IsCorrect = false, Text = "Durabilidad" },
                // Q19
                new Option { OptionId = 73, QuestionId = 19, IsCorrect = true, Text = "NoSQL" },
                new Option { OptionId = 74, QuestionId = 19, IsCorrect = false, Text = "Relacional" },
                new Option { OptionId = 75, QuestionId = 19, IsCorrect = false, Text = "Excel" },
                new Option { OptionId = 76, QuestionId = 19, IsCorrect = false, Text = "Jerárquica" },
                // Q20
                new Option { OptionId = 77, QuestionId = 20, IsCorrect = true, Text = "GROUP BY" },
                new Option { OptionId = 78, QuestionId = 20, IsCorrect = false, Text = "ORDER BY" },
                new Option { OptionId = 79, QuestionId = 20, IsCorrect = false, Text = "HAVING" },
                new Option { OptionId = 80, QuestionId = 20, IsCorrect = false, Text = "WHERE" },
                // Q21
                new Option { OptionId = 81, QuestionId = 21, IsCorrect = true, Text = "Durabilidad" },
                new Option { OptionId = 82, QuestionId = 21, IsCorrect = false, Text = "Atomicidad" },
                new Option { OptionId = 83, QuestionId = 21, IsCorrect = false, Text = "Disponibilidad" },
                new Option { OptionId = 84, QuestionId = 21, IsCorrect = false, Text = "Escalabilidad" },
                // Q22
                new Option { OptionId = 85, QuestionId = 22, IsCorrect = true, Text = "FK (Foreign Key)" },
                new Option { OptionId = 86, QuestionId = 22, IsCorrect = false, Text = "PK (Primary Key)" },
                new Option { OptionId = 87, QuestionId = 22, IsCorrect = false, Text = "Check" },
                new Option { OptionId = 88, QuestionId = 22, IsCorrect = false, Text = "Unique" },
                // Q23
                new Option { OptionId = 89, QuestionId = 23, IsCorrect = true, Text = "Trigger" },
                new Option { OptionId = 90, QuestionId = 23, IsCorrect = false, Text = "Procedimiento" },
                new Option { OptionId = 91, QuestionId = 23, IsCorrect = false, Text = "Función" },
                new Option { OptionId = 92, QuestionId = 23, IsCorrect = false, Text = "Vista" },
                // Q24
                new Option { OptionId = 93, QuestionId = 24, IsCorrect = true, Text = "Tabla Intermedia" },
                new Option { OptionId = 94, QuestionId = 24, IsCorrect = false, Text = "Auto-relación" },
                new Option { OptionId = 95, QuestionId = 24, IsCorrect = false, Text = "Nulabilidad" },
                new Option { OptionId = 96, QuestionId = 24, IsCorrect = false, Text = "Herencia" },
                // Q25
                new Option { OptionId = 97, QuestionId = 25, IsCorrect = true, Text = "INNER JOIN" },
                new Option { OptionId = 98, QuestionId = 25, IsCorrect = false, Text = "LEFT JOIN" },
                new Option { OptionId = 99, QuestionId = 25, IsCorrect = false, Text = "OUTER JOIN" },
                new Option { OptionId = 100, QuestionId = 25, IsCorrect = false, Text = "CROSS JOIN" },
                // Q26
                new Option { OptionId = 101, QuestionId = 26, IsCorrect = true, Text = "Particionamiento" },
                new Option { OptionId = 102, QuestionId = 26, IsCorrect = false, Text = "Indexación" },
                new Option { OptionId = 103, QuestionId = 26, IsCorrect = false, Text = "Compresión" },
                new Option { OptionId = 104, QuestionId = 26, IsCorrect = false, Text = "Normalización" },
                // Q27
                new Option { OptionId = 105, QuestionId = 27, IsCorrect = true, Text = "Rollback de Víctima" },
                new Option { OptionId = 106, QuestionId = 27, IsCorrect = false, Text = "Commit Forzado" },
                new Option { OptionId = 107, QuestionId = 27, IsCorrect = false, Text = "Backup" },
                new Option { OptionId = 108, QuestionId = 27, IsCorrect = false, Text = "Reinicio" },
                // Q28
                new Option { OptionId = 109, QuestionId = 28, IsCorrect = true, Text = "Diferencial" },
                new Option { OptionId = 110, QuestionId = 28, IsCorrect = false, Text = "Completo" },
                new Option { OptionId = 111, QuestionId = 28, IsCorrect = false, Text = "Log" },
                new Option { OptionId = 112, QuestionId = 28, IsCorrect = false, Text = "Espejo" },
                // Q29
                new Option { OptionId = 113, QuestionId = 29, IsCorrect = true, Text = "Vistas (Views)" },
                new Option { OptionId = 114, QuestionId = 29, IsCorrect = false, Text = "Stored Procs" },
                new Option { OptionId = 115, QuestionId = 29, IsCorrect = false, Text = "Triggers" },
                new Option { OptionId = 116, QuestionId = 29, IsCorrect = false, Text = "Esquemas" },
                // Q30
                new Option { OptionId = 117, QuestionId = 30, IsCorrect = true, Text = "Bulk-Logged" },
                new Option { OptionId = 118, QuestionId = 30, IsCorrect = false, Text = "Simple" },
                new Option { OptionId = 119, QuestionId = 30, IsCorrect = false, Text = "Full" },
                new Option { OptionId = 120, QuestionId = 30, IsCorrect = false, Text = "Read-Only" }
            );
        }
    }
}