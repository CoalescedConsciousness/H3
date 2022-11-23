namespace BD_First.Models
{
    /// <summary>
    /// Model not yet implemented, please ignore.
    /// Note example properties (equivalents exist in the ingested data) are far from exhaustive of all data in datasets
    /// </summary>
    public class WeatherModel
    {
        public int Id { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; } 
        public DateTime Timestamp { get; set; }
        public string WindMean { get; set; }
        public string WindDir { get; set; }
        public string WindMax10 { get; set; }
        public string WindMax3 { get; set; }
    }
}
