namespace TraktNet.Objects.Tests.Post.Checkins.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Checkins.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.JsonReader")]
    public partial class CheckinPostErrorResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CheckinPostErrorResponseObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new CheckinPostErrorResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinErrorResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinErrorResponse.Should().NotBeNull();
                checkinErrorResponse.ExpiresAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_CheckinPostErrorResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new CheckinPostErrorResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinErrorResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                checkinErrorResponse.Should().NotBeNull();
                checkinErrorResponse.ExpiresAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CheckinPostErrorResponseObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new CheckinPostErrorResponseObjectJsonReader();

            var checkinErrorResponse = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            checkinErrorResponse.Should().BeNull();
        }

        [Fact]
        public async Task Test_CheckinPostErrorResponseObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new CheckinPostErrorResponseObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var checkinErrorResponse = await traktJsonReader.ReadObjectAsync(jsonReader);
                checkinErrorResponse.Should().BeNull();
            }
        }
    }
}
