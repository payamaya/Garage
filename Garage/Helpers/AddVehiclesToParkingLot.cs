using Garage.Models;
using System.Text.RegularExpressions;

namespace Garage.Helpers
{
    internal static class AddVehiclesToParkingLot
    {

        public static void AddVehicleToParkingLot(Garage<Vehicle> garage)
        {
            //check if user enter a valid regex regnumber
            string regNumber = string.Empty;
            bool isValidRegNumber = false;

            do
            {
                Console.Write("Enter registration number: ");
                regNumber = Console.ReadLine()?.Trim().ToUpper()!;

                // Validate registration number format
                if (!Regex.IsMatch(regNumber, @"^[a-zA-Z0-9]+$") ||
                    !Regex.IsMatch(regNumber, @"([a-zA-Z].*){3,}") ||  // Contains at least one letter
                    !Regex.IsMatch(regNumber, @"\d"))         // Contains at least one number
                {
                    Console.WriteLine("Invalid registration number. \n\u001b[31mPlease enter a registration number with with at least three alphabetic characters and numbers.\u001b[0m");

                }

                // Check if registration number already exists
                else if (garage.IsRegistrationNumberExist(regNumber))
                {
                    Console.WriteLine("\u001b[31mA vehicle with this registration number already exists in the parking lot\u001b[0m\n");

                }
                else
                {
                    isValidRegNumber = true;
                }

            } while (!isValidRegNumber);

            //Check if user enter a string color
       /*     string color = string.Empty;*/
           /* bool hasColor = false;*/
          string color =  InputHelper.GetColor();
           /* do
            {
                Console.Write("Enter color: ");
                color = Console.ReadLine()?.Trim().ToUpper()!;

                if (string.IsNullOrEmpty(color) || color.Length < 3 || !Regex.IsMatch(color, @"^[A-Z]+$"))
                {
                    Console.WriteLine("\u001b[34mInvalid input. Please enter a color with at least three alphabetic characters.\u001b[0m\n");
                }
                else
                {
                    hasColor = true;
                }

            } while (!hasColor);*/

            int numberOfWheels = 2;
            bool isValidNumberOfWheels = false;

            do
            {
                Console.Write("Enter number of wheels (1-12): ");
                string input = Console.ReadLine()?.Trim()!;

                if (!int.TryParse(input, out numberOfWheels) || numberOfWheels > 12)
                {
                    Console.WriteLine("\u001b[34mInvalid input. Please enter a valid number of wheels (between 1 and 12).\u001b[0m\n");
                }
                else
                {
                    isValidNumberOfWheels = true;
                }

            } while (!isValidNumberOfWheels);
            // Validate vehicle type using enum
            VehicleType vehicleType;
            bool isValidVehicleType = false;

            do
            {
                Console.Write("Enter vehicle type (Car/Bus/Boat/Airplane/Motorcycle): ");
                string vehicleTypeInput = Console.ReadLine()?.Trim().ToUpper()!;

                if (Enum.TryParse(vehicleTypeInput, true, out vehicleType))
                {
                    isValidVehicleType = true;
                }
                else
                {
                    Console.WriteLine("Invalid vehicle type. Please enter either 'Car', 'Bus', 'Boat', 'Airplane', or 'Motorcycle'.\n");
                }
            } while (!isValidVehicleType);

            Vehicle newVehicle;
            switch (vehicleType)
            {
                case VehicleType.Car:

                    string fuelType = InputHelper.GetFuelType();
                    newVehicle = new Car(numberOfWheels, color, regNumber, fuelType);
                    break;
                case VehicleType.Bus:
                    Console.Write("Enter number of seats: ");
                    if (!int.TryParse(Console.ReadLine(), out int numberOfSeats))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number of seats.\n");
                        return;
                    }
                    newVehicle = new Bus(numberOfWheels, color, regNumber, numberOfSeats);
                    break;
                case VehicleType.Boat:
                    Console.Write("Enter boat length: ");
                    if (!int.TryParse(Console.ReadLine(), out int boatLength))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid boat length.\n");
                        return;
                    }
                    newVehicle = new Boat(numberOfWheels, color, regNumber, boatLength);
                    break;
                case VehicleType.Airplane:
                    Console.Write("Enter number of engines: ");
                    if (!int.TryParse(Console.ReadLine(), out int numOfEngines))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number of engines.\n");
                        return;
                    }
                    newVehicle = new Airplane(numberOfWheels, color, regNumber, numOfEngines);
                    break;
                case VehicleType.Motorcycle:
                    Console.Write("Enter cylinder volume: ");
                    if (!int.TryParse(Console.ReadLine(), out int cylinderVolume))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid cylinder volume.\n");
                        return;
                    }
                    newVehicle = new Motorcycle(numberOfWheels, color, regNumber, cylinderVolume);
                    break;
                default:
                    Console.WriteLine("Invalid vehicle type. Please enter either 'Car', 'Bus', 'Boat', 'Airplane', or 'Motorcycle'.\n");
                    return;
            }

            // Prompt user for row number until a valid number is entered
            int row;
            while (true)
            {
                Console.Write("Enter row number to park the vehicle: ");
                if (int.TryParse(Console.ReadLine(), out row))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a valid row number.");
            }

            // Prompt user for column number until a valid number is entered
            int col;
            while (true)
            {
                Console.Write("Enter column number to park the vehicle: ");
                if (int.TryParse(Console.ReadLine(), out col))
                {
                    break;
                }
                Console.WriteLine("Invalid input. Please enter a valid column number.");
            }

            // Attempt to add the vehicle to the garage at the specified position
            if (garage.AddVehicle(newVehicle, row, col))
            {
                Console.WriteLine($"Successfully parked the vehicle: {newVehicle}");
            }
            else
            {
                Console.WriteLine("Parking spot is already occupied or invalid.");
            }
        
        }
       
    }
}