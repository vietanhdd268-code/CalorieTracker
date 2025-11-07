using System.ComponentModel.DataAnnotations; 

namespace CalorieTracker.DTOs

{
    public class AuthRequestDto
    {
        [Required(ErrorMessage = "Điền Username đi em zai!")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Điền Password em zai eiii!")]

        [MinLength(8, ErrorMessage = "Password ngắn quá, phải ít nhất 8 ký tự!")]
        [RegularExpression(
    @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8}$",
    ErrorMessage = "Password phải có: 1 chữ hoa, 1 chữ thường, 1 số, 1 ký tự đặc biệt (@$!%*?&)!")]      
        public string Password { get; set; } = string.Empty;
    }
}