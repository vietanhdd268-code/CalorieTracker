using CalorieTracker.Models;
using CalorieTracker.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CalorieTracker.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
       
        public AuthController(
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var userExists = await _userManager.FindByNameAsync(registerDto.Username!);
            if (userExists != null)
            {
                return BadRequest(new { Message = "Username đã tồn tại!" });
            }

            var userByEmailExists = await _userManager.FindByEmailAsync(registerDto.Email!);
            if (userByEmailExists != null)
            {
                return BadRequest(new { Message = "Email đã tồn tại!" });
            }
            User user = new()
            {
                Email = registerDto.Email,                                                                                                  
                SecurityStamp = Guid.NewGuid().ToString(), 
                UserName = registerDto.Username
            };

            try
            {
                var result = await _userManager.CreateAsync(user, registerDto.Password!);

                if (!result.Succeeded)
                {
                    return BadRequest(new { Message = "Tạo user thất bại!", Errors = result.Errors });
                }

                return Ok(new { Message = "Tạo user thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Message = "Đã xảy ra lỗi hệ thống!", Details = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username!);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password!))
            {
                var jwtToken = GenerateJwtToken(user);

                return Ok(new
                {
                    Message = "Đăng nhập thành công!",
                    Token = jwtToken
                });
            }

            return Unauthorized(new { Message = "Sai Username hoặc Password!" });
        }
        private string GenerateJwtToken(User user)
        {
            var secretKey = _configuration["JwtSettings:Secret"];
            var validIssuer = _configuration["JwtSettings:ValidIssuer"];
            var validAudience = _configuration["JwtSettings:ValidAudience"];

            if (string.IsNullOrEmpty(secretKey) || string.IsNullOrEmpty(validIssuer) || string.IsNullOrEmpty(validAudience))
            {
                throw new InvalidOperationException("Thiếu cấu hình JWT trong appsettings.json. Anh zai check lại file config đi!");
            }
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id), 
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), 
                new Claim(ClaimTypes.Name, user.UserName !), 
                new Claim(ClaimTypes.Email, user.Email !) 
            };
            var token = new JwtSecurityToken(
                issuer: validIssuer,
                audience: validAudience,
                expires: DateTime.Now.AddHours(1), 
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}