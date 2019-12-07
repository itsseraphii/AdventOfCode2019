using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 1 : The Tyranny of the Rocket Equation. Part 1");

            string pathToFile = @"C:\Users\Eclipse\source\repos\AdventOfCode\Data\day1input.txt";
            string strModuleMass;
            decimal totalFuel = 0;
            System.IO.StreamReader reader = new System.IO.StreamReader(pathToFile);
            int counter = 1;
            while((strModuleMass = reader.ReadLine()) != null)
            {
                decimal intMass = decimal.Parse(strModuleMass);
                decimal dbFuelReq = Math.Floor(intMass / 3) - 2;
                totalFuel += dbFuelReq;
                Console.WriteLine("Module #{0} : Mass {1} : Fuel {2} : Total Fuel {3}", counter, intMass, dbFuelReq, totalFuel);
                counter++;
            }

            Console.WriteLine("Total Fuel : " + totalFuel);
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Day 1 : The Tyranny of the Rocket Equation. Part 2");
            reader = new System.IO.StreamReader(pathToFile);
            counter = 1;
            totalFuel = 0;
            while ((strModuleMass = reader.ReadLine()) != null)
            {
                decimal intMass = decimal.Parse(strModuleMass);
                Console.Write("Module #{0} : \n", counter);
                decimal fuelModule = CalculateFuel(intMass);
                totalFuel += fuelModule;
                Console.Write(" = " + totalFuel + "\n");

                counter++;
            }

            Console.WriteLine("Total Fuel : " + totalFuel);
            Console.ReadKey();
        }

        static decimal CalculateFuel(decimal intMass)
        {
            decimal dcFuelNeeded;
            if (intMass <= 0)
                return 0;
            else
            {
                dcFuelNeeded = Math.Floor(intMass / 3) - 2;
                if (dcFuelNeeded >= 0)
                {
                    dcFuelNeeded += CalculateFuel(dcFuelNeeded);
                    Console.WriteLine(" + " + dcFuelNeeded);
                    return dcFuelNeeded;
                }
                else
                    return 0;
            }

        }


    }
}
