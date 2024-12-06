using WaterMonitoringSystem.DAL.Entities;
using WaterMonitoringSystem.DAL.Repositories.Interfaces;

namespace WaterMonitoringSystem.DAL.Repositories.Impl
{
    public class MonitoringDataRepository : BaseRepository<MonitoringData>, IMonitoringDataRepository
    {
        public MonitoringDataRepository(WaterMonitoringContext context) : base(context)
        {
        }
    }
}