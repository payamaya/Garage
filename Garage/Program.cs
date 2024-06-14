
using System.Drawing;
using System.Text.RegularExpressions;

namespace Garage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Build your own parking by adding the amount of rows and columns");
            Console.Write("Enter number of rows for the parkings lot: ");
            int rows = int.Parse(Console.ReadLine()!);
            Console.Write("Enter number of cols for the parkings lot: ");
            int cols = int.Parse(Console.ReadLine()!);

            ParkingLot parkingLot = new ParkingLot(rows, cols);



            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1.)Check if parking spot is empty");
                Console.WriteLine("2.)List vehicle types and how many of each are in the garage");
                Console.WriteLine("3.)Display ParkingLot in the garage");
                Console.WriteLine("4.)Add Vehicle To ParkingLot");
                Console.WriteLine("5.)Remove Vehicle From ParkingLot");
                Console.WriteLine("6.)Total Vehicle Parked 'Lista samtliga parkerade fordon'");
                Console.WriteLine("7.)Remained ParkingSpot");
                Console.WriteLine("8.)Find Vehicle 'Hitta ett specifikt fordon via registreringsnumret. Det ska gå fungera med både\r\nABC123 samt Abc123 eller AbC123.'");
                Console.WriteLine("9.)List Vehicles Sorted by Color");
                Console.Write("\nChoose an option: ");

                string input = Console.ReadLine()!;

                switch (input)
                {
                    case "1":
                        GetSpecificParkingSpotInfo(parkingLot);
                        break;
                    case "2":
                        CountNumberOfCars(parkingLot);
                        break;
                    case "3":
                        parkingLot.DisplayParkingLot();
                        break;
                    case "4":              
                        AddVehicleToParkingLot(parkingLot);
                        break;
                    case "5":
                        RemoveVehicleToParkingLot(parkingLot);
                        break;
                    case "6":
                        TotalParkedVehicle(parkingLot);
                        break;
                    case "7":
                        RemainedParkingSpot(parkingLot);
                        break;
                    case "8":
                        FindVehicleByRegistrationNumber(parkingLot);
                        break;
                    case "9":
                        ListVehiclesByColor(parkingLot);
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
        // Method to get information about a specific parking spot
        private static void GetSpecificParkingSpotInfo(ParkingLot parkingLot)
        {
            Console.WriteLine("Enter row Number");
            if (!int.TryParse(Console.ReadLine(), out int row))
            {
                Console.WriteLine("Invalid input .Please enter a valid plate number");
                return;
            }
            Console.WriteLine("Enter column Number");
            if (!int.TryParse(Console.ReadLine(), out int col))
            {
                Console.WriteLine("Invalid input .Please enter a valid plate number");
                return;
            }

            Vehicle parkedCar = parkingLot.GetCar(row, col);
            if (parkedCar != null)
            {
                Console.WriteLine($"Car parked at spot [{row},{col}]: {parkedCar}");
            }
            else
            {
                Console.WriteLine($"No car parked at spot [{row},{col}].");
            }
            /* // Count the number of cars parked
             int numberOfCars = parkingLot.CountVehicles();
             Console.WriteLine($"Number of cars parked: {numberOfCars}");*/
        }
        private static void TotalParkedVehicle(ParkingLot vehicle)
        {

            // Count the number of cars parked
            int numberOfCars = vehicle.CountVehicles();
            Console.WriteLine($"Number of cars parked: {numberOfCars}");
        }
        private static void RemainedParkingSpot(ParkingLot parkingLot)
        {

            int totalSpots = parkingLot.totalSpots;
            int numberOfCars = parkingLot.CountVehicles();
            int remainingSpots = totalSpots - numberOfCars;
            Console.WriteLine($"Remaining spots in the parking {remainingSpots}");

        }
        // Other methods like GetSpecificParkingSpotInfo, CountNumberOfCars, AddVehicleToParkingLot, RemoveVehicleFromParkingLot...
        static void FindVehicleByRegistrationNumber(ParkingLot parkingLot)
        {
            Console.Write("Enter registration number: ");
            string regNumber = Console.ReadLine()!.Trim().ToUpper();

            Vehicle vehicle = parkingLot.FindVehicleByRegistrationNumber(regNumber);
            if (vehicle != null)
            {
                Console.WriteLine($"\u001b[31mVehicle found:\u001b[0m \u001b[32m{vehicle}\u001b[0m");
            }
            else
            {
                Console.WriteLine("No vehicle with that registration number found in the parking lot.");
            }
        }
        // Method to add a vehicle to the parking lot
        static void AddVehicleToParkingLot(ParkingLot parkingLot)
        {
            Console.Write("Enter registration number: ");
            string regNumber = Console.ReadLine()!.Trim().ToUpper();

            // Validate the registration number to ensure it contains only alphabetic characters and numbers
            if (!Regex.IsMatch(regNumber, @"^[a-zA-Z0-9]+$") ||
                !Regex.IsMatch(regNumber, @"([a-zA-Z].*){3,}") ||  // Contains at least one letter
                !Regex.IsMatch(regNumber, @"\d"))         // Contains at least one number
            {
                Console.WriteLine("\u001b[31mInvalid registration number. Please enter a registration number with both alphabetic characters and numbers.\u001b[0m");
                return;
            }
            if (parkingLot.IsRegistrationNumberExist(regNumber))
            {
                Console.WriteLine("\u001b[31mA vehicle with this registration number already exist in the parking lot\u001b[0m");
                return;
            }

            Console.Write("Enter color: ");
            string color = Console.ReadLine()!.Trim().ToUpper();

            Console.Write("Enter vehicle number of wheels: ");
            if (!int.TryParse(Console.ReadLine(), out int numberOfWheels))
            {
                Console.WriteLine("Invalid input. Please enter a valid number of wheels.");
                return;
            }

            Console.Write("Enter row number to park the vehicle: ");
            if (!int.TryParse(Console.ReadLine(), out int row))
            {
                return;
            }
            Console.Write("Enter col number to park the vehicle: ");
            if (!int.TryParse(Console.ReadLine(), out int col))
            {
                return;
            }

            Vehicle newVehicle = new Vehicle(numberOfWheels, color, regNumber);

            // Find an available parking spot and park the car
            if (parkingLot.AddVehicle(newVehicle, row, col))
            {
                Console.WriteLine($"Successfully parked the car: {newVehicle}");
                /*   Console.WriteLine(newVehicle.ToString());*/
            }
            else
            {
                Console.WriteLine("Parking spot is already occupied or invalid.");
            }
        }
        // Method to remove a vehicle to the parking lot
        static void RemoveVehicleToParkingLot(ParkingLot parkingLot)
        {
            Console.Write("Enter registration number: ");
            string regNumber = Console.ReadLine()!.Trim().ToUpper();

            //Remove vehicle
            if (parkingLot.RemoveVehicle(regNumber))
            {
                Console.WriteLine($"Successfully removed the vehicle with the registration number : {regNumber}");
            }
            else
            {
                Console.WriteLine("No vehicle with that registration number found in the parking lot");
            }

        }

        private static void CountNumberOfCars(ParkingLot parkingLot)
        {
            int numberOfCars = parkingLot.CountVehicles();
            Console.WriteLine($"Number of cars parked: {numberOfCars}");
        }

        static void ListVehiclesByColor(ParkingLot parkingLot)
        {
            Console.Write("Enter color to search for: ");
            string color = Console.ReadLine()!.Trim();

            List<Vehicle> vehicles = parkingLot.GetVehiclesByColor(color);
            if (vehicles.Count > 0)
            {
                Console.WriteLine($"Vehicles with color '{color}':");
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
