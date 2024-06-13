
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
                Console.WriteLine("1.)Check if parking spot is empty");
                Console.WriteLine("2.)List vehicle types and how many of each are in the garage");
                Console.WriteLine("3.)Display ParkingLot in the garage");
                Console.WriteLine("4.)Add Vehicle To ParkingLot");
                Console.WriteLine("5.)Remove Vehicle From ParkingLot");
                Console.WriteLine("6.)TotalVehicleParked");
                Console.WriteLine("7.)Remained ParkingSpot");
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
                        // Call method to add a vehicle to the parking lot
                        RemoveVehicleToParkingLot(parkingLot);
                        break; 
                    case "6":
                        TotalParkedVehicle(parkingLot);
                        break;  
                    case "7":
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
            if(parkingLot.IsRegistrationNumberExist(regNumber))
            {
                Console.WriteLine("A vehicle with this registration number already exist in the parking lot");
                return ;    
            }

            Console.Write("Enter color: ");
            string color = Console.ReadLine()!.Trim();

            Console.Write("Enter vehicle number of wheels: ");
            if (!int.TryParse(Console.ReadLine(), out int numberOfWheels))
            {
                Console.WriteLine("Invalid input. Please enter a valid number of wheels.");
                return;
            }

            Console.Write("Enter row number to park the vehicle: ");
            if(!int.TryParse(Console.ReadLine(),out int row))
            {
                return ;
            }
            Console.Write("Enter col number to park the vehicle: ");
            if (!int.TryParse(Console.ReadLine(),out int col))
            {
                return;
            }

            Vehicle newVehicle = new Vehicle(numberOfWheels, color, regNumber);

            // Find an available parking spot and park the car
            if (parkingLot.AddVehicle(newVehicle,row,col))
            {
                Console.WriteLine($"Successfully parked the car: {newVehicle}");
            }
            else
            {
                Console.WriteLine("Parking lot is full. Cannot park the car.");
            }
        } 
        // Method to add a vehicle to the parking lot
        static void RemoveVehicleToParkingLot(ParkingLot parkingLot)
        {
            Console.Write("Enter registration number: ");
            string regNumber = Console.ReadLine()!.Trim().ToUpper();

            //Remove vehicle
            if(parkingLot.RemoveVehicle(regNumber))
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
            
    }
     
}
