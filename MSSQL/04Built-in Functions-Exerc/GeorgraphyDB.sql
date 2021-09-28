USE Geography

--Task 1 Countries Holding 'A'
SELECT [CountryName] AS [Country Name] , [IsoCode] AS [Iso Code]
FROM[Countries]
WHERE [CountryName] LIKE '%a%a%a%'
ORDER BY [IsoCode]

-- Task 2 Mix of Peak and River Names
SELECT [PeakName],[RiverName], CONCAT(LOWER([PeakName]),LOWER(SUBSTRING([RiverName],2,LEN([RiverName])))) AS Mix 
FROM [Peaks],[Rivers]
WHERE RIGHT([PeakName],1) = LEFT([RiverName],1)
ORDER BY Mix