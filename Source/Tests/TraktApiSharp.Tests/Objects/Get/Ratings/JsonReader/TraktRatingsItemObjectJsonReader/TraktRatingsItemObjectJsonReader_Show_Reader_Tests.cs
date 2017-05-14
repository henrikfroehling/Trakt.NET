namespace TraktApiSharp.Tests.Objects.Get.Ratings.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Ratings.JsonReader;
    using Xunit;

    [Category("Objects.Get.Ratings.JsonReader")]
    public partial class TraktRatingsItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_Show_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktRatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktRatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktRatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new TraktRatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new TraktRatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().Be(9);
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Show);
                traktRatingItem.Show.Should().BeNull();

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Season.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new TraktRatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().BeNull();
                traktRatingItem.Type.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Season.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new TraktRatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().BeNull();
                traktRatingItem.Rating.Should().Be(9);
                traktRatingItem.Type.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Season.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new TraktRatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().BeNull();
                traktRatingItem.Rating.Should().BeNull();
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Show);
                traktRatingItem.Show.Should().BeNull();

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Season.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new TraktRatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktRatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktRatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktRatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new TraktRatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().Be(9);
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Show);
                traktRatingItem.Show.Should().BeNull();

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Season.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktRatingsItemObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new TraktRatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

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
}
