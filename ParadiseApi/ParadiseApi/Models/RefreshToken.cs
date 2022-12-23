namespace ParadiseApi.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public int UserId { get; set;}
        public string Token { get; set; }
        public int JwtId { get; set; }
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime AddeDate { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
