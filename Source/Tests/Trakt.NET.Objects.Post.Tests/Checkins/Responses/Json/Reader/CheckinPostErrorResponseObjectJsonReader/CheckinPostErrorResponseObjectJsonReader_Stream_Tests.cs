namespace TraktNet.Objects.Post.Tests.Checkins.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Checkins.Responses;
    using TraktNet.Objects.Post.Checkins.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.JsonReader")]
    public partial class CheckinPostErrorResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CheckinPostErrorResponseObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new CheckinPostErrorResponseObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var checkinErrorResponse = await jsonReader.ReadObjectAsync(stream);

                checkinErrorResponse.Should().NotBeNull();
                checkinErrorResponse.ExpiresAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_CheckinPostErrorResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var jsonReader = new CheckinPostErrorResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var checkinErrorResponse = await jsonReader.ReadObjectAsync(stream);

                checkinErrorResponse.Should().NotBeNull();
                checkinErrorResponse.ExpiresAt.Should().BeNull();
            }
        }

        [Fact]
        public void Test_CheckinPostErrorResponseObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new CheckinPostErrorResponseObjectJsonReader();
            Func<Task<ITraktCheckinPostErrorResponse>> checkinErrorResponse = () => jsonReader.ReadObjectAsync(default(Stream));
            checkinErrorResponse.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_CheckinPostErrorResponseObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new CheckinPostErrorResponseObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var checkinErrorResponse = await jsonReader.ReadObjectAsync(stream);
                checkinErrorResponse.Should().BeNull();
            }
        }
    }
}
