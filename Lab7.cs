using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Fun
{
    class Program
    {
        void PrintHelp()
        {
            Console.WriteLine("This application checks if a string is a valid Vehicle Registration Number");
            Console.WriteLine("Command line argument: /h - help, /f 'filename' - check from file, /s - read strings from CLI");
        }

        void CheckArray(string[] arguments)
        {
            //Vehicle Registration Number
            Regex VRN = new Regex("^[ABCEHIKMOPTX]{2}(?!0{4})[0-9]{4}[ABCEHIKMOPTX]{2}$");
            foreach(string str in arguments)
            {
                Match match = VRN.Match(str);
                if (match.Success)
                    Console.WriteLine($"{str} is a valid VRN");
                else
                    Console.WriteLine($"{str} is not a valid VRN");
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            if (args.Length > 0)
            {
                if (args[0] == "/?" || args[0] == "/h")
                    program.PrintHelp();
                if (args[0] == "/s")
                    program.CheckArray(args);
                if (args[0] == "/f")
                {
                    using (StreamReader sr = new StreamReader(args[1]))
                    {
                        string[] file_input = sr.ReadToEnd().Split(" ");
                        program.CheckArray(file_input);
                    }
                }
            }
            else
            {
                Console.WriteLine("You can input 'end' to stop the program");
                for(; ; )
                {
                    Console.WriteLine("Input a string: ");
                    string input = Console.ReadLine();
                    if (input == "end")
                        break;
                    string[] array = input.Split(" ");
                    program.CheckArray(array);
                }
            }
        }
    }
}
