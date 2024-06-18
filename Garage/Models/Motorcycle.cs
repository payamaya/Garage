namespace Garage.Models
{
    // Derived class subClass
    //ToDo calculation
    public class Motorcycle:Vehicle
    {
        public int CylinderVolume { get; set; }

        public Motorcycle(int wheelsNumber, string color, string registrationNumber, int cylinderVolume) : base(wheelsNumber, color, registrationNumber,VehicleType.Motorcycle)
        {
            CylinderVolume = cylinderVolume;
        }
        public override string ToString() => $"Motorcycle -{base.ToString()}, Modal: {CylinderVolume}";
    }
}
