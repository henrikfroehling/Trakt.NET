namespace TraktApiSharp.Tests.Objects.Get.Shows.Json
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.Json;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class ShowIdsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(1390);
            traktShowIds.Slug.Should().Be("game-of-thrones");
            traktShowIds.Tvdb.Should().Be(121361U);
            traktShowIds.Imdb.Should().Be("tt0944947");
            traktShowIds.Tmdb.Should().Be(1399U);
            traktShowIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(0);
            traktShowIds.Slug.Should().Be("game-of-thrones");
            traktShowIds.Tvdb.Should().Be(121361U);
            traktShowIds.Imdb.Should().Be("tt0944947");
            traktShowIds.Tmdb.Should().Be(1399U);
            traktShowIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(1390);
            traktShowIds.Slug.Should().BeNull();
            traktShowIds.Tvdb.Should().Be(121361U);
            traktShowIds.Imdb.Should().Be("tt0944947");
            traktShowIds.Tmdb.Should().Be(1399U);
            traktShowIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(1390);
            traktShowIds.Slug.Should().Be("game-of-thrones");
            traktShowIds.Tvdb.Should().BeNull();
            traktShowIds.Imdb.Should().Be("tt0944947");
            traktShowIds.Tmdb.Should().Be(1399U);
            traktShowIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(1390);
            traktShowIds.Slug.Should().Be("game-of-thrones");
            traktShowIds.Tvdb.Should().Be(121361U);
            traktShowIds.Imdb.Should().BeNull();
            traktShowIds.Tmdb.Should().Be(1399U);
            traktShowIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(1390);
            traktShowIds.Slug.Should().Be("game-of-thrones");
            traktShowIds.Tvdb.Should().Be(121361U);
            traktShowIds.Imdb.Should().Be("tt0944947");
            traktShowIds.Tmdb.Should().BeNull();
            traktShowIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(1390);
            traktShowIds.Slug.Should().Be("game-of-thrones");
            traktShowIds.Tvdb.Should().Be(121361U);
            traktShowIds.Imdb.Should().Be("tt0944947");
            traktShowIds.Tmdb.Should().Be(1399U);
            traktShowIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(1390);
            traktShowIds.Slug.Should().BeNull();
            traktShowIds.Tvdb.Should().BeNull();
            traktShowIds.Imdb.Should().BeNull();
            traktShowIds.Tmdb.Should().BeNull();
            traktShowIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(0);
            traktShowIds.Slug.Should().Be("game-of-thrones");
            traktShowIds.Tvdb.Should().BeNull();
            traktShowIds.Imdb.Should().BeNull();
            traktShowIds.Tmdb.Should().BeNull();
            traktShowIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(0);
            traktShowIds.Slug.Should().BeNull();
            traktShowIds.Tvdb.Should().Be(121361U);
            traktShowIds.Imdb.Should().BeNull();
            traktShowIds.Tmdb.Should().BeNull();
            traktShowIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(0);
            traktShowIds.Slug.Should().BeNull();
            traktShowIds.Tvdb.Should().BeNull();
            traktShowIds.Imdb.Should().Be("tt0944947");
            traktShowIds.Tmdb.Should().BeNull();
            traktShowIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_11()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_11);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(0);
            traktShowIds.Slug.Should().BeNull();
            traktShowIds.Tvdb.Should().BeNull();
            traktShowIds.Imdb.Should().BeNull();
            traktShowIds.Tmdb.Should().Be(1399U);
            traktShowIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Incomplete_12()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_12);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(0);
            traktShowIds.Slug.Should().BeNull();
            traktShowIds.Tvdb.Should().BeNull();
            traktShowIds.Imdb.Should().BeNull();
            traktShowIds.Tmdb.Should().BeNull();
            traktShowIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(0);
            traktShowIds.Slug.Should().Be("game-of-thrones");
            traktShowIds.Tvdb.Should().Be(121361U);
            traktShowIds.Imdb.Should().Be("tt0944947");
            traktShowIds.Tmdb.Should().Be(1399U);
            traktShowIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(1390);
            traktShowIds.Slug.Should().BeNull();
            traktShowIds.Tvdb.Should().Be(121361U);
            traktShowIds.Imdb.Should().Be("tt0944947");
            traktShowIds.Tmdb.Should().Be(1399U);
            traktShowIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(1390);
            traktShowIds.Slug.Should().Be("game-of-thrones");
            traktShowIds.Tvdb.Should().BeNull();
            traktShowIds.Imdb.Should().Be("tt0944947");
            traktShowIds.Tmdb.Should().Be(1399U);
            traktShowIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(1390);
            traktShowIds.Slug.Should().Be("game-of-thrones");
            traktShowIds.Tvdb.Should().Be(121361U);
            traktShowIds.Imdb.Should().BeNull();
            traktShowIds.Tmdb.Should().Be(1399U);
            traktShowIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(1390);
            traktShowIds.Slug.Should().Be("game-of-thrones");
            traktShowIds.Tvdb.Should().Be(121361U);
            traktShowIds.Imdb.Should().Be("tt0944947");
            traktShowIds.Tmdb.Should().BeNull();
            traktShowIds.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(1390);
            traktShowIds.Slug.Should().Be("game-of-thrones");
            traktShowIds.Tvdb.Should().Be(121361U);
            traktShowIds.Imdb.Should().Be("tt0944947");
            traktShowIds.Tmdb.Should().Be(1399U);
            traktShowIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_7()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_7);

            traktShowIds.Should().NotBeNull();
            traktShowIds.Trakt.Should().Be(0);
            traktShowIds.Slug.Should().BeNull();
            traktShowIds.Tvdb.Should().BeNull();
            traktShowIds.Imdb.Should().BeNull();
            traktShowIds.Tmdb.Should().BeNull();
            traktShowIds.TvRage.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(default(string));
            traktShowIds.Should().BeNull();
        }

        [Fact]
        public async Task Test_ShowIdsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ShowIdsObjectJsonReader();

            var traktShowIds = await jsonReader.ReadObjectAsync(string.Empty);
            traktShowIds.Should().BeNull();
        }
    }
}
