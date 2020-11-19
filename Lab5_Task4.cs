using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Practise
{
    public abstract class Printed_Edition : IComparable<Printed_Edition>
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
        // Implement the generic CompareTo method with the Printed_Edition
        // class as the Type parameter.
        public int CompareTo(Printed_Edition other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;

            // The  comparison depends on the comparison of
            // price
            return Price.CompareTo(other.Price);
        }

        // Define the is greater than operator.
        public static bool operator >(Printed_Edition operand1, Printed_Edition operand2)
        {
            return operand1.CompareTo(operand2) == 1;
        }

        // Define the is less than operator.
        public static bool operator <(Printed_Edition operand1, Printed_Edition operand2)
        {
            return operand1.CompareTo(operand2) == -1;
        }

        // Define the is greater than or equal to operator.
        public static bool operator >=(Printed_Edition operand1, Printed_Edition operand2)
        {
            return operand1.CompareTo(operand2) >= 0;
        }

        // Define the is less than or equal to operator.
        public static bool operator <=(Printed_Edition operand1, Printed_Edition operand2)
        {
            return operand1.CompareTo(operand2) <= 0;
        }

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
    public class Book : Printed_Edition, IComparable
    {
        //Overriden function to get information
        public override string GetInfo()
        {
            return base.GetInfo();
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Book otherBook = obj as Book;
            if (otherBook != null)
                return base.CompareTo(otherBook);
            else
                throw new ArgumentException("Object is not a Book");
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

    //custom collection class
    class CollectionType<T>
    {
        //stores elements
        private List<T> collection;
        //readonly number of elements
        public int Count
        {
            get { return collection.Count; }
        }
        //indexer
        public T this[int i]
        {
            get { return collection[i]; }
            set { collection[i] = value; }
        }
        //default constructor
        public CollectionType()
        {
            collection = new List<T>();
        }
        //constructor that sets capacity
        public CollectionType(int capacity)
        {
            collection = new List<T>(capacity);
        }
        //constructor with array as parameter
        public CollectionType(T[] array)
        {
            collection = new List<T>(array);
        }
        //method to add element to the collection
        public void Add(T element)
        {
            collection.Add(element);
        }
        //method to remove element to the collection
        public void Remove(T element)
        {
            collection.Remove(element);
        }
        //method to check if collection contains such element
        public bool Contains(T element)
        {
            return collection.Contains(element);
        }

        public int IndexOf(T element)
        {
            return collection.IndexOf(element);
        }
        //method to sort the collection
        public void Sort()
        {
            collection.Sort();
        }

    }

    class Program
    {
        void RandomData(int amount, ArrayList alis, List<Book> list, Printed_Edition[] arr, CollectionType<Book> collection)
        {
            Random r = new Random();
            for(int i = 0;i< amount; i++)
            {
                Book p = new Book();
                p.Price = r.Next(0, Int32.MaxValue) / 100;
                alis.Add(p);
                list.Add(new Book());
                arr[i] = new Book();
                collection.Add(new Book());
                list[i].Price = r.Next(0, Int32.MaxValue) / 100;
                arr[i].Price = r.Next(0, Int32.MaxValue) / 100;
                collection[i].Price = r.Next(0, Int32.MaxValue) / 100;
            }
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            int amount;
            Console.WriteLine("Input number of elements: ");
            for (; ; )
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out amount))
                    break;
            }
            Stopwatch sw = new Stopwatch();
            ArrayList alis = new ArrayList(amount);
            List<Book> list = new List<Book>(amount);
            Book[] arr = new Book[amount];
            CollectionType<Book> collection = new CollectionType<Book>(amount);
            p.RandomData(amount, alis, list, arr, collection);
            sw.Start();
            alis.Sort();
            sw.Stop();
            TimeSpan duration = sw.Elapsed;
            Console.WriteLine("ArrayList : {0}", duration.ToString());
            sw.Reset();
            sw.Start();
            list.Sort();
            sw.Stop();
            duration = sw.Elapsed;
            Console.WriteLine("List : {0}", duration.ToString());
            sw.Reset();
            sw.Start();
            Array.Sort(arr);
            sw.Stop();
            duration = sw.Elapsed;
            Console.WriteLine("Array : {0}", duration.ToString());
            sw.Reset();
            sw.Start();
            collection.Sort();
            sw.Stop();
            duration = sw.Elapsed;
            Console.WriteLine("CollectionType : {0}", duration.ToString());
        }
    }
}
