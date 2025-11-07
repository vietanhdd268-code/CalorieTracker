
using CalorieTracker.Models;
using CalorieTracker.Repositories; 
using CalorieTracker.DTOs;        
using BCrypt.Net;                 
using System.Collections.Generic; 
using System.Threading.Tasks;     

namespace CalorieTracker.Services
{
    // "Kế thừa" Interface
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ApiResponse<User>> RegisterAsync(string username, string password)
        {
            var existingUser = await _userRepository.GetUserByUsernameAsync(username);
            if (existingUser != null)
            {
                return ApiResponse<User>.CreateFailure(new List<string> { "Username đã tồn tại!" });
            }
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var newUser = new User
            {
                Username = username,
                PasswordHash = hashedPassword
            };

            await _userRepository.AddUserAsync(newUser);

            return ApiResponse<User>.CreateSuccess(newUser, "Đăng ký thành công!");
        }
        public async Task<ApiResponse<string>> LoginAsync(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null)
            {
                return ApiResponse<string>.CreateFailure(new List<string> { "Sai username hoặc password!" });
            }
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (!isPasswordValid)
            {
                return ApiResponse<string>.CreateFailure(new List<string> { "Sai username hoặc password!" });
            }
            string fakeToken = "day_la_cai_token_gia_sau_nay_thay_bang_JWT";

            return ApiResponse<string>.CreateSuccess(fakeToken, "Đăng nhập thành công!");
        }
    }
}