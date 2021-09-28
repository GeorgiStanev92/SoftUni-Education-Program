USE SoftUni

--Task 1
SELECT * FROM Departments

--Task 2
SELECT [Name]
FROM Departments

-- Task 3
SELECT [FirstName], [LastName], [Salary]
FROM [Employees]

--Task 4
SELECT [FirstName], [MiddleName], [LastName]
FROM [Employees]

--Task 5
SELECT CONCAT([FirstName],'.', [LastName],'@softuni.bg') AS [Full Email Address]
FROM Employees

--Task 6
SELECT DISTINCT [Salary]
FROM [Employees]

-- Task 7
SELECT [EmployeeID] AS [ID],
[FirstName],
[LastName],
[MiddleName],
[JobTitle],
[DepartmentID],
[ManagerID],
[HireDate],
[Salary],
[AddressID]
FROM [Employees]
WHERE [JobTitle] LIKE 'Sales Representative'

-- Task 8
SELECT [FirstName], [LastName], [JobTitle]
FROM [Employees]
WHERE [Salary] BETWEEN 20000 AND 30000

--Task 9
SELECT CONCAT(FirstName, ' ', MiddleName, ' ',  LastName) AS [Full Name]
FROM [Employees]
WHERE [Salary] IN (25000, 14000, 12500, 23600)

--Task 10
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [ManagerID] IS  NULL

-- Task 11
SELECT [FirstName], [LastName], [Salary]
FROM [Employees]
WHERE [Salary] > 50000
ORDER BY [Salary] DESC

--Task 12
SELECT TOP (5) [FirstName], [LastName]
FROM [Employees]
ORDER BY [Salary] DESC

-- Task 13
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [DepartmentID] != 4

--Task 14
SELECT *
FROM [Employees]
ORDER BY [Salary] DESC 
		,[FirstName]
		,[LastName] DESC
		,[MiddleName]

--Task 15
CREATE VIEW V_EmployeesSalaries AS
SELECT [FirstName], [LastName], [Salary]
FROM [Employees]

--Task 16
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT CONCAT([FirstName],' ', [MiddleName],' ', [LastName]) AS [FullName], [JobTitle] AS[Job Title]
FROM [Employees]

--Task 17
SELECT DISTINCT [JobTitle]
FROM [Employees]

-- Task 18
SELECT TOP(10) [ProjectID] AS [ID],[Name], [Description], [StartDate], [EndDate]
FROM [Projects]
ORDER BY [StartDate] , [Name]

-- Task 19
SELECT TOP(7) [FirstName], [LastName], [HireDate]
FROM [Employees]
ORDER BY [HireDate] DESC

-- Task 20
UPDATE [Employees]
SET [Salary] += [Salary] * 0.12
WHERE [DepartmentID] IN (1, 2, 4, 11)

SELECT [Salary] FROM [Employees]
