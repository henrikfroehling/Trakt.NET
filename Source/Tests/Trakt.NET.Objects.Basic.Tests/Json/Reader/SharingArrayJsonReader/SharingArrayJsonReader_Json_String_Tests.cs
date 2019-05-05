namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SharingArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new SharingArrayJsonReader();
            IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktSharings.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new SharingArrayJsonReader();
            IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(JSON_COMPLETE);

            traktSharings.Should().NotBeNull();
            ITraktSharing[] sharings = traktSharings.ToArray();

            sharings[0].Should().NotBeNull();
            sharings[0].Facebook.Should().BeTrue();
            sharings[0].Twitter.Should().BeTrue();
            sharings[0].Google.Should().BeTrue();
            sharings[0].Tumblr.Should().BeTrue();
            sharings[0].Medium.Should().BeTrue();
            sharings[0].Slack.Should().BeTrue();

            sharings[1].Should().NotBeNull();
            sharings[1].Facebook.Should().BeTrue();
            sharings[1].Twitter.Should().BeTrue();
            sharings[1].Google.Should().BeTrue();
            sharings[1].Tumblr.Should().BeTrue();
            sharings[1].Medium.Should().BeTrue();
            sharings[1].Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new SharingArrayJsonReader();
            IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

            traktSharings.Should().NotBeNull();
            ITraktSharing[] sharings = traktSharings.ToArray();

            sharings[0].Should().NotBeNull();
            sharings[0].Facebook.Should().BeTrue();
            sharings[0].Twitter.Should().BeTrue();
            sharings[0].Google.Should().BeTrue();
            sharings[0].Tumblr.Should().BeTrue();
            sharings[0].Medium.Should().BeTrue();
            sharings[0].Slack.Should().BeTrue();

            sharings[1].Should().NotBeNull();
            sharings[1].Facebook.Should().BeNull();
            sharings[1].Twitter.Should().BeTrue();
            sharings[1].Google.Should().BeTrue();
            sharings[1].Tumblr.Should().BeTrue();
            sharings[1].Medium.Should().BeTrue();
            sharings[1].Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new SharingArrayJsonReader();
            IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

            traktSharings.Should().NotBeNull();
            ITraktSharing[] sharings = traktSharings.ToArray();

            sharings[0].Should().NotBeNull();
            sharings[0].Facebook.Should().BeNull();
            sharings[0].Twitter.Should().BeTrue();
            sharings[0].Google.Should().BeTrue();
            sharings[0].Tumblr.Should().BeTrue();
            sharings[0].Medium.Should().BeTrue();
            sharings[0].Slack.Should().BeTrue();

            sharings[1].Should().NotBeNull();
            sharings[1].Facebook.Should().BeTrue();
            sharings[1].Twitter.Should().BeTrue();
            sharings[1].Google.Should().BeTrue();
            sharings[1].Tumblr.Should().BeTrue();
            sharings[1].Medium.Should().BeTrue();
            sharings[1].Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new SharingArrayJsonReader();
            IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

            traktSharings.Should().NotBeNull();
            ITraktSharing[] sharings = traktSharings.ToArray();

            sharings[0].Should().NotBeNull();
            sharings[0].Facebook.Should().BeNull();
            sharings[0].Twitter.Should().BeTrue();
            sharings[0].Google.Should().BeTrue();
            sharings[0].Tumblr.Should().BeTrue();
            sharings[0].Medium.Should().BeTrue();
            sharings[0].Slack.Should().BeTrue();

            sharings[1].Should().NotBeNull();
            sharings[1].Facebook.Should().BeTrue();
            sharings[1].Twitter.Should().BeTrue();
            sharings[1].Google.Should().BeTrue();
            sharings[1].Tumblr.Should().BeTrue();
            sharings[1].Medium.Should().BeTrue();
            sharings[1].Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new SharingArrayJsonReader();
            IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

            traktSharings.Should().NotBeNull();
            ITraktSharing[] sharings = traktSharings.ToArray();

            sharings[0].Should().NotBeNull();
            sharings[0].Facebook.Should().BeTrue();
            sharings[0].Twitter.Should().BeTrue();
            sharings[0].Google.Should().BeTrue();
            sharings[0].Tumblr.Should().BeTrue();
            sharings[0].Medium.Should().BeTrue();
            sharings[0].Slack.Should().BeTrue();

            sharings[1].Should().NotBeNull();
            sharings[1].Facebook.Should().BeNull();
            sharings[1].Twitter.Should().BeTrue();
            sharings[1].Google.Should().BeTrue();
            sharings[1].Tumblr.Should().BeTrue();
            sharings[1].Medium.Should().BeTrue();
            sharings[1].Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new SharingArrayJsonReader();
            IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);

            traktSharings.Should().NotBeNull();
            ITraktSharing[] sharings = traktSharings.ToArray();

            sharings[0].Should().NotBeNull();
            sharings[0].Facebook.Should().BeNull();
            sharings[0].Twitter.Should().BeTrue();
            sharings[0].Google.Should().BeTrue();
            sharings[0].Tumblr.Should().BeTrue();
            sharings[0].Medium.Should().BeTrue();
            sharings[0].Slack.Should().BeTrue();

            sharings[1].Should().NotBeNull();
            sharings[1].Facebook.Should().BeNull();
            sharings[1].Twitter.Should().BeTrue();
            sharings[1].Google.Should().BeTrue();
            sharings[1].Tumblr.Should().BeTrue();
            sharings[1].Medium.Should().BeTrue();
            sharings[1].Slack.Should().BeTrue();
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new SharingArrayJsonReader();
            IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(default(string));
            traktSharings.Should().BeNull();
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new SharingArrayJsonReader();
            IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(string.Empty);
            traktSharings.Should().BeNull();
        }
    }
}
