using Garage.Enums;

namespace Garage.Models
{
    public class Airplane : Vehicle
    {
        public int NumOfEngines { get; set; }

        public override string ToString() => $"Airplane - {base.ToString()}, NumOfEngines:{NumOfEngines}";

        public Airplane(int wheelNumber, string color, string registrationNumber, int numOfEngines) : base(wheelNumber, color, registrationNumber, VehicleType.Airplane)
        {
            NumOfEngines = wheelNumber;
        }

    }
}
