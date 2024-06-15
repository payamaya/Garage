/*using System;
using System.Collections.Generic;
using System.Linq;

namespace Garage
{
    public class ParkingPlot
    {
        private Vehicle[,] _spots;
        *//* private List<Vehicle> _vehicles;*//*

        public ParkingPlot(int rows, int cols)
        {
            _spots = new Vehicle[rows, cols];
            *//*    _vehicles = new List<Vehicle>();*//*
        }

        public int TotalSpots => _spots.GetLength(0) * _spots.GetLength(1);

        *//*    public bool AddVehicleToSpot(Vehicle vehicle, int row, int col)
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
            }*/

        /*    public bool AddVehicle(Vehicle vehicle)
            {
                if (_vehicles.Any(v => v.RegistrationNumber == vehicle.RegistrationNumber))
                {
                    Console.WriteLine("A vehicle with this registration number already exists in the garage.");
                    return false;
                }

                _vehicles.Add(vehicle);
                return true;
            }
    */
        /*   public bool RemoveVehicleFromSpot(int row, int col)
           {
               if (row < 0 || row >= _spots.GetLength(0) || col < 0 || col >= _spots.GetLength(1))
               {
                   Console.WriteLine($"Invalid parking spot. Row and column numbers must be within valid range (0 - {_spots.GetLength(0) - 1}, 0 - {_spots.GetLength(1) - 1}).");
                   return false;
               }

               if (_spots[row, col] == null)
               {
                   Console.WriteLine($"No vehicle is parked at spot [{row},{col}].");
                   return false;
               }

               _vehicles.Remove(_spots[row, col]);
               _spots[row, col] = null;
               return true;
           }*/
        /*
                public bool RemoveVehicle(string registrationNumber)
                {
                    var vehicle = _vehicles.FirstOrDefault(v => v.RegistrationNumber == registrationNumber);
                    if (vehicle == null)
                    {
                        Console.WriteLine("No vehicle with that registration number found in the garage.");
                        return false;
                    }

                    _vehicles.Remove(vehicle);

                    for (int row = 0; row < _spots.GetLength(0); row++)
                    {
                        for (int col = 0; col < _spots.GetLength(1); col++)
                        {
                            if (_spots[row, col]?.RegistrationNumber == registrationNumber)
                            {
                                _spots[row, col] = null;
                                break;
                            }
                        }
                    }
                    return true;
                }*/

        /*      public Vehicle FindVehicleByRegistrationNumber(string registrationNumber)
              {
                  return _vehicles.FirstOrDefault(v => v.RegistrationNumber == registrationNumber);
              }

              public List<Vehicle> GetVehiclesSortedByColor()
              {
                  return _vehicles.OrderBy(v => v.Color).ToList();
              }

              public List<Vehicle> GetVehiclesByColor(string color)
              {
                  return _vehicles.Where(v => v.Color.Equals(color, StringComparison.OrdinalIgnoreCase)).ToList();
              }

              public void DisplayAllVehicles()
              {
                  if (_vehicles.Count == 0)
                  {
                      Console.WriteLine("No vehicles in the garage.");
                  }
                  else
                  {
                      foreach (var vehicle in _vehicles)
                      {
                          Console.WriteLine(vehicle);
                      }
                  }
              }*/

      /*  public void DisplayParkingLot()
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
        }*/

        /*  private string GetCarEmoji(Vehicle vehicle)
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
          }*//*
    }
}
*/