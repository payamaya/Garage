using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Garage
{
    public class Garage<T>:IEnumerable<T> where T : Vehicle
    {
        //Create a parking lot with 2 dimension array[,]
        private T[,] _spots;
        private List<T> _vehicles;
        /*    private int capacity;*/

        /*     public int Capacity => capacity;*/

        public Garage(int rows, int cols)
        {
            _spots = new T[rows, cols];
            _vehicles = new List<T>();
            /*      capacity = rows * cols;*/
        }

        public int TotalSpots => _spots.GetLength(0) * _spots.GetLength(1);


        public T GetCar(int row, int col)
        {
            return _spots[row, col];
        }

        public T FindVehicleByRegistrationNumber(string regNumber)
        {
            string normalizedRegNumber = regNumber.ToUpper();
            for (int row = 0; row < _spots.GetLength(0); row++)
            {
                for (int col = 0; col < _spots.GetLength(1); col++)
                {
                    if (_spots[row, col] != null && _spots[row, col].RegistrationNumber?.ToUpper() == normalizedRegNumber)
                    {
                        return _spots[row, col];
                    }
                }
            }
            return null;
        }
        public bool AddVehicleToSpot(T vehicle, int row, int col)
        {
            if (row < 0 || row >= _spots.GetLength(0) || col < 0 || col >= _spots.GetLength(1))
            {
                Console.WriteLine($"Invalid parking spot. Row and column numbers must be within valid range (0 - {_spots.GetLength(0) - 1}, 0 - {_spots.GetLength(1) - 1}).");
                return false;
            }

            if (_spots[row, col] != null)
            {
                Console.WriteLine($"Parking spot at [{row},{col}] is already occupied.");
                return false;
            }

            if (_vehicles.Any(v => v.RegistrationNumber == vehicle.RegistrationNumber))
            {
                Console.WriteLine("A vehicle with this registration number already exists in the garage.");
                return false;
            }

            _spots[row, col] = vehicle;
            _vehicles.Add(vehicle);
            return true;
        }

        public bool AddVehicle(T vehicle, int row, int col)
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
            if(vehicle is Bus)
            {
                if (row + 1 >= numRows || _spots[row, col + 1] != null && col + 1 >= numCols || _spots[row, col + 1] != null)
                {
                    Console.WriteLine($"Not enough space for the Bus at [{row},{col}].");
                    return false;
                }
            }
            else
            {
                // For other vehicles, occupy just one spot
                _spots[row, col] = vehicle;
            }
            // Assign the vehicle to the parking spot(s)
            _spots[row, col] = vehicle;
            if (vehicle is Bus)
            {
                _spots[row, col + 1] = vehicle; // Occupy the next spot for the Bus
            }
            // Assign the vehicle to the parking spot
            _spots[row, col] = vehicle;
            return true;
        }

        public bool ParkedCar(T vehicle, int row, int col)
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
            bool isFull = true;

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

            Console.WriteLine("Parking Lot Status:");
            Console.WriteLine();

            for (int row = 0; row < _spots.GetLength(0); row++)
            {
                for (int col = 0; col < _spots.GetLength(1); col++)
                {
                    if (_spots[row, col] == null)
                    {
                        // Empty spot with green background
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write("|  |");
                    }
                    else
                    {
                        // Occupied spot with vehicle emoji
                        string emoji = GetVehicleEmoji(_spots[row, col]);
                        Console.BackgroundColor = ConsoleColor.Black; // Reset to default background
                        Console.Write($"{emoji} ");
                    }
                }
                Console.ResetColor(); // Reset after each row
                Console.WriteLine(); // Move to the next row
            }

            // Set the background color to red if the parking lot is full
            if (isFull)
            {
                Console.WriteLine("\n\u001b[31mParking Lot is FULL!\u001b[0m"); // Optional message indicating full status
            }

            // Reset the console colors after displaying the parking lot
            Console.ResetColor();
        }

        private string GetVehicleEmoji(T vehicle)
        {
            return vehicle switch
            {
                Car car => car.Color.ToLower() switch
                {
                    "red" => "[🚗]",
                    "blue" => "[🚙]",
                    "green" => "[🚕]",
                    "yellow" => "[🚖]",
                    "black" => "[🚘]",
                    _ => "[🚗]" // Default car emoji
                },
                Bus bus => "[🚌]",
                Boat boat => "[⛵]",
                Airplane airplane => "[✈️]",
                Motorcycle motorcycle => "[🏍️]",
                _ => "[🚗]" // Default emoji if the vehicle type is not recognized
            };
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

        public IEnumerator<T> GetEnumerator()
        {
            return _vehicles.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}