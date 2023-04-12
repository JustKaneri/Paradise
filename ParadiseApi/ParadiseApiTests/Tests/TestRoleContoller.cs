namespace ParadiseApiTests.Tests
{
    public class TestRoleContoller
    {
        public readonly HttpClient _client;

        public TestRoleContoller()
        {
            _client = TestServer.GetClient();
        }

        [Fact]
        public async void TestNotAuth()
        {
            var response = await _client.GetAsync("api/v1/user-role/roles");
            Assert.Equal(401, (double)response.StatusCode);
        }


        [Fact]
        public async void TestAuthJustUser()
        {
            var tokens = await Authorize.GetTokens(_client, Authorize.TypeUser.User);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens.Token);
            var response = await _client.GetAsync("api/v1/user-role/roles");
            Assert.Equal(403, (double)response.StatusCode);
        }

        [Fact]
        public async void TestAuthAdmin()
        {
            var tokens = await Authorize.GetTokens(_client, Authorize.TypeUser.Admin);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens.Token);
            var response = await _client.GetAsync("api/v1/user-role/roles");
            Assert.Equal(200, (double)response.StatusCode);
        }

        [Fact]
        public async void TestContentAdminRole()
        {
            var tokens = await Authorize.GetTokens(_client, Authorize.TypeUser.Admin);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens.Token);
            var response = await _client.GetAsync("api/v1/user-role/roles");

            var result = await response.Content.ReadFromJsonAsync<List<UserRole>>();

            Assert.Equal(true, result.Where(r => r.Name.Equals("Administrator")).FirstOrDefault() != null);
        }

        [Fact]
        public async void TestContentUserRole()
        {
            var tokens = await Authorize.GetTokens(_client, Authorize.TypeUser.Admin);

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokens.Token);
            var response = await _client.GetAsync("api/v1/user-role/roles");

            var result = await response.Content.ReadFromJsonAsync<List<UserRole>>();

            Assert.Equal(true, result.Where(r => r.Name.Equals("Administrator")).FirstOrDefault() != null);
        }
    }
}