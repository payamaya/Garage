namespace Garage.Interface
{
    public interface IParkingGarage<T>
    {
        void DisplayParkingLot();
        int CountVehicles();
        List<T> GetVehiclesByColor(string color);
    }
}
