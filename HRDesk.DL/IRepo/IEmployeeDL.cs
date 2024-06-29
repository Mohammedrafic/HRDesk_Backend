using HRDesk.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDesk.DL.IRepo
{
    public interface IEmployeeDL
    {
        Task<List<EmployeeResponse>> GetAllEmployee();
        Task<EmployeeResponse> GetEmployeeById(int id);
        Task<bool> UpdateStarred(int id);
    }
}
