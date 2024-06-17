using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Garage.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Garage
{
    // We implement interface and inherit baseClass(from object)
    public partial class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        //Create a parking lot with 2 dimension array[,]
        private T[,] _spots;
        private List<T> _vehicles;
        /*    private int capacity;*/

        /*     public int Capacity => capacity;*/

        public Garage(int rows=1, int cols = 1)
        {
            _spots = new T[rows, cols];
            _vehicles = new List<T>();
            /*      capacity = rows * cols;*/
        }

        public int TotalSpots => _spots.GetLength(0) * _spots.GetLength(1);


       
    }
}