USE [Gringotts]
-- Task 1 Records’ Count
SELECT COUNT(wd.[Id]) AS [Count]
FROM [WizzardDeposits] AS wd

--  Other solution  SELECT COUNT(*) AS [Count]
--					FROM [WizzardDeposits]

-- Task 2 Longest Magic Wand
SELECT TOP 1 MAX(wd.[MagicWandSize]) AS [LongestMagicWand]
FROM [WizzardDeposits] AS WD
GROUP BY wd.[MagicWandSize]
ORDER BY wd.[MagicWandSize] DESC

-- Task 3 Longest Magic Wand per Deposit Groups
SELECT wd.[DepositGroup], MAX(wd.[MagicWandSize]) AS [LongestMagicWand]
FROM [WizzardDeposits] AS wd
GROUP BY wd.[DepositGroup]

-- Task 4 Smallest Deposit Group Per Magic Wand Size
SELECT TOP (2) wd.[DepositGroup]
FROM [WizzardDeposits] AS wd
GROUP BY wd.[DepositGroup]
ORDER BY AVG(wd.[MagicWandSize])

-- TASK 5 Deposits Sum
SELECT wd.[DepositGroup], SUM(wd.[DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits] AS wd
GROUP BY wd.[DepositGroup]

-- Task 6 Deposits Sum for Ollivander Family
SELECT wd.[DepositGroup], SUM(wd.[DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits] AS wd
WHERE wd.[MagicWandCreator] = 'Ollivander family'
GROUP BY wd.[DepositGroup]

-- Task 7 Deposits Filter
SELECT wd.[DepositGroup], SUM(wd.[DepositAmount]) AS [TotalSum]
FROM [WizzardDeposits] AS wd
WHERE wd.[MagicWandCreator] = 'Ollivander family'
GROUP BY wd.[DepositGroup]
HAVING SUM(wd.[DepositAmount]) < 150000
ORDER BY [TotalSum] DESC

-- Task 8 Deposit Charge
SELECT wd.[DepositGroup], wd.[MagicWandCreator], MIN(wd.[DepositCharge]) AS [MinDepositCharge]
FROM [WizzardDeposits] AS wd
GROUP BY wd.[DepositGroup], wd.[MagicWandCreator]
ORDER BY wd.[MagicWandCreator], wd.[DepositGroup]

-- Task 9 Age Groups
SELECT [AgeGroup],
	   COUNT([Id]) AS [WizardCount]
FROM	(SELECT *,
			CASE
				WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
				WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
				WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
				WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
				WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
				WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
				ELSE '[61+]'
			END AS [AgeGroup]
		  FROM [WizzardDeposits]) AS [AgeGroupingQuery]
GROUP BY [AgeGroup]

-- Task 10 First Letter
SELECT DISTINCT LEFT(wd.[FirstName], 1) AS [FirstLetter]
FROM [WizzardDeposits] AS wd
WHERE wd.DepositGroup = 'Troll Chest'
GROUP BY LEFT([FirstName], 1)

-- Task 11 Average Interest
SELECT wd.[DepositGroup],
	   wd.[IsDepositExpired],
	   AVG(wd.[DepositInterest]) AS [AverageInterest]
FROM [WizzardDeposits] AS wd
WHERE [DepositStartDate] > '1985-01-01'
GROUP BY wd.[DepositGroup], wd.[IsDepositExpired]
ORDER BY wd.[DepositGroup] DESC, wd.[IsDepositExpired]
-- Task 12 Rich Wizard, Poor Wizard
SELECT SUM([DIFFERENCE]) AS [SumDifference]
FROM	(SELECT wd.[FirstName] AS [Host Wizard],
		   wd.[DepositAmount] AS [Host Wizard Deposit],
		   LEAD(wd.[FirstName]) OVER(ORDER BY wd.[Id]) AS [Guest Wizard],
		   Lead(wd.[DepositAmount]) OVER(ORDER BY wd.[Id]) AS [Guest Wizard Deposit],
		   (wd.[DepositAmount] - Lead(wd.[DepositAmount]) OVER(ORDER BY wd.[Id])) AS [Difference]
		FROM [WizzardDeposits] AS wd) AS [DifferenceSubQuery]

		-- Other solution
/*SELECT SUM([DIFFERENCE]) AS [SumDifference]
FROM	(SELECT wd1.[FirstName] AS [Host Wizard],
			   wd1.[DepositAmount] AS [Host Wizard Deposit],
			   wd2.[FirstName] AS [Guest Wizard],
			   wd2.[DepositAmount] AS [Guest Wizard Deposit],
			   wd1.[DepositAmount] - wd2.[DepositAmount] AS [Difference]
		FROM [WizzardDeposits] AS wd1
		JOIN [WizzardDeposits] AS wd2
		ON wd1.[Id] + 1 = wd2.[Id]) AS [DifferenceSubQuery]*/

USE [SoftUni]
-- Task 13 Departments Total Salaries
SELECT e.[DepartmentID],
	   SUM(e.[Salary])
FROM [Employees] AS e
GROUP BY e.[DepartmentID]
ORDER BY e.[DepartmentID]

-- Task 14 Employees Minimum Salaries
SELECT e.[DepartmentID],
	   MIN(e.[Salary])
FROM [Employees] AS e
WHERE e.[DepartmentID] IN (2, 5, 7) AND e.[HireDate] > '2000-01-01'
GROUP BY e.[DepartmentID]
ORDER BY e.[DepartmentID]

-- Task 15 Employees Average Salaries
SELECT *
  INTO EmployeesAverageSalaries
  FROM Employees
 WHERE Salary > 30000

DELETE 
	FROM EmployeesAverageSalaries
	WHERE ManagerID = 42

UPDATE EmployeesAverageSalaries
	SET Salary += 5000
	WHERE DepartmentID = 1

SELECT e.DepartmentID, AVG(e.Salary) AS AverageSalary
	FROM EmployeesAverageSalaries e
	GROUP BY e.DepartmentID

-- Task 16 Employees Maximum Salaries
SELECT e.[DepartmentID],
		MAX(e.[Salary]) AS [MaxSalary]
FROM [Employees] AS e
GROUP BY e.[DepartmentID]
HAVING MAX(e.[Salary]) NOT BETWEEN 30000 AND 70000

-- Task 17 Employees Count Salaries
SELECT COUNT(*) AS [Count]
FROM [Employees] AS e
WHERE e.[ManagerID] IS NULL

-- Task 18 3rd Highest Salary
SELECT DISTINCT [DepartmentID],
				[Salary] AS [ThirdHighestSalary]
FROM		(SELECT e.[DepartmentID],
						e.[Salary],
						DENSE_RANK() OVER(PARTITION BY e.[DepartmentId] ORDER BY e.[Salary] DESC) AS [SalaryRank]
				FROM [Employees] AS e) AS [SalaryRankingQuery]
WHERE [SalaryRank] = 3

-- Task 19 Salary Challenge
SELECT TOP 10 e.[FirstName],
	   e.[LastName],
	   e.[DepartmentID]
FROM [Employees] AS e
WHERE e.[Salary] > (SELECT AVG(esub.[Salary]) AS [DepartmentAverageSalary]
					FROM [Employees] AS esub
					WHERE esub.[DepartmentID] = e.[DepartmentID]
					GROUP BY esub.[DepartmentID])
ORDER BY e.[DepartmentID]
