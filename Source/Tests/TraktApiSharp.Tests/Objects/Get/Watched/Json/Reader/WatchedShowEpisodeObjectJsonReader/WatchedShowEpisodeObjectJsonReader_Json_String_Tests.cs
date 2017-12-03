namespace TraktApiSharp.Tests.Objects.Get.Watched.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedShowEpisodeObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktWatchedShowEpisode.Should().NotBeNull();
            traktWatchedShowEpisode.Number.Should().Be(1);
            traktWatchedShowEpisode.Plays.Should().Be(1);
            traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktWatchedShowEpisode.Should().NotBeNull();
            traktWatchedShowEpisode.Number.Should().BeNull();
            traktWatchedShowEpisode.Plays.Should().Be(1);
            traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktWatchedShowEpisode.Should().NotBeNull();
            traktWatchedShowEpisode.Number.Should().Be(1);
            traktWatchedShowEpisode.Plays.Should().BeNull();
            traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktWatchedShowEpisode.Should().NotBeNull();
            traktWatchedShowEpisode.Number.Should().Be(1);
            traktWatchedShowEpisode.Plays.Should().Be(1);
            traktWatchedShowEpisode.LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktWatchedShowEpisode.Should().NotBeNull();
            traktWatchedShowEpisode.Number.Should().Be(1);
            traktWatchedShowEpisode.Plays.Should().BeNull();
            traktWatchedShowEpisode.LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktWatchedShowEpisode.Should().NotBeNull();
            traktWatchedShowEpisode.Number.Should().BeNull();
            traktWatchedShowEpisode.Plays.Should().Be(1);
            traktWatchedShowEpisode.LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktWatchedShowEpisode.Should().NotBeNull();
            traktWatchedShowEpisode.Number.Should().BeNull();
            traktWatchedShowEpisode.Plays.Should().BeNull();
            traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktWatchedShowEpisode.Should().NotBeNull();
            traktWatchedShowEpisode.Number.Should().BeNull();
            traktWatchedShowEpisode.Plays.Should().Be(1);
            traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktWatchedShowEpisode.Should().NotBeNull();
            traktWatchedShowEpisode.Number.Should().Be(1);
            traktWatchedShowEpisode.Plays.Should().BeNull();
            traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktWatchedShowEpisode.Should().NotBeNull();
            traktWatchedShowEpisode.Number.Should().Be(1);
            traktWatchedShowEpisode.Plays.Should().Be(1);
            traktWatchedShowEpisode.LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktWatchedShowEpisode.Should().NotBeNull();
            traktWatchedShowEpisode.Number.Should().BeNull();
            traktWatchedShowEpisode.Plays.Should().BeNull();
            traktWatchedShowEpisode.LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(default(string));
            traktWatchedShowEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(string.Empty);
            traktWatchedShowEpisode.Should().BeNull();
        }
    }
}
