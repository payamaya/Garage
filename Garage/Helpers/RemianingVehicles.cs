using Garage.Interface;
using Garage.Models;

namespace Garage.Helpers
{
    internal static class RemianingVehicles
    {

        public static void RemainedParkingSpots(Garage<IVehicle> garage)
        {
            int totalSpots = garage.TotalSpots;
            int numberOfVehicles = garage.CountVehicles();
            int remainingSpots = totalSpots - numberOfVehicles;
            Console.WriteLine($"Remaining spots in the parking: \u001b[31m{remainingSpots}\u001b[0m");
        }
    }
}