namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests;
    using Utils;

    [TestClass]
    public class TraktMoviesModuleTests
    {
        [TestMethod]
        public void TestTraktMoviesModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktMoviesModule)).Should().BeTrue();
        }

        [ClassInitialize]
        public static void InitializeTests(TestContext context)
        {
            TestUtility.SetupMockHttpClient();
        }

        [ClassCleanup]
        public static void CleanupTests()
        {
            TestUtility.ResetMockHttpClient();
        }

        [TestCleanup]
        public void CleanupSingleTest()
        {
            TestUtility.ClearMockHttpClient();
        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region SingleMovie

        [TestMethod]
        public void TestTraktMoviesModuleGetSingleMovie()
        {
            var movie = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieSummaryFullAndImages.json");
            movie.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}", movie);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAsync(movieId).Result;

            response.Should().NotBeNull();
            response.Title.Should().Be("Star Wars: The Force Awakens");
            response.Year.Should().Be(2015);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(94024);
            response.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            response.Ids.Imdb.Should().Be("tt2488496");
            response.Ids.Tmdb.Should().Be(140607);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetSingleMovieWithExtendedOption()
        {
            var movie = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieSummaryFullAndImages.json");
            movie.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}?extended={extendedOption.ToString()}", movie);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAsync(movieId, extendedOption).Result;

            response.Should().NotBeNull();
            response.Title.Should().Be("Star Wars: The Force Awakens");
            response.Year.Should().Be(2015);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(94024);
            response.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            response.Ids.Imdb.Should().Be("tt2488496");
            response.Ids.Tmdb.Should().Be(140607);
            response.Images.Should().NotBeNull();
            response.Images.FanArt.Full.Should().Be("https://walter.trakt.us/images/movies/000/094/024/fanarts/original/707a0ae2ab.jpg");
            response.Images.FanArt.Medium.Should().Be("https://walter.trakt.us/images/movies/000/094/024/fanarts/medium/707a0ae2ab.jpg");
            response.Images.FanArt.Thumb.Should().Be("https://walter.trakt.us/images/movies/000/094/024/fanarts/thumb/707a0ae2ab.jpg");
            response.Images.Poster.Full.Should().Be("https://walter.trakt.us/images/movies/000/094/024/posters/original/45feef2558.jpg");
            response.Images.Poster.Medium.Should().Be("https://walter.trakt.us/images/movies/000/094/024/posters/medium/45feef2558.jpg");
            response.Images.Poster.Thumb.Should().Be("https://walter.trakt.us/images/movies/000/094/024/posters/thumb/45feef2558.jpg");
            response.Images.Logo.Full.Should().Be("https://walter.trakt.us/images/movies/000/094/024/logos/original/077cc27594.png");
            response.Images.ClearArt.Full.Should().Be("https://walter.trakt.us/images/movies/000/094/024/cleararts/original/a31ab70d60.png");
            response.Images.Banner.Full.Should().Be("https://walter.trakt.us/images/movies/000/094/024/banners/original/b20b70cbf5.jpg");
            response.Images.Thumb.Full.Should().Be("https://walter.trakt.us/images/movies/000/094/024/thumbs/original/627810fb39.jpg");
            response.Tagline.Should().Be("Every generation has a story.");
            response.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            response.Released.Should().Be(DateTime.Parse("2015-12-18"));
            response.Runtime.Should().Be(136);
            response.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            response.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            response.TrailerUri.Should().NotBeNull();
            response.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            response.HomepageUri.Should().NotBeNull();
            response.Rating.Should().Be(8.31988f);
            response.Votes.Should().Be(9338);
            response.LanguageCode.Should().Be("en");
            response.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            response.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            response.Certification.Should().Be("PG-13");
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetSingleMovieExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktMovie>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetSingleMovieArgumentExceptions()
        {
            var movie = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieSummaryFullAndImages.json");
            movie.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}", movie);

            Func<Task<TraktMovie>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MultipleMovies

        [TestMethod]
        public void TestTraktMoviesModuleGetMultipleMoviesArgumentExceptions()
        {
            Func<Task<TraktListResult<TraktMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviesAsync(new string[] { null });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviesAsync(new string[] { string.Empty });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviesAsync(new string[] { });
            act.ShouldNotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviesAsync(null);
            act.ShouldNotThrow();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieAliases

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieAliases()
        {
            var movieAliases = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieAliases.json");
            movieAliases.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/aliases", movieAliases);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAliasesAsync(movieId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieAliasesExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/aliases";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResult<TraktMovieAlias>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAliasesAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieAliasesArgumentExceptions()
        {
            var movieAliases = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieAliases.json");
            movieAliases.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/aliases", movieAliases);

            Func<Task<TraktListResult<TraktMovieAlias>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAliasesAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAliasesAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieReleases

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieReleases()
        {
            var movieReleases = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieReleases.json");
            movieReleases.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/releases", movieReleases);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(movieId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieReleasesExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/releases";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResult<TraktMovieRelease>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieReleasesArgumentExceptions()
        {
            var movieReleases = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieReleases.json");
            movieReleases.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/releases", movieReleases);

            Func<Task<TraktListResult<TraktMovieRelease>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieSingleRelease

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieSingleRelease()
        {
            var movieRelease = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieSingleRelease.json");
            movieRelease.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var countryCode = "us";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/releases/{countryCode}", movieRelease);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleReleaseAsync(movieId, countryCode).Result;

            response.Should().NotBeNull();
            response.CountryCode.Should().Be(countryCode);
            response.Certification.Should().Be("PG-13");
            response.ReleaseDate.Should().Be(DateTime.Parse("2015-12-14"));
            response.ReleaseType.Should().Be(TraktReleaseType.Premiere);
            response.Note.Should().Be("Los Angeles, California");
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieSingleReleaseExceptions()
        {
            var movieId = "94024";
            var countryCode = "us";
            var uri = $"movies/{movieId}/releases/{countryCode}";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktMovieRelease>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleReleaseAsync(movieId, countryCode);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieSingleReleaseArgumentExceptions()
        {
            var movieRelease = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieSingleRelease.json");
            movieRelease.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var countryCode = "us";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/releases/{countryCode}", movieRelease);

            Func<Task<TraktMovieRelease>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleReleaseAsync(null, countryCode);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleReleaseAsync(string.Empty, countryCode);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleReleaseAsync(movieId, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleReleaseAsync(movieId, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleReleaseAsync(movieId, "u");
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleReleaseAsync(movieId, "usa");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieTranslations

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieTranslations()
        {
            var movieTranslations = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieTranslations.json");
            movieTranslations.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/translations", movieTranslations);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieTranslationsAsync(movieId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieTranslationsExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/translations";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResult<TraktMovieTranslation>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieTranslationsAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieTranslationsArgumentExceptions()
        {
            var movieTranslations = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieTranslations.json");
            movieTranslations.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/translations", movieTranslations);

            Func<Task<TraktListResult<TraktMovieTranslation>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieTranslationsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieTranslationsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieSingleTranslation

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieSingleTranslation()
        {
            var movieTranslation = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieSingleTranslation.json");
            movieTranslation.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var languageCode = "en";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/translations/{languageCode}", movieTranslation);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleTranslationAsync(movieId, languageCode).Result;

            response.Should().NotBeNull();
            response.Title.Should().Be("Star Wars: Episode VII - The Force Awakens");
            response.Overview.Should().Be("A continuation of the saga created by George Lucas, set thirty years after Star Wars: Episode VI – Return of the Jedi.");
            response.Tagline.Should().Be("The Force Lives On...");
            response.LanguageCode.Should().Be(languageCode);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieSingleTranslationExceptions()
        {
            var movieId = "94024";
            var languageCode = "us";
            var uri = $"movies/{movieId}/translations/{languageCode}";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktMovieTranslation>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleTranslationAsync(movieId, languageCode);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieSingleTranslationArgumentExceptions()
        {
            var movieTranslation = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieSingleTranslation.json");
            movieTranslation.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var languageCode = "en";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/translations/{languageCode}", movieTranslation);

            Func<Task<TraktMovieTranslation>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleTranslationAsync(null, languageCode);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleTranslationAsync(string.Empty, languageCode);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleTranslationAsync(movieId, null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleTranslationAsync(movieId, string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleTranslationAsync(movieId, "u");
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleTranslationAsync(movieId, "usa");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieComments

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieComments()
        {
            var movieComments = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieComments.json");
            movieComments.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments",
                                                                movieComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsWithSortOrder()
        {
            var movieComments = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieComments.json");
            movieComments.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            var sortOrder = TraktCommentSortOrder.Likes;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments/{sortOrder.AsString()}",
                                                                movieComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, sortOrder).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsWithPage()
        {
            var movieComments = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieComments.json");
            movieComments.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments?page={page}",
                                                                movieComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsWithSortOrderAndPage()
        {
            var movieComments = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieComments.json");
            movieComments.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            var sortOrder = TraktCommentSortOrder.Likes;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments/{sortOrder.AsString()}?page={page}",
                                                                movieComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, sortOrder, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsWithLimit()
        {
            var movieComments = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieComments.json");
            movieComments.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments?limit={limit}",
                                                                movieComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsWithSortOrderAndLimit()
        {
            var movieComments = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieComments.json");
            movieComments.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            var sortOrder = TraktCommentSortOrder.Likes;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments/{sortOrder.AsString()}?limit={limit}",
                                                                movieComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, sortOrder, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsWithPageAndLimit()
        {
            var movieComments = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieComments.json");
            movieComments.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments?page={page}&limit={limit}",
                                                                movieComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsComplete()
        {
            var movieComments = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieComments.json");
            movieComments.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            var sortOrder = TraktCommentSortOrder.Likes;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments/{sortOrder.AsString()}?page={page}&limit={limit}",
                                                                movieComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, sortOrder, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/comments";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktMovieComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsArgumentExceptions()
        {
            var movieComments = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieComments.json");
            movieComments.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments", movieComments);

            Func<Task<TraktPaginationListResult<TraktMovieComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviePeople

        [TestMethod]
        public void TestTraktMoviesModuleGetMoviePeople()
        {
            var moviePeople = TestUtility.ReadFileContents(@"Objects\Get\Movies\MoviePeople.json");
            moviePeople.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/people", moviePeople);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviePeopleAsync(movieId).Result;

            response.Should().NotBeNull();
            response.Cast.Should().NotBeNull().And.HaveCount(3);
            response.Crew.Should().NotBeNull();
            response.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            response.Crew.Art.Should().NotBeNull().And.HaveCount(2);
            response.Crew.Crew.Should().NotBeNull().And.HaveCount(2);
            response.Crew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
            response.Crew.Directing.Should().NotBeNull().And.HaveCount(1);
            response.Crew.Writing.Should().NotBeNull().And.HaveCount(2);
            response.Crew.Sound.Should().NotBeNull().And.HaveCount(2);
            response.Crew.Camera.Should().NotBeNull().And.HaveCount(2);
            response.Crew.Lighting.Should().NotBeNull().And.HaveCount(2);
            response.Crew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
            response.Crew.Editing.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMoviePeopleWithExtendedOption()
        {
            var moviePeople = TestUtility.ReadFileContents(@"Objects\Get\Movies\MoviePeople.json");
            moviePeople.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/people?extended={extendedOption.ToString()}", moviePeople);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviePeopleAsync(movieId, extendedOption).Result;

            response.Should().NotBeNull();
            response.Cast.Should().NotBeNull().And.HaveCount(3);
            response.Crew.Should().NotBeNull();
            response.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            response.Crew.Art.Should().NotBeNull().And.HaveCount(2);
            response.Crew.Crew.Should().NotBeNull().And.HaveCount(2);
            response.Crew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
            response.Crew.Directing.Should().NotBeNull().And.HaveCount(1);
            response.Crew.Writing.Should().NotBeNull().And.HaveCount(2);
            response.Crew.Sound.Should().NotBeNull().And.HaveCount(2);
            response.Crew.Camera.Should().NotBeNull().And.HaveCount(2);
            response.Crew.Lighting.Should().NotBeNull().And.HaveCount(2);
            response.Crew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
            response.Crew.Editing.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMoviePeopleExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/people";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktMoviePeople>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviePeopleAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMoviePeopleArgumentExceptions()
        {
            var moviePeople = TestUtility.ReadFileContents(@"Objects\Get\Movies\MoviePeople.json");
            moviePeople.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/people", moviePeople);

            Func<Task<TraktMoviePeople>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviePeopleAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviePeopleAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieRatings

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRatings()
        {
            var movieRatings = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRatings.json");
            movieRatings.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/ratings", movieRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRatingsAsync(movieId).Result;

            response.Should().NotBeNull();
            response.Rating.Should().Be(8.31325f);
            response.Votes.Should().Be(10359);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  185 }, { "2", 28 }, { "3", 34 }, { "4", 89 }, { "5", 184 },
                { "6",  630 }, { "7", 1244 }, { "8", 2509 }, { "9", 2622 }, { "10", 2834 }
            };

            response.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRatingsExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/ratings";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktMovieRating>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRatingsAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRatingsArgumentExceptions()
        {
            var movieRatings = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRatings.json");
            movieRatings.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/ratings", movieRatings);

            Func<Task<TraktMovieRating>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRatingsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRatingsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieRelatedMovies

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMovies()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFullAndImages.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related", movieRelatedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithExtendedOption()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFullAndImages.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?extended={extendedOption.ToString()}",
                                                                movieRelatedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithPage()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFullAndImages.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?page={page}",
                                                                movieRelatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithExtendedOptionAndPage()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFullAndImages.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            var page = 2;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?extended={extendedOption.ToString()}&page={page}",
                                                                movieRelatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, extendedOption, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithLimit()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFullAndImages.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?limit={limit}",
                                                                movieRelatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithExtendedOptionAndLimit()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFullAndImages.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?extended={extendedOption.ToString()}&limit={limit}",
                                                                movieRelatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, extendedOption, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithPageAndLimit()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFullAndImages.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?page={page}&limit={limit}",
                                                                movieRelatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesComplete()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFullAndImages.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?extended={extendedOption.ToString()}&page={page}&limit={limit}",
                                                                movieRelatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, extendedOption, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/related";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesArgumentExceptions()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFullAndImages.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related", movieRelatedMovies);

            Func<Task<TraktPaginationListResult<TraktMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieStatistics

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieStatistics()
        {
            var movieStatistics = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieStatistics.json");
            movieStatistics.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/stats", movieStatistics);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieStatisticsAsync(movieId).Result;

            response.Should().NotBeNull();
            response.Watchers.Should().Be(40619);
            response.Plays.Should().Be(64620);
            response.Collectors.Should().Be(17519);
            response.CollectedEpisodes.Should().NotHaveValue();
            response.Comments.Should().Be(99);
            response.Lists.Should().Be(17089);
            response.Votes.Should().Be(10359);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieStatisticsExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/stats";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktMovieStatistics>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieStatisticsAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieStatisticsArgumentExceptions()
        {
            var movieStatistics = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieStatistics.json");
            movieStatistics.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/stats", movieStatistics);

            Func<Task<TraktMovieStatistics>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieStatisticsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieStatisticsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieWatchingUsers

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieWatchingUsers()
        {
            var movieWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieWatchingUsers.json");
            movieWatchingUsers.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/watching", movieWatchingUsers);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieWatchingUsersAsync(movieId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieWatchingUsersWithExtendedOption()
        {
            var movieWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieWatchingUsers.json");
            movieWatchingUsers.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/watching?extended={extendedOption.ToString()}", movieWatchingUsers);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieWatchingUsersAsync(movieId, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieWatchingUsersExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/watching";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResult<TraktMovieWatchingUser>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieWatchingUsersAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieWatchingUsersArgumentExceptions()
        {
            var movieWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieWatchingUsers.json");
            movieWatchingUsers.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/watching", movieWatchingUsers);

            Func<Task<TraktListResult<TraktMovieWatchingUser>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieWatchingUsersAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieWatchingUsersAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviesTrending

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMovies()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviesPopular

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMovies()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviesMostPlayed

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMovies()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriod()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviesMostWatched

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMovies()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriod()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviesMostCollected

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMovies()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriod()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviesMostAnticipated

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMovies()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviesBoxOffice

        [TestMethod]
        public void TestTraktMoviesModuleGetBoxOfficeMovies()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetBoxOfficeMoviesWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetBoxOfficeMoviesExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviesRecentlyUpdated

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMovies()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithStartDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithStartDateAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithStartDateAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithStartDateAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
