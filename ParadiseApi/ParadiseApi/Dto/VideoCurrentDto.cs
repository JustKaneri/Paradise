namespace ParadiseApi.Dto
{
    public class VideoCurrentDto : VideoDto
    {
       public List<CommentDto> Comments { get; set; }
    }
}
