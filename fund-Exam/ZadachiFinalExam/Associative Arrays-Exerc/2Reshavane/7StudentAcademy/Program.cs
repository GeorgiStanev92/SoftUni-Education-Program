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

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (grades.ContainsKey(student))
                {
                    grades[student].Add(grade);
                }
                else
                {
                    grades.Add(student, new List<double>());
                    grades[student].Add(grade);
                }
            }
            Dictionary<string, double> sortedGrades = grades
                .Select(s => new KeyValuePair<string, double>(s.Key, s.Value.Average()))
                .Where(s => s.Value >= 4.5)
                .OrderByDescending(s => s.Value)
                .ToDictionary(s => s.Key, s => s.Value);

            foreach (var student in sortedGrades)
            {
                Console.WriteLine($"{student.Key} -> {student.Value:F2}");
            }
        }
    }
}
