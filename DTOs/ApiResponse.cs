namespace CalorieTracker.DTOs 
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; } = true;

        public T? Data { get; set; } 

        public string Message { get; set; } = string.Empty;

        public List<string>? Errors { get; set; }

        public static ApiResponse<T> CreateSuccess(T data, string message = "Thành công")
        {
            return new ApiResponse<T> { Success = true, Data = data, Message = message };
        }

        public static ApiResponse<T> CreateFailure(List<string> errors, string message = "Yêu cầu không hợp lệ")
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = message,
                Errors = errors
            };
        }
    }
}