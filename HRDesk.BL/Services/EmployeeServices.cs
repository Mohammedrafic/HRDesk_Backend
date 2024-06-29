using HRDesk.BL.IServices;
using HRDesk.DL.IRepo;
using HRDesk.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDesk.BL.Services
{
    public class EmployeeServices : IEmployeeservices
    {
        private readonly IEmployeeDL _context;
        public EmployeeServices(IEmployeeDL context)
        {
            _context = context;
        }
        public async Task<List<EmployeeResponse>> GetAllEmployee()
        {
            var response = await _context.GetAllEmployee();
            return response;
        }

        public async Task<EmployeeResponse> GetEmployeeById(int id)
        {
            var response = await _context.GetEmployeeById(id);
            return response;
        }

        public async Task<bool> UpdateStarred(int id)
        {
            var response = await _context.UpdateStarred(id);
            return response;
        }
    }
}
