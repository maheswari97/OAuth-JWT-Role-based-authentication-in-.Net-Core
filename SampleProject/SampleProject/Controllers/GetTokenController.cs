using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SampleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetTokenContoller : Controller
    {
        private IConfiguration _config;

        public GetTokenContoller(IConfiguration config)
        {
            _config = config;
        }

        [AllowAnonymous]
        [HttpGet]
        public string GetToken(string Role)
        {

            string Token = generateJwt(Role);
            return Token;
        }

        private string generateJwt(string Role)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //In claims can add the user deatils
            var claims = new[] {
                                 new Claim(JwtRegisteredClaimNames.Sub, "user_name"),
                                 new Claim(JwtRegisteredClaimNames.Email, "user_email"),
                                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                                 new Claim(ClaimTypes.Role,Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
