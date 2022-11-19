namespace ParadiseApi.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateRegestry { get; set; }
        public ICollection<UserRole> Role { get; set; }
    }
}
