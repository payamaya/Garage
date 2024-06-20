using Garage.Helpers;
using Garage.Interface;
using Garage.Models;

namespace Garage.Helprs
{
    internal static class FindByReg
    {
        public static void FindVehicleByRegistrationNumber(Garage<IVehicle> garage)
        {
            if (garage.CountVehicles() == 0)
            {
                Console.WriteLine("\u001b[31mThe parking lot is empty.\u001b[0m");
                return;
            }

            string prompt = "Enter registration number (or type 'bakc' to return to main menu";
            string errorMessage = "No Vehicle with tah registration number found in the parkinh lot";

            InputHelper.GetInputWithRetry(prompt, errorMessage, (input) =>
            {
                IVehicle? foundVehicle = garage.FindVehicleByRegistrationNumber(input);
                if (foundVehicle != null)
                {
                    Console.WriteLine($"\u001b[34mVehicle found:\u001b[0m {foundVehicle}");
                    return true;
                }
                return false;
            });
          
        }
    }
}
