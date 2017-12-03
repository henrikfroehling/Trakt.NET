namespace TraktApiSharp.Tests.Objects.Get.Watched.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedShowEpisodeArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktWatchedShowEpisodes.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(JSON_COMPLETE);
            traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

            watchedShowEpisodes[0].Should().NotBeNull();
            watchedShowEpisodes[0].Number.Should().Be(1);
            watchedShowEpisodes[0].Plays.Should().Be(1);
            watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[1].Should().NotBeNull();
            watchedShowEpisodes[1].Number.Should().Be(2);
            watchedShowEpisodes[1].Plays.Should().Be(1);
            watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[2].Should().NotBeNull();
            watchedShowEpisodes[2].Number.Should().Be(3);
            watchedShowEpisodes[2].Plays.Should().Be(1);
            watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);
            traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

            watchedShowEpisodes[0].Should().NotBeNull();
            watchedShowEpisodes[0].Number.Should().BeNull();
            watchedShowEpisodes[0].Plays.Should().Be(1);
            watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[1].Should().NotBeNull();
            watchedShowEpisodes[1].Number.Should().Be(2);
            watchedShowEpisodes[1].Plays.Should().Be(1);
            watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[2].Should().NotBeNull();
            watchedShowEpisodes[2].Number.Should().Be(3);
            watchedShowEpisodes[2].Plays.Should().Be(1);
            watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);
            traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

            watchedShowEpisodes[0].Should().NotBeNull();
            watchedShowEpisodes[0].Number.Should().Be(1);
            watchedShowEpisodes[0].Plays.Should().Be(1);
            watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[1].Should().NotBeNull();
            watchedShowEpisodes[1].Number.Should().Be(2);
            watchedShowEpisodes[1].Plays.Should().BeNull();
            watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[2].Should().NotBeNull();
            watchedShowEpisodes[2].Number.Should().Be(3);
            watchedShowEpisodes[2].Plays.Should().Be(1);
            watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Json_String_Incomplete_3()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_3);
            traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

            watchedShowEpisodes[0].Should().NotBeNull();
            watchedShowEpisodes[0].Number.Should().Be(1);
            watchedShowEpisodes[0].Plays.Should().Be(1);
            watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[1].Should().NotBeNull();
            watchedShowEpisodes[1].Number.Should().Be(2);
            watchedShowEpisodes[1].Plays.Should().Be(1);
            watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[2].Should().NotBeNull();
            watchedShowEpisodes[2].Number.Should().Be(3);
            watchedShowEpisodes[2].Plays.Should().Be(1);
            watchedShowEpisodes[2].LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Json_String_Incomplete_4()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_4);
            traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

            watchedShowEpisodes[0].Should().NotBeNull();
            watchedShowEpisodes[0].Number.Should().Be(1);
            watchedShowEpisodes[0].Plays.Should().BeNull();
            watchedShowEpisodes[0].LastWatchedAt.Should().BeNull();

            watchedShowEpisodes[1].Should().NotBeNull();
            watchedShowEpisodes[1].Number.Should().Be(2);
            watchedShowEpisodes[1].Plays.Should().Be(1);
            watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[2].Should().NotBeNull();
            watchedShowEpisodes[2].Number.Should().Be(3);
            watchedShowEpisodes[2].Plays.Should().Be(1);
            watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Json_String_Incomplete_5()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_5);
            traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

            watchedShowEpisodes[0].Should().NotBeNull();
            watchedShowEpisodes[0].Number.Should().Be(1);
            watchedShowEpisodes[0].Plays.Should().Be(1);
            watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[1].Should().NotBeNull();
            watchedShowEpisodes[1].Number.Should().BeNull();
            watchedShowEpisodes[1].Plays.Should().Be(1);
            watchedShowEpisodes[1].LastWatchedAt.Should().BeNull();

            watchedShowEpisodes[2].Should().NotBeNull();
            watchedShowEpisodes[2].Number.Should().Be(3);
            watchedShowEpisodes[2].Plays.Should().Be(1);
            watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Json_String_Incomplete_6()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_6);
            traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

            watchedShowEpisodes[0].Should().NotBeNull();
            watchedShowEpisodes[0].Number.Should().Be(1);
            watchedShowEpisodes[0].Plays.Should().Be(1);
            watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[1].Should().NotBeNull();
            watchedShowEpisodes[1].Number.Should().Be(2);
            watchedShowEpisodes[1].Plays.Should().Be(1);
            watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[2].Should().NotBeNull();
            watchedShowEpisodes[2].Number.Should().BeNull();
            watchedShowEpisodes[2].Plays.Should().BeNull();
            watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);
            traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

            watchedShowEpisodes[0].Should().NotBeNull();
            watchedShowEpisodes[0].Number.Should().BeNull();
            watchedShowEpisodes[0].Plays.Should().Be(1);
            watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[1].Should().NotBeNull();
            watchedShowEpisodes[1].Number.Should().Be(2);
            watchedShowEpisodes[1].Plays.Should().Be(1);
            watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[2].Should().NotBeNull();
            watchedShowEpisodes[2].Number.Should().Be(3);
            watchedShowEpisodes[2].Plays.Should().Be(1);
            watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);
            traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

            watchedShowEpisodes[0].Should().NotBeNull();
            watchedShowEpisodes[0].Number.Should().Be(1);
            watchedShowEpisodes[0].Plays.Should().Be(1);
            watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[1].Should().NotBeNull();
            watchedShowEpisodes[1].Number.Should().Be(2);
            watchedShowEpisodes[1].Plays.Should().BeNull();
            watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[2].Should().NotBeNull();
            watchedShowEpisodes[2].Number.Should().Be(3);
            watchedShowEpisodes[2].Plays.Should().Be(1);
            watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);
            traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

            watchedShowEpisodes[0].Should().NotBeNull();
            watchedShowEpisodes[0].Number.Should().Be(1);
            watchedShowEpisodes[0].Plays.Should().Be(1);
            watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[1].Should().NotBeNull();
            watchedShowEpisodes[1].Number.Should().Be(2);
            watchedShowEpisodes[1].Plays.Should().Be(1);
            watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[2].Should().NotBeNull();
            watchedShowEpisodes[2].Number.Should().Be(3);
            watchedShowEpisodes[2].Plays.Should().Be(1);
            watchedShowEpisodes[2].LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_4);
            traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

            watchedShowEpisodes[0].Should().NotBeNull();
            watchedShowEpisodes[0].Number.Should().BeNull();
            watchedShowEpisodes[0].Plays.Should().Be(1);
            watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[1].Should().NotBeNull();
            watchedShowEpisodes[1].Number.Should().Be(2);
            watchedShowEpisodes[1].Plays.Should().BeNull();
            watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            watchedShowEpisodes[2].Should().NotBeNull();
            watchedShowEpisodes[2].Number.Should().Be(3);
            watchedShowEpisodes[2].Plays.Should().Be(1);
            watchedShowEpisodes[2].LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            var traktEpisodeWatchedProgress = await jsonReader.ReadArrayAsync(default(string));
            traktEpisodeWatchedProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            var traktEpisodeWatchedProgress = await jsonReader.ReadArrayAsync(string.Empty);
            traktEpisodeWatchedProgress.Should().BeNull();
        }
    }
}
