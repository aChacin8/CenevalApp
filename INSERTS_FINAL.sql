USE CenevalDB;

-- =============================================
-- INGENIERÍA DE SOFTWARE (TopicId 1)
-- =============================================

INSERT INTO Questions (QuestionId, TopicId, Difficulty, Content, Feedback) VALUES 
(32, 1, 1, '¿Qué significa la sigla CASE en ingeniería de software?', 'Computer-Aided Software Engineering son herramientas que automatizan tareas del ciclo de vida.'),
(33, 1, 2, '¿Qué tipo de diagrama de UML se usa para modelar el comportamiento de un sistema ante eventos externos?', 'El diagrama de Máquina de Estados es ideal para modelar transiciones basadas en eventos.'),
(34, 1, 3, '¿En qué consiste el principio de Inversión de Dependencias (D de SOLID)?', 'Establece que los módulos de alto nivel no deben depender de los de bajo nivel, sino de abstracciones.'),
(35, 1, 1, '¿Cuál es el objetivo de las pruebas de Caja Negra?', 'Evaluar la funcionalidad del sistema sin conocer su estructura interna de código.'),
(36, 1, 2, '¿Qué característica define al desarrollo basado en componentes?', 'La reutilización de piezas de software predefinidas para construir sistemas más complejos.'),
(37, 1, 2, 'En Scrum, ¿quién es el responsable de maximizar el valor del producto?', 'El Product Owner gestiona el Product Backlog y prioriza las necesidades del negocio.'),
(38, 1, 1, '¿Qué es un requerimiento NO funcional?', 'Es una restricción o atributo de calidad (seguridad, rendimiento) más que una función específica.'),
(39, 1, 3, '¿Qué diferencia a un framework de una librería?', 'La inversión de control: el framework llama a tu código, mientras que tú llamas a la librería.'),
(40, 1, 2, '¿Qué patrón de diseño se usa para desacoplar una abstracción de su implementación?', 'El patrón Bridge permite que ambos varíen de forma independiente.'),
(41, 1, 1, '¿Qué es el Refactoring?', 'Proceso de reestructurar código interno sin cambiar su comportamiento externo.'),
(42, 1, 3, '¿Qué mide la Complejidad Ciclomática de McCabe?', 'El número de caminos linealmente independientes a través del código fuente.'),
(43, 1, 2, '¿Cuál es el propósito del diagrama de secuencia en UML?', 'Mostrar la interacción entre objetos organizados en una secuencia temporal.'),
(44, 1, 1, 'En Git, ¿qué comando se usa para traer cambios del remoto y fusionarlos?', 'git pull es la combinación de fetch y merge.'),
(45, 1, 3, '¿Qué es la arquitectura de Microservicios?', 'Un estilo arquitectónico que estructura una aplicación como una colección de servicios pequeños y autónomos.'),
(46, 1, 2, '¿Qué es una User Story?', 'Una descripción breve y simple de una funcionalidad desde la perspectiva del usuario final.'),
(47, 1, 1, '¿Qué es el prototipado rápido?', 'Creación de modelos funcionales incompletos para visualizar la interfaz o lógica con el cliente.'),
(48, 1, 2, '¿Qué indica una alta cohesión en un módulo?', 'Indica que las responsabilidades del módulo están muy relacionadas y enfocadas.'),
(49, 1, 3, '¿Qué es el desarrollo TDD (Test Driven Development)?', 'Escribir las pruebas antes de escribir el código de la funcionalidad.'),
(50, 1, 1, '¿Qué herramienta se usa comúnmente para la gestión de proyectos ágiles?', 'Jira es un estándar para el seguimiento de tickets y sprints.'),
(51, 1, 2, '¿Qué es un "Code Review"?', 'Una revisión sistemática del código fuente por parte de otros desarrolladores.'),
(52, 1, 3, '¿Qué es el patrón de arquitectura MVC?', 'Divide la aplicación en Modelo (datos), Vista (interfaz) y Controlador (lógica).'),
(53, 1, 1, '¿Qué es el despliegue continuo (Continuous Deployment)?', 'Práctica donde cada cambio que pasa las pruebas se libera automáticamente a producción.'),
(54, 1, 2, '¿Qué diagrama UML muestra la distribución física de los nodos de hardware?', 'El diagrama de despliegue (Deployment Diagram).'),
(55, 1, 3, '¿Qué es el análisis estático de código?', 'Revisión del código sin ejecutarlo para encontrar errores potenciales o malas prácticas.'),
(56, 1, 1, '¿Qué es un Bug?', 'Un error, falla o defecto en el software que causa un resultado inesperado.'),
(57, 1, 2, '¿Qué metodología utiliza un tablero con columnas (To Do, In Progress, Done)?', 'Kanban visualiza el flujo de trabajo y limita el trabajo en curso.'),
(58, 1, 3, '¿Qué es la orquestación de contenedores?', 'Gestión automatizada del ciclo de vida de los contenedores (ej. Kubernetes).'),
(59, 1, 2, '¿Qué es el acoplamiento de control?', 'Cuando un módulo le dice a otro qué hacer pasando información de control (flags).'),
(60, 1, 1, '¿Qué es el mantenimiento correctivo?', 'Cambios realizados para reparar defectos descubiertos después de la entrega.'),
(61, 1, 3, '¿Qué es la modularidad?', 'La capacidad de un sistema de dividirse en partes que pueden ser modificadas independientemente.');

