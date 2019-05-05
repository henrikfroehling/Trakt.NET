namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class IdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(1390);
            traktIds.Slug.Should().Be("game-of-thrones");
            traktIds.Tvdb.Should().Be(121361U);
            traktIds.Imdb.Should().Be("tt0944947");
            traktIds.Tmdb.Should().Be(1399U);
            traktIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(0);
            traktIds.Slug.Should().Be("game-of-thrones");
            traktIds.Tvdb.Should().Be(121361U);
            traktIds.Imdb.Should().Be("tt0944947");
            traktIds.Tmdb.Should().Be(1399U);
            traktIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(1390);
            traktIds.Slug.Should().BeNull();
            traktIds.Tvdb.Should().Be(121361U);
            traktIds.Imdb.Should().Be("tt0944947");
            traktIds.Tmdb.Should().Be(1399U);
            traktIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(1390);
            traktIds.Slug.Should().Be("game-of-thrones");
            traktIds.Tvdb.Should().BeNull();
            traktIds.Imdb.Should().Be("tt0944947");
            traktIds.Tmdb.Should().Be(1399U);
            traktIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(1390);
            traktIds.Slug.Should().Be("game-of-thrones");
            traktIds.Tvdb.Should().Be(121361U);
            traktIds.Imdb.Should().BeNull();
            traktIds.Tmdb.Should().Be(1399U);
            traktIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(1390);
            traktIds.Slug.Should().Be("game-of-thrones");
            traktIds.Tvdb.Should().Be(121361U);
            traktIds.Imdb.Should().Be("tt0944947");
            traktIds.Tmdb.Should().BeNull();
            traktIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(1390);
            traktIds.Slug.Should().Be("game-of-thrones");
            traktIds.Tvdb.Should().Be(121361U);
            traktIds.Imdb.Should().Be("tt0944947");
            traktIds.Tmdb.Should().Be(1399U);
            traktIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(1390);
            traktIds.Slug.Should().BeNull();
            traktIds.Tvdb.Should().BeNull();
            traktIds.Imdb.Should().BeNull();
            traktIds.Tmdb.Should().BeNull();
            traktIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(0);
            traktIds.Slug.Should().Be("game-of-thrones");
            traktIds.Tvdb.Should().BeNull();
            traktIds.Imdb.Should().BeNull();
            traktIds.Tmdb.Should().BeNull();
            traktIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(0);
            traktIds.Slug.Should().BeNull();
            traktIds.Tvdb.Should().Be(121361U);
            traktIds.Imdb.Should().BeNull();
            traktIds.Tmdb.Should().BeNull();
            traktIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(0);
            traktIds.Slug.Should().BeNull();
            traktIds.Tvdb.Should().BeNull();
            traktIds.Imdb.Should().Be("tt0944947");
            traktIds.Tmdb.Should().BeNull();
            traktIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_11()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_11);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(0);
            traktIds.Slug.Should().BeNull();
            traktIds.Tvdb.Should().BeNull();
            traktIds.Imdb.Should().BeNull();
            traktIds.Tmdb.Should().Be(1399U);
            traktIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_12()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_12);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(0);
            traktIds.Slug.Should().BeNull();
            traktIds.Tvdb.Should().BeNull();
            traktIds.Imdb.Should().BeNull();
            traktIds.Tmdb.Should().BeNull();
            traktIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(0);
            traktIds.Slug.Should().Be("game-of-thrones");
            traktIds.Tvdb.Should().Be(121361U);
            traktIds.Imdb.Should().Be("tt0944947");
            traktIds.Tmdb.Should().Be(1399U);
            traktIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(1390);
            traktIds.Slug.Should().BeNull();
            traktIds.Tvdb.Should().Be(121361U);
            traktIds.Imdb.Should().Be("tt0944947");
            traktIds.Tmdb.Should().Be(1399U);
            traktIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(1390);
            traktIds.Slug.Should().Be("game-of-thrones");
            traktIds.Tvdb.Should().BeNull();
            traktIds.Imdb.Should().Be("tt0944947");
            traktIds.Tmdb.Should().Be(1399U);
            traktIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(1390);
            traktIds.Slug.Should().Be("game-of-thrones");
            traktIds.Tvdb.Should().Be(121361U);
            traktIds.Imdb.Should().BeNull();
            traktIds.Tmdb.Should().Be(1399U);
            traktIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(1390);
            traktIds.Slug.Should().Be("game-of-thrones");
            traktIds.Tvdb.Should().Be(121361U);
            traktIds.Imdb.Should().Be("tt0944947");
            traktIds.Tmdb.Should().BeNull();
            traktIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(1390);
            traktIds.Slug.Should().Be("game-of-thrones");
            traktIds.Tvdb.Should().Be(121361U);
            traktIds.Imdb.Should().Be("tt0944947");
            traktIds.Tmdb.Should().Be(1399U);
            traktIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_7()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_7);

            traktIds.Should().NotBeNull();
            traktIds.Trakt.Should().Be(0);
            traktIds.Slug.Should().BeNull();
            traktIds.Tvdb.Should().BeNull();
            traktIds.Imdb.Should().BeNull();
            traktIds.Tmdb.Should().BeNull();
            traktIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(default(string));
            traktIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_IdsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new IdsObjectJsonReader();

            var traktIds = await jsonReader.ReadObjectAsync(string.Empty);
            traktIds.Should().BeNull();
        }
    }
}
