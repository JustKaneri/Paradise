namespace ParadiseApi.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public ICollection<Users> Account { get; set; }
        public ICollection<Users> Subscriber { get; set; }

    }
}
