using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParadiseApiTests
{
    public class TestUserController
    {
        private readonly HttpClient _client;
        public TestUserController()
        {
            _client = TestServer.GetClient();
        }

        [Fact]
        public async void TestAllUser()
        {
            var response = await _client.GetAsync("api/v1/users");
            Assert.Equal(401, (double)response.StatusCode);
        }

        [Fact]
        public async void TestAllUserWithRightsNotAdmin()
        {
            var tokens = await Authorize.GetTokens(_client, Authorize.TypeUser.User);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens.Token);
            var response = await _client.GetAsync("api/v1/users");
            Assert.Equal(403, (double)response.StatusCode);
        }

        [Fact]
        public async void TestAllUserWithRightstAdmin()
        {
            var tokens = await Authorize.GetTokens(_client, Authorize.TypeUser.Admin);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens.Token);
            var response = await _client.GetAsync("api/v1/users");
            Assert.Equal(200, (double)response.StatusCode);
        }

        [Theory]
        [InlineData(100)]
        public async void TestGetNotExistSelectUser(int id)
        {
            var response = await _client.GetAsync("api/v1/users/"+id);
            Assert.Equal(404, (double)response.StatusCode);
        }

        [Theory]
        [InlineData(1)]
        public async void TestGetExistSelectUser(int id)
        {
            var response = await _client.GetAsync("api/v1/users/" + id);
            Assert.Equal(200, (double)response.StatusCode);
        }

        [Fact]
        public async void TestGetNotAuthUser()
        {
            var response = await _client.GetAsync("api/v1/users/auth");
            Assert.Equal(401, (double)response.StatusCode);
        }

        [Fact]
        public async void TestGetAuthUser()
        {
            var tokens = await Authorize.GetTokens(_client, Authorize.TypeUser.User);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens.Token);

            var response = await _client.GetAsync("api/v1/users/auth");
            Assert.Equal(200, (double)response.StatusCode);
        }
    }
}
