namespace ParadiseApi.Models
{
    public class UserRole
    {
        public int Id { get; set; }
        public ICollection<Users> Users {get; set; }
        public string Name { get; set; } 
    }
}
