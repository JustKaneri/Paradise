namespace ParadiseApi.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discript { get; set; }
        public DateTime DateCreate { get; set; }
        public int CountWatch { get; set;}
        public string PathVideo { get; set; }
        public string PathPoster { get; set; }


    }
}
