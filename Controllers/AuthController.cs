using CalorieTracker.Services; 
using CalorieTracker.DTOs;    
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks; 

namespace CalorieTracker.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")] 
        public async Task<IActionResult> Register([FromBody] AuthRequestDto requestDto)
        {
            var response = await _authService.RegisterAsync(requestDto.Username, requestDto.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("login")] 
        public async Task<IActionResult> Login([FromBody] AuthRequestDto requestDto)
        {
            var response = await _authService.LoginAsync(requestDto.Username, requestDto.Password);

            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}