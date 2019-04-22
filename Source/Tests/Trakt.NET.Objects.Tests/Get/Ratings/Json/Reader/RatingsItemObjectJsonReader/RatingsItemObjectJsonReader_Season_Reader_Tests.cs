namespace TraktNet.Objects.Tests.Get.Ratings.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Ratings.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Ratings.JsonReader")]
    public partial class RatingsItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new RatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().Be(8);
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Season);
                traktRatingItem.Season.Should().NotBeNull();
                traktRatingItem.Season.Number.Should().Be(1);
                traktRatingItem.Season.Ids.Should().NotBeNull();
                traktRatingItem.Season.Ids.Trakt.Should().Be(61430U);
                traktRatingItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktRatingItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktRatingItem.Season.Ids.TvRage.Should().Be(36939U);

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new RatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().BeNull();
                traktRatingItem.Rating.Should().Be(8);
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Season);
                traktRatingItem.Season.Should().NotBeNull();
                traktRatingItem.Season.Number.Should().Be(1);
                traktRatingItem.Season.Ids.Should().NotBeNull();
                traktRatingItem.Season.Ids.Trakt.Should().Be(61430U);
                traktRatingItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktRatingItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktRatingItem.Season.Ids.TvRage.Should().Be(36939U);

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new RatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().BeNull();
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Season);
                traktRatingItem.Season.Should().NotBeNull();
                traktRatingItem.Season.Number.Should().Be(1);
                traktRatingItem.Season.Ids.Should().NotBeNull();
                traktRatingItem.Season.Ids.Trakt.Should().Be(61430U);
                traktRatingItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktRatingItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktRatingItem.Season.Ids.TvRage.Should().Be(36939U);

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new RatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().Be(8);
                traktRatingItem.Type.Should().BeNull();
                traktRatingItem.Season.Should().NotBeNull();
                traktRatingItem.Season.Number.Should().Be(1);
                traktRatingItem.Season.Ids.Should().NotBeNull();
                traktRatingItem.Season.Ids.Trakt.Should().Be(61430U);
                traktRatingItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktRatingItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktRatingItem.Season.Ids.TvRage.Should().Be(36939U);

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new RatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().Be(8);
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Season);
                traktRatingItem.Season.Should().BeNull();

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new RatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().BeNull();
                traktRatingItem.Type.Should().BeNull();
                traktRatingItem.Season.Should().BeNull();

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new RatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().BeNull();
                traktRatingItem.Rating.Should().Be(8);
                traktRatingItem.Type.Should().BeNull();
                traktRatingItem.Season.Should().BeNull();

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new RatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().BeNull();
                traktRatingItem.Rating.Should().BeNull();
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Season);
                traktRatingItem.Season.Should().BeNull();

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new RatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().BeNull();
                traktRatingItem.Rating.Should().BeNull();
                traktRatingItem.Type.Should().BeNull();
                traktRatingItem.Season.Should().NotBeNull();
                traktRatingItem.Season.Number.Should().Be(1);
                traktRatingItem.Season.Ids.Should().NotBeNull();
                traktRatingItem.Season.Ids.Trakt.Should().Be(61430U);
                traktRatingItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktRatingItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktRatingItem.Season.Ids.TvRage.Should().Be(36939U);

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new RatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().BeNull();
                traktRatingItem.Rating.Should().Be(8);
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Season);
                traktRatingItem.Season.Should().NotBeNull();
                traktRatingItem.Season.Number.Should().Be(1);
                traktRatingItem.Season.Ids.Should().NotBeNull();
                traktRatingItem.Season.Ids.Trakt.Should().Be(61430U);
                traktRatingItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktRatingItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktRatingItem.Season.Ids.TvRage.Should().Be(36939U);

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new RatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().BeNull();
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Season);
                traktRatingItem.Season.Should().NotBeNull();
                traktRatingItem.Season.Number.Should().Be(1);
                traktRatingItem.Season.Ids.Should().NotBeNull();
                traktRatingItem.Season.Ids.Trakt.Should().Be(61430U);
                traktRatingItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktRatingItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktRatingItem.Season.Ids.TvRage.Should().Be(36939U);

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new RatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().Be(8);
                traktRatingItem.Type.Should().BeNull();
                traktRatingItem.Season.Should().NotBeNull();
                traktRatingItem.Season.Number.Should().Be(1);
                traktRatingItem.Season.Ids.Should().NotBeNull();
                traktRatingItem.Season.Ids.Trakt.Should().Be(61430U);
                traktRatingItem.Season.Ids.Tvdb.Should().Be(279121U);
                traktRatingItem.Season.Ids.Tmdb.Should().Be(60523U);
                traktRatingItem.Season.Ids.TvRage.Should().Be(36939U);

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new RatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().Be(8);
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Season);
                traktRatingItem.Season.Should().BeNull();

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new RatingsItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRatingItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().BeNull();
                traktRatingItem.Rating.Should().BeNull();
                traktRatingItem.Type.Should().BeNull();
                traktRatingItem.Season.Should().BeNull();
                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
            }
        }
    }
}
