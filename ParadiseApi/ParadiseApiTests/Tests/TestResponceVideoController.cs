using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParadiseApiTests.Tests
{
    public class TestResponceVideoController
    {
        private readonly HttpClient _client;

        public TestResponceVideoController()
        {
            _client = TestServer.GetClient();
        }

        [Theory]
        [InlineData(0)]
        public async void TestGetCountResponceNotExistVideo(int id)
        {
            var result = await _client.GetAsync($"api/v1/responce-video/video/{id}/count-responce");

            Assert.Equal(400, (double)result.StatusCode);
        }

        [Theory]
        [InlineData(3)]
        public async void TestGetCountResponceExistVideo(int id)
        {
            var result = await _client.GetAsync($"api/v1/responce-video/video/{id}/count-responce");

            Assert.Equal(200, (double)result.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        public async void TestGettResponceNotExistVideo(int id)
        {
            var result = await _client.GetAsync($"api/v1/responce-video/video/{id}/info-responce");

            Assert.Equal(401, (double)result.StatusCode);
        }

        [Theory]
        [InlineData(3)]
        public async void TestGettResponceExistVideo(int id)
        {
            var result = await _client.GetAsync($"api/v1/responce-video/video/{id}/info-responce");

            Assert.Equal(401, (double)result.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        public async void TestGettResponceNotExistVideoAuth(int id)
        {

            var tokens = await Authorize.GetTokens(_client,Authorize.TypeUser.User);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens.Token);

            var result = await _client.GetAsync($"api/v1/responce-video/video/{id}/info-responce");

            Assert.Equal(400, (double)result.StatusCode);
        }

        [Theory]
        [InlineData(3)]
        public async void TestGettResponceExistVideoAuth(int id)
        {

            var tokens = await Authorize.GetTokens(_client, Authorize.TypeUser.User);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens.Token);

            var result = await _client.GetAsync($"api/v1/responce-video/video/{id}/info-responce");

            Assert.Equal(200, (double)result.StatusCode);
        }
    }
}
