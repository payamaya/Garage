using Garage.Models;
using System.Linq;
namespace Garage
{
    public partial class Garage<T>
    {
        private List<T> _vehicle = new List<T>();

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

            if (row < 0 || row >= numRows || col < 0 || col >= numCols)
            {
                Console.WriteLine($"Invalid parking spot. Row and column numbers must be within valid range (0 - {numRows - 1}, 0 - {numCols - 1}).");
                return false;
            }

            if (_spots[row, col] != null)
            {
                Console.WriteLine($"Parking spot at [{row},{col}] is already occupied.");
                return false;
            }

            /* Special handling for Bus
            if (vehicle is Bus)
            {
                if (col + 1 >= numCols || _spots[row, col + 1] != null)
                {
                    Console.WriteLine($"Not enough space for the Bus at [{row},{col}].");
                    return false;
                }
                _spots[row, col] = vehicle;
                _spots[row, col + 1] = vehicle;
                Console.WriteLine($"Successfully parked the Bus horizontally at [{row},{col}] and [{row},{col + 1}].");
            }
            else
            {
                _spots[row, col] = vehicle;
            }
            if (vehicle is Bus)
            {
                _spots[row, col + 1] = vehicle;
            }
            */

            _spots[row, col] = vehicle;
            _vehicles.Add(vehicle);
            return true;
        }


        /*   public bool ParkedCar(T vehicle, int row, int col)
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
           }*/
        public bool IsSpotOccupied(T vehicle, int row, int col)
        {
            if (row < 0 || row >= _spots.GetLength(0) || col < 0 || col >= _spots.GetLength(1))
            {
                throw new ArgumentOutOfRangeException($"Row and column numbers must be within valid range (0 - {_spots.GetLength(0) - 1}, 0 - {_spots.GetLength(1) - 1}).");
            }

            return _spots[row, col] != null;
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

        private string GetVehicleEmoji(T vehicle)
        {
            return vehicle switch
            {
                Car car => car?.Color?.ToLower() switch
                {
                    "red" => "🚗",
                    "blue" => "🚙",
                    "green" => "🚕",
                    "yellow" => "🚖",
                    "black" => "🚘",
                    _ => "🚗" // Default car emoji
                },
                Bus bus => "🚌",
                Boat boat => "⛵",
                Airplane airplane => "✈️",
                Motorcycle motorcycle => "🏍️",
                _ => "🚗" // Default emoji if the vehicle type is not recognized
            };
        }
        public List<T> GetVehiclesByWheelsNumber(int wheelNumber)
        {
            return _vehicles.Where(v => v.WheelsNumber == wheelNumber).ToList();
        }

        public bool IsEmpty()
        {
            return !_vehicles.Any();
        }

    }
}
