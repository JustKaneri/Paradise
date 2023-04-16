using Paradise.Data.Data;
using ParadiseApi.Interfaces;

namespace ParadiseApi.Repository
{
    public class ApiRepository: IApiRepository
    {
        private readonly DataContext _context;

        public ApiRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<RequestResult<string>> StatusApi()
        {
            RequestResult<string> requestResult = new RequestResult<string>();

            var conn =  await _context.Database.CanConnectAsync();

            if (conn)
                requestResult.Result = "worked";
            else
                requestResult.Result = "not worked";

            return requestResult;
        }

        public RequestResult<List<string>> VersionApi()
        {
            RequestResult<List<string>> requestResult = new RequestResult<List<string>>();

            List<string> version = new List<string>() {"v1"};

            requestResult.Result = version;

            return requestResult;
        }
    }
}
