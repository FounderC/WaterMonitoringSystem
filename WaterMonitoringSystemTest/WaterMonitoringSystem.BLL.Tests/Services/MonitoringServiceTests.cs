using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using WaterMonitoringSystem.BLL.Services.Impl;
using WaterMonitoringSystemTest.DAL.Entities;
using WaterMonitoringSystemTest.DAL.Repositories.Interfaces;
using WaterMonitoringSystemTest.DAL.UnitOfWork;
using WaterMonitoringSystem.CCL.Identity;

namespace WaterMonitoringSystem.BLL.Tests.Services
{
    public class MonitoringServiceTests
    {
        [Fact]
        public void Ctor_InputNull_ThrowArgumentNullException()
        {
            // Arrange
            IUnitOfWork nullUnitOfWork = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new MonitoringService(nullUnitOfWork));
        }

        [Fact]
        public void StartMonitoring_UserNotAdmin_ThrowMethodAccessException()
        {
            // Arrange
            var user = new Operator(1, "TestOperator");
            SecurityContext.SetUser(user);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var service = new MonitoringService(mockUnitOfWork.Object);

            // Act & Assert
            Assert.Throws<MethodAccessException>(() => service.StartMonitoring());
        }

        [Fact]
        public void StartMonitoring_ValidUser_SuccessfulExecution()
        {
            // Arrange
            var user = new Admin(1, "TestAdmin");
            SecurityContext.SetUser(user);

            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var testSensors = new List<Sensor>
            {
                new Sensor { SensorID = 1, Name = "Sensor1", Data = "OldData" },
                new Sensor { SensorID = 2, Name = "Sensor2", Data = "OldData" }
            };

            // Налаштування для ISensorRepository
            var mockSensorRepository = new Mock<ISensorRepository>();
            mockSensorRepository.Setup(r => r.GetAll()).Returns(testSensors);

            mockUnitOfWork.Setup(u => u.Sensors).Returns(mockSensorRepository.Object);
            mockUnitOfWork.Setup(u => u.MonitoringData.Create(It.IsAny<MonitoringData>()));
            mockUnitOfWork.Setup(u => u.Save());

            var service = new MonitoringService(mockUnitOfWork.Object);

            // Act
            service.StartMonitoring();

            // Assert
            mockUnitOfWork.Verify(u => u.MonitoringData.Create(It.IsAny<MonitoringData>()), Times.Exactly(2));
            mockUnitOfWork.Verify(u => u.Save(), Times.Once);
        }

        [Fact]
        public void GetRecentMonitoringData_UserNotAdmin_ThrowMethodAccessException()
        {
            // Arrange
            var user = new Operator(1, "TestOperator");
            SecurityContext.SetUser(user);

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            var service = new MonitoringService(mockUnitOfWork.Object);

            // Act & Assert
            Assert.Throws<MethodAccessException>(() => service.GetRecentMonitoringData(5));
        }

        [Fact]
        public void GetRecentMonitoringData_ValidInput_ReturnsCorrectData()
        {
            // Arrange
            var user = new Admin(1, "TestAdmin");
            SecurityContext.SetUser(user);

            var testMonitoringData = new List<MonitoringData>
            {
                new MonitoringData { MonitoringDataID = 1, SensorID = 1, Data = "TestData1", Timestamp = DateTime.Now },
                new MonitoringData { MonitoringDataID = 2, SensorID = 2, Data = "TestData2", Timestamp = DateTime.Now }
            };

            var mockUnitOfWork = new Mock<IUnitOfWork>();

            var mockMonitoringDataRepository = new Mock<IMonitoringDataRepository>();
            mockMonitoringDataRepository.Setup(r => r.Find(It.IsAny<Func<MonitoringData, bool>>()))
                .Returns(testMonitoringData);

            mockUnitOfWork.Setup(u => u.MonitoringData).Returns(mockMonitoringDataRepository.Object);

            var service = new MonitoringService(mockUnitOfWork.Object);

            // Act
            var result = service.GetRecentMonitoringData(5);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
    }
}