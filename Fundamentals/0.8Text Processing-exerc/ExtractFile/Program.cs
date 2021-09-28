using System;
using System.Text;

namespace ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] path = Console.ReadLine().Split("\\", StringSplitOptions.RemoveEmptyEntries);

            string fileWithExtension = path[path.Length - 1];

            //string[] fileParts = fileWithExtension.Split('.');

            //string extension = fileParts[fileParts.Length - 1];

            //string fileName = fileWithExtension.Replace($".{extension}", "");    

            //Console.WriteLine($"File name: {fileName}");
            // Console.WriteLine($"File extension: {extension}");

            int extensionIdx = fileWithExtension.LastIndexOf('.');

            string fileName = fileWithExtension.Substring(0, extensionIdx);

            string extesnion = fileWithExtension.Substring(extensionIdx + 1);

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {extesnion}");
        }
    }
}
