namespace Garage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Build your own parking by adding the amount of rows and columns");
            Console.Write("Enter number of rows for the parkings lot: ");
            int rows = int.Parse(Console.ReadLine()!);
            Console.Write("Enter number of cols for the parkings lot: ");
            int cols = int.Parse(Console.ReadLine()!);

            var garage = new Garage<Vehicle>(rows, cols);
            ProgramHelpers.DisplayMenu(garage);
            Console.ReadLine();

        }

    }
}