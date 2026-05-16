-- Insertar Temas
INSERT INTO Topics (TopicId, Name) 
VALUES (1, 'Ingeniería de Software'), 
       (2, 'Bases de Datos');

-- Insertar Usuarios
INSERT INTO Users (Username, Password, FullName) 
VALUES ('achacin', 'admin123', 'Alejandro Chacin');

-- Insertar Preguntas
INSERT INTO Questions (QuestionId, TopicId, Difficulty, Content, Feedback) 
VALUES 
(1, 1, 1, '¿Qué modelo de ciclo de vida gestiona mejor los riesgos?', 'El modelo en espiral permite iteraciones basadas en riesgo.'),
(16, 2, 1, '¿Qué forma normal elimina dependencias transitivas?', 'La 3NF normaliza los atributos no clave.');

-- Insertar Opciones
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) 
VALUES 
(1, 1, 'Modelo en Espiral', 1), 
(2, 1, 'Cascada', 0), 
(3, 1, 'RUP', 0), 
(4, 1, 'Prototipado', 0),
(61, 16, '3NF', 1), 
(62, 16, '1NF', 0), 
(63, 16, '2NF', 0), 
(64, 16, 'BCNF', 0);

USE CenevalDB;

-- Preguntas de Ingeniería de Software (TopicId 1)
INSERT INTO Questions (QuestionId, TopicId, Difficulty, Content, Feedback) VALUES 
(2, 1, 1, '¿Qué metodología se basa en sprints de 2 a 4 semanas?', 'Scrum divide el trabajo en ciclos cortos llamados sprints.'),
(3, 1, 1, '¿Cuál es el primer paso en el ciclo de vida de desarrollo de software?', 'El análisis de requisitos es fundamental antes de diseñar o codificar.'),
(4, 1, 2, 'En UML, ¿qué diagrama describe la estructura estática del sistema?', 'El diagrama de clases muestra las clases, atributos y sus relaciones.'),
(5, 1, 2, '¿Qué métrica mide el grado de interdependencia entre módulos?', 'El acoplamiento mide qué tan conectados están los módulos; se busca que sea bajo.'),
(6, 1, 2, '¿Qué patrón de diseño garantiza que una clase tenga una única instancia?', 'El patrón Singleton restringe la instanciación de una clase a un solo objeto.'),
(7, 1, 3, '¿Cuál es el objetivo principal de la integración continua (CI)?', 'Detectar errores de integración lo antes posible mediante pruebas automatizadas.'),
(8, 1, 3, '¿Qué principio SOLID establece que una clase debe ser abierta para extensión pero cerrada para modificación?', 'El principio Open/Closed evita que cambios nuevos rompan código existente.'),
(9, 1, 3, 'En pruebas de software, ¿qué es el "Camino Crítico"?', 'Es la secuencia de actividades que determina la duración total del proyecto.'),
(10, 1, 1, '¿Qué significa el acrónimo MVP en desarrollo de software?', 'Minimum Viable Product es la versión con funciones básicas para validar una idea.'),
(11, 1, 2, '¿Qué tipo de prueba verifica que cambios nuevos no afecten funcionalidades existentes?', 'Las pruebas de regresión aseguran que el código antiguo siga funcionando.'),
(12, 1, 3, 'En el manifiesto ágil, ¿qué se valora más que los procesos y las herramientas?', 'Se valora más a los individuos y su interacción.'),
(13, 1, 2, '¿Qué herramienta se utiliza comúnmente para el control de versiones distribuido?', 'Git permite que múltiples desarrolladores trabajen en el mismo código.'),
(14, 1, 1, '¿Cuál es la principal característica del modelo en Cascada?', 'Es un enfoque lineal y secuencial donde cada fase debe terminar para iniciar la otra.'),
(15, 1, 3, '¿Qué es el "Technical Debt" (Deuda Técnica)?', 'Es el costo futuro de elegir una solución rápida en lugar de una bien estructurada.');

