namespace TraktApiSharp.Tests.Objects.Post.Checkins.Responses.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Checkins.Responses;
    using TraktApiSharp.Objects.Post.Checkins.Responses.Implementations;
    using TraktApiSharp.Objects.Post.Checkins.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.Implementations")]
    public class TraktCheckinPostErrorResponse_Tests
    {
        [Fact]
        public void Test_TraktCheckinPostErrorResponse_Implements_ITraktCheckinPostErrorResponse_Interface()
        {
            typeof(TraktCheckinPostErrorResponse).GetInterfaces().Should().Contain(typeof(ITraktCheckinPostErrorResponse));
        }

        [Fact]
        public void Test_TraktCheckinPostErrorResponse_Default_Constructor()
        {
            var checkinErrorResponse = new TraktCheckinPostErrorResponse();

            checkinErrorResponse.ExpiresAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktCheckinPostErrorResponse_From_Json()
        {
            var jsonReader = new TraktCheckinPostErrorResponseObjectJsonReader();
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
