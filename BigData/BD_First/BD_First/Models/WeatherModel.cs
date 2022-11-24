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
        public float WindMean { get; set; }
        public float WindDir { get; set; }
        public float WindMax10 { get; set; }
        public float WindMax3 { get; set; }
    }
}
