using System.Collections.Generic;

namespace BorderControl
{
    public class Robot : IRobot
    {
        public string Model { get; private set; }

        public string Id { get; private set; }

        public Queue<string> robotPopulation { get; set; }

        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
            robotPopulation = new Queue<string>();
        }
    }
}
