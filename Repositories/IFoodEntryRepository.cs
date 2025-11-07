using CalorieTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalorieTracker.Repositories
{
    public interface IFoodEntryRepository
    {
        Task AddAsync(FoodEntry foodEntry);

        Task<IEnumerable<FoodEntry>> GetByDateAsync(DateTime date);

        Task<FoodEntry?> GetByIdAsync(int id);

        Task UpdateAsync(FoodEntry foodEntry);

        Task DeleteAsync(int id);
        Task<IEnumerable<FoodEntry>> GetAllAsync();
    }
}