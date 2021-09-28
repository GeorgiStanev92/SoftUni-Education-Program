CREATE DATABASE CarRental
USE CarRental

CREATE TABLE [Categories](
			 [Id] INT PRIMARY KEY IDENTITY(1,1),
			 [CategoryName] VARCHAR(20) NOT NULL,
			 [DailyRate] INT,
			 [WeeklyRate] INT,
			 [MonthlyRate] INT,
			 [WeekendRate] INT
);

INSERT INTO [Categories]([CategoryName])
VALUES		('Cat1'),
			('Cat2'),
			('Cat3');


CREATE TABLE [Cars](
			 [Id] INT PRIMARY KEY IDENTITY(1,1),
			 [PlateNumber] NVARCHAR(20) NOT NULL,
			 [Manufacturer] VARCHAR(30),
			 [Model] VARCHAR(30),
			 [CarYear] INT,
			 [CategoryId] INT FOREIGN KEY REFERENCES [Categories](Id),
			 [Doors] INT,
			 [Picture] VARBINARY(MAX),
			 [Condition] VARCHAR(20),
			 [Available] VARCHAR(10)
);

INSERT INTO [Cars]([PlateNumber])
VALUES		('CB 3345'),
			('CB 2345'),
			('CB 1345')


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
			 [Id] INT PRIMARY KEY IDENTITY(1,1),
			 [DriverLicenceNumber] INT NOT NULL,
			 [FullName] NVARCHAR(55) NOT NULL,
			 [Address] NVARCHAR(50),
			 [City] NVARCHAR(30),
			 [ZIPCode] INT,
			 [Notes] TEXT
);

INSERT INTO [Customers]([DriverLicenceNumber], [FullName])
VALUES		(123456, 'Full'),
			(987456, 'Full1'),
			(345678, 'Full2')


CREATE TABLE [RentalOrders](
			 [Id] INT PRIMARY KEY IDENTITY(1,1),
			 [EmployeeId] INT FOREIGN KEY REFERENCES [Employees](Id),
			 [CustomerId] INT FOREIGN KEY REFERENCES [Customers](Id),
			 [CarId] INT FOREIGN KEY REFERENCES [Cars](Id),
			 [TankLevel] INT,
			 [KilometrageStart] INT,
			 [KilometrageEnd] INT,
			 [TotalKilometrage] INT,
			 [StartDate] DATE NOT NULL,
			 [EndDate] DATE NOT NULL,
			 [TotalDays] INT,
			 [RateApplied] REAL,
			 [TaxRate] REAL,
			 [OrderStatus] NVARCHAR(20),
			 [Notes] TEXT
);

INSERT INTO [RentalOrders]([EmployeeId], [CustomerId], [CarId], [StartDate], [EndDate])
VALUES		(1, 2, 3, '01-01-2021', '06-01-2021'),
			(3, 2, 1, '01-02-2021', '06-02-2021'),
			(2, 2, 2, '01-03-2021', '06-03-2021')