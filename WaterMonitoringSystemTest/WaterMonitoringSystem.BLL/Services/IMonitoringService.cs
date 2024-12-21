using WaterMonitoringSystem.BLL.DTO;

namespace WaterMonitoringSystem.BLL.Services
{
    public interface IMonitoringService
    {
        IEnumerable<MonitoringDataDTO> GetRecentMonitoringData(int minutes);
        void StartMonitoring();
    }
}