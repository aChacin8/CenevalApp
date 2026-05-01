CREATE DATABASE CenevalDB;
GO

USE CenevalDB;
GO

CREATE TABLE Topics (
    TopicId INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

CREATE TABLE Questions (
    QuestionId INT PRIMARY KEY,
    TopicId INT NOT NULL,
    Difficulty INT NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    Feedback NVARCHAR(MAX),
    FOREIGN KEY (TopicId) REFERENCES Topics(TopicId)
);

CREATE TABLE Options (
    OptionId INT PRIMARY KEY,
    QuestionId INT NOT NULL,
    Text NVARCHAR(MAX) NOT NULL,
    IsCorrect BIT NOT NULL,
    FOREIGN KEY (QuestionId) REFERENCES Questions(QuestionId)
);

CREATE TABLE UserProgress (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UserId NVARCHAR(100) NOT NULL,
    CurrentTopicId INT DEFAULT 1,
    CurrentDifficulty INT DEFAULT 1,
    ConsecutiveHits INT DEFAULT 0,
    TotalQuestionsAsked INT DEFAULT 0,
    TotalCorrectAnswers INT DEFAULT 0
);

INSERT INTO Topics (TopicId, Name) VALUES (1, 'Ingeniería de Software'), (2, 'Bases de Datos');

INSERT INTO Questions (QuestionId, TopicId, Difficulty, Content, Feedback) VALUES 
(1, 1, 1, '¿Qué modelo de ciclo de vida gestiona mejor los riesgos?', 'El modelo en espiral permite iteraciones basadas en riesgo.'),
(16, 2, 1, '¿Qué forma normal elimina dependencias transitivas?', 'La 3NF normaliza los atributos no clave.');

INSERT INTO Options (OptionId, QuestionId, Text, IsCorrect) VALUES 
(1, 1, 'Modelo en Espiral', 1), (2, 1, 'Cascada', 0), (3, 1, 'RUP', 0), (4, 1, 'Prototipado', 0),
(61, 16, '3NF', 1), (62, 16, '1NF', 0), (63, 16, '2NF', 0), (64, 16, 'BCNF', 0);
GO