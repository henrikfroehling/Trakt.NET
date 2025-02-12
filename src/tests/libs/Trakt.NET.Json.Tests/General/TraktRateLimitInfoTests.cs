namespace TraktNET.Json.General
{
    public sealed class TraktRateLimitInfoTests
    {
        [Fact]
        public void TestTraktRateLimitInfoConstructor()
        {
            var rateLimitInfo = new TraktRateLimitInfo();

            rateLimitInfo.Name.ShouldBeNull();
            rateLimitInfo.Period.ShouldBeNull();
            rateLimitInfo.Limit.ShouldBeNull();
            rateLimitInfo.Remaining.ShouldBeNull();
            rateLimitInfo.Until.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktRateLimitInfoFromJson()
        {
            TraktRateLimitInfo? rateLimitInfo = await TraktTestUtility.DeserializeJsonAsync<TraktRateLimitInfo>("General\\ratelimitinfo.json");

            rateLimitInfo.ShouldNotBeNull();

            rateLimitInfo!.Name.ShouldBe("UNAUTHED_API_GET_LIMIT");
            rateLimitInfo!.Period.ShouldBe(300U);
            rateLimitInfo!.Limit.ShouldBe(1000U);
            rateLimitInfo!.Remaining.ShouldBe(500U);
            rateLimitInfo!.Until.ShouldBe(TestUtility.ParseUTCDateTime("2024-08-04T00:24:00Z"));
        }
    }
}
