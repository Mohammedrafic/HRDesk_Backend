using HRDesk.DL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRDesk.Authentication
{
    public class UserController : Controller
    {
        private readonly DbfirstApproachContext _context;
        private readonly JWTTokenGeneratorModel _jwtTokenGeneratorModel;

        public UserController(DbfirstApproachContext context, IOptions<JWTTokenGeneratorModel> options)
        {
            _context = context;
            _jwtTokenGeneratorModel = options.Value;
        }

        [Route("Authentication")]
        [HttpPost]
        public IActionResult Authentication(string email, string password)
        {
            var user = _context.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            if (user == null)
                return Unauthorized();
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenkey = Encoding.UTF8.GetBytes(_jwtTokenGeneratorModel.SecurityKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Email,ClaimTypes.Role)
                }),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenkey), SecurityAlgorithms.HmacSha256),
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);
            string FinalToken = tokenhandler.WriteToken(token);

            return Ok(FinalToken);
        }
    }
}
