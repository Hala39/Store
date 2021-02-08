using System.Threading.Tasks;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Wrappers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _auth;

        public AuthController(IAuthRepository auth)
        {
            _auth = auth;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> CustomerRegister(UserRegisterDto request)
        {
            ServiceResponse<string> response = await _auth.Register(
                new User { Email = request.Email, First_Name = request.First_Name, Last_Name = request.Last_Name}, request.Password
            );
            if(!response.Success) {
                return BadRequest(response);
            }
                return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> CustomerLogin(UserLoginDto request)
        {
            AuthResponse<string> response = await _auth.Login(request.Email, request.Password);
            
            if(!response.Success) {
                return BadRequest(response);
            }
                return Ok(response);
        }
    }
}