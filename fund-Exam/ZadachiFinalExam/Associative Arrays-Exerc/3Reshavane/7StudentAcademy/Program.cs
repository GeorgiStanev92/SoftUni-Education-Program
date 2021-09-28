using System;
using System.Collections.Generic;
using System.Linq;

namespace _7StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> grades = new Dictionary<string, List<double>>();

            int lines = int.Parse(Console.ReadLine());

            for (int i = 0; i < lines; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!grades.ContainsKey(name))
                {
                    grades.Add(name, new List<double>());
                    grades[name].Add(grade);
                }
                else
                {
                    grades[name].Add(grade);
                }
            }
            Dictionary<string, double> sortedGrades = grades
                .Select(s => new KeyValuePair<string, double>(s.Key, s.Value.Average()))
                .Where(s => s.Value >= 4.50)
                .OrderByDescending(s => s.Value)
                .ToDictionary(s => s.Key, s => s.Value);

            foreach (var student in sortedGrades)
            {
                Console.WriteLine($"{student.Key} -> {student.Value:F2}");
            }
        }
    }
}
