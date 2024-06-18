using Garage.Helpers;
using Garage.Interface;
using Garage.Models;


namespace Garage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                IConsoleInputHelper inputHelper = new ConsoleInputHelper();
                GarageInputHandler inputHandler = new GarageInputHandler(inputHelper);

                (int maxRows, int maxCols) = inputHandler.GetValidGarageDimensions();

                var garage = new Garage<Vehicle>(maxRows, maxCols);
                DisplayMainMenu.DisplayMenu(garage);
                Console.ReadLine();
            }
        }

        
    }
}
