using Garage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Garage.Test
{
    public class AddVehicleTest
    {
        [Fact]
        public void AddVehicle_AddExistingVehicle_RetunsTrue()
        {
            //Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(2, 2);
            Vehicle addVehicle = new Car(4, "GREEN", "GHJ565", "BENSIN");
            garage.AddVehicle(addVehicle, 0, 0);
            //Act
            bool add = garage.AddVehicle(addVehicle, 0,0);
            //Assert

            Assert.True(add);
            Assert.Equal(addVehicle, garage.GetCar(0,0));   
        }

        [Fact]
        public void AddVehicle_VehicleWithExistingRegistrationNumber_ReturnsFalse()
        {
            //Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(2, 2);
            Vehicle existingVehicle = new Car(4, "BLUE", "GKLO98", "DEISEL");
            garage.AddVehicle(existingVehicle, 0, 0);

            Vehicle newVehicleWithSameRegNumber = new Car(4, "GREEN", "GHJ565", "BENSIN");

            //Act
            bool added = garage.AddVehicle(existingVehicle,0,0);
            //Assert

            Assert.False(added);
            Assert.NotEqual( newVehicleWithSameRegNumber,garage.GetCar(1,1));
        }

        [Fact]
        public void AddVehicle_OccupiedParkingSpot_ReturnsFalse()
        {
            //Arrange
            Garage<Vehicle> garage = new Garage<Vehicle> (2, 2);
            Vehicle firstVehicle = new Car(4, "BLUE", "GKLO98", "DEISEL");
            Vehicle secondVehicle = new Car(4, "GREEN", "GHJ565", "BENSIN");

            garage.AddVehicle(firstVehicle, 0, 0);
            //Act
            bool added = garage.AddVehicle (secondVehicle, 0, 0);
            //Assert
            Assert.False(added);
            Assert.NotEqual(firstVehicle,garage.GetCar(0,0));
        }
        [Theory]
        [InlineData(-1, 0)] // Invalid row
        [InlineData(0, -1)] // Invalid column
        [InlineData(2, 0)]  // Row out of range
        [InlineData(0, 2)]  // Column out of range
        public void AddVehicle_InvalidParkingSpot_ReturnsFalse(int row, int col)
        {
            // Arrange
            Garage<Vehicle> garage = new Garage<Vehicle>(2, 2); // Example garage with 2x2 spots
            Vehicle vehicleToAdd = new Car(4, "Red", "ABC123", "Petrol");

            // Act
            bool added = garage.AddVehicle(vehicleToAdd, row, col);

            // Assert
            Assert.False(added);
            Assert.NotEqual(vehicleToAdd, garage.GetCar(row, col)); // Ensure the vehicle is not added to invalid spot
        }
    }
}
