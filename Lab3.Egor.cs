using System;

namespace Practise
{
    class Program
    {
        // Parent class
        public abstract class Printed_Edition
        {
            //Stores the name of object
            private string name;
            //Stores number of pages of the object
            private int pages;
            //Stores number of chapters of the object
            private int chapters;
            //Stores price of the object
            private double price;
            //Stores quantity of the object
            private int quantity;

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

            //pages properties
            public int Pages
            {
                get { return pages; }
                set
                {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    else
                        pages = value;
                }
            }

            //chapters properties
            public int Chapters
            {
                get { return chapters; }
                set
                {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    else
                        chapters = value;
                }
            }

            //price properties
            public double Price
            {
                get { return price; }
                set
                {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    else
                        price = value;
                }
            }

            //quantity prorperties
            public int Quantity
            {
                get { return quantity; }
                set
                {
                    if (value < 0)
                        throw new ArgumentOutOfRangeException();
                    else
                        quantity = value;
                }
            }

            //returns string with information about the objects
            public virtual string GetInfo()
            {
                return $"{name} has {pages} pages, {chapters} chapters, costs {price} and there are {quantity} copies of it";
            }

            //Default constructor
            public Printed_Edition()
            {

            }

            //Constructor that sets name
            public Printed_Edition(string Name)
            {
                this.Name = Name;
            }

            //Constructor that sets pages and chapters
            public Printed_Edition(int Pages, int Chapters)
            {
                this.Pages = Pages;
                this.Chapters = Chapters;
            }

            //Constructor that sets price and quantity
            public Printed_Edition(double Price, int Quantity)
            {
                this.Price = Price;
                this.Quantity = Quantity;
            }

        }

        //Child class
        public class Book : Printed_Edition
        {
            //Overriden function to get information
            public override string GetInfo()
            {
                return base.GetInfo();
            }

            //Default constructor
            public Book() : base()
            {

            }

            //Constructor that sets name
            public Book(string Name) : base(Name)
            {

            }

            //Constructor that sets pages and chapters
            public Book(int Pages, int Chapters) : base(Pages, Chapters)
            {

            }

            //Constructor that sets price and quantity
            public Book(double Price, int Quantity) : base(Price, Quantity)
            {

            }
        }

        //Child class
        public class Magazine : Printed_Edition
        {
            //Overriden function to get information
            public override string GetInfo()
            {
                return base.GetInfo();
            }

            //Default constructor
            public Magazine() : base()
            {

            }

            //Constructor that sets name
            public Magazine(string Name) : base(Name)
            {

            }

            //Constructor that sets pages and chapters
            public Magazine(int Pages, int Chapters) : base(Pages, Chapters)
            {

            }

            //Constructor that sets price and quantity
            public Magazine(double Price, int Quantity) : base(Price, Quantity)
            {

            }
        }
    
        public static void Input_Info(Printed_Edition p)
        {
            Console.WriteLine("Input name: ");
            p.Name = Console.ReadLine();
            try
            {
                Console.WriteLine("Input number of pages: ");
                p.Pages = int.Parse(Console.ReadLine());
                Console.WriteLine("Input number of chapters: ");
                p.Chapters = int.Parse(Console.ReadLine());
                Console.WriteLine("Input price in USD: ");
                p.Price = double.Parse(Console.ReadLine());
                Console.WriteLine("Input number of goods: ");
                p.Quantity = int.Parse(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Invalid input!");
            }
        }


        static void Main(string[] args)
        {
            Printed_Edition[] arr = new Printed_Edition[2];
            Magazine magazine = new Magazine();
            Book book = new Book();
            Input_Info(book);
            Input_Info(magazine);
            arr[0] = book;
            arr[1] = magazine;
            for(; ; )
            {
                string[] action;
                int i;
                Console.WriteLine("Input 1 to choose book or 2 to choose magazine");
                int.TryParse(Console.ReadLine(), out i);
                i--;
                Console.WriteLine("Actions: ");
                Console.WriteLine("sn 'name' to set name\t\t\tgn to get name");
                Console.WriteLine("sp 'pages' to set pages\t\t\tgp to get pages");
                Console.WriteLine("sc 'chapters' to set chapters\t\t\tgc to get chapters;");
                Console.WriteLine("sr 'price' to set price\t\t\tgp to get price ");
                Console.WriteLine("sq 'quantity' to set quantity\t\t\tgq to get quantity");
                Console.WriteLine("pa to print all info\t\t\tex to exit");
                Console.WriteLine("Input: ");
                action = Console.ReadLine().Split(" ");
                if (action[0] == "sn")
                    arr[0].Name = action[1];
                try
                {
                    if (action[0] == "sp")
                        arr[0].Pages = int.Parse(action[1]);
                    if (action[0] == "sc")
                        arr[0].Chapters = int.Parse(action[1]);
                    if (action[0] == "sp")
                        arr[0].Price = double.Parse(action[1]);
                    if (action[0] == "sq")
                        arr[0].Quantity = int.Parse(action[1]);
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Invalid input!");
                }
                if (action[0] == "gn")
                    Console.WriteLine($"Name: {arr[i].Name}");
                if (action[0] == "gp")
                    Console.WriteLine($"Pages: {arr[i].Pages}");
                if (action[0] == "gc")
                    Console.WriteLine($"Chapters: {arr[i].Chapters}");
                if (action[0] == "gp")
                    Console.WriteLine($"Price: {arr[i].Price}");
                if (action[0] == "gq")
                    Console.WriteLine($"Quantity: {arr[i].Quantity}");
                if (action[0] == "pa")
                    Console.WriteLine(arr[i].GetInfo());
                if (action[0] == "ex")
                    break;

            }
        }
    }
}
