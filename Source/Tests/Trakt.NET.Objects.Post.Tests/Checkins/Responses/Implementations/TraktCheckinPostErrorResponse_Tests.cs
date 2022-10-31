namespace TraktNet.Objects.Post.Tests.Checkins.Responses.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Checkins.Responses;
    using TraktNet.Objects.Post.Checkins.Responses.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Checkins.Responses.Implementations")]
    public class TraktCheckinPostErrorResponse_Tests
    {
        [Fact]
        public void Test_TraktCheckinPostErrorResponse_Default_Constructor()
        {
            var checkinErrorResponse = new TraktCheckinPostErrorResponse();

            checkinErrorResponse.ExpiresAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCheckinPostErrorResponse_From_Json()
        {
            var jsonReader = new CheckinPostErrorResponseObjectJsonReader();
            var checkinErrorResponse = await jsonReader.ReadObjectAsync(JSON) as TraktCheckinPostErrorResponse;

            checkinErrorResponse.Should().NotBeNull();
            checkinErrorResponse.ExpiresAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""expires_at"": ""2016-04-01T12:44:40Z"",
              }";
    }
}
