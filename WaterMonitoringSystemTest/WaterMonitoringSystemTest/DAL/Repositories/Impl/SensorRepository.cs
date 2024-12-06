using WaterMonitoringSystemTest.DAL.Entities;
using WaterMonitoringSystemTest.DAL.Repositories.Interfaces;

namespace WaterMonitoringSystemTest.DAL.Repositories.Impl
{
    public class SensorRepository : BaseRepository<Sensor>, ISensorRepository
    {
        public SensorRepository(WaterMonitoringContext context) : base(context)
        {
        }
    }
}