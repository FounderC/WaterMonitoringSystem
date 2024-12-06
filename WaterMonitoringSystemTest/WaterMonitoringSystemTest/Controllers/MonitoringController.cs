using Microsoft.AspNetCore.Mvc;
using WaterMonitoringSystemTest.DAL.Entities;
using WaterMonitoringSystemTest.DAL.UnitOfWork;

namespace WaterMonitoringSystemTest.Controllers
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
            if (!User.Identity.IsAuthenticated)
                return Unauthorized("Ви не авторизовані!");

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

        [HttpGet("status")]
        public IActionResult GetMonitoringStatus()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized("Ви не авторизовані!");

            var recentData = _unitOfWork.MonitoringData.Find(m => m.Timestamp > DateTime.Now.AddMinutes(-5)).Any();
            if (recentData)
                return Ok("Моніторинг активний, дані надходять.");
            else
                return Ok("Моніторинг неактивний або нових даних немає.");
        }

        [HttpGet("check-data")]
        public IActionResult CheckMonitoringData()
        {
            if (!User.Identity.IsAuthenticated)
                return Unauthorized("Ви не авторизовані!");

            var data = _unitOfWork.MonitoringData.GetAll().ToList();
            return Ok(data);
        }

        private string ReadSensorData(Sensor sensor)
        {
            return "Стабільні дані";
        }
    }
}
