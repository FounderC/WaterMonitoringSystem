using Microsoft.AspNetCore.Mvc;
using WaterMonitoringSystem.DAL;
using WaterMonitoringSystem.DAL.Entities;
using WaterMonitoringSystem.DAL.UnitOfWork;

namespace WaterMonitoringSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitoringController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MonitoringController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("start")]
        public IActionResult StartMonitoring()
        {
            var sensors = _unitOfWork.Sensors.GetAll();
            foreach (var sensor in sensors)
            {
                var data = ReadSensorData(sensor);
                var monitoringData = new MonitoringData
                {
                    SensorID = sensor.SensorID,
                    Data = data,
                    Timestamp = DateTime.Now
                };
                _unitOfWork.MonitoringData.Create(monitoringData);
            }

            _unitOfWork.Save();
            return Ok("Моніторинг успішно запущено!");
        }

        private string ReadSensorData(Sensor sensor)
        {
            return "Стабільні дані"; // Симуляція зчитування даних з сенсора
        }
    }
}