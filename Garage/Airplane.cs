namespace Garage
{
    public class Airplane:Vehicle
    {
        public int NumOfEngines { get; set; }
        public Airplane(int wheelNumber, string color, string registrationNumber, int numOfEngines):base( wheelNumber,  color,  registrationNumber)
        {
            NumOfEngines = wheelNumber;
        }
        public override string ToString()=>$"Airplane - {base.ToString()}, NumOfEngines:{NumOfEngines}";
        
    }
}
