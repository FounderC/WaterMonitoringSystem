using AutoMapper;
using WaterMonitoringSystem.BLL.DTO;
using WaterMonitoringSystem.CCL.Identity;
using WaterMonitoringSystemTest.DAL.Entities;
using WaterMonitoringSystemTest.DAL.UnitOfWork;

namespace WaterMonitoringSystem.BLL.Services.Impl
{
    public class MonitoringService : IMonitoringService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MonitoringService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public IEnumerable<MonitoringDataDTO> GetRecentMonitoringData(int minutes)
        {
            var user = SecurityContext.GetUser();
            if (user.GetType() != typeof(Admin))
                throw new MethodAccessException("Access denied");

            var recentData = _unitOfWork.MonitoringData
                .Find(m => m.Timestamp >= DateTime.Now.AddMinutes(-minutes));

            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<MonitoringData, MonitoringDataDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<MonitoringData>, List<MonitoringDataDTO>>(recentData);
        }

        public void StartMonitoring()
        {
            var user = SecurityContext.GetUser();
            if (user.GetType() != typeof(Admin))
                throw new MethodAccessException("Access denied");

            var sensors = _unitOfWork.Sensors.GetAll();

            foreach (var sensor in sensors ?? new List<Sensor>())
            {
                var data = "Simulated Data"; 
                var monitoringData = new MonitoringData
                {
                    SensorID = sensor.SensorID,
                    Data = data,
                    Timestamp = DateTime.Now
                };
                _unitOfWork.MonitoringData.Create(monitoringData);
            }

            _unitOfWork.Save();
        }
    }
}