using Garage.Models;

namespace Garage.Helprs
{
    internal static class FindVehicles
    {

        public static void FindVehicleByRegistrationNumber(Garage<Vehicle> garage)
        {
            Console.Write("Enter registration number: ");
            string regNumber = Console.ReadLine()?.Trim().ToUpper();

            Vehicle foundVehicle = garage.FindVehicleByRegistrationNumber(regNumber);
            if (foundVehicle != null)
            {
                Console.WriteLine($"Vehicle found: {foundVehicle}");
            }
            else
            {
                Console.WriteLine("No vehicle with that registration number found in the parking lot.");
            }
        }
    }
}