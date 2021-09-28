USE SoftUni

-- Task 1 Find Names of All Employees by First Name
SELECT [FirstName], [LastName] 
FROM Employees
WHERE LEFT([FirstName],2) = 'Sa'

-- Task 2 Find Names of All Employees by Last Name
SELECT [FirstName], [LastName] 
FROM Employees
WHERE [LastName] like '%ei%'

-- Task 3 Find First Names of All Employess
SELECT [FirstName] 
FROM Employees
WHERE [DepartmentID] IN(3, 10) AND YEAR([HireDate]) BETWEEN 1995 AND 2005 

--Task 4 Find All Employees Except Engineers
SELECT FirstName, LastName 
	FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

-- Task 5 Find Towns with Name Length
Select [Name]
FROM [Towns]
WHERE LEN([Name]) IN (5,6)
ORDER BY [Name]

--Task 6 Find Towns Starting With
SELECT *
FROM [Towns]
WHERE LEFT([Name],1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]

-- Task 7 Find Towns Not Starting With
SELECT *
FROM [Towns]
WHERE LEFT([Name],1) NOT IN ('R', 'B', 'D')
ORDER BY [Name]

-- Task 8 
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE YEAR([HireDate]) > 2000

-- Task 9 Length of Last Name
SELECT [FirstName], [LastName] FROM [Employees]
WHERE LEN([LastName]) = 5

-- Task 10 Rank Employees by Salary
SELECT [EmployeeID],[FirstName],[LastName],[Salary], 
		DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank] 
FROM [Employees]
WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

-- Task 11 Find All Employees with Rank 2
SELECT * 
FROM (
			SELECT [EmployeeID],[FirstName],[LastName],[Salary], 
				DENSE_RANK() OVER (PARTITION BY [Salary] ORDER BY [EmployeeID]) AS [Rank] 
			FROM [Employees]
			WHERE [Salary] BETWEEN 10000 AND 50000) AS [RankingTable]
WHERE [Rank] = 2
ORDER BY [Salary] DESC