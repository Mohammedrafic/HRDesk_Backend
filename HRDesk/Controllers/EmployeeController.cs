using HRDesk.BL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HRDesk.Controllers
{
    [Route("[Controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeservices _context;
        public EmployeeController(IEmployeeservices context)
        {
            _context = context;
        }
        [HttpGet("api/GetEmployeeList")]
        public async Task<IActionResult> EmployeeList()
        {
            var response = await _context.GetAllEmployee();
            return Ok(response);
        }

        [HttpGet("api/GetEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var response = await _context.GetEmployeeById(id);
            return Ok(response);
        }

        [HttpGet("api/UpdateStarred/{id}")]
        public async Task<IActionResult> UpdateStarred(int id)
        {
            var response = await _context.UpdateStarred(id);
            return Ok(response);
        }
    }
}
