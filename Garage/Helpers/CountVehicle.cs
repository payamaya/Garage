using Garage;
using Garage.Models;

internal static class CountVehicle
{

    public static void CountNumberOfVehicles(Garage<Vehicle> garage)
    {
        int numberOfVehicles = garage.CountVehicles();
        /* if(garage.CountVehicles() ==0)
         {
             Console.WriteLine("\u001b[31mThe parking lot is empty.\u001b[0m");
         }
         else
         {
         Console.WriteLine($"Number of vehicles parked: \u001b[33m{numberOfVehicles}\u001b[0m");
         }*/

        Console.WriteLine(numberOfVehicles==0 ? "\u001b[31mThe parking lot is empty.\u001b[0m": $"Number of vehicles parked: \u001b[33m{numberOfVehicles}\u001b[0m");
     
    }
}