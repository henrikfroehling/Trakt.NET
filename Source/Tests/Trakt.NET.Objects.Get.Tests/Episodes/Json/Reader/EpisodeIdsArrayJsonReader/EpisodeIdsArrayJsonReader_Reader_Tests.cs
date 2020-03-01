namespace TraktNet.Objects.Get.Tests.Episodes.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeIdsArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeIds.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();
            var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktEpisodeIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeIds.Should().BeNull();
            }
        }
    }
}
