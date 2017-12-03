namespace TraktApiSharp.Tests.Objects.Get.Shows.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class TrendingShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TrendingShowObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new TrendingShowObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(stream);

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
        public async Task Test_TrendingShowObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new TrendingShowObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(stream);

                traktTrendingShow.Should().NotBeNull();
                traktTrendingShow.Watchers.Should().Be(35);
                traktTrendingShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TrendingShowObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new TrendingShowObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(stream);

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
        public async Task Test_TrendingShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new TrendingShowObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(stream);

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
        public async Task Test_TrendingShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new TrendingShowObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(stream);

                traktTrendingShow.Should().NotBeNull();
                traktTrendingShow.Watchers.Should().Be(35);
                traktTrendingShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TrendingShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new TrendingShowObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(stream);

                traktTrendingShow.Should().NotBeNull();
                traktTrendingShow.Watchers.Should().BeNull();
                traktTrendingShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TrendingShowObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new TrendingShowObjectJsonReader();

            var traktTrendingShow = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktTrendingShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_TrendingShowObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new TrendingShowObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(stream);
                traktTrendingShow.Should().BeNull();
            }
        }
    }
}
