using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using System.Net;

namespace ParadiseApiTests
{
    public class TestRoleContoller
    {
        public readonly HttpClient _client;

        public TestRoleContoller()
        {
            var server = new WebApplicationFactory<Program>();
            _client = server.CreateClient();
        }
        
        [Fact]
        public async void TestNotAuth()
        {
            var response = await _client.GetAsync("api/v1/user-role/roles");
            var data = await response.Content.ReadAsStringAsync();
            Assert.Equal(401, (double)response.StatusCode);
        }
    }
}