namespace ParadiseApi.Dto
{
    public class ResponceVideoDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VideoId { get; set; }
        public bool IsLike { get; set; } = false;
        public bool IsDisLike { get; set; } = false;
        public DateTime DateResponce { get; set; }
    }
}
