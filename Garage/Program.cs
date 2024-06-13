namespace Garage
{
    internal class Program
    {
        static void Main(string[] args)
        {

            ParkingLot parkingLot = new ParkingLot(3, 3);
            parkingLot.ParkedCar(0, 0, new Vehicle(4, "Red", "ABC123"));
            parkingLot.ParkedCar(0, 0, new Vehicle(4, "Green", "abc345"));

            parkingLot.DisplayParkingLot();

            int row = 0;
            int col = 0;
             
            Vehicle parkedCar= parkingLot.GetCar(row, col);
            if(parkedCar != null )
            {
                Console.WriteLine($"Car parked at spot [{row},{col}]: {parkedCar}");
            }
            else
            {
                Console.WriteLine($"No car parked at spot [{row},{col}].");
            }

            Console.ReadKey();
        }
    }
}
