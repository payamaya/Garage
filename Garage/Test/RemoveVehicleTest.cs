using Garage.Models;
using Garage;
using Xunit;

namespace Garage.Test
{
    public class RemoveVehicleTest
    {
        [Fact]
        public void RemoveVehicle_RemoveExistingVehicle_ReturnsTrue()
        {
            //Arrange

            Garage<Vehicle> garage = new Garage<Vehicle>(2, 2);
            Vehicle removeVehicle = new Car(4, "Reducer", "dfhj34", "bensin");
            garage.AddVehicleToSpot(removeVehicle, 0,0);

            //Act
            bool remove = garage.RemoveVehicle("dfhj34");
            //Assert
            Assert.True(remove);
            Assert.Null(garage.GetCar(0,0));    
        }


            [Fact]
        public void RemoveVehicle_NonExistingVehicle_RetunsFalse()
        {
            //Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(2,2);
            Vehicle vehicleToRemove = new Car(2, "Red", "RTS65", "DESIEL");
            garage.AddVehicleToSpot(vehicleToRemove, 0,0);
            //Act
            bool removed = garage.RemoveVehicle("JLHGU78");
            //Assert
          /*  Assert.True(!removed);*/
            Assert.False(removed);
            Assert.Null(garage.GetCar(0,0));    
        }
    }
}
