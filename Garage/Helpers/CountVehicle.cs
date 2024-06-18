using Garage;
using Garage.Models;

internal static class CountVehicle
{

    public static void CountNumberOfVehicles(Garage<Vehicle> garage)
    {
        int numberOfVehicles = garage.CountVehicles();
        Console.WriteLine($"Number of vehicles parked: {numberOfVehicles}");
     
    }
}