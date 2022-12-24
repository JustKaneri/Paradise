namespace ParadiseApi.Models
{
    public class RequestResult <T>
    {
        public T Result { get; set; }
        public string Error { get; set; }
    }
}
