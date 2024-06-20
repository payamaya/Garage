using Garage;
using Garage.Interface;
using Garage.Models;
using System;

internal static class GetSpecificCarInfo
{
    public static void GetSpecificParkingSpotInfo(Garage<IVehicle> garage)
    {
        Console.Write("Enter row Number: ");
        if (!int.TryParse(Console.ReadLine(), out int row))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        Console.Write("Enter column Number: ");
        if (!int.TryParse(Console.ReadLine(), out int col))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
            return;
        }

        IVehicle parkedVehicle = garage.GetCar(row, col);
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
