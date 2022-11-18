namespace BD_First.Models
{
    /// <summary>
    /// Model not yet implemented, please ignore.
    /// Note example properties (equivalents exist in the ingested data) are far from exhaustive of all data in datasets
    /// </summary>
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
