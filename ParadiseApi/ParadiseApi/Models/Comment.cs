namespace ParadiseApi.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public Video Video { get; set; }
        public Users User { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
