using System.Text.Json.Serialization;

namespace ParadiseApi.Models
{
    public class History
    {
        public int Id { get; set; }
        public DateTime DateWath { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public int VideoId { get; set; }
        [JsonIgnore]
        public Users User { get; set; }
        [JsonIgnore]
        public Video Video { get; set; }

    }
}
