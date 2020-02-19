namespace TraktNet.Objects.Get.Tests.Episodes.Json.Reader
{
    using FluentAssertions;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeIdsArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new EpisodeIdsArrayJsonReader();
            var traktEpisodeIds = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktEpisodeIds.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new EpisodeIdsArrayJsonReader();

            var traktEpisodeIds = await jsonReader.ReadArrayAsync(JSON_COMPLETE);
            traktEpisodeIds.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var episodeIds = traktEpisodeIds.ToArray();

            episodeIds[0].Should().NotBeNull();
            episodeIds[0].Trakt.Should().Be(73640);
            episodeIds[0].Tvdb.Should().Be(3254641U);
            episodeIds[0].Imdb.Should().Be("tt1480055");
            episodeIds[0].Tmdb.Should().Be(63056U);
            episodeIds[0].TvRage.Should().Be(1065008299U);
            episodeIds[0].HasAnyId.Should().BeTrue();

            episodeIds[1].Should().NotBeNull();
            episodeIds[1].Trakt.Should().Be(73640);
            episodeIds[1].Tvdb.Should().Be(3254641U);
            episodeIds[1].Imdb.Should().Be("tt1480055");
            episodeIds[1].Tmdb.Should().Be(63056U);
            episodeIds[1].TvRage.Should().Be(1065008299U);
            episodeIds[1].HasAnyId.Should().BeTrue();
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new EpisodeIdsArrayJsonReader();

            var traktEpisodeIds = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);
            traktEpisodeIds.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var episodeIds = traktEpisodeIds.ToArray();

            episodeIds[0].Should().NotBeNull();
            episodeIds[0].Trakt.Should().Be(73640);
            episodeIds[0].Tvdb.Should().Be(3254641U);
            episodeIds[0].Imdb.Should().Be("tt1480055");
            episodeIds[0].Tmdb.Should().Be(63056U);
            episodeIds[0].TvRage.Should().Be(1065008299U);
            episodeIds[0].HasAnyId.Should().BeTrue();

            episodeIds[1].Should().NotBeNull();
            episodeIds[1].Trakt.Should().Be(0);
            episodeIds[1].Tvdb.Should().Be(3254641U);
            episodeIds[1].Imdb.Should().Be("tt1480055");
            episodeIds[1].Tmdb.Should().Be(63056U);
            episodeIds[1].TvRage.Should().Be(1065008299U);
            episodeIds[1].HasAnyId.Should().BeTrue();
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new EpisodeIdsArrayJsonReader();

            var traktEpisodeIds = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);
            traktEpisodeIds.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var episodeIds = traktEpisodeIds.ToArray();

            episodeIds[0].Should().NotBeNull();
            episodeIds[0].Trakt.Should().Be(0);
            episodeIds[0].Tvdb.Should().Be(3254641U);
            episodeIds[0].Imdb.Should().Be("tt1480055");
            episodeIds[0].Tmdb.Should().Be(63056U);
            episodeIds[0].TvRage.Should().Be(1065008299U);
            episodeIds[0].HasAnyId.Should().BeTrue();

            episodeIds[1].Should().NotBeNull();
            episodeIds[1].Trakt.Should().Be(73640);
            episodeIds[1].Tvdb.Should().Be(3254641U);
            episodeIds[1].Imdb.Should().Be("tt1480055");
            episodeIds[1].Tmdb.Should().Be(63056U);
            episodeIds[1].TvRage.Should().Be(1065008299U);
            episodeIds[1].HasAnyId.Should().BeTrue();
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new EpisodeIdsArrayJsonReader();

            var traktEpisodeIds = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);
            traktEpisodeIds.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var episodeIds = traktEpisodeIds.ToArray();

            episodeIds[0].Should().NotBeNull();
            episodeIds[0].Trakt.Should().Be(0);
            episodeIds[0].Tvdb.Should().Be(3254641U);
            episodeIds[0].Imdb.Should().Be("tt1480055");
            episodeIds[0].Tmdb.Should().Be(63056U);
            episodeIds[0].TvRage.Should().Be(1065008299U);
            episodeIds[0].HasAnyId.Should().BeTrue();

            episodeIds[1].Should().NotBeNull();
            episodeIds[1].Trakt.Should().Be(73640);
            episodeIds[1].Tvdb.Should().Be(3254641U);
            episodeIds[1].Imdb.Should().Be("tt1480055");
            episodeIds[1].Tmdb.Should().Be(63056U);
            episodeIds[1].TvRage.Should().Be(1065008299U);
            episodeIds[1].HasAnyId.Should().BeTrue();
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new EpisodeIdsArrayJsonReader();

            var traktEpisodeIds = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);
            traktEpisodeIds.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var episodeIds = traktEpisodeIds.ToArray();

            episodeIds[0].Should().NotBeNull();
            episodeIds[0].Trakt.Should().Be(73640);
            episodeIds[0].Tvdb.Should().Be(3254641U);
            episodeIds[0].Imdb.Should().Be("tt1480055");
            episodeIds[0].Tmdb.Should().Be(63056U);
            episodeIds[0].TvRage.Should().Be(1065008299U);
            episodeIds[0].HasAnyId.Should().BeTrue();

            episodeIds[1].Should().NotBeNull();
            episodeIds[1].Trakt.Should().Be(0);
            episodeIds[1].Tvdb.Should().Be(3254641U);
            episodeIds[1].Imdb.Should().Be("tt1480055");
            episodeIds[1].Tmdb.Should().Be(63056U);
            episodeIds[1].TvRage.Should().Be(1065008299U);
            episodeIds[1].HasAnyId.Should().BeTrue();
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new EpisodeIdsArrayJsonReader();

            var traktEpisodeIds = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);
            traktEpisodeIds.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

            var episodeIds = traktEpisodeIds.ToArray();

            episodeIds[0].Should().NotBeNull();
            episodeIds[0].Trakt.Should().Be(0);
            episodeIds[0].Tvdb.Should().Be(3254641U);
            episodeIds[0].Imdb.Should().Be("tt1480055");
            episodeIds[0].Tmdb.Should().Be(63056U);
            episodeIds[0].TvRage.Should().Be(1065008299U);
            episodeIds[0].HasAnyId.Should().BeTrue();

            episodeIds[1].Should().NotBeNull();
            episodeIds[1].Trakt.Should().Be(0);
            episodeIds[1].Tvdb.Should().Be(3254641U);
            episodeIds[1].Imdb.Should().Be("tt1480055");
            episodeIds[1].Tmdb.Should().Be(63056U);
            episodeIds[1].TvRage.Should().Be(1065008299U);
            episodeIds[1].HasAnyId.Should().BeTrue();
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new EpisodeIdsArrayJsonReader();
            var traktEpisodeIds = await jsonReader.ReadArrayAsync(default(string));
            traktEpisodeIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new EpisodeIdsArrayJsonReader();
            var traktEpisodeIds = await jsonReader.ReadArrayAsync(string.Empty);
            traktEpisodeIds.Should().BeNull();
        }
    }
}
