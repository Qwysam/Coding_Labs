using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03lib
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
        private int amount_stuff;
        //  pages - amount_pupils
        //  chaptes - Year_Studying
        //  price - number
        //  quantity - amount_stuff

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
        public int Amount_Stuff
        {
            get { return amount_stuff; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException();
                else
                    amount_stuff = value;
            }
        }

        //returns string with information about the objects
        public virtual string Getinfo()
        {
            return $"{name} of number {number}. There are  {amount_pupils}  pupils, and {amount_stuff} stuff. You need {Year_Studying} year of studing";
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
        public institude (int Amount_Pupils, int Amount_Stuff, bool kostil)
        {
            this.Amount_Stuff = Amount_Stuff;
            this.Amount_Pupils = Amount_Pupils;
        }

    }

    //Child class
    public class School : institude
    {
        //Overriden function to get information
        public override string Getinfo()
        {
            return base.Getinfo();
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
        public School (int Number, int Amount_stuff, bool kostil) : base(Number, Amount_stuff)
        {

        }
    }

    //Child class
    public class University : institude
    {
        //Overriden function to get information
        public override string Getinfo()
        {
            return base.Getinfo();
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
        public University(int Number, int Amount_stuff, bool kostil) : base(Number, Amount_stuff)
        {
            
        }
    }
}
