using Garage.Models;

namespace Garage.Helpers
{
    public static class ListVehiclesTypeAndCount
    {
        public static void ListVehicleTypesAndCounts(Garage<Vehicle> garage)
        {
            var vehicleCounts = new Dictionary<VehicleType, int>();

            foreach (var vehicle in garage)
            {
                if (vehicleCounts.ContainsKey(vehicle.Type))
                {
                    vehicleCounts[vehicle.Type]++;
                }
                else
                {
                    vehicleCounts[vehicle.Type] = 1;
                }
            }

            Console.WriteLine("Vehicle Types and Counts:");
            foreach (var kvp in vehicleCounts)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

    }
}
