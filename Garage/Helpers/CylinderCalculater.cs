namespace Garage.Helpers
{
    internal partial class InputHelper
    {
        public class CylinderCalculater
        {
            public static double GetCylinderVolume()
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Calculate Cylinder Volume");

                        Console.Write("Enter Height of Cylinder: ");
                        double height = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter Radius of Cylinder: ");
                        double radius = Convert.ToDouble(Console.ReadLine());

                        double volume = CalculateVolume(height, radius);

                        Console.WriteLine($"Volume of cylinder: {volume}");
                        return volume;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                }

            }
            public static double CalculateVolume(double height, double radius)
            {
                return Math.Round(Math.PI * (radius * radius) * height, 3);
            }
        }

    }
}
