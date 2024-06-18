using Garage.Models;

namespace Garage.Helprs
{
    internal static class FindVehicles
    {

        public static void FindVehicleByRegistrationNumber(Garage<Vehicle> garage)
        {
            Console.Write("Enter registration number: ");
            string regNumber = Console.ReadLine()?.Trim().ToUpper()!;

            Vehicle foundVehicle = garage.FindVehicleByRegistrationNumber(regNumber)!;
            if (foundVehicle != null)
            {
                Console.WriteLine($"\u001b[34mVehicle found:\u001b[0m {foundVehicle}");
            }
            else
            {
                Console.WriteLine("\u001b[32mNo vehicle with that registration number found in the parking lot.\u001b[0m");
            }
        }
    }
}