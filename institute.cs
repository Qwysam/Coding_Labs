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
        private string name;
        private int amount_pupils; 
        private int year_studying; 
        private int number;     
        private int amount_stuff;
        
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

        public virtual string Getinfo()
        {
            return $"{name} of number {number}. There are  {amount_pupils}  pupils, and {amount_stuff} stuff. You need {Year_Studying} year of studing";
        }

        public institude()
        {

        }

        public institude(string Name)
        {

            this.Name = Name;
        }
        public institude(int Year_Studying, int Number)
        {
            this.Year_Studying = Year_Studying;
            this.Number = Number;
        }

        public institude (int Amount_Pupils, int Amount_Stuff, bool kostil)
        {
            this.Amount_Stuff = Amount_Stuff;
            this.Amount_Pupils = Amount_Pupils;
        }

    }

    public class School : institude
    {
        public override string Getinfo()
        {
            return base.Getinfo();
        }

        public School() : base()
        {

        }

        public School(string Name) : base(Name)
        {

        }

        public School(int Amount_pupils, int Year_Studing) : base(Amount_pupils, Year_Studing)
        {


        }

        public School (int Number, int Amount_stuff, bool kostil) : base(Number, Amount_stuff)
        {

        }
    }

    public class University : institude
    {
        public override string Getinfo()
        {
            return base.Getinfo();
        }

        public University() : base()
        {

        }

        public University(string Name) : base(Name)
        {


        }

        public University(int Amount_pupils, int Year_Studing) : base(Amount_pupils, Year_Studing)
        {

        }

        public University(int Number, int Amount_stuff, bool kostil) : base(Number, Amount_stuff)
        {
            
        }
    }
}
