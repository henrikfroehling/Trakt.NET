namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
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
        public async Task Test_SharingArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new SharingArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktSharing> traktSharings = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSharings.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new SharingArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktSharing> traktSharings = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktSharings.Should().NotBeNull();
                ITraktSharing[] sharings = traktSharings.ToArray();

                sharings[0].Should().NotBeNull();
                sharings[0].Twitter.Should().BeTrue();
                sharings[0].Google.Should().BeTrue();
                sharings[0].Tumblr.Should().BeTrue();
                sharings[0].Medium.Should().BeTrue();
                sharings[0].Slack.Should().BeTrue();

                sharings[1].Should().NotBeNull();
                sharings[1].Twitter.Should().BeTrue();
                sharings[1].Google.Should().BeTrue();
                sharings[1].Tumblr.Should().BeTrue();
                sharings[1].Medium.Should().BeTrue();
                sharings[1].Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SharingArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktSharing> traktSharings = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktSharings.Should().NotBeNull();
                ITraktSharing[] sharings = traktSharings.ToArray();

                sharings[0].Should().NotBeNull();
                sharings[0].Twitter.Should().BeTrue();
                sharings[0].Google.Should().BeTrue();
                sharings[0].Tumblr.Should().BeTrue();
                sharings[0].Medium.Should().BeTrue();
                sharings[0].Slack.Should().BeTrue();

                sharings[1].Should().NotBeNull();
                sharings[1].Twitter.Should().BeNull();
                sharings[1].Google.Should().BeTrue();
                sharings[1].Tumblr.Should().BeTrue();
                sharings[1].Medium.Should().BeTrue();
                sharings[1].Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SharingArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktSharing> traktSharings = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktSharings.Should().NotBeNull();
                ITraktSharing[] sharings = traktSharings.ToArray();

                sharings[0].Should().NotBeNull();
                sharings[0].Twitter.Should().BeNull();
                sharings[0].Google.Should().BeTrue();
                sharings[0].Tumblr.Should().BeTrue();
                sharings[0].Medium.Should().BeTrue();
                sharings[0].Slack.Should().BeTrue();

                sharings[1].Should().NotBeNull();
                sharings[1].Twitter.Should().BeTrue();
                sharings[1].Google.Should().BeTrue();
                sharings[1].Tumblr.Should().BeTrue();
                sharings[1].Medium.Should().BeTrue();
                sharings[1].Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SharingArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktSharing> traktSharings = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktSharings.Should().NotBeNull();
                ITraktSharing[] sharings = traktSharings.ToArray();

                sharings[0].Should().NotBeNull();
                sharings[0].Twitter.Should().BeTrue();
                sharings[0].Google.Should().BeTrue();
                sharings[0].Tumblr.Should().BeTrue();
                sharings[0].Medium.Should().BeTrue();
                sharings[0].Slack.Should().BeTrue();

                sharings[1].Should().NotBeNull();
                sharings[1].Twitter.Should().BeNull();
                sharings[1].Google.Should().BeTrue();
                sharings[1].Tumblr.Should().BeTrue();
                sharings[1].Medium.Should().BeTrue();
                sharings[1].Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SharingArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktSharing> traktSharings = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktSharings.Should().NotBeNull();
                ITraktSharing[] sharings = traktSharings.ToArray();

                sharings[0].Should().NotBeNull();
                sharings[0].Twitter.Should().BeNull();
                sharings[0].Google.Should().BeTrue();
                sharings[0].Tumblr.Should().BeTrue();
                sharings[0].Medium.Should().BeTrue();
                sharings[0].Slack.Should().BeTrue();

                sharings[1].Should().NotBeNull();
                sharings[1].Twitter.Should().BeTrue();
                sharings[1].Google.Should().BeTrue();
                sharings[1].Tumblr.Should().BeTrue();
                sharings[1].Medium.Should().BeTrue();
                sharings[1].Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SharingArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktSharing> traktSharings = await traktJsonReader.ReadArrayAsync(jsonReader);

                traktSharings.Should().NotBeNull();
                ITraktSharing[] sharings = traktSharings.ToArray();

                sharings[0].Should().NotBeNull();
                sharings[0].Twitter.Should().BeNull();
                sharings[0].Google.Should().BeTrue();
                sharings[0].Tumblr.Should().BeTrue();
                sharings[0].Medium.Should().BeTrue();
                sharings[0].Slack.Should().BeTrue();

                sharings[1].Should().NotBeNull();
                sharings[1].Twitter.Should().BeNull();
                sharings[1].Google.Should().BeTrue();
                sharings[1].Tumblr.Should().BeTrue();
                sharings[1].Medium.Should().BeTrue();
                sharings[1].Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new SharingArrayJsonReader();
            IEnumerable<ITraktSharing> traktSharings = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktSharings.Should().BeNull();
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new SharingArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktSharing> traktSharings = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSharings.Should().BeNull();
            }
        }
    }
}
