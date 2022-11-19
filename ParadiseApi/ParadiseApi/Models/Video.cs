namespace ParadiseApi.Models
{
    public class Video
    {
        public int Id { get; set; }
        public Users User { get; set; }
        public string Name { get; set; }
        public string Discript { get; set; }
        public DateTime DateCreate { get; set; }
        public int CountWatch { get; set;}
        public string PathVideo { get; set; }
        public string PathPoster { get; set; }
        public ICollection<ResponceVideo> ResponceVideos { get; set; }
        public ICollection<Comment> Comments { get; set; }


    }
}
