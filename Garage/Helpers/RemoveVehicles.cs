using Garage.Models;

namespace Garage.Helpers
{
    internal static class RemoveVehicles
    {

        public static void RemoveVehicleFromParkingLot(Garage<Vehicle> garage)
        {
            if (garage.CountVehicles() == 0)
            {
                Console.WriteLine("The parking lot is empty. \u001b[31mThere are no vehicles to remove.\u001b[0m");
                return;
            }

            while (true)
            {
                Console.Write("Enter registration number: ");
                string regNumber = Console.ReadLine()?.Trim().ToUpper()!;

                if (garage.RemoveVehicle(regNumber))
                {
                    Console.WriteLine($"Successfully removed the vehicle with the registration number: {regNumber}");
                    break;
                }
                else
                {
                    Console.WriteLine("No vehicle with that registration number found in the parking lot");
                }
            }

        }
    }
}