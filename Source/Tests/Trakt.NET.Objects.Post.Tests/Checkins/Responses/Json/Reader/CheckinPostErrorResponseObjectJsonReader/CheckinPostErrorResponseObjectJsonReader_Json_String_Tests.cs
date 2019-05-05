namespace TraktNet.Objects.Post.Tests.Checkins.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Checkins.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.JsonReader")]
    public partial class CheckinPostErrorResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CheckinPostErrorResponseObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new CheckinPostErrorResponseObjectJsonReader();

            var checkinErrorResponse = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            checkinErrorResponse.Should().NotBeNull();
            checkinErrorResponse.ExpiresAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_CheckinPostErrorResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new CheckinPostErrorResponseObjectJsonReader();

            var checkinErrorResponse = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            checkinErrorResponse.Should().NotBeNull();
            checkinErrorResponse.ExpiresAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_CheckinPostErrorResponseObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new CheckinPostErrorResponseObjectJsonReader();

            var checkinErrorResponse = await jsonReader.ReadObjectAsync(default(string));
            checkinErrorResponse.Should().BeNull();
        }

        [Fact]
        public async Task Test_CheckinPostErrorResponseObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new CheckinPostErrorResponseObjectJsonReader();

            var checkinErrorResponse = await jsonReader.ReadObjectAsync(string.Empty);
            checkinErrorResponse.Should().BeNull();
        }
    }
}
