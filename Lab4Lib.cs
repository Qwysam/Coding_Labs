using System;
using System.Collections.Generic;

namespace Practise
{
    public class Fraction
    {
        //stores denominator value
        private int denominator;
        //stores numenator value
        private int numenator;
        //if sign == false then +
        private bool sign;
        //stores division result
        private double state;
        //denominator property
        public int Denominator
        {
            get { return denominator; }
            set
            {
                //throws an exeption instead of setting 0 as denominator
                if (value == 0)
                    throw new DivideByZeroException();
                else
                    denominator = value;
            }
        }
        //numenator property
        public int Numenator
        {
            get { return numenator; }
            set { numenator = value; }
        }

        //sign property
        public bool Sign
        {
            //is readonly
            get
            {
                //identifies the sign when called
                if (State >= 0)
                    sign = false;
                else
                    sign = true;
                return sign;

            }
        }

        //state property
        public double State
        {
            //readonly
            get
            {
                //calculates when called
                state = numenator / denominator;
                return state;
            }
        }

        //constructor without parameters
        public Fraction()
        {

        }
        //constructor that sets numerator
        public Fraction(int numenator)
        {
            this.numenator = numenator;
        }
        //constructor that sets numerator and denominator
        public Fraction(int numenator, int denominator)
        {
            this.numenator = numenator;
            this.denominator = denominator;
        }

        //explicit conversion to double
        public static explicit operator double(Fraction r)
        {
            return r.State;
        }

        //implicit conversion to string
        public static implicit operator string(Fraction r)
        {
            string res = "";
            if (r.sign)
                res += "-";
            res += $"{r.numenator}/{r.denominator}";
            return res;
        }

        //method to calculate least common multiple
        private int LCM(int num1, int num2)
        {
            int x = num1;
            int y = num2;
            while (num1 != num2)
            {
                if (num1 > num2)
                {
                    num1 = num1 - num2;
                }
                else
                {
                    num2 = num2 - num1;
                }
            }
            int lcm = (x * y) / num1;
            return lcm;
        }

        //method to compare current object with another object of the same class
        private int Compare(Fraction r)
        {
            //returns 0 if objects are equal
            //negative number if current < r
            //positive number if current > r
            if (State == r.State)
                return 0;
            if (State > r.State)
                return 1;
            else
                return -1;

        }

        // + operator for int
        public static Fraction operator +(Fraction r, int value)
        {
            int temp = value * r.Denominator;
            return new Fraction(r.Numenator + temp, r.Denominator);
        }
        // + operator for Fraction
        public static Fraction operator +(Fraction r, Fraction addendum)
        {
            int mult_r, mult_addendum;
            if (r.denominator == addendum.Denominator)
                return new Fraction(r.Numenator + addendum.Numenator, r.Denominator);
            else
            {
                int lcm = r.LCM(r.Denominator, addendum.Denominator);
                mult_r = lcm / r.Denominator;
                mult_addendum = lcm / addendum.Denominator;
                return new Fraction(r.Numenator * mult_r + addendum.Numenator * mult_addendum, r.Denominator * mult_r);
            }

        }

        // - operator for Fraction
        public static Fraction operator -(Fraction r, Fraction subtrahend)
        {
            int mult_r, mult_subtrahend;
            if (r.denominator == subtrahend.Denominator)
                return new Fraction(r.Numenator - subtrahend.Numenator, r.Denominator);
            else
            {
                int lcm = r.LCM(r.Denominator, subtrahend.Denominator);
                mult_r = lcm / r.Denominator;
                mult_subtrahend = lcm / subtrahend.Denominator;
                return new Fraction(r.Numenator * mult_r - subtrahend.Numenator * mult_subtrahend, r.Denominator * mult_r);
            }
        }

        // - operatorr for int
        public static Fraction operator -(Fraction r, int value)
        {
            int temp = value * r.Denominator;
            return new Fraction(r.Numenator - temp, r.Denominator);
        }

        // * operator for Fraction
        public static Fraction operator *(Fraction r, Fraction multiplier)
        {
            return new Fraction(r.Numenator * multiplier.Numenator, r.Denominator * multiplier.Denominator);
        }

        // / operator for Fraction
        public static Fraction operator /(Fraction r, Fraction divisor)
        {
            return new Fraction(r.Numenator * divisor.Denominator, r.Denominator * divisor.Numenator);
        }

        // < operator for Fraction
        public static bool operator <(Fraction first, Fraction second)
        {
            return first.Compare(second) < 0;
        }

        // > operator for Fraction
        public static bool operator >(Fraction first, Fraction second)
        {
            return first.Compare(second) > 0;
        }

        // == operator for Fraction
        public static bool operator ==(Fraction first, Fraction second)
        {
            return first.Compare(second) == 0;
        }

