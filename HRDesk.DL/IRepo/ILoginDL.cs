using HRDesk.Models.Request;
using HRDesk.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDesk.DL.IRepo
{
    public interface ILoginDL
    {
        Task<LoginResponse> Login(LoginRequest loginRequest);
        Task<string> GetOTP(string Email);
    }
}
