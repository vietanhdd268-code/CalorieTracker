using CalorieTracker.Data;
using CalorieTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTracker.Repositories
{
    public class FoodEntryRepository : IFoodEntryRepository
    {
        private readonly CalorieTrackerDbContext _context;

        public FoodEntryRepository(CalorieTrackerDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(FoodEntry foodEntry)
        {
            await _context.FoodEntries.AddAsync(foodEntry);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entryToDelete = await _context.FoodEntries.FindAsync(id);
            if (entryToDelete != null)
            {
                _context.FoodEntries.Remove(entryToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<FoodEntry>> GetAllAsync()
        {
            return await _context.FoodEntries.ToListAsync();
        }

        public async Task<IEnumerable<FoodEntry>> GetByDateAsync(DateTime date)
        {
            var entries = await _context.FoodEntries
                .Where(entry => entry.ThoiGianAn.Date == date.Date)
                .ToListAsync();

            return entries; 
        }

        public async Task<FoodEntry?> GetByIdAsync(int id)
        {
            var entry = await _context.FoodEntries.FindAsync(id);
            return entry;
        }

        public async Task UpdateAsync(FoodEntry foodEntry)
        {
            _context.FoodEntries.Update(foodEntry);
            await _context.SaveChangesAsync();
        }
    }
}