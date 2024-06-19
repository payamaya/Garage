namespace Garage.Models
{
    // Derived class subClass
    public class Car : Vehicle
    {
        public string FuelType { get; set; }

        public Car(int wheelNumber, string color, string registrationNumber, string fuelType) : base(wheelNumber, color, registrationNumber, VehicleType.Car)
        {
            FuelType = fuelType;
            WheelsNumber = wheelNumber;
        }

        public override string ToString() => $"Car - {base.ToString()}, FuelType: {FuelType}";
    }
}
