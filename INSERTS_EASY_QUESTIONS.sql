USE CenevalDB;

-- =============================================
-- PREGUNTAS FÁCILES - INGENIERÍA DE SOFTWARE (TopicId 1, Difficulty = 3)
-- =============================================

INSERT INTO Questions (QuestionId, TopicId, Difficulty, Content, Feedback) VALUES
(92,  1, 3, '¿Qué significa la sigla IDE en programación?', 'IDE significa Entorno de Desarrollo Integrado (Integrated Development Environment).'),
(93,  1, 3, '¿Qué es un algoritmo?', 'Un algoritmo es una secuencia finita de pasos ordenados para resolver un problema.'),
(94,  1, 3, '¿Cuál es la función principal de un compilador?', 'El compilador traduce el código fuente escrito por el programador a código máquina ejecutable.'),
(95,  1, 3, '¿Qué es la programación orientada a objetos (POO)?', 'Es un paradigma que organiza el software en objetos que combinan datos y comportamiento.'),
(96,  1, 3, '¿Qué es una variable en programación?', 'Es un espacio en memoria que almacena un valor que puede cambiar durante la ejecución.'),
(97,  1, 3, '¿Qué es un ciclo (loop) en programación?', 'Una estructura que repite un bloque de código mientras se cumpla una condición.'),
(98,  1, 3, '¿Para qué sirve el control de versiones en un proyecto de software?', 'Permite llevar un historial de cambios del código y colaborar entre varios desarrolladores.'),
(99,  1, 3, '¿Qué es la herencia en la POO?', 'Mecanismo que permite que una clase derive atributos y métodos de otra clase.'),
(100, 1, 3, '¿Qué es un diagrama de flujo?', 'Una representación gráfica de los pasos de un proceso o algoritmo usando símbolos estándar.'),
(101, 1, 3, '¿Cuál es el propósito principal de las pruebas de software?', 'Verificar que el sistema funcione correctamente y detectar defectos antes de su entrega.'),
(102, 1, 3, '¿Qué significa la palabra "depurar" (debug) en programación?', 'Identificar y corregir errores en el código fuente del programa.'),
(103, 1, 3, '¿Qué es un lenguaje de programación de alto nivel?', 'Un lenguaje cercano al lenguaje humano, más fácil de escribir y entender que el código máquina.'),
(104, 1, 3, '¿Qué es una función en programación?', 'Un bloque de código reutilizable que realiza una tarea específica cuando es invocado.'),
(105, 1, 3, '¿Qué es el pseudocódigo?', 'Una forma de describir un algoritmo usando lenguaje natural mezclado con instrucciones lógicas, sin ser código real.'),
(106, 1, 3, '¿Qué tipo de error ocurre cuando el programa se compila correctamente pero falla al ejecutarse?', 'Se llama error en tiempo de ejecución (runtime error).'),

-- =============================================
-- PREGUNTAS FÁCILES - BASES DE DATOS (TopicId 2, Difficulty = 3)
-- =============================================

(107, 2, 3, '¿Qué es una base de datos?', 'Una colección organizada de datos que se pueden acceder, gestionar y actualizar fácilmente.'),
(108, 2, 3, '¿Qué es una tabla en una base de datos relacional?', 'Una estructura organizada en filas (registros) y columnas (campos) para almacenar datos.'),
(109, 2, 3, '¿Qué es SQL?', 'SQL (Structured Query Language) es el lenguaje estándar para gestionar bases de datos relacionales.'),
(110, 2, 3, '¿Qué hace el comando INSERT en SQL?', 'Agrega nuevos registros (filas) a una tabla de la base de datos.'),
(111, 2, 3, '¿Qué hace el comando DELETE en SQL?', 'Elimina uno o más registros de una tabla según una condición especificada.'),
(112, 2, 3, '¿Qué es una clave primaria (Primary Key)?', 'Un campo o conjunto de campos que identifica de forma única cada registro en una tabla.'),
(113, 2, 3, '¿Qué hace la cláusula WHERE en SQL?', 'Filtra los registros de una consulta para que solo se devuelvan los que cumplen una condición.'),
(114, 2, 3, '¿Qué es un campo en una base de datos?', 'Una columna de una tabla que representa un atributo específico de los datos almacenados.'),
(115, 2, 3, '¿Qué comando se usa para actualizar datos en SQL?', 'El comando UPDATE permite modificar los valores de uno o más registros existentes.'),
(116, 2, 3, '¿Para qué sirve el comando CREATE TABLE?', 'Para crear una nueva tabla con sus columnas y tipos de datos en la base de datos.'),
(117, 2, 3, '¿Qué es un DBMS (Database Management System)?', 'Software que permite crear, gestionar y controlar el acceso a bases de datos (ej. MySQL, SQL Server).'),
(118, 2, 3, '¿Qué tipo de dato se usa para almacenar texto de longitud variable en SQL?', 'VARCHAR permite almacenar cadenas de texto con longitud variable hasta un máximo definido.'),
(119, 2, 3, '¿Qué hace la función MAX() en SQL?', 'Devuelve el valor máximo de una columna numérica dentro de un conjunto de resultados.'),
(120, 2, 3, '¿Qué es una consulta (query) en bases de datos?', 'Una instrucción escrita en SQL para recuperar, insertar, actualizar o eliminar datos.'),
(121, 2, 3, '¿Qué significa el comando DROP TABLE?', 'Elimina por completo una tabla y todos sus datos de la base de datos.');

