namespace Garage
{
    public class Vehicle
    {
        
        public int WheelsNumber { get; set; }
        public string? Color { get; set; }
        public string? RegistrationNumber { get; set; }

        public Vehicle(int wheelNumber, string color, string registrationNumber)
        {
            WheelsNumber = wheelNumber;
            Color = color;
            RegistrationNumber = registrationNumber;
        }
        public override string ToString()=> $"Registration Number: {RegistrationNumber}, Color:{Color} , Number of Wheels: {WheelsNumber}";
    }

      
}
