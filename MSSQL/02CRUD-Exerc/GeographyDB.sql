USE Geography 

--Task 1
SELECT  [PeakName]
FROM [Peaks]
ORDER BY [PeakName]

--Task 2
SELECT TOP(30) [CountryName], [Population] 
FROM [Countries]
WHERE [ContinentCode] = 'EU'
ORDER BY [Population] DESC, [CountryName]

--Task 3
SELECT [CountryName], [CountryCode],
	CASE
		WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
		ELSE 'Not Euro'
	END AS [Currency]
FROM [Countries]
ORDER BY [CountryName]