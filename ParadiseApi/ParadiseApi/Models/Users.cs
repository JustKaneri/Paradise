using System.Text.Json.Serialization;

namespace ParadiseApi.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Profile Profile { get; set; }
        [JsonIgnore]
        public string Login { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public DateTime DateRegestry { get; set; }
        [JsonIgnore]
        public UserRole Role { get; set; }
        [JsonIgnore]
        public ICollection<Video> Videos { get; set; }
        [JsonIgnore]
        public ICollection<ResponceVideo> Responces { get; set; }
        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; }
        [JsonIgnore]
        public ICollection<Users> Accounts { get; set; }
        [JsonIgnore]
        public ICollection<Users> Subscribers { get; set; }
    }
}
