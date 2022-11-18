namespace BD_First.Models
{
    /// <summary>
    /// Model used (surprisingly!) for ingestion of data; minimal extraction of data from the dataset, needed for recursive execution of the API call involved.
    /// </summary>
    public class IngestModel
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public DateTime Date { get; set; }
        public bool UsingTimer { get; set; }
    }
}
