using Garage.Models;
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

        public static string GetRegistrationNumber(Garage<Vehicle> garage)
        {
            while (true)
            {
                Console.Write("Enter registration number: ");
                string regNumber = Console.ReadLine()?.Trim().ToUpper()!;
                if (IsValidRegistrationNumber(regNumber) && !garage.IsRegistrationNumberExist(regNumber))
                {
                    return regNumber;
                }
                Console.WriteLine("\u001b[34mInvalid or duplicate registration number. Please try again.\u001b[0m\n");
            }
        }
        private static bool IsValidRegistrationNumber(string regNumber)
        {
            return Regex.IsMatch(regNumber, @"^[a-zA-Z0-9]+$") &&
                   Regex.IsMatch(regNumber, @"([a-zA-Z].*){3,}") &&
                   Regex.IsMatch(regNumber, @"\d");
        }
        public static VehicleType GetVehicleType()
        {
            while (true)
            {
                Console.Write("Enter vehicle type (Car/Bus/Boat/Airplane/Motorcycle): ");

                if (Enum.TryParse(Console.ReadLine()?.Trim(), true, out VehicleType vehicleType) && Enum.IsDefined(typeof(VehicleType), vehicleType))
                {
                    return vehicleType;
                }
                Console.WriteLine("\u001b[34mInvalid vehicle type. Please enter either 'Car', 'Bus', 'Boat', 'Airplane', or 'Motorcycle'.\u001b[0m\n");
            }
        }
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
                Console.WriteLine("\u001b[34mInvalid fuel type. Please enter Bensin, Diesel, or Electric.\u001b[0m\n");
            }
        }

        public static int GetNumberOfWheels()
        {
            while (true)
            {
                Console.Write("Enter number of wheels (1-12): ");
                if (int.TryParse(Console.ReadLine()?.Trim(), out int numberOfWheels) && numberOfWheels >= 1 && numberOfWheels <= 12)
                {
                    return numberOfWheels;
                }
                Console.WriteLine("\u001b[34mInvalid input. Please enter a valid number of wheels (between 1 and 12).\u001b[0m\n");

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
        public static int GetNumberOfSeats()
        {
            while (true)
            {
                Console.Write("Enter number of seats: ");
                if (int.TryParse(Console.ReadLine(), out int numberOfSeats))
                {
                    return numberOfSeats;
                }
                Console.WriteLine("Invalid input. Please enter a valid number of seats.\n");
            }
        }
        public static int GetBoatLength()
        {
            while (true)
            {
                Console.Write("Enter boat length: ");
                if (int.TryParse(Console.ReadLine(), out int boatLength))
                {
                    return boatLength;
                }
                Console.WriteLine("Invalid boat length. Please enter a valid length.");
            }
        }
        public static int GetNumberOfEngines()
        {
            while (true)
            {
                Console.Write("Enter number of engines: ");
                if (int.TryParse(Console.ReadLine(), out int numOfEngines))
                {
                    return numOfEngines;
                }
                Console.WriteLine("Invalid number of engines. Please enter a valid number.");
            }
        }
        public static int GetCylinderVolume()
        {
            while (true)
            {
                Console.Write("Enter cylinder volume: ");
                if (int.TryParse(Console.ReadLine(), out int cylinderVolume))
                {
                    return cylinderVolume;
                }
                Console.WriteLine("Invalid cylinder volume. Please enter a valid volume.");
            }
        }
        public static int GetRow()
        {
            while (true)
            {
                Console.Write("Enter row number to park the vehicle: ");
                if (int.TryParse(Console.ReadLine(), out int row))
                {
                    return row;
                }
                Console.WriteLine("Invalid row number. Please enter a valid number.");
            }
        }
        public static int GetColumn()
        {
            while (true)
            {
                Console.Write("Enter column number to park the vehicle: ");
                if (int.TryParse(Console.ReadLine(), out int col))
                {
                    return col;
                }
                Console.WriteLine("Invalid column number. Please enter a valid number.");
            }
        }
    }
}
