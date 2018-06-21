namespace TraktNet.Tests.Objects.Get.Ratings.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Ratings.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Ratings.JsonReader")]
    public partial class RatingsItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Show_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_JSON_COMPLETE);

            traktRatingItem.Should().NotBeNull();
            traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRatingItem.Rating.Should().Be(9);
            traktRatingItem.Type.Should().Be(TraktRatingsItemType.Show);
            traktRatingItem.Show.Should().NotBeNull();
            traktRatingItem.Show.Title.Should().Be("Game of Thrones");
            traktRatingItem.Show.Year.Should().Be(2011);
            traktRatingItem.Show.Ids.Should().NotBeNull();
            traktRatingItem.Show.Ids.Trakt.Should().Be(1390U);
            traktRatingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktRatingItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktRatingItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktRatingItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktRatingItem.Show.Ids.TvRage.Should().Be(24493U);

            traktRatingItem.Movie.Should().BeNull();
            traktRatingItem.Season.Should().BeNull();
            traktRatingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Show_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_JSON_INCOMPLETE_1);

            traktRatingItem.Should().NotBeNull();
            traktRatingItem.RatedAt.Should().BeNull();
            traktRatingItem.Rating.Should().Be(9);
            traktRatingItem.Type.Should().Be(TraktRatingsItemType.Show);
            traktRatingItem.Show.Should().NotBeNull();
            traktRatingItem.Show.Title.Should().Be("Game of Thrones");
            traktRatingItem.Show.Year.Should().Be(2011);
            traktRatingItem.Show.Ids.Should().NotBeNull();
            traktRatingItem.Show.Ids.Trakt.Should().Be(1390U);
            traktRatingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktRatingItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktRatingItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktRatingItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktRatingItem.Show.Ids.TvRage.Should().Be(24493U);

            traktRatingItem.Movie.Should().BeNull();
            traktRatingItem.Season.Should().BeNull();
            traktRatingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Show_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_JSON_INCOMPLETE_2);

            traktRatingItem.Should().NotBeNull();
            traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRatingItem.Rating.Should().BeNull();
            traktRatingItem.Type.Should().Be(TraktRatingsItemType.Show);
            traktRatingItem.Show.Should().NotBeNull();
            traktRatingItem.Show.Title.Should().Be("Game of Thrones");
            traktRatingItem.Show.Year.Should().Be(2011);
            traktRatingItem.Show.Ids.Should().NotBeNull();
            traktRatingItem.Show.Ids.Trakt.Should().Be(1390U);
            traktRatingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktRatingItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktRatingItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktRatingItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktRatingItem.Show.Ids.TvRage.Should().Be(24493U);

            traktRatingItem.Movie.Should().BeNull();
            traktRatingItem.Season.Should().BeNull();
            traktRatingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Show_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_JSON_INCOMPLETE_3);

            traktRatingItem.Should().NotBeNull();
            traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRatingItem.Rating.Should().Be(9);
            traktRatingItem.Type.Should().BeNull();
            traktRatingItem.Show.Should().NotBeNull();
            traktRatingItem.Show.Title.Should().Be("Game of Thrones");
            traktRatingItem.Show.Year.Should().Be(2011);
            traktRatingItem.Show.Ids.Should().NotBeNull();
            traktRatingItem.Show.Ids.Trakt.Should().Be(1390U);
            traktRatingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktRatingItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktRatingItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktRatingItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktRatingItem.Show.Ids.TvRage.Should().Be(24493U);

            traktRatingItem.Movie.Should().BeNull();
            traktRatingItem.Season.Should().BeNull();
            traktRatingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Show_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_JSON_INCOMPLETE_4);

            traktRatingItem.Should().NotBeNull();
            traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRatingItem.Rating.Should().Be(9);
            traktRatingItem.Type.Should().Be(TraktRatingsItemType.Show);
            traktRatingItem.Show.Should().BeNull();

            traktRatingItem.Movie.Should().BeNull();
            traktRatingItem.Season.Should().BeNull();
            traktRatingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Show_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_JSON_INCOMPLETE_5);

            traktRatingItem.Should().NotBeNull();
            traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRatingItem.Rating.Should().BeNull();
            traktRatingItem.Type.Should().BeNull();
            traktRatingItem.Show.Should().BeNull();

            traktRatingItem.Movie.Should().BeNull();
            traktRatingItem.Season.Should().BeNull();
            traktRatingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Show_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_JSON_INCOMPLETE_6);

            traktRatingItem.Should().NotBeNull();
            traktRatingItem.RatedAt.Should().BeNull();
            traktRatingItem.Rating.Should().Be(9);
            traktRatingItem.Type.Should().BeNull();
            traktRatingItem.Show.Should().BeNull();

            traktRatingItem.Movie.Should().BeNull();
            traktRatingItem.Season.Should().BeNull();
            traktRatingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Show_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_JSON_INCOMPLETE_7);

            traktRatingItem.Should().NotBeNull();
            traktRatingItem.RatedAt.Should().BeNull();
            traktRatingItem.Rating.Should().BeNull();
            traktRatingItem.Type.Should().Be(TraktRatingsItemType.Show);
            traktRatingItem.Show.Should().BeNull();

            traktRatingItem.Movie.Should().BeNull();
            traktRatingItem.Season.Should().BeNull();
            traktRatingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Show_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_JSON_INCOMPLETE_8);

            traktRatingItem.Should().NotBeNull();
            traktRatingItem.RatedAt.Should().BeNull();
            traktRatingItem.Rating.Should().BeNull();
            traktRatingItem.Type.Should().BeNull();
            traktRatingItem.Show.Should().NotBeNull();
            traktRatingItem.Show.Title.Should().Be("Game of Thrones");
            traktRatingItem.Show.Year.Should().Be(2011);
            traktRatingItem.Show.Ids.Should().NotBeNull();
            traktRatingItem.Show.Ids.Trakt.Should().Be(1390U);
            traktRatingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktRatingItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktRatingItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktRatingItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktRatingItem.Show.Ids.TvRage.Should().Be(24493U);

            traktRatingItem.Movie.Should().BeNull();
            traktRatingItem.Season.Should().BeNull();
            traktRatingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Show_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_JSON_NOT_VALID_1);

            traktRatingItem.Should().NotBeNull();
            traktRatingItem.RatedAt.Should().BeNull();
            traktRatingItem.Rating.Should().Be(9);
            traktRatingItem.Type.Should().Be(TraktRatingsItemType.Show);
            traktRatingItem.Show.Should().NotBeNull();
            traktRatingItem.Show.Title.Should().Be("Game of Thrones");
            traktRatingItem.Show.Year.Should().Be(2011);
            traktRatingItem.Show.Ids.Should().NotBeNull();
            traktRatingItem.Show.Ids.Trakt.Should().Be(1390U);
            traktRatingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktRatingItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktRatingItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktRatingItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktRatingItem.Show.Ids.TvRage.Should().Be(24493U);

            traktRatingItem.Movie.Should().BeNull();
            traktRatingItem.Season.Should().BeNull();
            traktRatingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Show_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_JSON_NOT_VALID_2);

            traktRatingItem.Should().NotBeNull();
            traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRatingItem.Rating.Should().BeNull();
            traktRatingItem.Type.Should().Be(TraktRatingsItemType.Show);
            traktRatingItem.Show.Should().NotBeNull();
            traktRatingItem.Show.Title.Should().Be("Game of Thrones");
            traktRatingItem.Show.Year.Should().Be(2011);
            traktRatingItem.Show.Ids.Should().NotBeNull();
            traktRatingItem.Show.Ids.Trakt.Should().Be(1390U);
            traktRatingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktRatingItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktRatingItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktRatingItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktRatingItem.Show.Ids.TvRage.Should().Be(24493U);

            traktRatingItem.Movie.Should().BeNull();
            traktRatingItem.Season.Should().BeNull();
            traktRatingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Show_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_JSON_NOT_VALID_3);

            traktRatingItem.Should().NotBeNull();
            traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRatingItem.Rating.Should().Be(9);
            traktRatingItem.Type.Should().BeNull();
            traktRatingItem.Show.Should().NotBeNull();
            traktRatingItem.Show.Title.Should().Be("Game of Thrones");
            traktRatingItem.Show.Year.Should().Be(2011);
            traktRatingItem.Show.Ids.Should().NotBeNull();
            traktRatingItem.Show.Ids.Trakt.Should().Be(1390U);
            traktRatingItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktRatingItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktRatingItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktRatingItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktRatingItem.Show.Ids.TvRage.Should().Be(24493U);

            traktRatingItem.Movie.Should().BeNull();
            traktRatingItem.Season.Should().BeNull();
            traktRatingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Show_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_JSON_NOT_VALID_4);

            traktRatingItem.Should().NotBeNull();
            traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktRatingItem.Rating.Should().Be(9);
            traktRatingItem.Type.Should().Be(TraktRatingsItemType.Show);
            traktRatingItem.Show.Should().BeNull();

            traktRatingItem.Movie.Should().BeNull();
            traktRatingItem.Season.Should().BeNull();
            traktRatingItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Show_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            var traktRatingItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_JSON_NOT_VALID_5);

            traktRatingItem.Should().NotBeNull();
            traktRatingItem.RatedAt.Should().BeNull();
            traktRatingItem.Rating.Should().BeNull();
            traktRatingItem.Type.Should().BeNull();
            traktRatingItem.Show.Should().BeNull();
            traktRatingItem.Movie.Should().BeNull();
            traktRatingItem.Season.Should().BeNull();
            traktRatingItem.Episode.Should().BeNull();
        }
    }
}
