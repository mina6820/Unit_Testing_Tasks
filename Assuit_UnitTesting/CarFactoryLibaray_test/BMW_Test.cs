using CarFactoryLibrary;
using System;
using Xunit;

namespace CarFactoryLibrary2
{
    public class BMW_Test
    {
        [Fact]
        public void Equal_velocityAndMode_true()
        {
            // Arrange
            BMW bmw = new BMW { velocity = 0, drivingMode = DrivingMode.Forward };
            BMW bmw2 = new BMW { velocity = 0, drivingMode = DrivingMode.Forward };

            // Act
            bool result = bmw.Equals(bmw2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void InRange_velocity_distance_true()
        {
            // Arrange
            BMW bmw = new BMW { velocity = 10 };

            // Act
            double time = bmw.TimeToCoverDistance(100);

            // Assert
            Assert.InRange(time, 5, 15);
        }

        [Fact]
        public void OutRange_velocity_distance_true()
        {
            // Arrange
            BMW bmw = new BMW { velocity = 10 };

            // Act
            double time = bmw.TimeToCoverDistance(100);

            // Assert
            Assert.NotInRange(time, 5, 6);
        }

        [Fact]
        public void TestStringStop_Direction_Stop()
        {
            // Arrange
            BMW bmw = new BMW { drivingMode = DrivingMode.Stopped };

            // Act
            string result = bmw.GetDirection();

            // Assert
            Assert.StartsWith("S", result);
            Assert.Matches("^S.*", result);
        }

        [Fact]
        public void TestStringBackward_Direction_Backward()
        {
            // Arrange
            BMW bmw = new BMW { drivingMode = DrivingMode.Backward };

            // Act
            string result = bmw.GetDirection();

            // Assert
            Assert.Equal(DrivingMode.Backward.ToString(), result);
            Assert.EndsWith("rd", result);
            Assert.Contains("wa", result);
            Assert.DoesNotContain("mm", result);
        }

        [Fact]
        public void GetMyCar_callFunction_SameCar()
        {
            // Arrange
            BMW bmw = new BMW();
            BMW t2 = new BMW();

            // Act
            Car car = bmw.GetMyCar();

            // Assert
            Assert.Same(bmw, car);
            Assert.NotSame(t2, car);
        }

        [Fact]
        public void NewCar_CarTypeBMW_ReturnsBMWInstance()
        {
            // Act
            Car? car = CarFactory.NewCar(CarTypes.BMW);

            // Assert
            Assert.IsType<BMW>(car);
            Assert.IsAssignableFrom<Car>(new BMW());
        }

        [Fact]
        public void NewCar_CarTypeHonda_ThrowsNotImplementedException()
        {
            // Assert & Act
            Assert.Throws<NotImplementedException>(() =>
            {
                // Act
                Car? result = CarFactory.NewCar(CarTypes.Honda);
            });
        }
    }
}