using WaterMonitoringSystemTest.DAL.Repositories.Interfaces;

namespace WaterMonitoringSystemTest.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ISensorRepository Sensors { get; }
        IMonitoringDataRepository MonitoringData { get; }
        void Save();
    }
}