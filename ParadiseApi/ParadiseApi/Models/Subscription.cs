namespace ParadiseApi.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public int SubscriberId { get; set; }

        public Users Account { get; set; }
        public Users Subscriber { get; set; }

    }
}
