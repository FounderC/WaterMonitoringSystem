namespace WaterMonitoringSystem.BLL.DTO;

public class MonitoringDataDTO
{
    public int MonitoringDataID { get; set; }
    public int SensorID { get; set; }
    public string Data { get; set; }
    public DateTime Timestamp { get; set; }
}