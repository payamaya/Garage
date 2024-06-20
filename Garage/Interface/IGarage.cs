using Garage.Models;

namespace Garage.Interface
{
    public interface IGarage<T> where T : Vehicle
    {
        int TotalSpots { get; }

        bool AddVehicle(T vehicle, int row, int col);
        bool AddVehicleToSpot(T vehicle, int row, int col);
        int CountVehicles();
        void DisplayParkingLot();
        T? FindVehicleByRegistrationNumber(string regNumber);
        T GetCar(int row, int col);
        IEnumerator<T> GetEnumerator();
        List<T> GetVehiclesByColor(string color);
        List<T> GetVehiclesByWheelsNumber(int wheelNumber);
        bool IsEmpty();
        bool IsRegistrationNumberExist(string regNumber);
      /*  bool ParkedCar(T vehicle, int row, int col);*/
        bool IsSpotOccupied(T vehicle, int row, int col);
        bool RemoveVehicle(string regNumber);
    }
}