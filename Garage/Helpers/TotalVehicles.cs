using Garage.Interface;
using Garage.Models;

namespace Garage.Helpers
{
    internal static class TotalVehicles
    {
        public static void TotalParkedVehicles(Garage<IVehicle> garage)
        {
            int numberOfVehicles = garage.CountVehicles();
            Console.WriteLine($"Number of vehicles parked: \u001b[31m{numberOfVehicles}\u001b[0m");
        }
    }
}