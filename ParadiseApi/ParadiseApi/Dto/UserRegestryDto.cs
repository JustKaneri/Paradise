using System.ComponentModel.DataAnnotations;

namespace ParadiseApi.Dto
{
    public class UserRegestryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        public DateTime DateRegestry { get; set; }
    }
}
