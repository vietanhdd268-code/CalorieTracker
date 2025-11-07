namespace CalorieTracker.Models
{
    public class FoodEntry
    {
        public int Id { get; set; }
        public string TenMonAn { get; set; } = string.Empty;
        public int SoCalo { get; set; }
        public DateTime ThoiGianAn { get; set; }
    }
}