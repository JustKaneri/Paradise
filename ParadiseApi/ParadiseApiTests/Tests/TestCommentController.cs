using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParadiseApiTests.Tests
{
    public class TestCommentController
    {
        private readonly HttpClient _client;

        public TestCommentController()
        {
            _client = TestServer.GetClient();
        }

        [Theory]
        [InlineData(0)]
        public async void TestGetAllCommentNotExistVideo(int id)
        {
            var result = await _client.GetAsync("api/v1/comment/comments?idVideo=" + id);

            Assert.Equal(400, (double)result.StatusCode);
        }

        [Theory]
        [InlineData(3)]
        public async void TestGetAllCommentExistVideo(int id)
        {
            var result = await _client.GetAsync("api/v1/comment/comments?idVideo=" + id);

            Assert.Equal(200, (double)result.StatusCode);
        }

        [Theory]
        [InlineData(15)]
        public async void TestGetAllNotExistCommentForVideo(int id)
        {
            var result = await _client.GetAsync("api/v1/comment/comments?idVideo=" + id);

            Assert.Equal(404, (double)result.StatusCode);
        }


        [Theory]
        [InlineData(3)]
        public async void TestCreateCommentNotContent(int id)
        {
            CreateCommentDto commentDto = new CreateCommentDto();
            commentDto.Content = null;
            commentDto.VideoId = id;

            JsonContent content = JsonContent.Create(commentDto);

            var tokens = await Authorize.GetTokens(_client, Authorize.TypeUser.User);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens.Token);

            var result = await _client.PostAsync("api/v1/comment/new-comment", content);

            Assert.Equal(400, (double)result.StatusCode);
        }

        [Fact]
        public async void TestCreateCommentNotExistVideo()
        {
            CreateCommentDto commentDto = new CreateCommentDto();
            commentDto.Content = "dawdaw";
            commentDto.VideoId = 0;

            JsonContent content = JsonContent.Create(commentDto);

            var tokens = await Authorize.GetTokens(_client, Authorize.TypeUser.User);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens.Token);

            var result = await _client.PostAsync("api/v1/comment/new-comment", content);

            Assert.Equal(400, (double)result.StatusCode);
        }
    }
}
