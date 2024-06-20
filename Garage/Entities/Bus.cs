using Garage.Enums;

namespace Garage.Models
{
    // Derived class subClass
    public class Bus : Vehicle
    {
        public int NumberOfSeats { get; set; }

        public override string ToString() => $"Bus -{base.ToString()}, NumberOfSeats: {NumberOfSeats}";

        public Bus(int wheelNumber, string color, string registrationNumber, int numberOfSeats) : base(wheelNumber, color, registrationNumber,VehicleType.Bus)
        {
            NumberOfSeats = numberOfSeats;
        }
    }
}
