using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _5NetherRealms
{
    public class Demon
    {
        public string Name { get; set; }

        public int Health { get; set; }

        public double Damage { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] demons = Console.ReadLine()
                .Split(',')
                .Select(e => e.Trim())
                .ToArray();

            Regex hpRegex = new Regex(@"[^\d\-+.*\/]");

            Regex numberRegex = new Regex(@"[+\-]*\d+\.?\d*");

            Regex amplifiersRegex = new Regex(@"[*\/]");

            List<Demon> allDemons = new List<Demon>();
            foreach (var demon in demons)
            {
                // int health = hpRegex.Matches(demon)
                //   .Select(m => char.Parse(m.Value))
                //   .Sum(x => x);

                MatchCollection hpMatches = hpRegex.Matches(demon);

                int health = GetHealth(hpMatches);

                MatchCollection numberMatches = numberRegex.Matches(demon);

                double damage = GetBaseDamage(numberMatches);

                MatchCollection amplifiersMatches = amplifiersRegex.Matches(demon);

                foreach (Match match in amplifiersMatches)
                {
                    if (match.Value == "*")
                    {
                        damage *= 2;
                    }
                    else
                    {
                        damage /= 2;
                    }
                }

                allDemons.Add(new Demon
                {
                    Name = demon,
                    Damage = damage,
                    Health = health
                });
            }

            List<Demon> sorted = allDemons
                .OrderBy(d => d.Name)
                .ToList();

            foreach (Demon demon in sorted)
            {
                Console.WriteLine($"{demon.Name} - {demon.Health} health, {demon.Damage:F2} damage");
            }
        }

        private static double GetBaseDamage(MatchCollection matchCollection)
        {
            double damage = 0;

            foreach (Match match in matchCollection)
            {
                damage += double.Parse(match.Value);
            }
            return damage;
        }

        private static int GetHealth(MatchCollection matchCollection)
        {
            int sum = 0;

            foreach (Match match in matchCollection)
            {
                sum += char.Parse(match.Value);
            }
            return sum;
        }
    }
}
