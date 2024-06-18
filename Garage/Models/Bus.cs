﻿namespace Garage.Models
{
    // Derived class subClass
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public Bus(int wheelsNumber, string color, string registrationNumber, int numberOfSeats) : base(wheelsNumber, color, registrationNumber,VehicleType.Bus)
        {
            NumberOfSeats = numberOfSeats;
        }
        public override string ToString() => $"Bus -{base.ToString()}, NumberOfSeats: {NumberOfSeats}";
    }
}
