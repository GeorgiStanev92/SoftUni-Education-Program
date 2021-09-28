CREATE DATABASE Relationship
USE Relationship

--One-To-One Relationship
CREATE TABLE [Passports](
			 [PassportID] INT PRIMARY KEY IDENTITY(101,1),
			 [PassportNumber] NVARCHAR(40)
);

INSERT INTO [Passports]([PassportNumber])
VALUES		('N34FG21B'),
			('K65LO4R7'),
			('ZE657QP2')

CREATE TABLE Persons(
			 [PersonID] INT PRIMARY KEY IDENTITY,
			 [FirstName] NVARCHAR(55) NOT NULL,
			 [Salary] DECIMAL NOT NULL,
  			 [PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportID]) UNIQUE NOT NULL
);

INSERT INTO [Persons]([FirstName], [Salary], [PassportID])
VALUES		('Roberto', 43300.00, 102),
			('Tom', 56100.00, 103),
			('Yana', 60200.00,101)

-- Task 2 One-To-Many Relationship
CREATE TABLE [Manufacturers](
			 [ManufacturerID] INT PRIMARY KEY IDENTITY,
			 [Name] VARCHAR(20) NOT NULL,
			 [EstablishedOn] DATE NOT NULL
);

INSERT INTO [Manufacturers]([Name], [EstablishedOn])
VALUES      ('BMW', '07/03/1916'),
			('Tesla', '01/01/2003'),
			('Lada', '01/05/1966')

CREATE TABLE [Models](
			 [ModelID] INT PRIMARY KEY IDENTITY(101,1),
			 [Name] VARCHAR(20) NOT NULL,
			 [ManufacturerID] INT FOREIGN KEY REFERENCES [Manufacturers](ManufacturerID) NOT NULL
);

INSERT INTO [Models]([Name],[ManufacturerID])
VALUES		('X1', 1),
			('i6', 1),
			('Model S', 2),
			('Model X', 2),
			('Model 3', 2),
			('Nova', 3)

-- Task 3 Many-To-Many Relationship

CREATE TABLE [Students](
			 [StudentID] INT PRIMARY KEY IDENTITY,
			 [Name] NVARCHAR(55) NOT NULL
);

INSERT INTO [Students]([Name])
VALUES		('Mila'),
			('Toni'),
			('Ron')


CREATE TABLE [Exams](
			 [ExamID] INT PRIMARY KEY IDENTITY(101,1),
			 [Name] NVARCHAR(30) NOT NULL
);

INSERT INTO [Exams]([Name])
VALUES		('SpringMVC'),
			('Neo4j'),
			('Oracle 11g')


CREATE TABLE [StudentsExams](
			 [StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL,
			 [ExamID] INT FOREIGN KEY REFERENCES [Exams]([ExamID]) NOT NULL,
			 PRIMARY KEY ([StudentID], [ExamID])
);

INSERT INTO [StudentsExams]([StudentID],[ExamID])
VALUES		(1,101),
			(1,102),
			(2,101),
			(3,103),
			(2,102),
			(2,103)

-- Task 4 Self-Referencing
CREATE TABLE [Teachers](
			 [TeacherID] INT PRIMARY KEY IDENTITY(101,1),
			 [Name] NVARCHAR(55) NOT NULL,
			 [ManagerID] INT FOREIGN KEY REFERENCES [Teachers]([TeacherID])
);

INSERT INTO [Teachers]([Name],[ManagerID])
VALUES		('John', NULL),
			('Maya', 106),
			('Silvia', 106),
			('Ted', 105),
			('Mark', 101),
			('Greta', 101)



