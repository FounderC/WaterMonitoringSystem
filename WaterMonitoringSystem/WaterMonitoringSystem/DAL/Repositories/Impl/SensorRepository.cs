using WaterMonitoringSystem.DAL.Entities;
using WaterMonitoringSystem.DAL.Repositories.Interfaces;

namespace WaterMonitoringSystem.DAL.Repositories.Impl
{
    public class SensorRepository : BaseRepository<Sensor>, ISensorRepository
    {
        public SensorRepository(WaterMonitoringContext context) : base(context)
        {
        }
    }
}