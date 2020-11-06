using System;
using System.Collections.Generic;

namespace Practise
{
    interface IDisplay
    {
        void TurnOnDisplay();

        void TurnOffDisplay();
    }

    interface IBattery
    {
        //input added charge in percentages
        void ChargeBattery(int added_charged);

        int BatteryInfo();
    }

    // Parent class
    public abstract class PC
    {
        public bool PC_On { get; private set; }
        public string Name { get; }
        public PC(string name)
        {
            Name = name;
            PC_On = false;
        }

        public void TurnOn()
        {
            PC_On = true;
        }

        public void TurnOff()
        {
            PC_On = false;
        }

        public virtual void Use()
        {
            if (PC_On)
                Console.WriteLine();
        }
    }

    public class Desktop : PC, IDisplay
    {
        private bool display_on;
        public Desktop(string name) : base(name)
        {
            display_on = false;
        }

        public override void Use()
        {
            if (PC_On)
            {
                base.Use();
                if (display_on)
                    Console.WriteLine("Display is turned on.");
                else
                    Console.WriteLine("Display is turned off.");
            }
            else
                Console.WriteLine("Desktop PC is turned off.");
        }

        public void TurnOnDisplay()
        {
            display_on = true;
        }

        public void TurnOffDisplay()
        {
            display_on = false;
        }

    }

    public class Laptop : PC, IDisplay, IBattery
    {
        private bool display_on;
        byte battery_lvl;
        public Laptop(string name) : base(name)
        {
            display_on = false;
            battery_lvl = 100;
        }

        public override void Use()
        {
            if (PC_On)
            {
                base.Use();
                if (display_on && battery_lvl > 0)
                {
                    Console.WriteLine("Display is turned on.");
                    Console.WriteLine($"Battery: {battery_lvl}%.");
                }

                if (!display_on && battery_lvl > 0)
                {
                    Console.WriteLine("Display is turned off.");
                    Console.WriteLine($"Battery: {battery_lvl}%.");
                }
                if (battery_lvl == 0)
                    Console.WriteLine("Battery needs to be charged.");
                if (battery_lvl > 5)
                    battery_lvl -= 5;
                else
                    battery_lvl = 0;
            }
            else
                Console.WriteLine("Laptop is turned off.");
        }

        public void TurnOnDisplay()
        {
            display_on = true;
        }

        public void TurnOffDisplay()
        {
            display_on = false;
        }

        public void ChargeBattery(int added_charged)
        {
            if (battery_lvl + added_charged > 100)
                battery_lvl = 100;
            else
                battery_lvl += (byte)added_charged;
        }

        public int BatteryInfo()
        {
            return battery_lvl;
        }
    }

    public class Tablet : PC,  IBattery
    {
        byte battery_lvl;
        public Tablet(string name) : base(name)
        {
            battery_lvl = 100;
        }

        public override void Use()
        {
            if (PC_On)
            {
                base.Use();
                if (battery_lvl > 0)
                {
                    Console.WriteLine($"Battery: {battery_lvl}%.");
                }
                else
                    Console.WriteLine("Battery needs to be charged.");
                if (battery_lvl > 5)
                    battery_lvl -= 5;
                else
                    battery_lvl = 0;
            }
            else
                Console.WriteLine("Tablet is turned off.");
        }

        public void ChargeBattery(int added_charged)
        {
            if (battery_lvl + added_charged > 100)
                battery_lvl = 100;
            else
                battery_lvl += (byte)added_charged;
        }

        public int BatteryInfo()
        {
            return battery_lvl;
        }
    }
    class Program
    {
        static void CreateDevice(PC[]arr,int index)
        {
            Console.WriteLine("Input device name: ");
            string temp = Console.ReadLine();
            if (index == 0)
                arr[index] = new Desktop(temp);
            if (index == 1)
                arr[index] = new Laptop(temp);
            if (index == 2)
                arr[index] = new Tablet(temp);
        }

        static void Main(string[] args)
        {
            PC[] arr = new PC[3];
            int index = -1;
            bool exit = false;
            for(; ; )
            {
                for(; ; )
                {
                    Console.WriteLine("Choose device:\n'1' - Desktop PC     '2'- Laptop     '3' - Tablet");
                    Console.WriteLine(" Or input 'e' to exit");
                    Console.WriteLine("Input: ");
                    string temp = Console.ReadLine();
                    if (temp == "1")
                    {
                        index = 0;
                        break;
                    }
                    if (temp == "2")
                    {
                        index = 1;
                        break;
                    }
                    if (temp == "3")
                    {
                        index = 2;
                        break;
                    }
                    if(temp == "e")
                    {
                        exit = true;
                        break;
                    }
                }
                if (exit)
                    break;
                for(; ; )
                {
                    string temp;
                    if (arr[index] == null)
                    {
                        CreateDevice(arr, index);
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Actions: ");
                        Console.WriteLine("'1' - Turn On\t'2' - Turn Off\t'3' - Use");
                        if (index == 0)
                            Console.WriteLine("'4' - Display On'5' - Display Off");
                        if (index == 1)
                        {
                            Console.WriteLine("'4' - Display On\t'5' - Display Off");
                            Console.WriteLine("'6' - Charge Battery\t'7' - Battery Info");
                        }
                        if (index == 2)
                            Console.WriteLine("'4' - Charge Battery\t'5' - Battery Info");
                        Console.WriteLine("Input 'b' to access previous menu");
                        Console.WriteLine("Input: ");
                        temp = Console.ReadLine();
                    }
                    if (temp == "b")
                        break;
                    else
                    {
                        if (temp == "1")
                        {
                            arr[index].TurnOn();
                            continue;
                        }
                        if (temp == "2")
                        {
                            arr[index].TurnOff();
                            continue;
                        }
                        if (temp == "3")
                        {
                            arr[index].Use();
                            continue;
                        }
                        if (temp == "4" && index == 0)
                        {
                            ((Desktop)arr[index]).TurnOnDisplay();
                            continue;
                        }
                        if (temp == "4" && index == 1)
                        {
                            ((Laptop)arr[index]).TurnOnDisplay();
                            continue;
                        }
                        if (temp == "4" && index == 2)
                        {
                            Console.WriteLine("Input added charge in pecrentages: ");
                            string percent = Console.ReadLine();
                            try
                            {
                                ((Tablet)arr[index]).ChargeBattery(int.Parse(percent));
                            }
                            catch(Exception e){}
                            continue;

                        }
                        if (temp == "5" && index == 0)
                        {
                            ((Desktop)arr[index]).TurnOffDisplay();
                            continue;
                        }
                        if (temp == "5" && index == 1)
                        {
                            ((Laptop)arr[index]).TurnOffDisplay();
                            continue;
                        }
                        if (temp == "5" && index == 2)
                        {
                            Console.WriteLine($"Charge:{((Tablet)arr[index]).BatteryInfo()}%");
                            continue;
                        }
                        if (temp == "6" && index == 1)
                        {
                            Console.WriteLine("Input added charge in pecrentages: ");
                            string percent = Console.ReadLine();
                            try
                            {
                                ((Laptop)arr[index]).ChargeBattery(int.Parse(percent));
                            }
                            catch (Exception e) { }
                            continue;
                        }
                        if (temp == "7" && index == 1)
                        {
                            Console.WriteLine($"Charge:{((Laptop)arr[index]).BatteryInfo()}%");
                            continue;
                        }
                    }
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
