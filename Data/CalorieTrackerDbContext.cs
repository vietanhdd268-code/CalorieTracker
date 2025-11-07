using Microsoft.EntityFrameworkCore;
using CalorieTracker.Models; 

namespace CalorieTracker.Data
{
    public class CalorieTrackerDbContext : DbContext 
    {
        public CalorieTrackerDbContext(DbContextOptions<CalorieTrackerDbContext> options) : base(options)
        {
        }
        public DbSet<FoodEntry> FoodEntries { get; set; }
        public DbSet<User> Users { get; set; }
    }
}   