using Microsoft.EntityFrameworkCore;
using Moq;
using WaterMonitoringSystemTest.DAL;
using WaterMonitoringSystemTest.DAL.Entities;
using WaterMonitoringSystemTest.DAL.Repositories.Impl;
using Xunit;

namespace DAL.Tests.Repositories
{
    public class MonitoringDataRepositoryTests
    {
        [Fact]
        public void Find_InputPredicate_CallsFindMethodOfDbSet()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WaterMonitoringContext>().Options;
            var mockContext = new Mock<WaterMonitoringContext>(options);
            var mockDbSet = new Mock<DbSet<MonitoringData>>();

            var testMonitoringData = new MonitoringData { MonitoringDataID = 1, Data = "Test Data" };
            var data = new List<MonitoringData> { testMonitoringData }.AsQueryable();

            mockDbSet.As<IQueryable<MonitoringData>>().Setup(m => m.Provider).Returns(data.Provider);
            mockDbSet.As<IQueryable<MonitoringData>>().Setup(m => m.Expression).Returns(data.Expression);
            mockDbSet.As<IQueryable<MonitoringData>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockDbSet.As<IQueryable<MonitoringData>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator);

            mockContext.Setup(c => c.Set<MonitoringData>()).Returns(mockDbSet.Object);

            var repository = new MonitoringDataRepository(mockContext.Object);

            // Act
            var result = repository.Find(m => m.MonitoringDataID == 1).FirstOrDefault();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.MonitoringDataID);
        }

        [Fact]
        public void Delete_InputId_CallsRemoveMethodOfDbSet()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<WaterMonitoringContext>().Options;
            var mockContext = new Mock<WaterMonitoringContext>(options);
            var mockDbSet = new Mock<DbSet<MonitoringData>>();

            var testMonitoringData = new MonitoringData { MonitoringDataID = 1, Data = "Test Data" };

            mockDbSet.Setup(m => m.Find(It.IsAny<int>())).Returns(testMonitoringData);

            mockContext.Setup(c => c.Set<MonitoringData>()).Returns(mockDbSet.Object);

            var repository = new MonitoringDataRepository(mockContext.Object);

            // Act
            repository.Delete(1);

            // Assert
            mockDbSet.Verify(dbSet => dbSet.Remove(It.Is<MonitoringData>(d => d == testMonitoringData)), Times.Once());
        }
    }
}
