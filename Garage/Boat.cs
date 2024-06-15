namespace Garage
{
    // Derived class subClass
    public class Boat:Vehicle
    {
        public int BoatLength { get; set; }
        public Boat(int wheelNumber, string color, string registrationNumber,int boatLength):base(wheelNumber, color, registrationNumber)
        {
            BoatLength= boatLength;
        }
        public override string ToString()=> $"Boat - {base.ToString()}," ;
        
    }
}
