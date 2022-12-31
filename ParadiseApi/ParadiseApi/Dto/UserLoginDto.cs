using System.ComponentModel.DataAnnotations;

namespace ParadiseApi.Dto
{
    public class UserLoginDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
