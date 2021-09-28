CREATE TABLE People (
	[Id] int PRIMARY KEY IDENTITY,
	[Name] NVARCHAR (200) UNIQUE NOT NULL,
	[Picture] VARBINARY (MAX),
	[Height] REAL,
	[Weight] REAL,
	[Gender] CHAR (1) NOT NULL,
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX));

INSERT INTO [People] ([Name], [Picture], [Height], [Weight], [Gender], [Birthdate], [Biography])
VALUES 
			('Gosho', null, 1.75, 63, 'm', '1992-01-05', null),
			('Krisi', null, 1.75, 63, 'f', '1992-01-05', null),
			('Sisi', null, 1.75, 63, 'f', '1992-01-05', null),
			('Gocho', null, 1.75, 63, 'm', '1992-01-05', null),
			('Sasho', null, 1.75, 63, 'm', '1992-01-05', null)


CREATE TABLE [Users](
	[Id] BIGINT IDENTITY(1,1) PRIMARY KEY,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT NOT NULL
);

INSERT INTO [Users] ([Username], [Password], [LastLoginTime], [IsDeleted])
VALUES
		('Gosho', '23456', '11.11.2020', 0),
		('Gosho1', '23456', '11.11.2020', 1),
		('Gosho2', '23456', '11.11.2020', 2),
		('Gosho3', '23456', '11.11.2020', 0),
		('Gosho4', '23456', '11.11.2020', 0)