using WaterMonitoringSystemTest.DAL.Repositories.Impl;
using WaterMonitoringSystemTest.DAL.Repositories.Interfaces;

namespace WaterMonitoringSystemTest.DAL.UnitOfWork
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly WaterMonitoringContext _context;
        private UserRepository _userRepository;
        private SensorRepository _sensorRepository;
        private MonitoringDataRepository _monitoringDataRepository;

        public EFUnitOfWork(WaterMonitoringContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _userRepository ??= new UserRepository(_context);
        public ISensorRepository Sensors => _sensorRepository ??= new SensorRepository(_context);
        public IMonitoringDataRepository MonitoringData => _monitoringDataRepository ??= new MonitoringDataRepository(_context);

        public void Save() => _context.SaveChanges();

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}