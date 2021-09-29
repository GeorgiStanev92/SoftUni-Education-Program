USE [Geography]

-- Task 1 Highest Peaks in Bulgaria
SELECT c.[CountryCode], m.[MountainRange], p.[PeakName],p.[Elevation]
FROM [Peaks] AS p
LEFT JOIN [Mountains] AS m
ON p.[MountainId] = m.[Id]
LEFT JOIN [MountainsCountries] AS mc
ON m.[Id] = mc.[MountainId]
LEFT JOIN [Countries] AS c
ON mc.[CountryCode] = c.[CountryCode]
WHERE c.[CountryCode] = 'BG' AND p.[Elevation] > 2835
ORDER BY p.[Elevation] DESC

-- Task 2 Count Mountain Ranges
SELECT c.[CountryCode], COUNT(mc.[MountainId]) AS  [MountainRanges]
FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc
ON c.[CountryCode] = mc.[CountryCode]
WHERE c.[CountryCode] IN ('BG', 'RU', 'US')
GROUP BY c.[CountryCode]

-- Task 3  Countries With or Without Rivers
SELECT TOP 5 c.[CountryName], r.[RiverName]
FROM [Countries] AS c
LEFT JOIN [CountriesRivers] AS cr
ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r
ON cr.[RiverId] = r.[Id]
WHERE c.[ContinentCode] = 'AF'
ORDER BY c.[CountryName]
-- Task 4 Continents and Currencies 
SELECT [ContinentCode], [CurrencyCode], [CurrencyCount] AS [CurrencyUsage]
FROM
		(SELECT *,
			DENSE_RANK() OVER(PARTITION BY [ContinentCode] ORDER BY [CurrencyCount] DESC) AS [CurrencyRank]
		FROM(
			SELECT [ContinentCode], [CurrencyCode], COUNT([CurrencyCode]) AS [CurrencyCount]
			FROM [Countries]
			GROUP BY [ContinentCode], [CurrencyCode]) AS [CurrencyCountSubQuery]
WHERE [CurrencyCount] > 1) AS [CurrencyRankingSubQuery]
WHERE [CurrencyRank] = 1
ORDER BY [ContinentCode]

-- Task 5 Countries Without any Mountains
SELECT COUNT(c.[CountryCode])
FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc
ON c.[CountryCode] = mc.[CountryCode]
WHERE [MountainId] IS NULL

-- Task 6  Highest Peak and Longest River by Country
SELECT TOP 5 c.[CountryName]
		,MAX(p.[Elevation]) AS [HighestPeakElevation]
		,MAX(r.[Length]) AS [LongestRiverLength]
FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc
ON c.[CountryCode] = mc.[CountryCode]
LEFT JOIN [Mountains] AS m
ON mc.[MountainId] = m.[Id]
LEFT JOIN [Peaks] AS p
ON m.[Id] = p.[MountainId]
LEFT JOIN [CountriesRivers] AS cr
ON c.[CountryCode] = cr.[CountryCode]
LEFT JOIN [Rivers] AS r
ON cr.[RiverId] = r.[Id]
GROUP BY c.[CountryName]
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, [CountryName]

-- Task 7 Highest Peak Name and Elevation by Country
SELECT TOP (5) [CountryName] AS [Country],
       ISNULL([PeakName], '(no highest peak)') AS [Highest Peak Name],
	   ISNULL([Elevation], 0) AS [Highest Peak Elevation],
	   ISNULL([MountainRange], '(no mountain)') AS [Mountain]
FROM (
		SELECT c.[CountryName],
			   p.[PeakName],
			   p.[Elevation],
			   m.[MountainRange],
			   DENSE_RANK() OVER(PARTITION BY c.[CountryName] ORDER BY p.[Elevation] DESC) AS [PeakRank]
		FROM [Countries] AS c
		LEFT JOIN [MountainsCountries] AS mc
		ON c.[CountryCode] = mc.[CountryCode]
		LEFT JOIN [Mountains] AS m
		ON mc.[MountainId] = m.[Id]
		LEFT JOIN [Peaks] AS p
		ON m.[Id] = p.[MountainId]
     ) AS [PeaksRankingSubQuery]
WHERE [PeakRank] = 1
ORDER BY [Country], [Highest Peak Name]