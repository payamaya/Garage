using Garage.Models;

namespace Garage.Helpers
{
    internal static class AddVehiclesToParkingLot
    {

        public static void AddVehicleToParkingLot(Garage<Vehicle> garage)
        {
            //check if user enter a valid regex regnumber

            string regNumber = InputHelper.GetRegistrationNumber(garage);

            //Check if user enter a string color

          string color =  InputHelper.GetColor();
            int numberOfWheels = InputHelper.GetNumberOfWheels();

            VehicleType vehicleType = InputHelper.GetVehicleType();

            Vehicle newVehicle;
            switch (vehicleType)
            {
                case VehicleType.Car:

                    string fuelType = InputHelper.GetFuelType();
                    newVehicle = new Car(numberOfWheels, color, regNumber, fuelType);
                    break;

                case VehicleType.Bus:
                    int numberOfSeats = InputHelper.GetNumberOfSeats();
                    newVehicle = new Bus(numberOfWheels, color, regNumber, numberOfSeats);
                    break;

                case VehicleType.Boat:
                 int boatLength = InputHelper.GetBoatLength();
                    newVehicle = new Boat(numberOfWheels, color, regNumber, boatLength);
                    break;

                case VehicleType.Airplane:
                int numOfEngines = InputHelper.GetNumberOfEngines();
                    newVehicle = new Airplane(numberOfWheels, color, regNumber, numOfEngines);
                    break;

                case VehicleType.Motorcycle:
                  double cylinderVolume= InputHelper.CylinderCalculater.GetCylinderVolume();  
                    newVehicle = new Motorcycle(numberOfWheels, color, regNumber, cylinderVolume);
                    break;
                default:
                    Console.WriteLine("Invalid vehicle type. Please enter either 'Car', 'Bus', 'Boat', 'Airplane', or 'Motorcycle'.\n");
                    return;
            }

            // Prompt user for row number until a valid number is entered
    
            //int col = InputHelper.GetColumn();
             // Prompt user for row number until a valid number is entered
            int row = InputHelper.GetRow();
            
            // Prompt user for column number until a valid number is entered
            int col = InputHelper.GetColumn();

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