namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Recommendations;
    using TraktNet.Objects.Get.Recommendations.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Recommendations.JsonReader")]
    public partial class RecommendedShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Complete()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_1()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().BeNull();
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_2()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().BeNull();
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_3()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().BeNull();
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_4()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().BeNull();
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_5()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().BeNull();
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_6()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_6);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().BeNull();
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_7()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_7);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().BeNull();
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_8()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_8);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().BeNull();
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_9()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_9);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().BeNull();
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_10()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_10);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().BeNull();
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_11()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_11);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().BeNull();
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_12()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_12);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().BeNull();
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_13()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_13);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().BeNull();
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_14()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_14);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().BeNull();
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_15()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_15);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().BeNull();
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_16()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_16);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().BeNull();
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_17()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_17);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().BeNull();
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_18()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_18);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().BeNull();
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_19()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_19);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().BeNull();
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_20()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_20);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().BeNull();
            traktRecommendedShow.Seasons.Should().BeNull();

            traktRecommendedShow.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedShow.RecommendedBy.First();

            recommendedBy.Should().NotBeNull();
            recommendedBy.User.Should().NotBeNull();
            recommendedBy.User.Username.Should().Be("sean");
            recommendedBy.User.IsPrivate.Should().BeFalse();
            recommendedBy.User.Name.Should().Be("Sean Rudford");
            recommendedBy.User.IsVIP.Should().BeTrue();
            recommendedBy.User.IsVIP_EP.Should().BeTrue();
            recommendedBy.User.Ids.Should().NotBeNull();
            recommendedBy.User.Ids.Slug.Should().Be("sean");
            recommendedBy.User.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            recommendedBy.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            recommendedBy.User.Location.Should().Be("SF");
            recommendedBy.User.About.Should().Be("I have all your cassette tapes.");
            recommendedBy.User.Gender.Should().Be("male");
            recommendedBy.User.Age.Should().Be(35);
            recommendedBy.User.Images.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Should().NotBeNull();
            recommendedBy.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            recommendedBy.User.IsVIP_OG.Should().BeTrue();
            recommendedBy.User.VIP_Years.Should().Be(5);
            recommendedBy.User.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
            recommendedBy.Notes.Should().Be("Recommended because ...");
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Incomplete_21()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_21);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedShow.Should().NotBeNull();
            traktRecommendedShow.Title.Should().Be("Game of Thrones");
            traktRecommendedShow.Year.Should().Be(2011);
            traktRecommendedShow.Ids.Should().NotBeNull();
            traktRecommendedShow.Ids.Trakt.Should().Be(1390U);
            traktRecommendedShow.Ids.Slug.Should().Be("game-of-thrones");
            traktRecommendedShow.Ids.Tvdb.Should().Be(121361U);
            traktRecommendedShow.Ids.Imdb.Should().Be("tt0944947");
            traktRecommendedShow.Ids.Tmdb.Should().Be(1399U);
            traktRecommendedShow.Ids.TvRage.Should().Be(24493U);
            traktRecommendedShow.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros.");
            traktRecommendedShow.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            traktRecommendedShow.Airs.Should().NotBeNull();
            traktRecommendedShow.Airs.Day.Should().Be("Sunday");
            traktRecommendedShow.Airs.Time.Should().Be("21:00");
            traktRecommendedShow.Airs.TimeZoneId.Should().Be("America/New_York");
            traktRecommendedShow.Runtime.Should().Be(60);
            traktRecommendedShow.Certification.Should().Be("TV-MA");
            traktRecommendedShow.Network.Should().Be("HBO");
            traktRecommendedShow.CountryCode.Should().Be("us");
            traktRecommendedShow.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            traktRecommendedShow.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            traktRecommendedShow.Status.Should().Be(TraktShowStatus.ReturningSeries);
            traktRecommendedShow.Rating.Should().Be(9.38327f);
            traktRecommendedShow.Votes.Should().Be(44773);
            traktRecommendedShow.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            traktRecommendedShow.LanguageCode.Should().Be("en");
            traktRecommendedShow.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            traktRecommendedShow.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            traktRecommendedShow.AiredEpisodes.Should().Be(50);
            traktRecommendedShow.Seasons.Should().BeNull();
            traktRecommendedShow.RecommendedBy.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Null()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();
            Func<Task<ITraktRecommendedShow>> traktRecommendedShow = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktRecommendedShow.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendedShowObjectJsonReader_ReadObject_Empty()
        {
            var traktJsonReader = new RecommendedShowObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedShow = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktRecommendedShow.Should().BeNull();
        }
    }
}
