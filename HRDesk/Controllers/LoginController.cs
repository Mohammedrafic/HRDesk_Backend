using HRDesk.BL.IServices;
using HRDesk.BL.Services;
using HRDesk.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace HRDesk.Controllers
{
    [Route("[Controller]")]
    public class LoginController : Controller
    {
        private readonly ILoginServices _loginServices;
        public LoginController(ILoginServices loginServices)
        {
            _loginServices = loginServices;
        }
        [HttpPost("api/login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest loginRequest)
        {
            var response = await _loginServices.Login(loginRequest);
            return Ok(response);
        }

        [HttpGet("api/GetOTP")]
        public async Task<IActionResult> GetOTP(string Email)
        {
            var response = await _loginServices.GetOTP(Email);
            if (response == "")
            {
                return Ok(new { Status = "Error" });
            }
            return Ok(new {result = response,Status = "Success"});
        }
    }
}
