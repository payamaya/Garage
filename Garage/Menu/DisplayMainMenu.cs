using Garage.Helpers;
using Garage.Helprs;
using Garage.Interface;
using Garage.Models;

namespace Garage.Menu
{
    public static class DisplayMainMenu
    {
        private const string MenuOptions =
            "1.) Check if parking spot is empty\n" +
            "2.) Count Number Of Vehicles\n" +
            "3.) Display ParkingLot in the garage\n" +
            "4.) Add Vehicle To ParkingLot\n" +
            "5.) Remove Vehicle From ParkingLot\n" +
            "6.) Total Vehicle Parked 'Lista samtliga parkerade fordon'\n" +
            "7.) Remained ParkingSpot\n" +
            "8.) Find Vehicle via registration number.'\n" +
            "9.) List Vehicles Sorted by Color\n" +
            "10.) List vehicle types and how many of each are in the garage\n" +
            "11.) List vehicle types by number of wheels\n" +
            "0.) Exit\n";

        public static void DisplayMenu(Garage<IVehicle> garage)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine(MenuOptions);
                Console.Write("Choose an option: ");
                string input = Console.ReadLine()?.Trim()!;

                switch (input)
                {
                    case "1":
                        GetSpecificCarInfo.GetSpecificParkingSpotInfo(garage);
                        break;
                    case "2":
                        CountVehicle.CountNumberOfVehicles(garage);
                        break;
                    case "3":
                        garage.DisplayParkingLot();
                        break;
                    case "4":
                        AddVehiclesToParkingLot.AddVehicleToParkingLot(garage);
                        break;
                    case "5":
                        RemoveVehicles.RemoveVehicleFromParkingLot(garage);
                        break;
                    case "6":
                        TotalVehicles.TotalParkedVehicles(garage);
                        break;
                    case "7":
                        RemianingVehicles.RemainedParkingSpots(garage);
                        break;
                    case "8":
                        FindByReg.FindVehicleByRegistrationNumber(garage);
                        break;
                    case "9":
                        VehiclesByColors.ListVehiclesByColor(garage);
                        break;
                    case "10":
                        ListVehiclesTypeAndCount.ListVehicleTypesAndCounts(garage);
                        break;
                    case "11":
                        FindByWheelsNumber.FindVehiclesByWheelsNumber(garage);
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
    }
}