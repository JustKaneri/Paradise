using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParadiseApiTests
{
    internal class TestServer
    {
        public static HttpClient GetClient()
        {
            var server = new WebApplicationFactory<Program>();
            HttpClient _client = server.CreateClient();

            return _client;
        }
    }
}
