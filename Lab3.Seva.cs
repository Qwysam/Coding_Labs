using System;

namespace Practise
{
    class Program
    {
        // Parent class
        public abstract class institude
        {
            //Stores the name of object
            private string name;
            //Stores number of pages of the object
            private int amount_pupils;
            //Stores number of chapters of the object
            private int year_studying;
            //Stores price of the object
            private int number;
            //Stores quantity of the object
            private int amount_staff;
            //  pages - amount_pupils
            //  chaptes - Year_Studying
            //  price - number
            //  quantity - amount_staff

            //name properties
            public string Name
            {
                get { return name; }
                set
                {
                    if (value == "")
                        throw new ArgumentNullException();
                    else
                        name = value;
                }
            }

            public int Amount_Pupils
            {
                //pages properties
                get { return amount_pupils; }
                set
                {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    else
                        amount_pupils = value;
                }
            }

            //chapters properties
            public int Year_Studying
            {
                get { return year_studying; }
                set
                {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    else
                        year_studying = value;
                }
            }

            //price properties
            public int Number
            {
                get { return number; }
                set
                {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    else
                        number = value;
                }
            }

            //quantity prorperties
            public int Amount_staff
            {
                get { return amount_staff; }
                set
                {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    else
                        amount_staff = value;
                }
            }

            //returns string with information about the objects
            public virtual string GetInfo()
            {
                return $"{name} of number {number}. There are  {amount_pupils}  pupils, and {amount_staff} staff. You need {year_studying} year of studing";
            }

            //Default constructor
            public institude()
            {
                //Default constructor
            }

            //Constructor that sets name
            public institude(string Name)
            {
                //Constructor that sets name

                this.Name = Name;
            }
            //Constructor that sets pages and chapters
            public institude(int Year_Studying, int Number)
            {
                this.Year_Studying = Year_Studying;
                this.Number = Number;
            }

            //Constructor that sets price and quantity
            public institude(int Amount_Pupils, int Amount_staff, bool kostil)
            {
                this.Amount_staff = Amount_staff;
                this.Amount_Pupils = Amount_Pupils;
            }

        }

        //Child class
        public class School : institude
        {
            //Overriden function to get information
            public override string GetInfo()
            {
                return base.GetInfo();
            }

            //Default constructor
            public School() : base()
            {

            }

            //Constructor that sets name
            public School(string Name) : base(Name)
            {

            }

            //Constructor that sets pages and chapters
            public School(int Amount_pupils, int Year_Studing) : base(Amount_pupils, Year_Studing)
            {


            }

            //Constructor that sets price and quantity
            public School(int Number, int Amount_staff, bool kostil) : base(Number, Amount_staff)
            {

            }
        }

        //Child class
        public class University : institude
        {
            //Overriden function to get information
            public override string GetInfo()
            {
                return base.GetInfo();
            }

            //Default constructor
            public University() : base()
            {

            }

            //Constructor that sets name
            public University(string Name) : base(Name)
            {


            }

            //Constructor that sets pages and chapters
            public University(int Amount_pupils, int Year_Studing) : base(Amount_pupils, Year_Studing)
            {

            }

            //Constructor that sets price and quantity
            public University(int Number, int Amount_staff, bool kostil) : base(Number, Amount_staff)
            {

            }
        }
    

    public static void Input_Info(institude i)
        {
            Console.WriteLine("Input name: ");
            i.Name = Console.ReadLine();
            try
            {
                Console.WriteLine("Input number of pupils: ");
                i.Amount_Pupils = int.Parse(Console.ReadLine());
                Console.WriteLine("Input years of studying: ");
                i.Year_Studying = int.Parse(Console.ReadLine());
                Console.WriteLine("Input facility number: ");
                i.Number = int.Parse(Console.ReadLine());
                Console.WriteLine("Input number of staff members: ");
                i.Amount_staff = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Invalid input!");
            }
        }


        static void Main(string[] args)
        {
            institude[] arr = new institude[2];
            School school = new School();
            University university = new University();
            Console.WriteLine("Input school information:");
            Input_Info(school);
            Console.WriteLine("Input university information:");
            Input_Info(university);
            arr[0] = school;
            arr[1] = university;
            for (; ; )
            {
                string[] action;
                int i;
                Console.WriteLine("Input 1 to choose school or 2 to choose university: ");
                int.TryParse(Console.ReadLine(), out i);
                i--;
                Console.WriteLine("Actions: ");
                Console.WriteLine("sn 'name' to set name\t\t\t\tgn to get name");
                Console.WriteLine("sp 'pupils' to set pupils\t\t\tgp to get pupils");
                Console.WriteLine("sy 'years' to set years\t\t\t\tgy to get years;");
                Console.WriteLine("su 'number' to set number\t\t\tgu to get number ");
                Console.WriteLine("st 'staff' to set staff\t\t\t\tgt to get staff");
                Console.WriteLine("pa to print all info\t\t\t\tex to exit");
                Console.WriteLine("Input: ");
                action = Console.ReadLine().Split(" ");
                if (action[0] == "sn")
                    arr[0].Name = action[1];
                try
                {
                    if (action[0] == "sp")
                        arr[0].Amount_Pupils = int.Parse(action[1]);
                    if (action[0] == "sy")
                        arr[0].Year_Studying = int.Parse(action[1]);
                    if (action[0] == "su")
                        arr[0].Number = int.Parse(action[1]);
                    if (action[0] == "st")
                        arr[0].Amount_staff = int.Parse(action[1]);
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Invalid input!");
                }
                if (action[0] == "gn")
                    Console.WriteLine($"Name: {arr[i].Name}");
                if (action[0] == "gp")
                    Console.WriteLine($"Pupils: {arr[i].Amount_Pupils}");
                if (action[0] == "gy")
                    Console.WriteLine($"Years: {arr[i].Year_Studying}");
                if (action[0] == "gu")
                    Console.WriteLine($"Number: {arr[i].Number}");
                if (action[0] == "gq")
                    Console.WriteLine($"Staff: {arr[i].Amount_staff}");
                if (action[0] == "pa")
                    Console.WriteLine(arr[i].GetInfo());
                if (action[0] == "ex")
                    break;

            }
        }
    }
}
