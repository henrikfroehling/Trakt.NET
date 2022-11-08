namespace TraktNet.Objects.Get.Tests.Ratings.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Ratings.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Ratings.JsonReader")]
    public partial class RatingsItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Episode_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_COMPLETE.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().Be(7);
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Episode);
                traktRatingItem.Episode.Should().NotBeNull();
                traktRatingItem.Episode.SeasonNumber.Should().Be(1);
                traktRatingItem.Episode.Number.Should().Be(1);
                traktRatingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktRatingItem.Episode.Ids.Should().NotBeNull();
                traktRatingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktRatingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktRatingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktRatingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktRatingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_1.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().BeNull();
                traktRatingItem.Rating.Should().Be(7);
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Episode);
                traktRatingItem.Episode.Should().NotBeNull();
                traktRatingItem.Episode.SeasonNumber.Should().Be(1);
                traktRatingItem.Episode.Number.Should().Be(1);
                traktRatingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktRatingItem.Episode.Ids.Should().NotBeNull();
                traktRatingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktRatingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktRatingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktRatingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktRatingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_2.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().BeNull();
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Episode);
                traktRatingItem.Episode.Should().NotBeNull();
                traktRatingItem.Episode.SeasonNumber.Should().Be(1);
                traktRatingItem.Episode.Number.Should().Be(1);
                traktRatingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktRatingItem.Episode.Ids.Should().NotBeNull();
                traktRatingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktRatingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktRatingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktRatingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktRatingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_3.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().Be(7);
                traktRatingItem.Type.Should().BeNull();
                traktRatingItem.Episode.Should().NotBeNull();
                traktRatingItem.Episode.SeasonNumber.Should().Be(1);
                traktRatingItem.Episode.Number.Should().Be(1);
                traktRatingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktRatingItem.Episode.Ids.Should().NotBeNull();
                traktRatingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktRatingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktRatingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktRatingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktRatingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_4.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().Be(7);
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Episode);
                traktRatingItem.Episode.Should().BeNull();
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
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_5.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().Be(7);
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Episode);
                traktRatingItem.Episode.Should().NotBeNull();
                traktRatingItem.Episode.SeasonNumber.Should().Be(1);
                traktRatingItem.Episode.Number.Should().Be(1);
                traktRatingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktRatingItem.Episode.Ids.Should().NotBeNull();
                traktRatingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktRatingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktRatingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktRatingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktRatingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktRatingItem.Show.Should().BeNull();

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_6.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().BeNull();
                traktRatingItem.Type.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_7.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().BeNull();
                traktRatingItem.Rating.Should().Be(7);
                traktRatingItem.Type.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_8.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().BeNull();
                traktRatingItem.Rating.Should().BeNull();
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Episode);
                traktRatingItem.Episode.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_9.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().BeNull();
                traktRatingItem.Rating.Should().BeNull();
                traktRatingItem.Type.Should().BeNull();
                traktRatingItem.Episode.Should().NotBeNull();
                traktRatingItem.Episode.SeasonNumber.Should().Be(1);
                traktRatingItem.Episode.Number.Should().Be(1);
                traktRatingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktRatingItem.Episode.Ids.Should().NotBeNull();
                traktRatingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktRatingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktRatingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktRatingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktRatingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktRatingItem.Show.Should().BeNull();

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Episode_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_INCOMPLETE_10.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().BeNull();
                traktRatingItem.Rating.Should().BeNull();
                traktRatingItem.Type.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
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
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_1.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().BeNull();
                traktRatingItem.Rating.Should().Be(7);
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Episode);
                traktRatingItem.Episode.Should().NotBeNull();
                traktRatingItem.Episode.SeasonNumber.Should().Be(1);
                traktRatingItem.Episode.Number.Should().Be(1);
                traktRatingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktRatingItem.Episode.Ids.Should().NotBeNull();
                traktRatingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktRatingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktRatingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktRatingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktRatingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_2.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().BeNull();
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Episode);
                traktRatingItem.Episode.Should().NotBeNull();
                traktRatingItem.Episode.SeasonNumber.Should().Be(1);
                traktRatingItem.Episode.Number.Should().Be(1);
                traktRatingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktRatingItem.Episode.Ids.Should().NotBeNull();
                traktRatingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktRatingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktRatingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktRatingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktRatingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_3.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().Be(7);
                traktRatingItem.Type.Should().BeNull();
                traktRatingItem.Episode.Should().NotBeNull();
                traktRatingItem.Episode.SeasonNumber.Should().Be(1);
                traktRatingItem.Episode.Number.Should().Be(1);
                traktRatingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktRatingItem.Episode.Ids.Should().NotBeNull();
                traktRatingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktRatingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktRatingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktRatingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktRatingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
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
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_4.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().Be(7);
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Episode);
                traktRatingItem.Episode.Should().BeNull();
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
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_5.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktRatingItem.Rating.Should().Be(7);
                traktRatingItem.Type.Should().Be(TraktRatingsItemType.Episode);
                traktRatingItem.Episode.Should().NotBeNull();
                traktRatingItem.Episode.SeasonNumber.Should().Be(1);
                traktRatingItem.Episode.Number.Should().Be(1);
                traktRatingItem.Episode.Title.Should().Be("Winter Is Coming");
                traktRatingItem.Episode.Ids.Should().NotBeNull();
                traktRatingItem.Episode.Ids.Trakt.Should().Be(73640U);
                traktRatingItem.Episode.Ids.Tvdb.Should().Be(3254641U);
                traktRatingItem.Episode.Ids.Imdb.Should().Be("tt1480055");
                traktRatingItem.Episode.Ids.Tmdb.Should().Be(63056U);
                traktRatingItem.Episode.Ids.TvRage.Should().Be(1065008299U);
                traktRatingItem.Show.Should().BeNull();

                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RatingsItemObjectJsonReader_Episode_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new RatingsItemObjectJsonReader();

            using (var stream = TYPE_EPISODE_JSON_NOT_VALID_6.ToStream())
            {
                var traktRatingItem = await jsonReader.ReadObjectAsync(stream);

                traktRatingItem.Should().NotBeNull();
                traktRatingItem.RatedAt.Should().BeNull();
                traktRatingItem.Rating.Should().BeNull();
                traktRatingItem.Type.Should().BeNull();
                traktRatingItem.Episode.Should().BeNull();
                traktRatingItem.Show.Should().BeNull();
                traktRatingItem.Movie.Should().BeNull();
                traktRatingItem.Season.Should().BeNull();
            }
        }
    }
}
