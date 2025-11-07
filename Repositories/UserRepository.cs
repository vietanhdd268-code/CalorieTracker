using CalorieTracker.Models; 
using CalorieTracker.Data;    
using Microsoft.EntityFrameworkCore; 

namespace CalorieTracker.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CalorieTrackerDbContext _context;

        public UserRepository(CalorieTrackerDbContext context)
        {
            _context = context;
        }
        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}