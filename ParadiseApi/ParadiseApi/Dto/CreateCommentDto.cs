namespace ParadiseApi.Dto
{
    public class CreateCommentDto
    {
        public int VideoId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
