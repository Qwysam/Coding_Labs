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
        void ChargeBattery(int added_charged)
        {

        }

        void BatteryInfo(int charge_lvl)
        {

        }
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

        void ChargeBattery(int added_charged)
        {
            if (battery_lvl + added_charged > 100)
                battery_lvl = 100;
            else
                battery_lvl += (byte)added_charged;
        }

        int BatteryInfo(int charge_lvl)
        {
            return charge_lvl;
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
            }
            else
                Console.WriteLine("Tablet is turned off.");
        }

        void ChargeBattery(int added_charged)
        {
            if (battery_lvl + added_charged > 100)
                battery_lvl = 100;
            else
                battery_lvl += (byte)added_charged;
        }

        int BatteryInfo(int charge_lvl)
        {
            return charge_lvl;
        }
    }
        class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
