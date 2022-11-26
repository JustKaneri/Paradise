namespace ParadiseApi.Dto
{
    public class UserRegestryDto
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateRegestry { get; set; }
        public int RoleId { get; set; }
    }
}
