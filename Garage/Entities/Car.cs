using Garage.Enums;

namespace Garage.Models
{
    // Derived class subClass
    public class Car : Vehicle
    {
        public string FuelType { get; set; }

        public override string ToString() => $"Car - {base.ToString()}, FuelType: {FuelType}";

        public Car(int wheelNumber, string color, string registrationNumber, string fuelType) : base(wheelNumber, color, registrationNumber, VehicleType.Car)
        {
            FuelType = fuelType;
        
        }

    }
}
