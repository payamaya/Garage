namespace Garage
{
    public class Car:Vehicle
    {
        public string FuelType { get; set; }
        public Car(int wheelNumber, string color, string registrationNumber, string fuelType) : base(wheelNumber, color, registrationNumber)
        {
            {
                FuelType = fuelType;
            }
        }
        public override string ToString() => $"Car - {base.ToString()}, FuelType";
    }
}
