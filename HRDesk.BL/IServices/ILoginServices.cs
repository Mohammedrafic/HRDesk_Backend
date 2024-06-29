using HRDesk.Models.Request;
using HRDesk.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDesk.BL.IServices
{
    public interface ILoginServices
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<string> GetOTP(string Email);
    }
}
