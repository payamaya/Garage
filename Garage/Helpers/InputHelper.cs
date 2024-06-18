using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Garage.Helpers
{
    internal class InputHelper
    {
        public static string GetFuelType()
        {
          /*  string color = string.Empty;*/
            while (true)
            {
                Console.Write("Enter fuel type (Bensin/Diesel/Electric): ");
                string fuelType = Console.ReadLine()?.Trim().ToUpper()!;
                if (fuelType == "BENSIN" || fuelType == "DIESEL" || fuelType == "ELECTRIC")
                {
                    return fuelType;
                }
                Console.WriteLine("Invalid fuel type. Please enter Bensin, Diesel, or Electric.");
            }
        }
    public static string GetColor()
    {
        while (true)
        {
            Console.Write("Enter color: ");
            string color = Console.ReadLine()?.Trim().ToUpper()!;
            if (!string.IsNullOrEmpty(color) && color.Length >= 3 && Regex.IsMatch(color, @"^[A-Z]+$"))
            {
                return color;
            }
            Console.WriteLine("Invalid color. Please enter a color with at least three alphabetic characters.");
        }
    }
    }
}
