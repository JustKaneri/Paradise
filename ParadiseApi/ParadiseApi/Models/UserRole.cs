using System.Text.Json.Serialization;

namespace ParadiseApi.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        [JsonIgnore]
        public ICollection<Users> Users {get; set; }
        public string Name { get; set; } 
    }
}
