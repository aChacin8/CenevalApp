-- 1. Crear la base de datos
CREATE DATABASE IF NOT EXISTS CenevalDB;
USE CenevalDB;

-- 2. Crear tabla Topics (necesaria para la FK de Questions)
CREATE TABLE Topics (
    TopicId INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL
);

-- 3. Crear tabla Questions (necesaria para la FK de Options)
CREATE TABLE Questions (
    QuestionId INT PRIMARY KEY,
    TopicId INT NOT NULL,
    Difficulty INT NOT NULL,
    Content TEXT NOT NULL,
    Feedback TEXT,
    CONSTRAINT FK_Questions_Topics FOREIGN KEY (TopicId) REFERENCES Topics(TopicId)
);

-- 4. Crear tabla Options
CREATE TABLE Options (
    OptionId INT PRIMARY KEY,
    QuestionId INT NOT NULL,
    Text TEXT NOT NULL,
    IsCorrect TINYINT(1) NOT NULL, -- MySQL usa 1/0 para booleanos
    CONSTRAINT FK_Options_Questions FOREIGN KEY (QuestionId) REFERENCES Questions(QuestionId)
);

-- 5. Crear tabla Users
CREATE TABLE Users (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(50) NOT NULL UNIQUE,
    Password VARCHAR(255) NOT NULL,
    FullName VARCHAR(100) NOT NULL
);

-- 6. Crear tabla UserProgress
CREATE TABLE UserProgress (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    UserId VARCHAR(100) NOT NULL,
    UserIdInt INT NOT NULL,
    CurrentTopicId INT DEFAULT 1,
    CurrentDifficulty INT DEFAULT 1,
    ConsecutiveHits INT DEFAULT 0,
    TotalQuestionsAsked INT DEFAULT 0,
    TotalCorrectAnswers INT DEFAULT 0,
    CONSTRAINT FK_UserProgress_Users FOREIGN KEY (UserIdInt) REFERENCES Users(Id)
);

CREATE TABLE Evaluations (
    EvaluationId INT PRIMARY KEY AUTO_INCREMENT,
    UserIdInt INT NOT NULL,
    StartDateTime DATETIME DEFAULT CURRENT_TIMESTAMP,
    TotalQuestions INT NOT NULL,
    CorrectAnswers INT NOT NULL,
    ScorePercentage DECIMAL(5,2) NOT NULL, -- Almacena por ejemplo 85.50
    CONSTRAINT FK_Evaluations_Users FOREIGN KEY (UserIdInt) REFERENCES Users(Id)
);

-- 2. Tabla de Detalles de Evaluación
-- Almacena la respuesta específica que dio el usuario a cada pregunta.
-- Esto permite saber exactamente en qué falló el usuario.
CREATE TABLE EvaluationDetails (
    DetailId INT PRIMARY KEY AUTO_INCREMENT,
    EvaluationId INT NOT NULL,
    QuestionId INT NOT NULL,
    SelectedOptionId INT NOT NULL,
    IsCorrect TINYINT(1) NOT NULL,
    CONSTRAINT FK_Details_Evaluations FOREIGN KEY (EvaluationId) REFERENCES Evaluations(EvaluationId),
    CONSTRAINT FK_Details_Questions FOREIGN KEY (QuestionId) REFERENCES Questions(QuestionId),
    CONSTRAINT FK_Details_Options FOREIGN KEY (SelectedOptionId) REFERENCES Options(OptionId)
);


















