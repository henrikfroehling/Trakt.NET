namespace TraktApiSharp.Tests.Objects.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Get.Movies;
    using Utils;

    [TestClass]
    public class TraktMovieTests
    {
        [TestMethod]
        public void TestTraktMovieDefaultConstructor()
        {
            var movie = new TraktMovie();

            movie.Title.Should().BeNullOrEmpty();
            movie.Year.Should().NotHaveValue();
            movie.Ids.Should().BeNull();
            movie.Tagline.Should().BeNullOrEmpty();
            movie.Overview.Should().BeNullOrEmpty();
            movie.Released.Should().NotHaveValue();
            movie.Runtime.Should().NotHaveValue();
            movie.UpdatedAt.Should().NotHaveValue();
            movie.Trailer.Should().BeNullOrEmpty();
            movie.Homepage.Should().BeNullOrEmpty();
            movie.Rating.Should().NotHaveValue();
            movie.Votes.Should().NotHaveValue();
            movie.LanguageCode.Should().BeNullOrEmpty();
            movie.AvailableTranslationLanguageCodes.Should().BeNull();
            movie.Genres.Should().BeNull();
            movie.Certification.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktMovieReadFromJsonMinimal()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieSummaryMinimal.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var movie = JsonConvert.DeserializeObject<TraktMovie>(jsonFile);

            movie.Should().NotBeNull();
            movie.Title.Should().Be("Star Wars: The Force Awakens");
            movie.Year.Should().Be(2015);
            movie.Ids.Should().NotBeNull();
            movie.Ids.Trakt.Should().Be(94024U);
            movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movie.Ids.Imdb.Should().Be("tt2488496");
            movie.Ids.Tmdb.Should().Be(140607U);
            movie.Tagline.Should().BeNullOrEmpty();
            movie.Overview.Should().BeNullOrEmpty();
            movie.Released.Should().NotHaveValue();
            movie.Runtime.Should().NotHaveValue();
            movie.UpdatedAt.Should().NotHaveValue();
            movie.Trailer.Should().BeNullOrEmpty();
            movie.Homepage.Should().BeNullOrEmpty();
            movie.Rating.Should().NotHaveValue();
            movie.Votes.Should().NotHaveValue();
            movie.LanguageCode.Should().BeNullOrEmpty();
            movie.AvailableTranslationLanguageCodes.Should().BeNull();
            movie.Genres.Should().BeNull();
            movie.Certification.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktMovieReadFromJsonFull()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieSummaryFull.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var movie = JsonConvert.DeserializeObject<TraktMovie>(jsonFile);

            movie.Should().NotBeNull();
            movie.Title.Should().Be("Star Wars: The Force Awakens");
            movie.Year.Should().Be(2015);
            movie.Ids.Should().NotBeNull();
            movie.Ids.Trakt.Should().Be(94024U);
            movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            movie.Ids.Imdb.Should().Be("tt2488496");
            movie.Ids.Tmdb.Should().Be(140607U);
            movie.Tagline.Should().Be("Every generation has a story.");
            movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            movie.Runtime.Should().Be(136);
            movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            movie.Rating.Should().Be(8.31988f);
            movie.Votes.Should().Be(9338);
            movie.LanguageCode.Should().Be("en");
            movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            movie.Certification.Should().Be("PG-13");
        }
    }
}
