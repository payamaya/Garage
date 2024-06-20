using Garage.Interface;
using Garage.Models;

namespace Garage
{
    // We implement interface and inherit baseClass(from object)
    public partial class Garage<T> where T : IVehicle
    {
        //Create a parking lot with 2 dimension array[,]
        private T[,] _spots;
        private List<T> _vehicles;


        public Garage(int rows = 1, int cols = 1)
        {
            _spots = new T[rows, cols];
            _vehicles = new List<T>();

        }

        public int TotalSpots => _spots.GetLength(0) * _spots.GetLength(1);

    
    }
}