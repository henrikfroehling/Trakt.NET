namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktEpisodeIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(stream);
                traktEpisodeIds.Should().BeNull();
            }
        }
    }
}
