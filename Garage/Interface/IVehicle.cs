using Garage.Models;

namespace Garage.Interface
{
    public interface IVehicle
    {
        VehicleType Type { get; set; }
        int WheelsNumber { get; set; }
        string? Color { get; set; }
        string RegistrationNumber { get; set; }
    }
}