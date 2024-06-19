using System;
using System.Collections.Generic;
using Garage.Models;

namespace Garage.Helpers
{
    public static class FindByWheelsNumber
    {
        public static void FindVehiclesByWheelsNumber(Garage<Vehicle> garage)
        {
            while (true)
            {
                Console.Write("Enter the number of wheels to search for: ");
                if (int.TryParse(Console.ReadLine(), out int wheelNumber))
                {
                    List<Vehicle> vehicles = garage.GetVehiclesByWheelsNumber(wheelNumber);

                    if (vehicles.Count > 0)
                    {
                        Console.WriteLine($"Vehicles with {wheelNumber} wheels:");
                        foreach (var vehicle in vehicles)
                        {
                            Console.WriteLine($"Registration Number: {vehicle.RegistrationNumber}, Type: {vehicle.GetType().Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No vehicles found with {wheelNumber} wheels.");
                    }
                    break;  // Exit the loop after successful search
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
    }
}
