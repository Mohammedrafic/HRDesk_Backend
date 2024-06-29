using HRDesk.BL.IServices;
using HRDesk.DL.IRepo;
using HRDesk.Models.Request;
using HRDesk.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRDesk.BL.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly ILoginDL _loginDL;
        public LoginServices(ILoginDL loginDL)
        {
            _loginDL = loginDL;
        }

        public async Task<string> GetOTP(string Email)
        {
            var response = await _loginDL.GetOTP(Email);
            return response;
        }

        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var response = await _loginDL.Login(loginRequest);
            return response;
        }
    }
}
