using System;
using System.Collections.Generic;
using System.Linq;

namespace _6Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "end")
                {
                    break;
                }

                string[] parts = line.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string course = parts[0];
                string name = parts[1];

                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>());
                }
                courses[course].Add(name);
            }
            Dictionary<string, List<string>> sorted = courses
                .OrderByDescending(c => c.Value.Count)
                .ToDictionary(c => c.Key, c => c.Value);

            foreach (var course in sorted)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");

                course.Value.Sort();

                foreach (var kvp in course.Value)
                {
                    Console.WriteLine($"-- {kvp}");
                }
            }
        }
    }
}
