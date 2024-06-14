using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class ParkingLot
    {
        //Create a parking lot with 2 dimension array[,]
        private Vehicle[,] _spots;
        /*    private int capacity;*/

        /*     public int Capacity => capacity;*/

        public ParkingLot(int rows, int cols)
        {
            _spots = new Vehicle[rows, cols];
            /*      capacity = rows * cols;*/
        }


        public int totalSpots => _spots.GetLength(0) * _spots.GetLength(1);

        public Vehicle GetCar(int row, int col)
        {
            return _spots[row, col];
        }
        public Vehicle FindVehicleByRegistrationNumber(string regNumber)
        {
            string normalizedRegNumber = regNumber.ToUpper();
            for (int row = 0; row < _spots.GetLength(0); row++)
            {
                for (int col = 0; col < _spots.GetLength(1); col++)
                {
                    if (_spots[row, col] != null && _spots[row, col]?.RegistrationNumber?.ToUpper() == normalizedRegNumber)
                    {
                        return _spots[row, col];
                    }
                }
            }
            return null;
        }
        public bool AddVehicle(Vehicle vehicle, int row, int col)
        {
            if (IsRegistrationNumberExist(vehicle.RegistrationNumber))
            {
                Console.WriteLine("A vehicle with this registration number already exists in the parking lot.");
                return false;
            }

            int numRows = _spots.GetLength(0);
            int numCols = _spots.GetLength(1);

            // Check if the specified row and column are within the valid range
            if (row < 0 || row >= numRows || col < 0 || col >= numCols)
            {
                Console.WriteLine($"Invalid parking spot. Row and column numbers must be within valid range (0 - {numRows - 1}, 0 - {numCols - 1}).");
                return false;
            }

            // Check if the spot is already occupied
            if (_spots[row, col] != null)
            {
                Console.WriteLine($"Parking spot at [{row},{col}] is already occupied.");
                return false;
            }

            // Assign the vehicle to the parking spot
            _spots[row, col] = vehicle;
            return true;
        }

        public bool ParkedCar(Vehicle vehicle, int row, int col)
        {
            int numRows = _spots.GetLength(0);
            int numCols = _spots.GetLength(1);

            if (row < 0 || row >= numRows || col < 0 || col >= numCols)
            {
                Console.WriteLine($"Invalid parking spot. Row and column numbers must be within valid range (0 - {numRows - 1}, 0 - {numCols - 1}).");
                return false;
            }

            // Check if the spot at [row, col] is occupied
            if (_spots[row, col] != null)
            {
                Console.WriteLine($"Parking spot at [{row},{col}] is occupied.");
                return true;
            }
            else
            {
                Console.WriteLine($"Parking spot at [{row},{col}] is vacant.");
                return false;
            }
        }


        public bool RemoveVehicle(string regNumber)
        {
            string normalizedRegNumber = regNumber.ToUpper();

            for (int row = 0; row < _spots.GetLength(0); row++)
            {
                for (int col = 0; col < _spots.GetLength(1); col++)
                {
                    if (_spots[row, col] is not null && _spots[row, col]?.RegistrationNumber?.ToUpper() == normalizedRegNumber)
                    {
                        _spots[row, col] = null!;
                        return true;
                    }
                }
            }
            return false;
        }
        //Unik regsiteration number
        public bool IsRegistrationNumberExist(string regNumber)
        {
            string normalizedRegNumber = regNumber.ToUpper();
            for (int row = 0; row < _spots.GetLength(0); row++)
            {
                for (int col = 0; col < _spots.GetLength(1); col++)
                {
                    if (_spots[row, col] is not null && _spots[row, col].RegistrationNumber?.ToUpper() == normalizedRegNumber)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void DisplayParkingLot()
        {
            Console.WriteLine("Parking Lot Status:");
            Console.WriteLine();
            for (int row = 0; row < _spots.GetLength(0); row++)
            {
                for (int col = 0; col < _spots.GetLength(1); col++)
                {
                    string status = (_spots[row, col] == null) ? "[ ]" : GetCarEmoji(_spots[row, col]);
                    Console.Write(status + " ");
                }
                Console.WriteLine();
            }
        }

        private string GetCarEmoji(Vehicle vehicle)
        {
            return vehicle?.Color?.ToLower() switch
            {
                "red" => "[🚗]",
                "blue" => "[🚙]",
                "green" => "[🚕]",
                "yellow" => "[🚖]",
                "black" => "[🚘]",
                _ => "[🚗]" // Default emoji if color is not recognized
            };
        }


        public int CountVehicles()
        {
            int Count = 0;

            foreach (Vehicle vehicle in _spots)
            {
                if (vehicle is not null)
                {
                    Count++;
                }
            }
            return Count;
        }

        public List<Vehicle> GetVehiclesByColor(string color)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
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