using ParadiseApi.Models;

namespace ParadiseApi.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserDto User { get; set; }
    }
}
