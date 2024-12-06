using WaterMonitoringSystem.DAL.Entities;
using WaterMonitoringSystem.DAL.Repositories.Interfaces;

namespace WaterMonitoringSystem.DAL.Repositories.Impl
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(WaterMonitoringContext context) : base(context)
        {
        }
    }
}