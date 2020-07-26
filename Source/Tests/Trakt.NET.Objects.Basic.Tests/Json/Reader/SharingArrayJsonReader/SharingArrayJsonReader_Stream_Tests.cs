namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class SharingArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktSharing>();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(stream);
                traktSharings.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktSharing>();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktSharing>();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktSharing>();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktSharing>();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktSharing>();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktSharing>();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(stream);

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
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktSharing>();
            IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(default(Stream));
            traktSharings.Should().BeNull();
        }

        [Fact]
        public async Task Test_SharingArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktSharing>();

            using (var stream = string.Empty.ToStream())
            {
                IEnumerable<ITraktSharing> traktSharings = await jsonReader.ReadArrayAsync(stream);
                traktSharings.Should().BeNull();
            }
        }
    }
}
