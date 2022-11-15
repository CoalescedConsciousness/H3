namespace BD_First.Models
{
    public class WeatherModel
    {
        public int Id { get; set; }
        public string Station { get; set; }
        public string Sunshine { get; set; }
        public string Radiation { get; set; }
        public string WindSpeedThreeMinute { get; set; }
        public string WindSpeedTenMinute { get; set; }
        public string WindSpeedDirection { get; set; }
    }
}
