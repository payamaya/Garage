using Garage.Models;

namespace Garage.Helpers
{
    internal static class VehiclesByColors
    {

        public static void ListVehiclesByColor(Garage<Vehicle> garage)
        {
            var colorMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "Black", "\u001b[30m" },
                { "Red", "\u001b[31m" },
                { "Green", "\u001b[32m" },
                { "Yellow", "\u001b[33m" },
                { "Blue", "\u001b[34m" },
                { "Magenta", "\u001b[35m" },
                { "Cyan", "\u001b[36m" },
                { "White", "\u001b[37m" }
            };

            while (true)
            {
                Console.Write("Enter color to search for (or type 'back' to return to the main menu): ");
                string color = Console.ReadLine()?.Trim()!;

                if (color.Equals("back", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                if (!colorMap.ContainsKey(color))
                {
                    Console.WriteLine("Invalid color. Please enter one of the following colors:");
                    foreach (var colorKey in colorMap.Keys)
                    {
                        Console.WriteLine($"{colorKey}: {colorMap[colorKey]}{colorKey}\u001b[0m");
                    }
                    continue;
                }

                List<Vehicle> vehicles = garage.GetVehiclesByColor(color);

                if (vehicles.Count > 0)
                {
                    Console.WriteLine($"Vehicles with color '{colorMap[color]}{color.ToUpper()}\u001b[0m':");

                    foreach (var vehicle in vehicles)
                    {
                        Console.WriteLine(vehicle.ToString());
                    }
                }
                else
                {
                    Console.WriteLine($"No vehicles found with color '{color}'. ");
                }
            }
        }
    }
}