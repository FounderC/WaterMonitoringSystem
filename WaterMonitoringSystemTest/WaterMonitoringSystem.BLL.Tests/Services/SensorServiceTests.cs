using Moq;
using WaterMonitoringSystem.BLL.Services.Impl;
using WaterMonitoringSystemTest.DAL.Entities;
using WaterMonitoringSystemTest.DAL.UnitOfWork;
using Xunit;

namespace WaterMonitoringSystem.BLL.Tests.Services
{
    public class SensorServiceTests
    {
        [Fact]
        public void GetAllSensors_ReturnsSensors()
        {
            // Arrange
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var mockSensors = new List<Sensor>
            {
                new Sensor { SensorID = 1, Name = "Sensor1", Data = "Data1", Timestamp = DateTime.Now },
                new Sensor { SensorID = 2, Name = "Sensor2", Data = "Data2", Timestamp = DateTime.Now }
            };

            mockUnitOfWork.Setup(u => u.Sensors.GetAll()).Returns(mockSensors);

            var service = new SensorService(mockUnitOfWork.Object);

            // Act
            var result = service.GetAllSensors();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
    }
}