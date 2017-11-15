namespace TraktApiSharp.Tests.Objects.Get.Episodes.Json
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes.Json;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().Be(1065008299U);
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(73640);
                traktEpisodeIds.Tvdb.Should().Be(3254641U);
                traktEpisodeIds.Imdb.Should().Be("tt1480055");
                traktEpisodeIds.Tmdb.Should().Be(63056U);
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeIds.Should().NotBeNull();
                traktEpisodeIds.Trakt.Should().Be(0);
                traktEpisodeIds.Tvdb.Should().BeNull();
                traktEpisodeIds.Imdb.Should().BeNull();
                traktEpisodeIds.Tmdb.Should().BeNull();
                traktEpisodeIds.TvRage.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktEpisodeIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new EpisodeIdsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeIds = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktEpisodeIds.Should().BeNull();
            }
        }
    }
}
