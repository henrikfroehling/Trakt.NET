namespace TraktNET.Json
{
    public sealed class TMDBErrorResponseTests
    {
        [Fact]
        public void TestTMDBErrorResponseConstructor()
        {
            var errorResponse = new TMDBErrorResponse();

            errorResponse.Success.ShouldBeNull();
            errorResponse.StatusCode.ShouldBeNull();
            errorResponse.StatusMessage.ShouldBeNull();
        }

        [Fact]
        public async Task TestTMDBErrorResponseFromJson()
        {
            TMDBErrorResponse? errorResponse = await TMDBTestUtility.DeserializeJsonAsync<TMDBErrorResponse>("errorresponse.json");

            errorResponse.ShouldNotBeNull();

            errorResponse!.Success.ShouldBe(false);
            errorResponse!.StatusCode.ShouldBe(6U);
            errorResponse!.StatusMessage.ShouldBe("Invalid id: The pre-requisite id is invalid or not found.");
        }
    }
}
