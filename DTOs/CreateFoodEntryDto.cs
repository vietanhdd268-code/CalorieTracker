using System.ComponentModel.DataAnnotations;


namespace CalorieTracker.DTOs
{
    public class CreateFoodEntryDto
    {
        [Required(ErrorMessage = "Tên món ăn không được để trống")]
        public string TenMonAn { get; set; } = string.Empty;
        [Range(1, int.MaxValue, ErrorMessage = "Số calo phải lớn hơn 0")]
        public int SoCalo { get; set; }
        public DateTime NgayAn { get; set; }
    }
}