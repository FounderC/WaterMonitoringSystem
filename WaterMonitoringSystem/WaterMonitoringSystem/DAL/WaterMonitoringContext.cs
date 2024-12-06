using Microsoft.EntityFrameworkCore;
using WaterMonitoringSystem.DAL.Entities;

namespace WaterMonitoringSystem.DAL
{
    public class WaterMonitoringContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<MonitoringData> MonitoringData { get; set; }

        public WaterMonitoringContext(DbContextOptions<WaterMonitoringContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=WaterMonitoringSystem;User=root;Password=your_password;",
                    new MySqlServerVersion(new Version(8, 0, 26)));
            }
        }
    }
}