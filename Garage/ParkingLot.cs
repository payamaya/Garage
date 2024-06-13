using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    public class ParkingLot
    {
        //Create a parking lot with 2 dimension array[,]
        public Vehicle[,] spots;
        private int capacity;

        public int Capacity => capacity;

        public ParkingLot(int rows, int cols)
        {
            spots = new Vehicle[rows, cols];
            capacity = rows * cols;
        }
        public bool ParkedCar(int row , int col, Vehicle vehicle)
        {
            if(row < 0 || row>=spots.GetLength(0) || col < 0 || col >= spots.GetLength(1))
            {
                Console.WriteLine("Invalid parking spot");
                return false;
            }
            if (spots[row, col] == null) 
            {
                spots[row,col]= vehicle;
                return true;
            }
            else
            {
                Console.WriteLine("Parking spot is already occupied.");
                return false ;
            }
        }

        public Vehicle GetCar(int row, int col) 
        {
            if(row <0 || row>=spots.GetLength(0) || col <0 || col >= spots.GetLength(1))
            {
                Console.WriteLine("Invalid parking spot");
                return null;
            }
          return spots[row, col];   
        }
        public void DisplayParkingLot()
        {
            for (int row = 0; row < spots.GetLength(0); row++)
            {
                for(int col = 0; col < spots.GetLength(1); col++)
                {
                    if(spots[row, col] == null)
                    {
                        Console.WriteLine($"Parking Spot [{row}, {col}] - Empty");
                    }
                    else
                    {
                        Console.WriteLine($"Parking spot [{row},{col}] - {spots[row,col]}");
                    }
                }
            }
        }
        public int CounterVehicles()
        {
            int Count = 0;
            for (int row = 0; row < spots.GetLength(0); row++)
            {
                for (int col = 0; col < spots.GetLength(1); col++)
                {
                    if (spots[row,col] is not null)
                    {
                        Count++;
                    }
                }
            }
            return Count;
        }

    }
}