-- =============================================
-- OPCIONES PARA PREGUNTAS FÁCILES
-- =============================================

-- Q92: ¿Qué significa IDE?
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(200, 92, 'Entorno de Desarrollo Integrado', 1),
(201, 92, 'Instrucción de Ejecución Directa', 0),
(202, 92, 'Interfaz de Diseño Estático', 0),
(203, 92, 'Índice de Datos Esenciales', 0);

-- Q93: ¿Qué es un algoritmo?
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(204, 93, 'Secuencia finita de pasos para resolver un problema', 1),
(205, 93, 'Un tipo de lenguaje de programación', 0),
(206, 93, 'Un componente de hardware', 0),
(207, 93, 'Un sistema operativo especializado', 0);

-- Q94: Función del compilador
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(208, 94, 'Traducir código fuente a código máquina', 1),
(209, 94, 'Ejecutar directamente el código fuente', 0),
(210, 94, 'Diseñar la interfaz gráfica del programa', 0),
(211, 94, 'Administrar la memoria RAM del sistema', 0);

-- Q95: Programación orientada a objetos
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(212, 95, 'Paradigma que organiza software en objetos con datos y comportamiento', 1),
(213, 95, 'Un lenguaje de programación específico', 0),
(214, 95, 'Una técnica exclusiva para videojuegos', 0),
(215, 95, 'Un método para comprimir archivos de código', 0);

-- Q96: ¿Qué es una variable?
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(216, 96, 'Espacio en memoria que almacena un valor modificable', 1),
(217, 96, 'Un tipo de operador matemático', 0),
(218, 96, 'Una función predefinida del lenguaje', 0),
(219, 96, 'Un archivo de configuración del sistema', 0);

-- Q97: ¿Qué es un ciclo?
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(220, 97, 'Estructura que repite código mientras se cumpla una condición', 1),
(221, 97, 'Una función que retorna un valor booleano', 0),
(222, 97, 'Un tipo de variable numérica', 0),
(223, 97, 'Un diagrama para representar clases', 0);

-- Q98: Control de versiones
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(224, 98, 'Llevar historial de cambios y colaborar en código', 1),
(225, 98, 'Administrar los permisos de los usuarios del sistema', 0),
(226, 98, 'Optimizar el rendimiento de la base de datos', 0),
(227, 98, 'Diseñar la arquitectura de red del proyecto', 0);

-- Q99: Herencia en POO
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(228, 99, 'Una clase deriva atributos y métodos de otra clase', 1),
(229, 99, 'Copiar archivos entre carpetas del proyecto', 0),
(230, 99, 'Un tipo de bucle especial en programación', 0),
(231, 99, 'La capacidad de una función de llamarse a sí misma', 0);

-- Q100: Diagrama de flujo
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(232, 100, 'Representación gráfica de los pasos de un proceso usando símbolos', 1),
(233, 100, 'Un diagrama que muestra la estructura de clases', 0),
(234, 100, 'Un gráfico de barras para métricas de rendimiento', 0),
(235, 100, 'Una pantalla de inicio de sesión de la aplicación', 0);

-- Q101: Propósito de las pruebas de software
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(236, 101, 'Verificar funcionamiento correcto y detectar defectos', 1),
(237, 101, 'Crear la documentación final del sistema', 0),
(238, 101, 'Diseñar la interfaz gráfica del usuario', 0),
(239, 101, 'Optimizar el tiempo de compilación del código', 0);

-- Q102: Depurar (debug)
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(244, 102, 'Identificar y corregir errores en el código', 1),
(245, 102, 'Agregar comentarios al código fuente', 0),
(246, 102, 'Ejecutar el programa en modo rápido', 0),
(247, 102, 'Guardar una copia de seguridad del proyecto', 0);

-- Q103: Lenguaje de alto nivel
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(248, 103, 'Lenguaje cercano al humano, más fácil que el código máquina', 1),
(249, 103, 'Un lenguaje que solo usa números binarios', 0),
(250, 103, 'Un lenguaje exclusivo para sistemas operativos', 0),
(251, 103, 'Un lenguaje que solo funciona en supercomputadoras', 0);

-- Q104: ¿Qué es una función?
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(252, 104, 'Bloque de código reutilizable que realiza una tarea específica', 1),
(253, 104, 'Una variable que guarda múltiples valores', 0),
(254, 104, 'Un tipo de error en tiempo de compilación', 0),
(255, 104, 'Una instrucción para detener el programa', 0);

-- Q105: Pseudocódigo
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(256, 105, 'Descripción de un algoritmo con lenguaje natural e instrucciones lógicas', 1),
(257, 105, 'Código cifrado que protege la aplicación', 0),
(258, 105, 'Un lenguaje de programación para principiantes', 0),
(259, 105, 'Código generado automáticamente por una IA', 0);

