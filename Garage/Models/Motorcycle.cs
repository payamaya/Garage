namespace Garage.Models
{
    // Derived class subClass
    //ToDo calculation
    public class Motorcycle:Vehicle
    {
        public double CylinderVolume { get; set; }

        public Motorcycle(int wheelsNumber, string color, string registrationNumber, double cylinderVolume) : base(wheelsNumber, color, registrationNumber,VehicleType.Motorcycle)
        {
            CylinderVolume = (int)cylinderVolume;
        }
        public override string ToString() => $"Motorcycle -{base.ToString()}, CylinderVolume: {CylinderVolume}";
    }
}
