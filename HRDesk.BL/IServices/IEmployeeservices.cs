using HRDesk.Models.Response;

namespace HRDesk.BL.IServices
{
    public interface IEmployeeservices
    {
        Task<List<EmployeeResponse>> GetAllEmployee();
        Task<EmployeeResponse> GetEmployeeById(int id);
        Task<bool> UpdateStarred(int id);
    }
}
