using AutoMapper;
using WaterMonitoringSystem.BLL.DTO;
using WaterMonitoringSystemTest.DAL.Entities;
using WaterMonitoringSystemTest.DAL.UnitOfWork;

namespace WaterMonitoringSystem.BLL.Services.Impl
{
    public class SensorService : ISensorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SensorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<SensorDTO> GetAllSensors()
        {
            var sensors = _unitOfWork.Sensors.GetAll();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Sensor, SensorDTO>()).CreateMapper();

            return mapper.Map<IEnumerable<Sensor>, List<SensorDTO>>(sensors);
        }
    }
}