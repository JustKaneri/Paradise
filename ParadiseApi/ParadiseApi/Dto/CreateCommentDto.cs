using System.ComponentModel.DataAnnotations;

namespace ParadiseApi.Dto
{
    public class CreateCommentDto
    {
        [Required]
        public int VideoId { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
