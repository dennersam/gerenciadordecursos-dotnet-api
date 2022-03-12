using GerenciadorDeCursos.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutheticationController : ControllerBase
    {

        private readonly JWTConfig JWTConfig;
        public AutheticationController(IOptions<JWTConfig> options)
        {
            JWTConfig = options.Value;
        }

        [HttpGet]
        public IActionResult GetToken()
        {
            var token = GenerateToken();

            var returnToken = new
            {
                Token = token
            };
            return Ok(returnToken);
        }

        private string GenerateToken()
        {
            IList<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Role, "Manager"));

            var handler = new JwtSecurityTokenHandler();
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWTConfig.Secret)), SecurityAlgorithms.HmacSha256Signature),
                Audience = "https://localhost:5001",
                Issuer = "CourseManager2022",
                Subject = new ClaimsIdentity(claims)
            };

            SecurityToken token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
    }
}
