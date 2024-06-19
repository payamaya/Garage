using Xunit;
using static Garage.Helpers.InputHelper;

namespace Helpers.Tests
{
    public class GetCylinderVolumeTest
    {
       
       //Arrange
        [Theory]
        [InlineData(10, 2.5, 196.350)]
        [InlineData(5, 1.2, 22.619)]
        [InlineData(7, 3.3, 239.761)]
        public void CalculateVolume_ReturnsCorrectVolume(double height, double radius, double expectedVolume)
        {
            //Act
          double result = CylinderCalculater.CalculateVolume(height, radius);

            //Assert
            Assert.Equal(expectedVolume, result);
        }

    }
}
