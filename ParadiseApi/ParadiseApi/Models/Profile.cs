using System.Text.Json.Serialization;

namespace ParadiseApi.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        [JsonIgnore]
        public Users User { get; set; }
        public string PathFon { get; set; }
        public string PathAvatar { get; set; }  
 
    }
}