-- =============================================
-- BASES DE DATOS (TopicId 2)
-- =============================================

INSERT INTO Questions (QuestionId, TopicId, Difficulty, Content, Feedback) VALUES 
(62, 2, 1, '¿Cuál es la función del comando SELECT?', 'Se utiliza para recuperar datos de una o más tablas.'),
(63, 2, 2, '¿Qué es una clave foránea (Foreign Key)?', 'Un campo que vincula una tabla con la clave primaria de otra tabla.'),
(64, 2, 3, '¿Qué es la Cuarta Forma Normal (4NF)?', 'Trata sobre la eliminación de dependencias multi-valuadas independientes.'),
(65, 2, 1, '¿Qué significa NoSQL?', 'Not Only SQL, bases de datos que no siguen el modelo relacional tradicional.'),
(66, 2, 2, '¿Qué es un índice agrupado (Clustered Index)?', 'Un índice que determina el orden físico de los datos en la tabla.'),
(67, 2, 3, '¿Qué es el teorema CAP?', 'Establece que un sistema distribuido no puede garantizar Consistencia, Disponibilidad y Partición simultáneamente.'),
(68, 2, 1, '¿Qué comando se usa para agregar una columna a una tabla existente?', 'ALTER TABLE es el comando para modificar la estructura.'),
(69, 2, 2, '¿Qué es una vista (View) en SQL?', 'Una tabla virtual basada en el conjunto de resultados de una consulta SQL.'),
(70, 2, 3, '¿Qué es la fragmentación de datos?', 'Un proceso donde los datos se dividen en partes y se almacenan en diferentes nodos.'),
(71, 2, 1, '¿Qué operador se usa para buscar un patrón específico en una columna?', 'El operador LIKE se usa con comodines como % o _.'),
(72, 2, 2, '¿Qué es el aislamiento (Isolation) en ACID?', 'Asegura que las transacciones concurrentes no interfieran entre sí.'),
(73, 2, 3, '¿Qué es un Trigger (Disparador)?', 'Un procedimiento que se ejecuta automáticamente ante eventos como INSERT, UPDATE o DELETE.'),
(74, 2, 1, '¿Qué es una base de datos relacional?', 'Un tipo de BD que organiza datos en tablas relacionadas mediante claves.'),
(75, 2, 2, '¿Qué es el modelo Entidad-Relación?', 'Una herramienta para el modelado de datos que describe estructuras y relaciones.'),
(76, 2, 3, '¿Qué es el "Sharding"?', 'Método de particionado horizontal que divide una BD en trozos más pequeños en distintos servidores.'),
(77, 2, 1, '¿Qué hace la función COUNT()?', 'Devuelve el número de filas que coinciden con un criterio.'),
(78, 2, 2, '¿Cuál es la diferencia entre INNER JOIN y LEFT JOIN?', 'INNER devuelve solo coincidencias; LEFT devuelve todo lo de la izquierda más coincidencias.'),
(79, 2, 3, '¿Qué es una base de datos orientada a grafos?', 'Una BD que usa estructuras de grafos (nodos y bordes) para representar datos.'),
(80, 2, 1, '¿Qué es el esquema de una base de datos?', 'La definición formal de la estructura, tablas y relaciones.'),
(81, 2, 2, '¿Qué es la normalización?', 'El proceso de organizar datos para minimizar la redundancia.'),
(82, 2, 3, '¿Qué es la replicación maestro-esclavo?', 'Un modelo donde un servidor (maestro) escribe y otros (esclavos) copian para lectura.'),
(83, 2, 1, '¿Para qué sirve el comando DISTINCT?', 'Para eliminar duplicados en los resultados de una consulta.'),
(84, 2, 2, '¿Qué es un cursor en SQL?', 'Un objeto que permite recorrer fila por fila un conjunto de resultados.'),
(85, 2, 3, '¿Qué es una transacción distribuida?', 'Una transacción que afecta a múltiples recursos o bases de datos distintas.'),
(86, 2, 1, '¿Qué es el log de transacciones?', 'Un archivo que registra todos los cambios realizados para recuperación ante fallos.'),
(87, 2, 2, '¿Qué es el SQL Injection?', 'Una vulnerabilidad donde se inserta código malicioso en consultas SQL.'),
(88, 2, 3, '¿Qué es el nivel de aislamiento Read Committed?', 'Nivel que impide leer datos que no han sido confirmados por otra transacción.'),
(89, 2, 1, '¿Qué es una base de datos en la nube?', 'Una BD que se ejecuta y se accede a través de una plataforma cloud.'),
(90, 2, 2, '¿Qué es el comando UNION?', 'Combina el conjunto de resultados de dos o más sentencias SELECT.'),
(91, 2, 3, '¿Qué es el almacenamiento columnar?', 'Almacena datos por columnas en lugar de filas, optimizando consultas analíticas.');

-- =============================================
-- OPCIONES (Ejemplos representativos)
-- =============================================

INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
-- De la 32 (Ing. Software)
(120, 32, 'Computer-Aided Software Engineering', 1), (121, 32, 'Control Access System Engine', 0), (122, 32, 'Common Applied Software Env', 0), (123, 32, 'Core Agile Software Entity', 0),
-- De la 62 (Bases de Datos)
(240, 62, 'Recuperar datos', 1), (241, 62, 'Insertar datos', 0), (242, 62, 'Borrar tablas', 0), (243, 62, 'Modificar usuarios', 0);