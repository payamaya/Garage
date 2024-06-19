using Xunit;
using Garage.Models; // Import the namespace where Car is defined

namespace Helpers.Tests
{
    public class CarTest
    {
        [Fact]
        public void Car_Constructor_ShouldInitializeProperties()
        {
            // Arrange
            int wheelNumber = 4;
            string color = "Red";
            string registrationNumber = "ABC123";
            string fuelType = "Bensin";

            // Act
            var car = new Car(wheelNumber, color, registrationNumber, fuelType);

            // Assert
            Assert.Equal(wheelNumber, car.WheelsNumber);
            Assert.Equal(color, car.Color);
            Assert.Equal(registrationNumber, car.RegistrationNumber);
            Assert.Equal(fuelType, car.FuelType);
            Assert.Equal(VehicleType.Car, car.Type); // Assuming Type is set in Vehicle base class
        }

        [Fact]
        public void Car_ToString_ReturnsCorrectFormat()
        {
            // Arrange
            var car = new Car(4, "Red", "ABC123", "Bensin");

            // Act
            string carString = car.ToString();

            // Assert
            Assert.Contains("Car", carString); // Check if the type is correctly included in the string
            Assert.Contains("WheelNumber: 4", carString); // Assuming base class ToString includes WheelNumber
            Assert.Contains("Color: Red", carString); // Assuming base class ToString includes Color
            Assert.Contains("RegistrationNumber: ABC123", carString); // Assuming base class ToString includes RegistrationNumber
            Assert.Contains("FuelType: Bensin", carString);
        }
    }
}
