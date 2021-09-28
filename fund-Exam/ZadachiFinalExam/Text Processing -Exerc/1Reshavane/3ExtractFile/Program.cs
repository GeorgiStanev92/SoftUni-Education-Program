using System;

namespace _3ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] path = Console.ReadLine()
                .Split("\\", StringSplitOptions.RemoveEmptyEntries);

            string fileWithExtension = path[path.Length - 1];

            int extensionIdx = fileWithExtension.LastIndexOf('.');

            string fileName = fileWithExtension.Substring(0, extensionIdx);

            string extension = fileWithExtension.Substring(extensionIdx + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extension}");
        }
    }
}
