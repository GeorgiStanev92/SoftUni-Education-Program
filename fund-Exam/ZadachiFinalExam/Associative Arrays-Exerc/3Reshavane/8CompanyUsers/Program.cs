using System;
using System.Collections.Generic;
using System.Linq;

namespace _8CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companies = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] parts = input.Split(" -> ");

                string company = parts[0];
                string id = parts[1];

                if (!companies.ContainsKey(company))
                {
                    companies.Add(company, new List<string>());
                    companies[company].Add(id);
                }
                else
                {
                    companies[company].Add(id);
                }
            }

            Dictionary<string, List<string>> sortedCompanies = companies
                .OrderBy(c => c.Key)
                .ToDictionary(c => c.Key, c => c.Value);

            foreach (var company in sortedCompanies)
            {
                Console.WriteLine(company.Key);

                List<string> uniqueId = company.Value
                    .Distinct()
                    .ToList();

                foreach (var id in uniqueId)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }
    }
}
