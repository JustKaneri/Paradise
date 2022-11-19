namespace ParadiseApi.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateRegestry { get; set; }
        public UserRole Role { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<ResponceVideo> Responces { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Users> Accounts { get; set; }
        public ICollection<Users> Subscribers { get; set; }
    }
}
