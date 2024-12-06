using System;
using WaterMonitoringSystem.DAL.Repositories.Interfaces;

namespace WaterMonitoringSystem.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        ISensorRepository Sensors { get; }
        IMonitoringDataRepository MonitoringData { get; }
        void Save();
    }
}