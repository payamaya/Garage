using System;
using Garage.Interface;

namespace Garage.Helpers
{
    public class GarageInputHandler
    {
        private readonly IConsoleInputHelper _inputHelper;

        public GarageInputHandler(IConsoleInputHelper inputHelper)
        {
            _inputHelper = inputHelper;
        }

        public (int rows, int cols) GetValidGarageDimensions()
        {
            int rows = 0, cols = 0; // Initialize with default values
            bool isValidInput = false;

            Console.WriteLine("Build your own parking by adding the amount of rows and columns");

            while (!isValidInput)
            {
                rows = _inputHelper.ReadInt("Enter number of rows for the parking lot: ");
                if (rows <= 0)
                {
                    Console.WriteLine("Invalid input. Number of rows must be greater than 0.");
                    continue;
                }

                cols = _inputHelper.ReadInt("Enter number of columns for the parking lot: ");
                if (cols <= 0)
                {
                    Console.WriteLine("Invalid input. Number of columns must be greater than 0.");
                    continue;
                }

                isValidInput = true;
            }

            return (rows, cols);
        }
    }
}
