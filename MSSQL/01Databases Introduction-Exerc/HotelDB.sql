CREATE DATABASE Hotel
USE Hotel

CREATE TABLE [Employees](
			 [Id] INT PRIMARY KEY IDENTITY(1,1),
			 [FirstName] NVARCHAR(20) NOT NULL,
			 [LastName] NVARCHAR(20) NOT NULL,
			 [Title] NVARCHAR(20),
			 [Notes] TEXT
);

INSERT INTO [Employees]([FirstName], [LastName])
VALUES		('F1', 'L1'),
			('F2', 'L2'),
			('F3', 'L3');


CREATE TABLE [Customers](
			 [AccountNumber] INT PRIMARY KEY IDENTITY(1,1),
			 [FirstName] NVARCHAR(50),
			 [LastName] NVARCHAR(50),
			 [PhoneNumber] INT NOT NULL,
			 [EmergencyName] NVARCHAR(55),
			 [EmergencyNumber] INT,
			 [Notes] TEXT
);

INSERT INTO [Customers]([FirstName], [LastName], [PhoneNumber])
VALUES		('CF', 'CL', 987456),
			('CF1', 'CL1', 987451),
			('CF2', 'CL2', 987453)


CREATE TABLE [RoomStatus](
			 [RoomStatus] NVARCHAR (15) PRIMARY KEY,
			 [Notes] NVARCHAR(MAX)
);

INSERT INTO [RoomStatus]([RoomStatus])
VALUES		('Free'),
			('Reserved'),
			('In use')


CREATE TABLE [RoomTypes](
			 [RoomType] NVARCHAR (15) PRIMARY KEY,
			 [Notes] NVARCHAR(MAX)
);

INSERT INTO [RoomTypes]([RoomType])
VALUES		('Double'),
			('Single'),
			('Family')


CREATE TABLE [BedTypes](
			 [BedType] NVARCHAR(30) PRIMARY KEY,
			 [Notes] NVARCHAR(MAX)
);

INSERT INTO [BedTypes]([BedType])
VALUES		('Standard Double'),
			('Queen Bed'),
			('King Bed')


CREATE TABLE [Rooms](
			 [RoomNumber] INT PRIMARY KEY IDENTITY(1,1),
			 [RoomType] NVARCHAR(15) FOREIGN KEY REFERENCES [RoomTypes](RoomType),
			 [BedType] NVARCHAR(30) FOREIGN KEY REFERENCES [BedTypes](BedType),
			 [Rate] REAL NOT NULL,
			 [RoomStatus] NVARCHAR (15) FOREIGN KEY REFERENCES [RoomStatus](RoomStatus),
			 [Notes] TEXT
);

INSERT INTO [Rooms]([RoomType], [BedType], [Rate], [RoomStatus])
VALUES		('Family', 'King Bed', 5.5, 'Free'),
			('Double', 'Queen Bed', 6.5, 'Reserved'),
			('Single', 'Standard Double', 8.5, 'In use')


CREATE TABLE [Payments](
			 [Id] INT PRIMARY KEY IDENTITY (1,1),
			 [EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id),
			 [PaymentDate] DATE NOT NULL,
			 [AccountNumber] INT FOREIGN KEY REFERENCES [Customers](AccountNumber),
			 [FirstDateOccupied] DATE NOT NULL,
			 [LastDateOccupied] DATE NOT NULL,
			 [TotalDays] INT NOT NULL,
			 [AmountCharged] DECIMAL,
			 [TaxRate] REAL NOT NULL,
			 [TaxAmount] DECIMAL,
			 [PaymentTotal] DECIMAL,
			 [Notes] TEXT
);

INSERT INTO [Payments]([EmployeeId], [PaymentDate], [AccountNumber], [FirstDateOccupied], [LastDateOccupied], [TotalDays], [TaxRate], [PaymentTotal])
VALUES		(1, '01-01-2021', 1, '06-01-2021', '07-01-2021', 1, 10, 100),
			(2, '01-01-2021', 2, '06-01-2021', '08-01-2021', 2, 8, 200),
			(3, '01-01-2021', 3, '06-01-2021', '09-01-2021', 3, 20, 400)

			
CREATE TABLE [Occupancies](
			 [Id] INT PRIMARY KEY IDENTITY (1,1),
			 [EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id),
			 [DateOccupied] DATE NOT NULL,
			 [AccountNumber] INT FOREIGN KEY REFERENCES [Customers](AccountNumber),
			 [RoomNumber] INT FOREIGN KEY REFERENCES [Rooms](RoomNumber),
			 [RateApplied] REAL,
			 [PhoneCharge] INT,
			 [Notes] TEXT
);

INSERT INTO [Occupancies]([EmployeeId], [DateOccupied], [AccountNumber], [RoomNumber])
VALUES		(3, '05-05-2005', 3, 3),
			(1, '05-05-2005', 1, 1),
			(2, '05-05-2005', 2, 2)