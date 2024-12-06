using Microsoft.EntityFrameworkCore;
using WaterMonitoringSystemTest.DAL.Entities;

namespace WaterMonitoringSystemTest.DAL
{
    public class WaterMonitoringContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<MonitoringData> MonitoringData { get; set; }

        public WaterMonitoringContext(DbContextOptions<WaterMonitoringContext> options) : base(options) { }
    }
}