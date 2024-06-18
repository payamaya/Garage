namespace Garage.Models
{
    //Base Class
    public enum VehicleType
    {
        Car,
        Bus,
        Boat,
        Airplane,
        Motorcycle
    }
    public abstract class Vehicle
    {
        // properties
        public VehicleType Type { get; set; }
        public int WheelsNumber { get; set; }
        public string? Color { get; set; }
        public string? RegistrationNumber { get; set; }
        //Methods
        public Vehicle(int wheelNumber, string color, string registrationNumber, VehicleType type)
        {
            Type = type;
            WheelsNumber = wheelNumber;
            Color = color;
            RegistrationNumber = registrationNumber;
        }
        public override string ToString() => $"Type: {Type} ,Registration Number: {RegistrationNumber}, Color:{Color} , Number of Wheels: {WheelsNumber}";

    }

}
