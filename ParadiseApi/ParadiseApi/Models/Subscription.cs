namespace ParadiseApi.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public Users Account { get; set; }
        public Users Subscriber { get; set; }

    }
}
