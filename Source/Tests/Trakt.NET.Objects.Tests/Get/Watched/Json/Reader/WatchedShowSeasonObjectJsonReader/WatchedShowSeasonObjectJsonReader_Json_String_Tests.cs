namespace TraktNet.Objects.Tests.Get.Watched.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Watched.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedShowSeasonObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchedShowSeasonObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new WatchedShowSeasonObjectJsonReader();

            var traktWatchedShowSeason = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktWatchedShowSeason.Should().NotBeNull();
            traktWatchedShowSeason.Number.Should().Be(1);

            traktWatchedShowSeason.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var traktWatchedShowSeasonEpisodes = traktWatchedShowSeason.Episodes.ToArray();

            traktWatchedShowSeasonEpisodes[0].Number.Should().Be(1);
            traktWatchedShowSeasonEpisodes[0].Plays.Should().Be(1);
            traktWatchedShowSeasonEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            traktWatchedShowSeasonEpisodes[1].Number.Should().Be(2);
            traktWatchedShowSeasonEpisodes[1].Plays.Should().Be(1);
            traktWatchedShowSeasonEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowSeasonObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new WatchedShowSeasonObjectJsonReader();

            var traktWatchedShowSeason = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktWatchedShowSeason.Should().NotBeNull();
            traktWatchedShowSeason.Number.Should().BeNull();

            traktWatchedShowSeason.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var traktWatchedShowSeasonEpisodes = traktWatchedShowSeason.Episodes.ToArray();

            traktWatchedShowSeasonEpisodes[0].Number.Should().Be(1);
            traktWatchedShowSeasonEpisodes[0].Plays.Should().Be(1);
            traktWatchedShowSeasonEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            traktWatchedShowSeasonEpisodes[1].Number.Should().Be(2);
            traktWatchedShowSeasonEpisodes[1].Plays.Should().Be(1);
            traktWatchedShowSeasonEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowSeasonObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new WatchedShowSeasonObjectJsonReader();

            var traktWatchedShowSeason = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktWatchedShowSeason.Should().NotBeNull();
            traktWatchedShowSeason.Number.Should().Be(1);
            traktWatchedShowSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowSeasonObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new WatchedShowSeasonObjectJsonReader();

            var traktWatchedShowSeason = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktWatchedShowSeason.Should().NotBeNull();
            traktWatchedShowSeason.Number.Should().BeNull();

            traktWatchedShowSeason.Episodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);
            var traktWatchedShowSeasonEpisodes = traktWatchedShowSeason.Episodes.ToArray();

            traktWatchedShowSeasonEpisodes[0].Number.Should().Be(1);
            traktWatchedShowSeasonEpisodes[0].Plays.Should().Be(1);
            traktWatchedShowSeasonEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

            traktWatchedShowSeasonEpisodes[1].Number.Should().Be(2);
            traktWatchedShowSeasonEpisodes[1].Plays.Should().Be(1);
            traktWatchedShowSeasonEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_WatchedShowSeasonObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new WatchedShowSeasonObjectJsonReader();

            var traktWatchedShowSeason = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktWatchedShowSeason.Should().NotBeNull();
            traktWatchedShowSeason.Number.Should().Be(1);
            traktWatchedShowSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowSeasonObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new WatchedShowSeasonObjectJsonReader();

            var traktWatchedShowSeason = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktWatchedShowSeason.Should().NotBeNull();
            traktWatchedShowSeason.Number.Should().BeNull();
            traktWatchedShowSeason.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowSeasonObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new WatchedShowSeasonObjectJsonReader();

            var traktWatchedShowSeason = await jsonReader.ReadObjectAsync(default(string));
            traktWatchedShowSeason.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowSeasonObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new WatchedShowSeasonObjectJsonReader();

            var traktWatchedShowSeason = await jsonReader.ReadObjectAsync(string.Empty);
            traktWatchedShowSeason.Should().BeNull();
        }
    }
}
