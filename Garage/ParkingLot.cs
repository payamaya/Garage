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
        public Vehicle[,] spots;
    /*    private int capacity;*/

   /*     public int Capacity => capacity;*/

        public ParkingLot(int rows, int cols)
        {
            spots = new Vehicle[rows, cols];
      /*      capacity = rows * cols;*/
        }

        /*   public void ParkedCar(int row, int col, Vehicle vehicle)
           {
               spots[row, col] = vehicle;
           }*/

        public int totalSpots => spots.GetLength(0) * spots.GetLength(1);

        public bool AddVehicle(Vehicle vehicle, int row, int col)
        {
            if (IsRegistrationNumberExist(vehicle.RegistrationNumber))
            {
                return false;
            }
            if (spots[row, col] == null)
            {
                spots[row, col] = vehicle;
                return true;
            }

            return false;
        } 
        public bool RemoveVehicle(string regNumber)
        {
            string normalizedRegNumber = regNumber.ToUpper();

            for (int row = 0; row < spots.GetLength(0); row++)
            {
                for (int col = 0; col < spots.GetLength(1); col++)
                {
                    if (spots[row, col] is not null && spots[row, col].RegistrationNumber.ToUpper() == normalizedRegNumber)
                    {
                        spots[row, col] = null;
                        return true;
                    }
                }
            }
            return false;
        }
        //Unik regsiteration number
        public bool IsRegistrationNumberExist(string? regNumber)
        {
            string normalizedRegNumber = regNumber.ToUpper();
            for (int row = 0; row < spots.GetLength(0); row++)
            {
                for(int col = 0;col < spots.GetLength(1);col++)
                {
                    if (spots[row,col] is not null && spots[row,col]?.RegistrationNumber?.ToUpper()==normalizedRegNumber)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Vehicle GetCar(int row, int col)
        {
            return spots[row, col];
        }
        /*      public Vehicle GetCar(int row, int col)
              {
                  if (row < 0 || row >= spots.GetLength(0) || col < 0 || col >= spots.GetLength(1))
                  {
                      Console.WriteLine("Invalid parking spot");
                      return null;
                  }
                  return spots[row, col];
              }*/
        public void DisplayParkingLot()
        {
            Console.WriteLine("Parking Lot Status:");
            Console.WriteLine();
            for (int row = 0; row < spots.GetLength(0); row++)
            {
                for (int col = 0; col < spots.GetLength(1); col++)
                {
                    string status = (spots[row, col] == null) ? "[ ]" : GetCarEmoji(spots[row, col]);
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
        public bool ParkedCar(int row, int col, Vehicle vehicle)
        {
            if (row < 0 || row >= spots.GetLength(0) || col < 0 || col >= spots.GetLength(1))
            {
                Console.WriteLine("Invalid parking spot");
                return false;
            }
            if (spots[row, col] == null)
            {
                spots[row, col] = vehicle;
                return true;
            }
            else
            {
                Console.WriteLine("Parking spot is already occupied.");
                return false;
            }
        }

        public int CountVehicles()
        {
            int Count = 0;

            foreach (Vehicle vehicle in spots)
            {
                if (vehicle is not null)
                {
                    Count++;
                }
            }
            return Count;
        }
  
    }
}
