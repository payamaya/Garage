namespace Garage
{
    public partial class Garage<T>
    {
        public void DisplayParkingLot()
        {
            bool isFull = true;
            Console.WriteLine("Parking Lot Status:");
            Console.WriteLine();

            // Check if the parking lot is full
            for (int row = 0; row < _spots.GetLength(0); row++)
            {
                for (int col = 0; col < _spots.GetLength(1); col++)
                {
                    if (_spots[row, col] == null)
                    {
                        isFull = false;
                        break;
                    }
                }
                if (!isFull)
                {
                    break;
                }
            }


            for (int row = 0; row < _spots.GetLength(0); row++)
            {
                for (int col = 0; col < _spots.GetLength(1); col++)
                {
                    if (_spots[row, col] == null)
                    {
                        // Empty spot with green background
                        Console.BackgroundColor = (isFull) ? ConsoleColor.Red : ConsoleColor.DarkGray;
                        Console.Write("||");
                    }
                    else
                    {
                        // Occupied spot with vehicle emoji
                        string emoji = GetVehicleEmoji(_spots[row, col]);
                        /*Console.BackgroundColor = ConsoleColor.Black;*/ // Reset to default background
                        Console.Write(emoji);


                    }
                }
                Console.ResetColor(); // Reset after each row
                Console.WriteLine(); // Move to the next row
            }

            // Set the background color to red if the parking lot is full
            if (isFull)
            {
                Console.WriteLine("\n\u001b[31mParking Lot is FULL!\u001b[0m"); // Optional message indicating full status
                Console.ResetColor();
            }

            // Reset the console colors after displaying the parking lot

        }
        public int CountVehicles()
        {
            int Count = 0;

            foreach (T vehicle in _spots)
            {
                if (vehicle is not null)
                {
                    Count++;
                }
            }
            return Count;
        }

        public List<T> GetVehiclesByColor(string color)
        {
            List<T> vehicles = new List<T>();
            for (int row = 0; row < _spots.GetLength(0); row++)
            {
                for (int col = 0; col < _spots.GetLength(1); col++)
                {
                    if (_spots[row, col] != null && _spots[row, col].Color.Equals(color, StringComparison.OrdinalIgnoreCase))
                    {
                        vehicles.Add(_spots[row, col]);
                    }
                }
            }
            return vehicles;
        }
    }
}
