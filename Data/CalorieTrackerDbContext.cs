using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CalorieTracker.Models; 

namespace CalorieTracker.Data
{
    public class CalorieTrackerDbContext : IdentityDbContext<User>
    {
        public CalorieTrackerDbContext(DbContextOptions<CalorieTrackerDbContext> options) : base(options)
        {
        }
        public DbSet<FoodEntry> FoodEntries { get; set; }

    }
}   