using Garage.Models;

namespace Garage.Helpers
{
    internal static class TotalVehicles
    {
        public static void TotalParkedVehicles(Garage<Vehicle> garage)
        {
            int numberOfVehicles = garage.CountVehicles();
            Console.WriteLine($"Number of vehicles parked: {numberOfVehicles}");
        }
    }
}