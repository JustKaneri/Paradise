using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParadiseApiTests.Tests
{
    public class TestHistoryController
    {
        private readonly HttpClient _client;

        public TestHistoryController()
        {
            _client = TestServer.GetClient();
        }

        [Fact]
        public async void TestGetHistoryNotAuht()
        {
            var result = await _client.GetAsync("api/v1/history");

            Assert.Equal(401, (double)result.StatusCode);
        }

        [Fact]
        public async void TestGetHistoryAuht()
        {
            var tokens = await Authorize.GetTokens(_client, Authorize.TypeUser.User);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens.Token);

            var result = await _client.GetAsync("api/v1/history");

            Assert.Equal(200, (double)result.StatusCode);
        }


        [Theory]
        [InlineData(0)]
        public async void TestCreateHistoryNotExistVideo(int id)
        {
            var tokens = await Authorize.GetTokens(_client, Authorize.TypeUser.User);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens.Token);

            var result = await _client.PostAsync("api/v1/history/create?idVideo" + id,null);

            Assert.Equal(400, (double)result.StatusCode);
        }

        [Theory]
        [InlineData(3)]
        public async void TestCreateHistoryNotAuth(int id)
        {
            var result = await _client.PostAsync("api/v1/history/create?idVideo" + id,null);

            Assert.Equal(401, (double)result.StatusCode);
        }
    }
}
