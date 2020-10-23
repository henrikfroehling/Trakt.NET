namespace TraktNet.Objects.Get.Tests.Episodes.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(0);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().BeNull();
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().BeNull();
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().BeNull();
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().BeNull();
            traktEpisodeIds.Imdb.Should().BeNull();
            traktEpisodeIds.Tmdb.Should().BeNull();
            traktEpisodeIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(0);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().BeNull();
            traktEpisodeIds.Tmdb.Should().BeNull();
            traktEpisodeIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(0);
            traktEpisodeIds.Tvdb.Should().BeNull();
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().BeNull();
            traktEpisodeIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(0);
            traktEpisodeIds.Tvdb.Should().BeNull();
            traktEpisodeIds.Imdb.Should().BeNull();
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(0);
            traktEpisodeIds.Tvdb.Should().BeNull();
            traktEpisodeIds.Imdb.Should().BeNull();
            traktEpisodeIds.Tmdb.Should().BeNull();
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(0);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().BeNull();
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().BeNull();
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().BeNull();
            traktEpisodeIds.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(73640);
            traktEpisodeIds.Tvdb.Should().Be(3254641U);
            traktEpisodeIds.Imdb.Should().Be("tt1480055");
            traktEpisodeIds.Tmdb.Should().Be(63056U);
            traktEpisodeIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktEpisodeIds.Should().NotBeNull();
            traktEpisodeIds.Trakt.Should().Be(0);
            traktEpisodeIds.Tvdb.Should().BeNull();
            traktEpisodeIds.Imdb.Should().BeNull();
            traktEpisodeIds.Tmdb.Should().BeNull();
            traktEpisodeIds.TvRage.Should().BeNull();
        }

        [Fact]
        public void Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();
            Func<Task<ITraktEpisodeIds>> traktEpisodeIds = () => jsonReader.ReadObjectAsync(default(string));
            traktEpisodeIds.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeIdsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new EpisodeIdsObjectJsonReader();

            var traktEpisodeIds = await jsonReader.ReadObjectAsync(string.Empty);
            traktEpisodeIds.Should().BeNull();
        }
    }
}
