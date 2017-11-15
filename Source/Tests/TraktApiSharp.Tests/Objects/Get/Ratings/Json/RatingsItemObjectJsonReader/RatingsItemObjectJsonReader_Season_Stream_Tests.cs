namespace TraktApiSharp.Tests.Objects.Get.Ratings.Json
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Ratings.Json;
    using Xunit;

    [Category("Objects.Get.Ratings.JsonReader")]
    public partial class RatingsItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_COMPLETE.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_1.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_2.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_3.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_4.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_5.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_6.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_7.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_INCOMPLETE_8.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_NOT_VALID_1.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_NOT_VALID_2.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_NOT_VALID_3.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_NOT_VALID_4.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_RatingsItemObjectJsonReader_Season_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_SEASON_JSON_NOT_VALID_5.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

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
