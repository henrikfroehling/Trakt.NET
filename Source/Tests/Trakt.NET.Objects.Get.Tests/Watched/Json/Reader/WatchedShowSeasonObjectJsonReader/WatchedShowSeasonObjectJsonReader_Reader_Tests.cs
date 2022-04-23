namespace TraktNet.Objects.Get.Tests.Watched.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Watched;
    using TraktNet.Objects.Get.Watched.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedShowSeasonObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchedShowSeasonObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new WatchedShowSeasonObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_WatchedShowSeasonObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new WatchedShowSeasonObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_WatchedShowSeasonObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new WatchedShowSeasonObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShowSeason.Should().NotBeNull();
                traktWatchedShowSeason.Number.Should().Be(1);
                traktWatchedShowSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowSeasonObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new WatchedShowSeasonObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_WatchedShowSeasonObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new WatchedShowSeasonObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShowSeason.Should().NotBeNull();
                traktWatchedShowSeason.Number.Should().Be(1);
                traktWatchedShowSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowSeasonObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new WatchedShowSeasonObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowSeason = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShowSeason.Should().NotBeNull();
                traktWatchedShowSeason.Number.Should().BeNull();
                traktWatchedShowSeason.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowSeasonObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new WatchedShowSeasonObjectJsonReader();
            Func<Task<ITraktWatchedShowSeason>> traktWatchedShowSeason = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktWatchedShowSeason.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_WatchedShowSeasonObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new WatchedShowSeasonObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowSeason = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktWatchedShowSeason.Should().BeNull();
            }
        }
    }
}
