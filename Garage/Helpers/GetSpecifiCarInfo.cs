using Garage;
using Garage.Models;

internal static class GetSpecifiCarInfo
{

    public static void GetSpecificParkingSpotInfo(Garage<Vehicle> garage)
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
}