using CalorieTracker.DTOs;        
using CalorieTracker.Models;
using CalorieTracker.Repositories; 
using System.Collections.Generic; 
using System.Threading.Tasks;    

namespace CalorieTracker.Services
{
    public class FoodEntryService : IFoodEntryService
    {
        private readonly IFoodEntryRepository _repository;

        public FoodEntryService(IFoodEntryRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<FoodEntry>> AddFoodEntryAsync(FoodEntry createDto)
        {
            await _repository.AddAsync(createDto);

            return new ApiResponse<FoodEntry>();
        }

        

        public async Task<IEnumerable<FoodEntry>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<FoodEntry?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(FoodEntry foodEntry)
        {
            await _repository.UpdateAsync(foodEntry);
        }
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<ApiResponse<FoodEntry>> AddFoodEntryAsync(CreateFoodEntryDto createDto)
        {
            var foodEntryModel = new FoodEntry
            {
                TenMonAn = createDto.TenMonAn,
                SoCalo = createDto.SoCalo,
                ThoiGianAn = createDto.NgayAn,
                
            };
            await _repository.AddAsync(foodEntryModel);

            return new ApiResponse<FoodEntry>();

            
            var response = new ApiResponse<FoodEntry>();
            response.Success = true;
            response.Data = foodEntryModel; 
            response.Message = "Thêm thành công!";
            response.Errors = null;
            return response;
        }
    }
    
}