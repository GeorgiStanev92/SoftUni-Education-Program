using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Citizen> people = new Dictionary<string, Citizen>();
            Dictionary<string, Robot> robots = new Dictionary<string, Robot>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0].All(t => char.IsLetter(t)))
                {
                    string name = tokens[0];
                    int age = int.Parse(tokens[1]);
                    string id = tokens[2];
                    Citizen person = new Citizen(name, age, id);
                    people[name] = person;
                    person.Population.Enqueue(id);
                }
                else
                {
                    string model = tokens[0];
                    string id = tokens[1];
                    Robot robot = new Robot(model, id);
                    robots[model] = robot;
                    robot.robotPopulation.Enqueue(id);
                }
            }

            string n = Console.ReadLine();

            foreach (var person in people)
            {
                foreach (var p in person.Value.Population)
                {
                    if (p.EndsWith(n))
                    {
                        Console.WriteLine(p);
                    }
                }
            }

            foreach (var robot in robots)
            {
                foreach (var r in robot.Value.robotPopulation)
                {
                    if (r.EndsWith(n))
                    {
                        Console.WriteLine(r);
                    }
                }
            }
            
        }
    }
}
