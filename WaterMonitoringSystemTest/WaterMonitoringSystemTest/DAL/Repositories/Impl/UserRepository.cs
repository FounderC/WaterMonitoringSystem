using WaterMonitoringSystemTest.DAL.Entities;
using WaterMonitoringSystemTest.DAL.Repositories.Interfaces;

namespace WaterMonitoringSystemTest.DAL.Repositories.Impl
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(WaterMonitoringContext context) : base(context)
        {
        }
    }
}