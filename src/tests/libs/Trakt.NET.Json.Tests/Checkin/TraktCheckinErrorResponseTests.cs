namespace TraktNET.Json.Checkin
{
    public sealed class TraktCheckinErrorResponseTests
    {
        [Fact]
        public void TestTraktCheckinErrorResponseConstructor()
        {
            var checkinErrorResponse = new TraktCheckinErrorResponse();

            checkinErrorResponse.ExpiresAt.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktCheckinErrorResponseFromJson()
        {
            TraktCheckinErrorResponse? checkinErrorResponse = await TraktTestUtility.DeserializeJsonAsync<TraktCheckinErrorResponse>("Checkin\\errorresponse.json");

            checkinErrorResponse.ShouldNotBeNull();

            checkinErrorResponse!.ExpiresAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-08-04T22:21:29.000Z"));
        }
    }
}
