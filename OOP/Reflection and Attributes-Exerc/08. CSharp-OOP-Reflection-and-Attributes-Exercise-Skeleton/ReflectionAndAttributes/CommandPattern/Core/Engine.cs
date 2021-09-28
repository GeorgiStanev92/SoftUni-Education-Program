using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter command;

        public Engine(ICommandInterpreter command)
        {
            this.command = command;
        }
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                string output = command.Read(input);

                Console.WriteLine(output);
            }
        }
    }
}
