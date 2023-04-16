namespace ParadiseApi.Interfaces
{
    public interface IApiRepository
    {
        public Task<RequestResult<string>> StatusApi();

        public RequestResult<List<string>> VersionApi();
    }
}
