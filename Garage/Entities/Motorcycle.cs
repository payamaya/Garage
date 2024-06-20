using Garage.Enums;

namespace Garage.Models
{
    // Derived class subClass
    //ToDo calculation
    public class Motorcycle:Vehicle
    {
        public double CylinderVolume { get; set; }

        public override string ToString() => $"Motorcycle -{base.ToString()}, CylinderVolume: {CylinderVolume}";

        public Motorcycle(int wheelNumber, string color, string registrationNumber, double cylinderVolume) : base(wheelNumber, color, registrationNumber,VehicleType.Motorcycle)
        {
            CylinderVolume = (int)cylinderVolume;
        }
    }
}
