using Microsoft.AspNetCore.Mvc;
using WaterMonitoringSystemTest.DAL.UnitOfWork;

namespace WaterMonitoringSystemTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _unitOfWork.Users.Find(u => u.Name == request.Username && u.Password == request.Password).FirstOrDefault();

            if (user != null)
            {
                return Ok(new { token = "valid_token" });
            }

            return Unauthorized("Invalid credentials");
        }

        public class LoginRequest
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}