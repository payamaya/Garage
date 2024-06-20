using Garage.Interface;
using Garage.Models;

namespace Garage.Helpers
{
    internal static class RemoveVehicles
    {

        public static void RemoveVehicleFromParkingLot(Garage<IVehicle> garage)
        {
            if (garage.CountVehicles() == 0)
            {
                Console.WriteLine("The parking lot is empty. \u001b[31mThere are no vehicles to remove.\u001b[0m");
                return;
            }

            string prompt = "Enter registration number (or type 'back' to return to the main menu): ";
            string errorMessage = "No vehicle with that registration number found in the parking lot.";

            InputHelper.GetInputWithRetry(prompt, errorMessage, (input) =>
            {
                if (garage.RemoveVehicle(input))
                {
                    Console.WriteLine($"Successfully removed the vehicle with the registration number: \u001b[33m{input}\u001b[0m");
                    return true;
                }
                return false;
            });

        }
    }
}