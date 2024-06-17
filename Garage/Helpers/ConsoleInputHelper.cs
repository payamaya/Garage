using Garage.Interface;

namespace Garage.Helpers
{
    public class ConsoleInputHelper : IConsoleInputHelper
    {
        public string ReadLineTrimToUpper(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine()?.Trim().ToUpper()!;
        }

        public string ReadLineTrimToLower(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine()?.Trim().ToLower()!;
        }

        public string ReadLineTrim(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine()?.Trim()!;
        }

        public int ReadInt(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }

}
