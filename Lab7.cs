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

        bool CheckString(string str)
        {
            //Vehicle Registration Number
            Regex VRN = new Regex("^[ABCEHIKMOPTX]{2}(?!0{4})[0-9]{4}[ABCEHIKMOPTX]{2}$");
            Match match = VRN.Match(str);
            return match.Success;
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            if (args.Length > 0)
            {
                if (args[0] == "/?" || args[0] == "/h")
                    program.PrintHelp();
                if (args[0] == "/s")
                {
                    if (args.Length > 1)
                    {
                        for (int i = 1; i < args.Length; i++)
                        {
                            if (program.CheckString(args[i]))
                                Console.WriteLine($"{args[i]} is a valid VRN");
                            else
                                Console.WriteLine($"{args[i]} is not a valid VRN");
                        }
                    }
                    if (args[0] == "/f")
                    {
                        using (StreamReader sr = new StreamReader(args[1]))
                        {
                            string[] file_input = sr.ReadToEnd().Split(" ");
                            foreach (string str in file_input)
                            {
                                if (program.CheckString(str))
                                    Console.WriteLine($"{str} is a valid VRN");
                                else
                                    Console.WriteLine($"{str} is not a valid VRN");
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("You can input 'end' to stop the program");
                for (; ; )
                {
                    Console.WriteLine("Input a string: ");
                    string input = Console.ReadLine();
                    if (input == "end")
                        break;
                    string[] array = input.Split(" ");
                    foreach (string str in array)
                    {
                        if (program.CheckString(str))
                            Console.WriteLine($"{str} is a valid VRN");
                        else
                            Console.WriteLine($"{str} is not a valid VRN");
                    }
                }
            }
        }
    }
}
