namespace Garage
{
    public interface IVehicle
    {
        string? Color { get; set; }
        string? RegistrationNumber { get; set; }
        int WheelsNumber { get; set; }

        string ToString();
    }
}