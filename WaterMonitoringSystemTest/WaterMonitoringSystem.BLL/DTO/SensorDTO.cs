namespace WaterMonitoringSystem.BLL.DTO
{
    public class SensorDTO
    {
        public int SensorID { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public DateTime Timestamp { get; set; }
    }
}