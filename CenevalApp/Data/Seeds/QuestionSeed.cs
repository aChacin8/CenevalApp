using Microsoft.EntityFrameworkCore;
using CenevalApp.Models;

namespace CenevalApp.Data.Seeds
{
    public static class QuestionSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasData(
                // INGENIERÍA DE SOFTWARE 
                new Question { QuestionId = 1, TopicId = 1, Difficulty = 1, Content = "Un equipo trabaja en un sistema crítico con requisitos poco claros. ¿Qué modelo es mejor?", Feedback = "El modelo en espiral gestiona riesgos y requisitos evolutivos." },
                new Question { QuestionId = 2, TopicId = 1, Difficulty = 2, Content = "Para reducir la dependencia entre componentes en un diseño modular, ¿qué acoplamiento es preferible?", Feedback = "El acoplamiento de datos es el más débil y deseable." },
                new Question { QuestionId = 3, TopicId = 1, Difficulty = 3, Content = "Se requiere escalar un sistema de telefonía para millones de usuarios. ¿Qué arquitectura es mejor?", Feedback = "Los microservicios permiten escalabilidad independiente." },
                new Question { QuestionId = 4, TopicId = 1, Difficulty = 4, Content = "Al gestionar múltiples hilos de ejecución concurrentes en una aplicación C#, ¿qué patrón evita condiciones de carrera?", Feedback = "Los patrones de concurrencia aseguran el acceso seguro a recursos." },
                new Question { QuestionId = 5, TopicId = 1, Difficulty = 1, Content = "Se necesita visualizar la estructura estática del sistema y sus relaciones. ¿Qué diagrama UML se utiliza?", Feedback = "El diagrama de clases muestra la estructura estática del software." },
                new Question { QuestionId = 6, TopicId = 1, Difficulty = 2, Content = "Para evitar inyecciones de código en formularios web, ¿qué medida de validación es prioritaria?", Feedback = "La validación de tipos y rangos previene entradas maliciosas." },
                new Question { QuestionId = 7, TopicId = 1, Difficulty = 3, Content = "Si un software tiene un alto acoplamiento y baja cohesión, ¿cuál es la consecuencia directa?", Feedback = "La baja mantenibilidad es el resultado de un diseño rígido." },
                new Question { QuestionId = 8, TopicId = 1, Difficulty = 4, Content = "Se requiere cambiar el algoritmo de validación de un IVR en tiempo de ejecución. ¿Qué patrón de diseño se aplica?", Feedback = "Strategy permite intercambiar algoritmos dinámicamente." },
                new Question { QuestionId = 9, TopicId = 1, Difficulty = 1, Content = "¿Qué metodología ágil se basa en entregas incrementales llamadas Sprints?", Feedback = "Scrum es la metodología ágil por excelencia para Sprints." },
                new Question { QuestionId = 10, TopicId = 1, Difficulty = 2, Content = "Para separar la lógica de auditoría de la lógica de negocio sin modificar el código original, ¿qué se usa?", Feedback = "La programación orientada a aspectos usa interceptores." },
                new Question { QuestionId = 11, TopicId = 1, Difficulty = 3, Content = "Se desea verificar que el sistema soporte 10,000 llamadas simultáneas. ¿Qué tipo de prueba es?", Feedback = "Las pruebas de carga validan el comportamiento bajo estrés." },
                new Question { QuestionId = 12, TopicId = 1, Difficulty = 4, Content = "Para asegurar que la comunicación entre el CRM y la base de datos no sea interceptada, ¿qué protocolo es vital?", Feedback = "HTTPS/TLS cifra el canal de comunicación." },
                new Question { QuestionId = 13, TopicId = 1, Difficulty = 1, Content = "¿En qué etapa de la ingeniería de software se resuelven conflictos entre los stakeholders?", Feedback = "La negociación de requisitos alinea las expectativas del cliente." },
                new Question { QuestionId = 14, TopicId = 1, Difficulty = 2, Content = "Un objeto necesita notificar a otros automáticamente cuando su estado cambia. ¿Qué patrón es?", Feedback = "El patrón Observer define una dependencia de uno a muchos." },
                new Question { QuestionId = 15, TopicId = 1, Difficulty = 3, Content = "Se requiere garantizar que una clase de conexión a la base de datos tenga una única instancia.", Feedback = "Singleton restringe la instanciación a un solo objeto." },

                // BASES DE DATOS 
                new Question { QuestionId = 16, TopicId = 2, Difficulty = 1, Content = "Se tiene una tabla con dependencias transitivas. ¿A qué forma normal se debe aplicar?", Feedback = "La 3NF elimina las dependencias transitivas." },
                new Question { QuestionId = 17, TopicId = 2, Difficulty = 2, Content = "Un sistema requiere consultas rápidas sin reordenar físicamente los datos. ¿Qué índice usar?", Feedback = "Los índices no agrupados son estructuras de búsqueda aparte." },
                new Question { QuestionId = 18, TopicId = 2, Difficulty = 3, Content = "¿Qué propiedad ACID asegura que todas las operaciones de una transacción se completen o ninguna?", Feedback = "La atomicidad garantiza la integridad de 'todo o nada'." },
                new Question { QuestionId = 19, TopicId = 2, Difficulty = 4, Content = "Para almacenar logs de llamadas no estructurados con alta velocidad de escritura, ¿qué BD es mejor?", Feedback = "NoSQL es ideal para datos no estructurados y escalabilidad." },
                new Question { QuestionId = 20, TopicId = 2, Difficulty = 1, Content = "¿Qué cláusula SQL se utiliza para agrupar resultados basándose en una columna específica?", Feedback = "GROUP BY permite aplicar funciones de agregado por grupos." },
                new Question { QuestionId = 21, TopicId = 2, Difficulty = 2, Content = "Si el servidor falla tras una transacción confirmada, ¿qué propiedad garantiza que los datos persistan?", Feedback = "La durabilidad asegura que los cambios confirmados no se pierdan." },
                new Question { QuestionId = 22, TopicId = 2, Difficulty = 3, Content = "Para mantener la relación entre una tabla de Usuarios y una de Llamadas, ¿qué restricción se aplica?", Feedback = "Las llaves foráneas (FK) mantienen la integridad referencial." },
                new Question { QuestionId = 23, TopicId = 2, Difficulty = 4, Content = "Se requiere ejecutar lógica automática cada vez que se inserta un nuevo registro de CRM.", Feedback = "Los triggers ejecutan código ante eventos de la tabla." },
                new Question { QuestionId = 24, TopicId = 2, Difficulty = 1, Content = "¿Cómo se representa una relación de muchos a muchos en un modelo relacional?", Feedback = "Se requiere una tabla asociativa o intermedia." },
                new Question { QuestionId = 25, TopicId = 2, Difficulty = 2, Content = "¿Qué tipo de JOIN devuelve solo las filas que tienen coincidencia en ambas tablas?", Feedback = "INNER JOIN es para intersecciones directas." },
                new Question { QuestionId = 26, TopicId = 2, Difficulty = 3, Content = "Para mejorar el rendimiento de una tabla con billones de registros, ¿qué técnica física se usa?", Feedback = "El particionamiento divide la tabla en segmentos manejables." },
                new Question { QuestionId = 27, TopicId = 2, Difficulty = 4, Content = "¿Cuál es la acción que toma SQL Server cuando ocurre un Deadlock?", Feedback = "SQL Server elige una víctima y hace Rollback de su transacción." },
                new Question { QuestionId = 28, TopicId = 2, Difficulty = 1, Content = "Se desea respaldar solo los cambios realizados desde el último backup completo.", Feedback = "El respaldo diferencial optimiza tiempo y espacio." },
                new Question { QuestionId = 29, TopicId = 2, Difficulty = 2, Content = "Para ocultar la complejidad de una consulta compleja a los desarrolladores Jr., ¿qué objeto se crea?", Feedback = "Las vistas (Views) actúan como tablas virtuales simplificadas." },
                new Question { QuestionId = 30, TopicId = 2, Difficulty = 3, Content = "Se realizará una carga masiva de millones de filas. ¿Qué modo de recuperación es más rápido?", Feedback = "Bulk-Logged minimiza el registro en el log de transacciones." }
            );
        }
    }
}