-- Q106: Error en tiempo de ejecución
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(260, 106, 'Error en tiempo de ejecución (runtime error)', 1),
(261, 106, 'Error de sintaxis', 0),
(262, 106, 'Error de compilación', 0),
(263, 106, 'Error de enlace (linker error)', 0);

-- Q107: ¿Qué es una base de datos?
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(264, 107, 'Colección organizada de datos accesibles y gestionables', 1),
(265, 107, 'Un programa para crear páginas web', 0),
(266, 107, 'Un dispositivo físico de almacenamiento', 0),
(267, 107, 'Un sistema de comunicación entre computadoras', 0);

-- Q108: ¿Qué es una tabla?
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(268, 108, 'Estructura en filas y columnas para almacenar datos', 1),
(269, 108, 'Un archivo de texto plano con datos', 0),
(270, 108, 'Una gráfica de barras en un reporte', 0),
(271, 108, 'Un tipo de conexión entre servidores', 0);

-- Q109: ¿Qué es SQL?
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(272, 109, 'Lenguaje estándar para gestionar bases de datos relacionales', 1),
(273, 109, 'Un sistema operativo de base de datos', 0),
(274, 109, 'Un protocolo de transferencia de archivos', 0),
(275, 109, 'Un lenguaje de programación orientado a objetos', 0);

-- Q110: Comando INSERT
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(276, 110, 'Agrega nuevos registros a una tabla', 1),
(277, 110, 'Elimina registros de una tabla', 0),
(278, 110, 'Modifica la estructura de una tabla', 0),
(279, 110, 'Consulta los datos de una tabla', 0);

-- Q111: Comando DELETE
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(280, 111, 'Elimina registros de una tabla según una condición', 1),
(281, 111, 'Agrega nuevos registros a una tabla', 0),
(282, 111, 'Elimina la tabla completa de la base de datos', 0),
(283, 111, 'Deshabilita temporalmente una columna', 0);

-- Q112: Clave primaria
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(284, 112, 'Campo que identifica de forma única cada registro', 1),
(285, 112, 'Un campo que permite valores duplicados', 0),
(286, 112, 'Una contraseña para acceder a la tabla', 0),
(287, 112, 'El primer campo que se crea en cualquier tabla', 0);

-- Q113: Cláusula WHERE
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(288, 113, 'Filtra registros que cumplen una condición', 1),
(289, 113, 'Ordena los resultados de una consulta', 0),
(290, 113, 'Agrupa filas con valores iguales', 0),
(291, 113, 'Limita el número máximo de resultados', 0);

-- Q114: ¿Qué es un campo?
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(292, 114, 'Una columna que representa un atributo de los datos', 1),
(293, 114, 'Una fila de datos en la tabla', 0),
(294, 114, 'Un tipo de consulta SQL avanzada', 0),
(295, 114, 'Un índice de búsqueda de la tabla', 0);

-- Q115: Comando UPDATE
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(296, 115, 'UPDATE', 1),
(297, 115, 'MODIFY', 0),
(298, 115, 'CHANGE', 0),
(299, 115, 'REPLACE', 0);

-- Q116: CREATE TABLE
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(300, 116, 'Crear una nueva tabla con columnas y tipos de datos', 1),
(301, 116, 'Modificar la estructura de una tabla existente', 0),
(302, 116, 'Insertar datos en una tabla ya creada', 0),
(303, 116, 'Eliminar todos los registros de una tabla', 0);

-- Q117: ¿Qué es un DBMS?
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(304, 117, 'Software para crear, gestionar y controlar bases de datos', 1),
(305, 117, 'Un lenguaje de programación orientado a datos', 0),
(306, 117, 'Un tipo de hardware de almacenamiento masivo', 0),
(307, 117, 'Una interfaz gráfica para diseñar reportes', 0);

-- Q118: VARCHAR
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(308, 118, 'VARCHAR', 1),
(309, 118, 'INT', 0),
(310, 118, 'BOOLEAN', 0),
(311, 118, 'FLOAT', 0);

-- Q119: Función MAX()
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(312, 119, 'Devuelve el valor máximo de una columna numérica', 1),
(313, 119, 'Suma todos los valores de una columna', 0),
(314, 119, 'Devuelve el número de registros de una tabla', 0),
(315, 119, 'Calcula el promedio de los valores de una columna', 0);

-- Q120: ¿Qué es una consulta?
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(316, 120, 'Instrucción SQL para recuperar, insertar, actualizar o eliminar datos', 1),
(317, 120, 'Un archivo de configuración del servidor', 0),
(318, 120, 'Un informe generado automáticamente', 0),
(319, 120, 'Una conexión entre dos bases de datos', 0);

-- Q121: DROP TABLE
INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES
(320, 121, 'Elimina por completo una tabla y todos sus datos', 1),
(321, 121, 'Elimina solo los registros, conservando la estructura', 0),
(322, 121, 'Deshabilita temporalmente una tabla', 0),
(323, 121, 'Crea una copia de seguridad de la tabla', 0);
