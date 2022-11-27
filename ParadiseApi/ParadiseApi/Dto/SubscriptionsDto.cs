using ParadiseApi.Models;

namespace ParadiseApi.Dto
{
    public class SubscriptionsDto
    {
        public int Id { get; set; }
        public UserDto Subscriber { get; set; }
    }
}
