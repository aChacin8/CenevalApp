USE CenevalDB;

-- =============================================
-- OPCIONES PARA INGENIERÍA DE SOFTWARE (TopicId 1)
-- =============================================

-- Pregunta 33: Diagrama UML eventos externos
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(124, 33, 'Máquina de Estados', 1), (125, 33, 'Clases', 0), (126, 33, 'Objetos', 0), (127, 33, 'Paquetes', 0);

-- Pregunta 34: Inversión de Dependencias (SOLID)
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(128, 34, 'Depender de abstracciones, no de concreciones', 1), (129, 34, 'Heredar de múltiples clases', 0), (130, 34, 'Instanciar objetos en el constructor', 0), (131, 34, 'Usar solo variables globales', 0);

-- Pregunta 35: Caja Negra
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(132, 35, 'Funcionalidad sin ver el código interno', 1), (133, 35, 'Revisión de bucles y condicionales', 0), (134, 35, 'Pruebas de cobertura de rutas', 0), (135, 35, 'Análisis de flujo de datos', 0);

-- Pregunta 37: Responsable del valor (Scrum)
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(136, 37, 'Product Owner', 1), (137, 37, 'Scrum Master', 0), (138, 37, 'Development Team', 0), (139, 37, 'Stakeholder', 0);

-- Pregunta 42: Complejidad Ciclomática
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(140, 42, 'Caminos independientes en el código', 1), (141, 42, 'Número de líneas de código', 0), (142, 42, 'Cantidad de variables locales', 0), (143, 42, 'Número de clases en el proyecto', 0);

-- Pregunta 49: TDD
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(144, 49, 'Escribir pruebas antes del código', 1), (145, 49, 'Escribir pruebas al final del proyecto', 0), (146, 49, 'No escribir pruebas, solo manuales', 0), (147, 49, 'Pruebas realizadas por el cliente', 0);

-- Pregunta 52: MVC
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(148, 52, 'Modelo, Vista, Controlador', 1), (149, 52, 'Módulo, Variable, Clase', 0), (150, 52, 'Mantenimiento, Validación, Carga', 0), (151, 52, 'Motor, Visualizador, Conector', 0);

-- =============================================
-- OPCIONES PARA BASES DE DATOS (TopicId 2)
-- =============================================

-- Pregunta 63: Foreign Key
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(152, 63, 'Vínculo con la PK de otra tabla', 1), (153, 63, 'Un identificador autoincremental', 0), (154, 63, 'Un campo que no acepta nulos', 0), (155, 63, 'Una tabla sin relaciones', 0);

-- Pregunta 64: 4NF
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(156, 64, 'Elimina dependencias multi-valuadas', 1), (157, 64, 'Elimina dependencias transitivas', 0), (158, 64, 'Elimina dependencias parciales', 0), (159, 64, 'Asegura que no haya nulos', 0);

-- Pregunta 67: Teorema CAP
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(160, 67, 'Consistencia, Disponibilidad, Tolerancia a partición', 1), (161, 67, 'Capacidad, Almacenamiento, Procesamiento', 0), (162, 67, 'Consultas, Atomicidad, Persistencia', 0), (163, 67, 'Control, Acceso, Privacidad', 0);

-- Pregunta 69: Vista (View)
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(164, 69, 'Una tabla virtual basada en una consulta', 1), (165, 69, 'Una copia física de los datos', 0), (166, 69, 'Un índice de búsqueda rápida', 0), (167, 69, 'Un backup de la base de datos', 0);

-- Pregunta 72: Aislamiento (ACID)
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(168, 72, 'Transacciones concurrentes no interfieren', 1), (169, 72, 'Los datos se guardan en disco', 0), (170, 72, 'La transacción es todo o nada', 0), (171, 72, 'El sistema nunca falla', 0);

-- Pregunta 73: Trigger
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(172, 73, 'Procedimiento automático ante eventos', 1), (173, 73, 'Un tipo de dato especial', 0), (174, 73, 'Un usuario con privilegios altos', 0), (175, 73, 'Una herramienta de backup', 0);

-- Pregunta 78: INNER vs LEFT JOIN
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(176, 78, 'INNER solo coincidencias, LEFT todo de la izquierda', 1), (177, 78, 'INNER es más lento que LEFT', 0), (178, 78, 'LEFT elimina duplicados automáticamente', 0), (179, 78, 'No hay diferencia técnica', 0);

-- Pregunta 81: Normalización
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(180, 81, 'Minimizar la redundancia de datos', 1), (181, 81, 'Aumentar el tamaño de la base de datos', 0), (182, 81, 'Crear más usuarios de acceso', 0), (183, 81, 'Encriptar la información sensible', 0);

-- Pregunta 87: SQL Injection
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(184, 87, 'Inserción de código malicioso en consultas', 1), (185, 87, 'Una forma rápida de insertar datos', 0), (186, 87, 'Optimización de consultas pesadas', 0), (187, 87, 'Un error de hardware en el servidor', 0);

-- Pregunta 90: UNION
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(188, 90, 'Combina resultados de múltiples SELECT', 1), (189, 90, 'Multiplica los valores de dos tablas', 0), (190, 90, 'Relaciona tablas mediante llaves', 0), (191, 90, 'Elimina la base de datos por completo', 0);