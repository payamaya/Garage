using Garage.Enums;
using Garage.Interface;

namespace Garage.Models
{
    public  class Vehicle: IVehicle
    {
        // properties
        public VehicleType Type { get; set; }
        public int WheelsNumber { get; set; }
        public string? Color { get; set; }
        public string RegistrationNumber { get; set; }
        //Constructor
        public Vehicle(int wheelNumber, string color, string registrationNumber, VehicleType type)
        {
            Type = type;
            WheelsNumber = wheelNumber;
            Color = color;
            RegistrationNumber = registrationNumber;
        }
        //Methods
        public override string ToString() => $"Type: {Type} ,Registration Number: {RegistrationNumber}, Color:{Color} , Number of Wheels: {WheelsNumber}";

    }

}
