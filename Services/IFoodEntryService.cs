using CalorieTracker.Models;
using CalorieTracker.DTOs; 
using System.Collections.Generic; 
using System.Threading.Tasks;  

namespace CalorieTracker.Services
{
    public interface IFoodEntryService
    {
        Task<ApiResponse<FoodEntry>> AddFoodEntryAsync(CreateFoodEntryDto createDto);

        Task<IEnumerable<FoodEntry>> GetAllAsync();
        Task<FoodEntry?> GetByIdAsync(int id); 
        Task UpdateAsync(FoodEntry foodEntry);
        Task DeleteAsync(int id);
    }
}