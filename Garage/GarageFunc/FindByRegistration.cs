namespace Garage
{
    public partial class Garage<T>
    {
        public T GetCar(int row, int col)
        {
            return _spots[row, col];
        }

        public T? FindVehicleByRegistrationNumber(string regNumber)
        {
            string normalizedRegNumber = regNumber.ToUpper();
            for (int row = 0; row < _spots.GetLength(0); row++)
            {
                for (int col = 0; col < _spots.GetLength(1); col++)
                {
                    if (_spots[row, col] != null && _spots[row, col].RegistrationNumber?.ToUpper() == normalizedRegNumber)
                    {
                        return _spots[row, col];
                    }
                }
            }
            return null;
        }    
 
    }
}
