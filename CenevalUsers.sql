USE CenevalDB;
GO

CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL
);

ALTER TABLE UserProgress
ADD UserIdInt INT NOT NULL;

ALTER TABLE UserProgress
ADD CONSTRAINT FK_UserProgress_Users FOREIGN KEY (UserIdInt) REFERENCES Users(Id);

INSERT INTO Users (Username, Password, FullName) 
VALUES ('achacin', 'admin123', 'Alejandro Chacin');
GO

    SELECT * FROM Users;