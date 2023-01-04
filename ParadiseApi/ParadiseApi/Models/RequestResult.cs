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
        public string Error 
        { 
            get 
            { 
               return Error; 
            } 
            set 
            {
                Error = value;
                Status = StatusRequest.Error;
            } 
        }

        public StatusRequest Status = StatusRequest.Ok;
    }
}
