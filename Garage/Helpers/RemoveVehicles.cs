using Garage.Models;

namespace Garage.Helpers
{
    internal static class RemoveVehicles
    {

        public static void RemoveVehicleFromParkingLot(Garage<Vehicle> garage)
        {
            Console.Write("Enter registration number: ");
            string regNumber = Console.ReadLine()?.Trim().ToUpper()!;

            if (garage.RemoveVehicle(regNumber))
            {
                Console.WriteLine($"Successfully removed the vehicle with the registration number: {regNumber}");
            }
            else
            {
                Console.WriteLine("No vehicle with that registration number found in the parking lot");
            }
        }
    }
}