-- Preguntas de Bases de Datos (TopicId 2)
INSERT INTO Questions (QuestionId, TopicId, Difficulty, Content, Feedback) VALUES 
(17, 2, 1, '¿Qué comando SQL se usa para eliminar todos los registros de una tabla sin borrar la estructura?', 'TRUNCATE es más rápido que DELETE para limpiar tablas.'),
(18, 2, 1, '¿Cuál es la función de una Primary Key?', 'Identificar de manera única cada registro en una tabla.'),
(19, 2, 2, '¿Qué propiedad de las transacciones asegura que una operación se realice por completo o no se realice nada?', 'La Atomicidad es la A en el acrónimo ACID.'),
(20, 2, 2, '¿Qué tipo de JOIN devuelve solo las filas que tienen coincidencia en ambas tablas?', 'INNER JOIN es el tipo de unión más común para filtrar coincidencias.'),
(21, 2, 3, '¿Cuál es el propósito de un Índice (Index) en una base de datos?', 'Mejorar la velocidad de las consultas de búsqueda de datos.'),
(22, 2, 3, '¿Qué es una dependencia funcional en el proceso de normalización?', 'Es una relación entre atributos donde uno determina el valor de otro.'),
(23, 2, 1, '¿Qué lenguaje se utiliza para definir la estructura de la base de datos (CREATE, ALTER)?', 'DDL (Data Definition Language) se encarga de la estructura.'),
(24, 2, 2, '¿Qué hace la cláusula GROUP BY?', 'Agrupa filas que tienen los mismos valores en columnas específicas para funciones de agregado.'),
(25, 2, 2, 'En ACID, ¿qué significa Durabilidad?', 'Garantiza que una vez confirmada una transacción, esta persistirá incluso tras un fallo.'),
(26, 2, 3, '¿Qué es un Stored Procedure?', 'Un conjunto de instrucciones SQL almacenadas en el servidor para su reutilización.'),
(27, 2, 1, '¿Qué comando se usa para otorgar permisos a un usuario?', 'GRANT es el comando estándar para gestionar privilegios.'),
(28, 2, 2, '¿Cuál es la diferencia entre CHAR y VARCHAR?', 'CHAR es de longitud fija y VARCHAR es de longitud variable.'),
(29, 2, 3, '¿Qué es el "Deadlock" en bases de datos?', 'Una situación donde dos procesos se bloquean mutuamente esperando recursos del otro.'),
(30, 2, 2, '¿Para qué sirve el comando HAVING?', 'Para filtrar resultados de un GROUP BY basado en una condición de agregado.'),
(31, 2, 1, '¿Qué comando se utiliza para modificar datos existentes?', 'UPDATE permite cambiar los valores de los registros.');

-- Ejemplo de Opciones (Solo algunas para brevedad, se sigue el mismo patrón)
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(5, 2, 'Scrum', 1), (6, 2, 'Waterfall', 0), (7, 2, 'Kanban', 0), (8, 2, 'Spiral', 0),
(9, 3, 'Análisis de Requisitos', 1), (10, 3, 'Codificación', 0), (11, 3, 'Pruebas', 0), (12, 3, 'Diseño', 0),
(65, 17, 'TRUNCATE', 1), (66, 17, 'DROP', 0), (67, 17, 'DELETE', 0), (68, 17, 'REMOVE', 0),
(69, 18, 'Identificar registros de forma única', 1), (70, 18, 'Permitir duplicados', 0), (71, 18, 'Relacionar tablas', 0), (72, 18, 'Indexar textos largos', 0),
(73, 19, 'Atomicidad', 1), (74, 19, 'Consistencia', 0), (75, 19, 'Aislamiento', 0), (76, 19, 'Durabilidad', 0);

-- Verificación
SELECT * FROM Users;
SELECT * FROM Questions;
SELECT * FROM Options;
SELECT * FROM Topics;