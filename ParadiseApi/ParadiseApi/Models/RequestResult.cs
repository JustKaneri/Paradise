namespace ParadiseApi.Models
{
    public enum StatusRequest
    {
        Ok,
        Error
    }

    public class RequestResult <T>
    {
        public T Result { get; set; }
        public string OtherData { get; set; }
        public string Error { get; set; }

        public StatusRequest Status = StatusRequest.Ok;

        public void SetError(string name)
        {
            Error = name;
            Status = StatusRequest.Error;
        }
    }
}
