using AutoMapper;
using Azure;
using HRDesk.DL.Context;
using HRDesk.DL.IRepo;
using HRDesk.DL.Models.DB;
using HRDesk.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDesk.DL.Repo
{
    public class EmployeeDL : IEmployeeDL
    {
        private readonly DbfirstApproachContext _context;
        private readonly IMapper _mapper;
        public EmployeeDL(DbfirstApproachContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<EmployeeResponse>> GetAllEmployee()
        {
            var response = _mapper.Map<List<EmployeeResponse>>(await _context.Employees.ToListAsync());
            return response;
        }
        public async Task<EmployeeResponse> GetEmployeeById(int id)
        {
            var result = await _context.Employees.Where(x => x.Id == id).FirstOrDefaultAsync();
            var response = _mapper.Map<EmployeeResponse>(result);
            return response;
        }

        public async Task<bool> UpdateStarred(int id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                if (employee == null)
                {
                    return false;
                }

                employee.IsStarred = !employee.IsStarred;
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
