using WaterMonitoringSystemTest.DAL.Entities;
using WaterMonitoringSystemTest.DAL.Repositories.Interfaces;

namespace WaterMonitoringSystemTest.DAL.Repositories.Impl
{
    public class MonitoringDataRepository : BaseRepository<MonitoringData>, IMonitoringDataRepository
    {
        public MonitoringDataRepository(WaterMonitoringContext context) : base(context)
        {
        }
    }
}