using System.Collections.Generic;

namespace BorderControl
{
    public class Citizen : ICitizens
    {
        
        public string Name { get;private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public Queue<string> Population { get; private set; }

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
            Population = new Queue<string>();
        }
    }
}
