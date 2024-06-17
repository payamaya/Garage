namespace Garage.Interface
{
    public interface IConsoleInputHelper
    {
        string ReadLineTrimToUpper(string prompt);
        string ReadLineTrimToLower(string prompt);
        string ReadLineTrim(string prompt);
        int ReadInt(string prompt);
    }

}
