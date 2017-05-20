namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class TraktTrendingShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktTrendingShowObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktTrendingShowObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_TraktTrendingShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktTrendingShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktTrendingShow.Should().NotBeNull();
                traktTrendingShow.Watchers.Should().Be(35);
                traktTrendingShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktTrendingShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktTrendingShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_TraktTrendingShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktTrendingShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_TraktTrendingShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktTrendingShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktTrendingShow.Should().NotBeNull();
                traktTrendingShow.Watchers.Should().Be(35);
                traktTrendingShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktTrendingShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktTrendingShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktTrendingShow.Should().NotBeNull();
                traktTrendingShow.Watchers.Should().BeNull();
                traktTrendingShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktTrendingShowObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktTrendingShowObjectJsonReader();

            var traktTrendingShow = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktTrendingShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktTrendingShowObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktTrendingShowObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktTrendingShow.Should().BeNull();
            }
        }
    }
}
