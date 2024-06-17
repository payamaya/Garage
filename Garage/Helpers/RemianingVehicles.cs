using Garage.Models;

namespace Garage.Helpers
{
    internal static class RemianingVehicles
    {

        public static void RemainedParkingSpots(Garage<Vehicle> garage)
        {
            int totalSpots = garage.TotalSpots;
            int numberOfVehicles = garage.CountVehicles();
            int remainingSpots = totalSpots - numberOfVehicles;
            Console.WriteLine($"Remaining spots in the parking: {remainingSpots}");
        }
    }
}