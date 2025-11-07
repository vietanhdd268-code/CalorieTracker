using CalorieTracker.Models;


namespace CalorieTracker.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);

        Task<User?> GetUserByUsernameAsync(string username);
    }
}