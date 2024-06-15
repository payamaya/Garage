using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Garage
{
    public static class ProgramHelpers
    {
        private const string MenuOptions =
            "1.) Check if parking spot is empty\n" +
            "2.) List vehicle types and how many of each are in the garage\n" +
            "3.) Display ParkingLot in the garage\n" +
            "4.) Add Vehicle To ParkingLot\n" +
            "5.) Remove Vehicle From ParkingLot\n" +
            "6.) Total Vehicle Parked 'Lista samtliga parkerade fordon'\n" +
            "7.) Remained ParkingSpot\n" +
            "8.) Find Vehicle 'Hitta ett specifikt fordon via registreringsnumret. Det ska gå fungera med både\r\nABC123 samt Abc123 eller AbC123.'\n" +
            "9.) List Vehicles Sorted by Color\n" +
            "0.) Exit\n";

        public static void DisplayMenu(Garage<Vehicle> garage)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(MenuOptions);
                Console.Write("Choose an option: ");
                string input = Console.ReadLine()?.Trim();

                switch (input)
                {
                    case "1":
                        GetSpecificParkingSpotInfo(garage);
                        break;
                    case "2":
                        CountNumberOfVehicles(garage);
                        break;
                    case "3":
                        garage.DisplayParkingLot();
                        break;
                    case "4":
                        AddVehicleToParkingLot(garage);
                        break;
                    case "5":
                        RemoveVehicleFromParkingLot(garage);
                        break;
                    case "6":
                        TotalParkedVehicles(garage);
                        break;
                    case "7":
                        RemainedParkingSpots(garage);
                        break;
                    case "8":
                        FindVehicleByRegistrationNumber(garage);
                        break;
                    case "9":
                        ListVehiclesByColor(garage);
                        break;
                    case "0":
                        Console.WriteLine("Exiting program...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please enter a valid option.");
                        break;
                }
            }
        }

        static void GetSpecificParkingSpotInfo(Garage<Vehicle> garage)
        {
            Console.WriteLine("Enter row Number");
            if (!int.TryParse(Console.ReadLine(), out int row))
            {
                Console.WriteLine("Invalid input. Please enter a valid plate number");
                return;
            }
            Console.WriteLine("Enter column Number");
            if (!int.TryParse(Console.ReadLine(), out int col))
            {
                Console.WriteLine("Invalid input. Please enter a valid plate number");
                return;
            }

            Vehicle parkedVehicle = garage.GetCar(row, col);
            if (parkedVehicle != null)
            {
                Console.WriteLine($"Vehicle parked at spot [{row},{col}]: {parkedVehicle}");
            }
            else
            {
                Console.WriteLine($"No vehicle parked at spot [{row},{col}].");
            }
        }

        static void TotalParkedVehicles(Garage<Vehicle> garage)
        {
            int numberOfVehicles = garage.CountVehicles();
            Console.WriteLine($"Number of vehicles parked: {numberOfVehicles}");
        }

        static void RemainedParkingSpots(Garage<Vehicle> garage)
        {
            int totalSpots = garage.TotalSpots;
            int numberOfVehicles = garage.CountVehicles();
            int remainingSpots = totalSpots - numberOfVehicles;
            Console.WriteLine($"Remaining spots in the parking: {remainingSpots}");
        }

        static void FindVehicleByRegistrationNumber(Garage<Vehicle> garage)
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

        public static void AddVehicleToParkingLot(Garage<Vehicle> garage)
        {
            Console.Write("Enter registration number: ");
            string regNumber = Console.ReadLine()?.Trim().ToUpper();

            // Validate registration number format
            if (!Regex.IsMatch(regNumber, @"^[a-zA-Z0-9]+$") ||
                !Regex.IsMatch(regNumber, @"([a-zA-Z].*){3,}") ||  // Contains at least one letter
                !Regex.IsMatch(regNumber, @"\d"))         // Contains at least one number
            {
                Console.WriteLine("\u001b[31mInvalid registration number. Please enter a registration number with both alphabetic characters and numbers.\u001b[0m");
                return;
            }

            // Check if registration number already exists
            if (garage.IsRegistrationNumberExist(regNumber))
            {
                Console.WriteLine("\u001b[31mA vehicle with this registration number already exists in the parking lot\u001b[0m");
                return;
            }

            Console.Write("Enter color: ");
            string color = Console.ReadLine()?.Trim().ToUpper();

            Console.Write("Enter number of wheels: ");
            if (!int.TryParse(Console.ReadLine(), out int numberOfWheels))
            {
                Console.WriteLine("Invalid input. Please enter a valid number of wheels.");
                return;
            }

            // Assuming vehicle type input or logic to determine vehicle type
            Console.Write("Enter vehicle type (Car/Bus/Boat/Airplane/Motorcycle): ");
            string vehicleType = Console.ReadLine()?.Trim().ToUpper();

            Vehicle newVehicle;
            switch (vehicleType)
            {
                case "CAR":
                    Console.Write("Enter fuel type: ");
                    string fuelType = Console.ReadLine()?.Trim();
                    newVehicle = new Car(numberOfWheels, color, regNumber, fuelType);
                    break;
                case "BUS":
                    Console.Write("Enter number of seats: ");
                    if (!int.TryParse(Console.ReadLine(), out int numberOfSeats))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number of seats.");
                        return;
                    }
                    newVehicle = new Bus(numberOfWheels, color, regNumber, numberOfSeats); 
                    break;
                case "AIRPLANE":
                    Console.Write("Enter number of seats: ");
                    if (!int.TryParse(Console.ReadLine(), out int numOfEngines))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number of seats.");
                        return;
                    }
                    newVehicle = new Airplane(numberOfWheels, color, regNumber, numOfEngines);
                    break;
                case "BOAT":
                    Console.Write("Enter number of seats: ");
                    if (!int.TryParse(Console.ReadLine(), out int boatLength))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number of seats.");
                        return;
                    }
                    newVehicle = new Boat(numberOfWheels, color, regNumber, boatLength);
                    break;
                case "MOTORCYCLE":
                 {  Console.Write("Enter number of seats: ");
                        newVehicle = new Motorcycle();
                    }
                 
                    break;
                default:
                    Console.WriteLine("Invalid vehicle type. Please enter either 'Car' or 'Bus'.");
                    return;
            }

            Console.Write("Enter row number to park the vehicle: ");
            if (!int.TryParse(Console.ReadLine(), out int row))
            {
                Console.WriteLine("Invalid input. Please enter a valid row number.");
                return;
            }

            Console.Write("Enter column number to park the vehicle: ");
            if (!int.TryParse(Console.ReadLine(), out int col))
            {
                Console.WriteLine("Invalid input. Please enter a valid column number.");
                return;
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



        static void RemoveVehicleFromParkingLot(Garage<Vehicle> garage)
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

        static void CountNumberOfVehicles(Garage<Vehicle> garage)
        {
            int numberOfVehicles = garage.CountVehicles();
            Console.WriteLine($"Number of vehicles parked: {numberOfVehicles}");
        }

        static void ListVehiclesByColor(Garage<Vehicle> garage)
        {
            var colorMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "Black", "\u001b[30m" },
                { "Red", "\u001b[31m" },
                { "Green", "\u001b[32m" },
                { "Yellow", "\u001b[33m" },
                { "Blue", "\u001b[34m" },
                { "Magenta", "\u001b[35m" },
                { "Cyan", "\u001b[36m" },
                { "White", "\u001b[37m" }
            };

            while (true)
            {
                Console.Write("Enter color to search for (or type 'back' to return to the main menu): ");
                string color = Console.ReadLine()?.Trim()!;

                if (color.Equals("back", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
                if (!colorMap.ContainsKey(color))
                {
                    Console.WriteLine("Invalid color. Please enter one of the following colors:");
                    foreach (var colorKey in colorMap.Keys)
                    {
                        Console.WriteLine($"{colorKey}: {colorMap[colorKey]}{colorKey}\u001b[0m");
                    }
                    continue;
                }

                List<Vehicle> vehicles = garage.GetVehiclesByColor(color);

                if (vehicles.Count > 0)
                {
                    Console.WriteLine($"Vehicles with color '{colorMap[color]}{color.ToUpper()}\u001b[0m':");

                    foreach (var vehicle in vehicles)
                    {
                        Console.WriteLine(vehicle);
                    }
                }
                else
                {
                    Console.WriteLine($"No vehicles found with color '{color}'.");
                }
            }
        }


    }
}