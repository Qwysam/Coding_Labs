using System;
using System.Collections.Generic;

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
    public class Magazine : Printed_Edition, IComparable
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

    class Program
    {

        static void Main(string[] args)
        {

        }
    }
}
