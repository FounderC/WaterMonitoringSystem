using WaterMonitoringSystem.BLL.DTO;

namespace WaterMonitoringSystem.BLL.Services
{
    public interface ISensorService
    {
        IEnumerable<SensorDTO> GetAllSensors();
    }
}