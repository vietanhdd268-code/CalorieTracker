using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CalorieTracker.Services;
using CalorieTracker.Models;
using CalorieTracker.DTOs;

using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FoodEntriesController : ControllerBase
    {
        private readonly IFoodEntryService _foodEntryService;
        public FoodEntriesController(IFoodEntryService foodEntryService)
        {
            _foodEntryService = foodEntryService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFoodEntry(
            [FromBody] CreateFoodEntryDto createDto)
        {
            var response = await _foodEntryService.AddFoodEntryAsync(createDto);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEntries()
        {
            var entries = await _foodEntryService.GetAllAsync();
            return Ok(entries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntryById(int id)
        {
            var entry = await _foodEntryService.GetByIdAsync(id);

            if (entry == null)
            {
                return NotFound();
            }

            return Ok(entry);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntry(int id, [FromBody] FoodEntry foodEntry)
        {
            if (id != foodEntry.Id)
            {
                return BadRequest("ID không khớp, xem lại đi em zai!");
            }

            await _foodEntryService.UpdateAsync(foodEntry);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntry(int id)
        {
            await _foodEntryService.DeleteAsync(id);

            return NoContent();
        }
    }
}