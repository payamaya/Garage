
using System.Drawing;

namespace Garage
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ParkingLot parkingLot = new ParkingLot(10, 10);
        /*    parkingLot.ParkedCar(0, 0, new Vehicle(4, "Red", "ABC123"));
            parkingLot.ParkedCar(2, 0, new Vehicle(4, "Green", "abc345"));*/


            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1.)List all parked vehicles");
                Console.WriteLine("2.)List vehicle types and how many of each are in the garage");
                Console.WriteLine("3.)Display ParkingLot in the garage");
                Console.WriteLine("4.)Add Vehicle To ParkingLot");
                Console.WriteLine("5.)TotalVehicleParked");
                Console.WriteLine("6.)Find a specific vehicle by registration number. It should work with both ABC123 and Abc123 or AbC123.");
                Console.Write("Choose an option: ");

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
                        // Call method to add a vehicle to the parking lot
                        AddVehicleToParkingLot(parkingLot);
                        break; 
                    case "5":
                        TotalParkedVehicle(parkingLot);
                        break;  
                    case "6":
                        RemainedParkingSpot(parkingLot);
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
        private static void TotalParkedVehicle(ParkingLot vehicle) {
         
            // Count the number of cars parked
            int numberOfCars = vehicle.CountVehicles();
            Console.WriteLine($"Number of cars parked: {numberOfCars}");
        } 
        private static void RemainedParkingSpot(ParkingLot parkingLot) {

            int totalSpots = parkingLot.totalSpots;
            int numberOfCars = parkingLot.CountVehicles();
            int remainingSpots = totalSpots - numberOfCars;
            Console.WriteLine($"Remaining spots in the parking {remainingSpots}");

        }

        // Method to add a vehicle to the parking lot
        static void AddVehicleToParkingLot(ParkingLot parkingLot)
        {
            Console.Write("Enter registration number: ");
            string regNumber = Console.ReadLine()!.Trim();

            Console.Write("Enter color: ");
            string color = Console.ReadLine()!.Trim();

            Console.Write("Enter vehicle number of wheels: ");
            if (!int.TryParse(Console.ReadLine(), out int numberOfWheels))
            {
                Console.WriteLine("Invalid input. Please enter a valid number of wheels.");
                return;
            }

            Vehicle newVehicle = new Vehicle(numberOfWheels, color, regNumber);

            // Find an available parking spot and park the car
            if (parkingLot.AddVehicle(newVehicle))
            {
                Console.WriteLine($"Successfully parked the car: {newVehicle}");
            }
            else
            {
                Console.WriteLine("Parking lot is full. Cannot park the car.");
            }
        }



        private static void CountNumberOfCars(ParkingLot parkingLot)
        {
            int numberOfCars = parkingLot.CountVehicles();
            Console.WriteLine($"Number of cars parked: {numberOfCars}");
        }
            
    }
     
}
