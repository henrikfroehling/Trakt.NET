namespace TraktNet.Objects.Basic.Tests.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktRateLimitInfo_Tests
    {
        [Fact]
        public void Test_TraktRateLimitInfo_Default_Constructor()
        {
            var traktRateLimitInfo = new TraktRateLimitInfo();

            traktRateLimitInfo.Name.Should().BeNull();
            traktRateLimitInfo.Period.Should().BeNull();
            traktRateLimitInfo.Limit.Should().BeNull();
            traktRateLimitInfo.Remaining.Should().BeNull();
            traktRateLimitInfo.Until.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRateLimitInfo_From_Json()
        {
            var jsonReader = new RateLimitInfoObjectJsonReader();
            var traktRateLimitInfo = await jsonReader.ReadObjectAsync(JSON) as TraktRateLimitInfo;

            traktRateLimitInfo.Should().NotBeNull();
            traktRateLimitInfo.Name.Should().Be("UNAUTHED_API_GET_LIMIT");
            traktRateLimitInfo.Period.Should().Be(300);
            traktRateLimitInfo.Limit.Should().Be(1000);
            traktRateLimitInfo.Remaining.Should().Be(250);
            traktRateLimitInfo.Until.Should().Be(DateTime.Parse("2020-10-10T00:24:00.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""name"": ""UNAUTHED_API_GET_LIMIT"",
                ""period"": 300,
                ""limit"": 1000,
                ""remaining"": 250,
                ""until"": ""2020-10-10T00:24:00.000Z""
              }";
    }
}
