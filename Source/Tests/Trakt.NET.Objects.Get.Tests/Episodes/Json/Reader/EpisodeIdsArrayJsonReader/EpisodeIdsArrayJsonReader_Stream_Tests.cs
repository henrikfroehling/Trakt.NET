namespace TraktNet.Objects.Get.Tests.Episodes.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeIdsArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(stream);
                traktEpisodeIds.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();
            var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(default(Stream));
            traktEpisodeIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeIdsArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var traktJsonReader = new EpisodeIdsArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadArrayAsync(stream);
                traktEpisodeIds.Should().BeNull();
            }
        }
    }
}
