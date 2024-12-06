namespace WaterMonitoringSystem.DAL.Entities
{
    public class Sensor
    {
        public int SensorID { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
        public DateTime Timestamp { get; set; }
    }
}