        // != operator for Fraction
        public static bool operator !=(Fraction first, Fraction second)
        {
            return first.Compare(second) != 0;
        }
        // <= operator for Fraction
        public static bool operator <=(Fraction first, Fraction second)
        {
            return first.Compare(second) <= 0;
        }
        // >= operator for Fraction
        public static bool operator >=(Fraction first, Fraction second)
        {
            return first.Compare(second) >= 0;
        }
    }
    class Program
    {
        static void CreateFraction(List<Fraction> list)
        {
            list.Add(new Fraction());
            Console.WriteLine("Creating Fraction object:");
            for (; ; )
            {
                Console.WriteLine("Input numenator: ");
                string temp = Console.ReadLine();
                int value;
                if (int.TryParse(temp, out value))
                {
                    list[list.Count-1].Numenator = value;
                    break;
                }
            }
            for (; ; )
            {
                Console.WriteLine("Input denominator: ");
                string temp = Console.ReadLine();
                int value;
                if (int.TryParse(temp, out value))
                {
                    try
                    {
                        list[list.Count-1].Denominator = value;
                    }
                    catch (DivideByZeroException)
                    {
                        Console.WriteLine("Denominator cannot be equal to 0");
                        continue;
                    }
                    break;
                }
            }
        }

        static void Main(string[] args)
        {
            List<Fraction> list = new List<Fraction>();
            if (list.Count == 0)
            {
                CreateFraction(list);
            }
                int index_first = 0,index_second = 0;
                bool exit = false;
                for (; ; )
                {
                    for (; ; )
                    {
                        Console.WriteLine($"Input 'c' to create new object or number from 1 to {list.Count} to choose an object");
                        Console.WriteLine("Input 'e' to exit");
                        string temp = Console.ReadLine();
                        if (temp == "c")
                            CreateFraction(list);
                        if(temp == "e")
                        {
                            exit = true;
                            break;
                        }
                        else
                        {
                            int value;
                            if (int.TryParse(temp, out value))
                            {
                                index_first = value;
                                index_first--;
                                break;
                            }
                            else
                                Console.WriteLine("Invalid input!");
                        }
                    }
                    if (exit)
                        break;
                    for (; ; )
                    {
                        Console.WriteLine("Input 's' to output object state\t Input 'd' to output the result of the division");
                        Console.WriteLine("Input 'e' to exit\t\t\t Input 'b' to return to previous menu");
                        Console.WriteLine($"Input index of another object from 1 to {list.Count} to perform operations that require two objects");
                        string temp = Console.ReadLine();
                        if (temp == "b")
                            break;
                        if (temp == "e")
                        {
                            exit = true;
                            break;
                        }
                        if (temp == "s")
                        {
                            Console.WriteLine($"Object: {(string)list[index_first]}");
                            continue;
                        }
                        if (temp == "d")
                        {
                            Console.WriteLine($"Object: {(double)list[index_first]}");
                            continue;
                        }

                        int value;
                        if (int.TryParse(temp, out value))
                        {
                            index_second = value;
                            index_second--;
                        if (index_second == index_first)
                        {
                            Console.WriteLine("Choose another object!");
                            continue;
                        }
                            for (; ; )
                            {
                                Console.WriteLine("Actions: ");
                                Console.WriteLine(" '*' to multiply\t'/'to divide");
                                Console.WriteLine(" '+' to sum\t'-' to subtract");
                                Console.WriteLine("Bool operators:\n !=\t==\t<\n  >\t>=\t<=");
                                Console.WriteLine("Input: ");
                                string _operator = Console.ReadLine();
                                if (_operator == "*")
                                {
                                    list[index_first] *= list[index_second];
                                    break;
                                }
                                if (_operator == "/")
                                {
                                    list[index_first] /= list[index_second];
                                    break;
                                }
                                if (_operator == "+")
                                {
                                    list[index_first] += list[index_second];
                                    break;
                                }
                                if (_operator == "-")
                                {
                                    list[index_first] -= list[index_second];
                                    break;
                                }
                                if (_operator == "!=")
                                {
                                    Console.WriteLine(list[index_first] != list[index_second]);
                                    break;
                                }
                                if (_operator == "=")
                                {
                                    Console.WriteLine(list[index_first] == list[index_second]);
                                    break;
                                }
                                if (_operator == "<")
                                {
                                    Console.WriteLine(list[index_first] < list[index_second]);
                                    break;
                                }
                                if (_operator == ">")
                                {
                                    Console.WriteLine(list[index_first] > list[index_second]);
                                    break;
                                }
                                if (_operator == ">=")
                                {
                                    Console.WriteLine(list[index_first] >= list[index_second]);
                                    break;
                                }
                                if (_operator == "<=")
                                {
                                    Console.WriteLine(list[index_first] <= list[index_second]);
                                    break;
                                }
                                Console.WriteLine("Invalid input!");
                            }
                        }
                        else
                            Console.WriteLine("Invalid input!");

                    }
                    if (exit)
                        break;
                }
            
        }
    }
}
