using static ParadiseApiTests.Authorize;

namespace ParadiseApiTests
{
    public class TestAuthController
    {
        private readonly HttpClient _client;

        public TestAuthController()
        {
            _client = TestServer.GetClient();
        }

        [Fact]
        public async void TestLogInNotExistUser()
        {
            UserLoginDto userLoginDto = new UserLoginDto();
            userLoginDto.Login = "1";
            userLoginDto.Password = "1";
   

            JsonContent content = JsonContent.Create(userLoginDto);

            var result = await _client.PostAsync("api/v1/authentication/login", content);

            Assert.Equal(400, (double)result.StatusCode);
        }

        [Fact]
        public async void TestLogInNullData()
        {
            UserLoginDto userLoginDto = new UserLoginDto();
            userLoginDto.Login = null;
            userLoginDto.Password = null;

            JsonContent content = JsonContent.Create(userLoginDto);

            var result = await _client.PostAsync("api/v1/authentication/login", content);

            Assert.Equal(400, (double)result.StatusCode);
        }

        [Fact]
        public async void TestLogInExistUser()
        {
            UserLoginDto userLoginDto = new UserLoginDto();
            userLoginDto.Login = "zzz";
            userLoginDto.Password = "zzz";

            JsonContent content = JsonContent.Create(userLoginDto);

            var result = await _client.PostAsync("api/v1/authentication/login", content);

            Assert.Equal(200, (double)result.StatusCode);
        }

        [Fact]
        public async void TestRefreshValidTokens()
        {
            var tokens = await Authorize.GetTokens(_client,TypeUser.User);

            JsonContent content = JsonContent.Create(tokens);

            var result = await _client.PostAsync("api/v1/authentication/refresh-token", content);

            Assert.Equal(200, (double)result.StatusCode);
        }

        [Fact]
        public async void TestRefreshNotValidTokens()
        {
            var tokens = await Authorize.GetTokens(_client, TypeUser.User);

            tokens.Token += "123";

            JsonContent content = JsonContent.Create(tokens);

            var result = await _client.PostAsync("api/v1/authentication/refresh-token", content);

            Assert.Equal(400, (double)result.StatusCode);
        }

        [Fact]
        public async void TestRevokedhValidTokens()
        {
            var tokens = await Authorize.GetTokens(_client, TypeUser.User);

            JsonContent content = JsonContent.Create(tokens);

            var result = await _client.PostAsync("api/v1/authentication/revoked-token", content);

            Assert.Equal(200, (double)result.StatusCode);
        }

        [Fact]
        public async void TestRevokedhNotValidTokens()
        {
            var tokens = await Authorize.GetTokens(_client, TypeUser.User);

            tokens.Token += "123";

            JsonContent content = JsonContent.Create(tokens);

            var result = await _client.PostAsync("api/v1/authentication/revoked-token", content);

            Assert.Equal(400, (double)result.StatusCode);
        }


        [Fact]
        public async void TestRegestryOcupedLogin()
        {
            UserRegestryDto userRegestryDto = new UserRegestryDto();
            userRegestryDto.Login = "zzz";
            userRegestryDto.Name = "dddd";
            userRegestryDto.Password = "ddd";
            userRegestryDto.ConfirmPassword = "ddd";

            JsonContent content = JsonContent.Create(userRegestryDto);

            var result = await _client.PostAsync("api/v1/authentication/regestry", content);

            Assert.Equal(400, (double)result.StatusCode);
        }

        [Fact]
        public async void TestRegestryOcupedName()
        {
            UserRegestryDto userRegestryDto = new UserRegestryDto();
            userRegestryDto.Login = "213ds";
            userRegestryDto.Name = "string";
            userRegestryDto.Password = "ddd";
            userRegestryDto.ConfirmPassword = "ddd";

            JsonContent content = JsonContent.Create(userRegestryDto);

            var result = await _client.PostAsync("api/v1/authentication/regestry", content);

            Assert.Equal(400, (double)result.StatusCode);
        }

        [Fact]
        public async void TestRegestryNotConfirmPassword()
        {
            UserRegestryDto userRegestryDto = new UserRegestryDto();
            userRegestryDto.Login = "213ds";
            userRegestryDto.Name = "stri312ng";
            userRegestryDto.Password = "ddd2";
            userRegestryDto.ConfirmPassword = "ddd";

            JsonContent content = JsonContent.Create(userRegestryDto);

            var result = await _client.PostAsync("api/v1/authentication/regestry", content);

            Assert.Equal(400, (double)result.StatusCode);
        }

        [Fact]
        public async void TestRegestryIsNull()
        {
            UserRegestryDto userRegestryDto = new UserRegestryDto();
            userRegestryDto.Login = null;
            userRegestryDto.Name = null;
            userRegestryDto.Password = null;
            userRegestryDto.ConfirmPassword = null;

            JsonContent content = JsonContent.Create(userRegestryDto);

            var result = await _client.PostAsync("api/v1/authentication/regestry", content);

            Assert.Equal(400, (double)result.StatusCode);
        }
    }
}
