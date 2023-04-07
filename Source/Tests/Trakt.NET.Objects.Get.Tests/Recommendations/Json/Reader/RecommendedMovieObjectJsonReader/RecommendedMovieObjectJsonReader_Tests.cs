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
    public partial class RecommendedMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Complete()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_1()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().BeNull();
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_2()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().BeNull();
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_3()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().BeNull();
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_4()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().BeNull();
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_5()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().BeNull();
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_6()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_6);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().BeNull();
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_7()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_7);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().BeNull();
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_8()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_8);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().BeNull();
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_9()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_9);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().BeNull();
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_10()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_10);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().BeNull();
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_11()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_11);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().BeNull();
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_12()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_12);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().BeNull();
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_13()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_13);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().BeNull();
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_14()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_14);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_15()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_15);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().BeNull();
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_16()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_16);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().BeNull();
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_17()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_17);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().BeNull();
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_18()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_18);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().BeNull();

            traktRecommendedMovie.RecommendedBy.Should().NotBeNull().And.HaveCount(1);

            ITraktRecommendedBy recommendedBy = traktRecommendedMovie.RecommendedBy.First();

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
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Incomplete_19()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_19);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().Be("Star Wars: The Force Awakens");
            traktRecommendedMovie.Year.Should().Be(2015);
            traktRecommendedMovie.Ids.Should().NotBeNull();
            traktRecommendedMovie.Ids.Trakt.Should().Be(94024U);
            traktRecommendedMovie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            traktRecommendedMovie.Ids.Imdb.Should().Be("tt2488496");
            traktRecommendedMovie.Ids.Tmdb.Should().Be(140607U);
            traktRecommendedMovie.Tagline.Should().Be("Every generation has a story.");
            traktRecommendedMovie.Overview.Should().Be("Thirty years after defeating the Galactic Empire,...");
            traktRecommendedMovie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            traktRecommendedMovie.Runtime.Should().Be(136);
            traktRecommendedMovie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            traktRecommendedMovie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            traktRecommendedMovie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            traktRecommendedMovie.Rating.Should().Be(8.31988f);
            traktRecommendedMovie.Votes.Should().Be(9338);
            traktRecommendedMovie.LanguageCode.Should().Be("en");
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            traktRecommendedMovie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            traktRecommendedMovie.Certification.Should().Be("PG-13");
            traktRecommendedMovie.CountryCode.Should().Be("us");
            traktRecommendedMovie.Status.Should().Be(TraktMovieStatus.Released);
            traktRecommendedMovie.RecommendedBy.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Not_Valid()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktRecommendedMovie.Should().NotBeNull();
            traktRecommendedMovie.Title.Should().BeNull();
            traktRecommendedMovie.Year.Should().BeNull();
            traktRecommendedMovie.Ids.Should().BeNull();
            traktRecommendedMovie.Tagline.Should().BeNull();
            traktRecommendedMovie.Overview.Should().BeNull();
            traktRecommendedMovie.Released.Should().BeNull();
            traktRecommendedMovie.Runtime.Should().BeNull();
            traktRecommendedMovie.UpdatedAt.Should().BeNull();
            traktRecommendedMovie.Trailer.Should().BeNull();
            traktRecommendedMovie.Homepage.Should().BeNull();
            traktRecommendedMovie.Rating.Should().BeNull();
            traktRecommendedMovie.Votes.Should().BeNull();
            traktRecommendedMovie.LanguageCode.Should().BeNull();
            traktRecommendedMovie.AvailableTranslationLanguageCodes.Should().BeNull();
            traktRecommendedMovie.Genres.Should().BeNull();
            traktRecommendedMovie.Certification.Should().BeNull();
            traktRecommendedMovie.CountryCode.Should().BeNull();
            traktRecommendedMovie.Status.Should().BeNull();
            traktRecommendedMovie.RecommendedBy.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Null()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();
            Func<Task<ITraktRecommendedMovie>> traktRecommendedMovie = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktRecommendedMovie.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_RecommendedMovieObjectJsonReader_ReadObject_Empty()
        {
            var traktJsonReader = new RecommendedMovieObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktRecommendedMovie = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktRecommendedMovie.Should().BeNull();
        }
    }
}
