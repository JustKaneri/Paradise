namespace Paradise.Model.Models
{
    public class ResponceVideo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public Video Video { get; set; }
        public Users User { get; set; }
        public bool IsLike { get; set; }
        public bool IsDisLike { get; set; }
        public DateTime DateResponce { get; set; }
    }
}
