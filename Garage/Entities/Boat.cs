using Garage.Enums;

namespace Garage.Models
{
    // Derived class subClass
    public class Boat : Vehicle
    {
        public int BoatLength { get; set; }

        public override string ToString() => $"Boat - {base.ToString()}, BoatLenght {BoatLength} cm";

        public Boat(int wheelNumber, string color, string registrationNumber, int boatLength) : base(wheelNumber, color, registrationNumber, VehicleType.Boat)
        {
            BoatLength = boatLength;
        }

    }
}
