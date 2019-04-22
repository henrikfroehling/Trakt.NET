namespace TraktNet.Objects.Tests.Get.Shows.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class TrendingShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TrendingShowObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TrendingShowObjectJsonReader();

            var traktTrendingShow = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktTrendingShow.Should().NotBeNull();
            traktTrendingShow.Watchers.Should().Be(35);
            traktTrendingShow.Show.Should().NotBeNull();
            traktTrendingShow.Show.Title.Should().Be("Game of Thrones");
            traktTrendingShow.Show.Year.Should().Be(2011);
            traktTrendingShow.Show.Ids.Should().NotBeNull();
            traktTrendingShow.Show.Ids.Trakt.Should().Be(1390U);
            traktTrendingShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktTrendingShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktTrendingShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktTrendingShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktTrendingShow.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_TrendingShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TrendingShowObjectJsonReader();

            var traktTrendingShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktTrendingShow.Should().NotBeNull();
            traktTrendingShow.Watchers.Should().Be(35);
            traktTrendingShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_TrendingShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TrendingShowObjectJsonReader();

            var traktTrendingShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktTrendingShow.Should().NotBeNull();
            traktTrendingShow.Watchers.Should().BeNull();
            traktTrendingShow.Show.Should().NotBeNull();
            traktTrendingShow.Show.Title.Should().Be("Game of Thrones");
            traktTrendingShow.Show.Year.Should().Be(2011);
            traktTrendingShow.Show.Ids.Should().NotBeNull();
            traktTrendingShow.Show.Ids.Trakt.Should().Be(1390U);
            traktTrendingShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktTrendingShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktTrendingShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktTrendingShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktTrendingShow.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_TrendingShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TrendingShowObjectJsonReader();

            var traktTrendingShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktTrendingShow.Should().NotBeNull();
            traktTrendingShow.Watchers.Should().BeNull();
            traktTrendingShow.Show.Should().NotBeNull();
            traktTrendingShow.Show.Title.Should().Be("Game of Thrones");
            traktTrendingShow.Show.Year.Should().Be(2011);
            traktTrendingShow.Show.Ids.Should().NotBeNull();
            traktTrendingShow.Show.Ids.Trakt.Should().Be(1390U);
            traktTrendingShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktTrendingShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktTrendingShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktTrendingShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktTrendingShow.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_TrendingShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TrendingShowObjectJsonReader();

            var traktTrendingShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktTrendingShow.Should().NotBeNull();
            traktTrendingShow.Watchers.Should().Be(35);
            traktTrendingShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_TrendingShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TrendingShowObjectJsonReader();

            var traktTrendingShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktTrendingShow.Should().NotBeNull();
            traktTrendingShow.Watchers.Should().BeNull();
            traktTrendingShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_TrendingShowObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TrendingShowObjectJsonReader();

            var traktTrendingShow = await jsonReader.ReadObjectAsync(default(string));
            traktTrendingShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_TrendingShowObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TrendingShowObjectJsonReader();

            var traktTrendingShow = await jsonReader.ReadObjectAsync(string.Empty);
            traktTrendingShow.Should().BeNull();
        }
    }
}
