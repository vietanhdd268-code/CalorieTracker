namespace CalorieTracker.DTOs
{
    public class CalorieStatusResponse
    {
        public long TotalCalories { get; set; } 
        public string Message { get; set; }   = string.Empty;
        public bool IsOverLimit { get; set; } 
    }
}