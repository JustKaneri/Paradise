namespace Paradise.Model.Models
{
    public class Logging
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string RequestBody { get; set; }
        public string RequestPath { get; set; }
        public int StatusCode { get; set; }
    }
}
