using CalorieTracker.DTOs; 
using CalorieTracker.Models; 

namespace CalorieTracker.Services
{
    public interface IAuthService
    {
        Task<ApiResponse<User>> RegisterAsync(string username, string password);

        Task<ApiResponse<string>> LoginAsync(string username, string password);
    }
}