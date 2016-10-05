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
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.Common;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Params;
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
            response.Ids.Trakt.Should().Be(94024U);
            response.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            response.Ids.Imdb.Should().Be("tt2488496");
            response.Ids.Tmdb.Should().Be(140607U);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetSingleMovieWithExtendedInfo()
        {
            var movie = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieSummaryFullAndImages.json");
            movie.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}?extended={extendedInfo.ToString()}", movie);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAsync(movieId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.Title.Should().Be("Star Wars: The Force Awakens");
            response.Year.Should().Be(2015);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(94024U);
            response.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            response.Ids.Imdb.Should().Be("tt2488496");
            response.Ids.Tmdb.Should().Be(140607U);
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
            response.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
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

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktMovie>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
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

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAsync("movie id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MultipleMovies

        [TestMethod]
        public void TestTraktMoviesModuleGetMultipleMoviesArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMultipleMoviesAsync(null);
            act.ShouldNotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMultipleMoviesAsync(
                new TraktMultipleObjectsQueryParams());
            act.ShouldNotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMultipleMoviesAsync(
                new TraktMultipleObjectsQueryParams { { null } });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMultipleMoviesAsync(
                new TraktMultipleObjectsQueryParams { { string.Empty } });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMultipleMoviesAsync(
                new TraktMultipleObjectsQueryParams { { "movie id" } });
            act.ShouldThrow<ArgumentException>();
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

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieAliasesExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/aliases";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktMovieAlias>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAliasesAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieAliasesArgumentExceptions()
        {
            var movieAliases = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieAliases.json");
            movieAliases.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/aliases", movieAliases);

            Func<Task<IEnumerable<TraktMovieAlias>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAliasesAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAliasesAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAliasesAsync("movie id");
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

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieReleasesExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/releases";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktMovieRelease>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieReleasesArgumentExceptions()
        {
            var movieReleases = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieReleases.json");
            movieReleases.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/releases", movieReleases);

            Func<Task<IEnumerable<TraktMovieRelease>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync("movie id");
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

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktMovieRelease>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleReleaseAsync(movieId, countryCode);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
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

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleReleaseAsync("movie id", countryCode);
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

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieTranslationsExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/translations";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktMovieTranslation>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieTranslationsAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieTranslationsArgumentExceptions()
        {
            var movieTranslations = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieTranslations.json");
            movieTranslations.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/translations", movieTranslations);

            Func<Task<IEnumerable<TraktMovieTranslation>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieTranslationsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieTranslationsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieTranslationsAsync("movie id");
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

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktMovieTranslation>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleTranslationAsync(movieId, languageCode);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
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

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieSingleTranslationAsync("movie id", languageCode);
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
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsWithSortOrder()
        {
            var movieComments = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieComments.json");
            movieComments.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            var sortOrder = TraktCommentSortOrder.Likes;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments/{sortOrder.UriName}",
                                                                movieComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, sortOrder).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
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
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments/{sortOrder.UriName}?page={page}",
                                                                movieComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, sortOrder, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
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
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments/{sortOrder.UriName}?limit={limit}",
                                                                movieComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, sortOrder, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
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
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
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

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments/{sortOrder.UriName}?page={page}&limit={limit}",
                                                                movieComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, sortOrder, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/comments";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsArgumentExceptions()
        {
            var movieComments = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieComments.json");
            movieComments.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments", movieComments);

            Func<Task<TraktPaginationListResult<TraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync("movie id");
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
        public void TestTraktMoviesModuleGetMoviePeopleWithExtendedInfo()
        {
            var moviePeople = TestUtility.ReadFileContents(@"Objects\Get\Movies\MoviePeople.json");
            moviePeople.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/people?extended={extendedInfo.ToString()}", moviePeople);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviePeopleAsync(movieId, extendedInfo).Result;

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

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktCastAndCrew>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviePeopleAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMoviePeopleArgumentExceptions()
        {
            var moviePeople = TestUtility.ReadFileContents(@"Objects\Get\Movies\MoviePeople.json");
            moviePeople.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/people", moviePeople);

            Func<Task<TraktCastAndCrew>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviePeopleAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviePeopleAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviePeopleAsync("movie id");
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

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktRating>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRatingsAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRatingsArgumentExceptions()
        {
            var movieRatings = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRatings.json");
            movieRatings.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/ratings", movieRatings);

            Func<Task<TraktRating>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRatingsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRatingsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRatingsAsync("movie id");
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
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithExtendedInfo()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFullAndImages.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?extended={extendedInfo.ToString()}",
                                                                movieRelatedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
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
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithExtendedInfoAndPage()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFullAndImages.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?extended={extendedInfo.ToString()}&page={page}",
                                                                movieRelatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, extendedInfo, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
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
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithExtendedInfoAndLimit()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFullAndImages.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?extended={extendedInfo.ToString()}&limit={limit}",
                                                                movieRelatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, extendedInfo, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
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
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
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

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                movieRelatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, extendedInfo, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/related";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
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

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync("movie id");
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

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktStatistics>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieStatisticsAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieStatisticsArgumentExceptions()
        {
            var movieStatistics = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieStatistics.json");
            movieStatistics.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/stats", movieStatistics);

            Func<Task<TraktStatistics>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieStatisticsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieStatisticsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieStatisticsAsync("movie id");
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

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieWatchingUsersWithExtendedInfo()
        {
            var movieWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieWatchingUsers.json");
            movieWatchingUsers.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/watching?extended={extendedInfo.ToString()}", movieWatchingUsers);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieWatchingUsersAsync(movieId, extendedInfo).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieWatchingUsersExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/watching";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktUser>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieWatchingUsersAsync(movieId);
            act.ShouldThrow<TraktMovieNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieWatchingUsersArgumentExceptions()
        {
            var movieWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieWatchingUsers.json");
            movieWatchingUsers.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/watching", movieWatchingUsers);

            Func<Task<IEnumerable<TraktUser>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieWatchingUsersAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieWatchingUsersAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieWatchingUsersAsync("movie id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviesTrending

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMovies()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending", moviesTrending, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.UserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesFiltered()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?{filter.ToString()}",
                                                                moviesTrending, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.UserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithExtendedInfo()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?extended={extendedInfo.ToString()}",
                                                                moviesTrending, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.UserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithExtendedInfoFiltered()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?extended={extendedInfo.ToString()}&{filter.ToString()}",
                                                                moviesTrending, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.UserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithPage()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?page={page}", moviesTrending, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.UserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithPageFiltered()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            var page = 2;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?{filter.ToString()}&page={page}",
                                                                moviesTrending, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, filter, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.UserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithExtendedInfoAndPage()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?extended={extendedInfo.ToString()}&page={page}",
                                                                moviesTrending, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.UserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithExtendedInfoAndPageFiltered()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/trending?extended={extendedInfo.ToString()}&page={page}&{filter.ToString()}",
                moviesTrending, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, filter, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.UserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithLimit()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?limit={limit}", moviesTrending, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.UserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithLimitFiltered()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?{filter.ToString()}&limit={limit}",
                                                                moviesTrending, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, filter, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.UserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithExtendedInfoAndLimit()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?extended={extendedInfo.ToString()}&limit={limit}",
                                                                moviesTrending, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.UserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithExtendedInfoAndLimitFiltered()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/trending?extended={extendedInfo.ToString()}&limit={limit}&{filter.ToString()}",
                moviesTrending, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, filter, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.UserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithPageAndLimit()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?page={page}&limit={limit}",
                                                                moviesTrending, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.UserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithPageAndLimitFiltered()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            var page = 2;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?page={page}&limit={limit}&{filter.ToString()}",
                                                                moviesTrending, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.UserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesComplete()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                moviesTrending, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.UserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesCompleteFiltered()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/trending?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                moviesTrending, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.UserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesExceptions()
        {
            var uri = $"movies/trending";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktTrendingMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviesPopular

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMovies()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular", popularMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesFiltered()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?{filter.ToString()}", popularMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(null, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithExtendedInfo()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?extended={extendedInfo.ToString()}",
                                                                popularMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithExtendedInfoFiltered()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?extended={extendedInfo.ToString()}&{filter.ToString()}",
                                                                popularMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithPage()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?page={page}", popularMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithPageFiltered()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?page={page}&{filter.ToString()}",
                                                                popularMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(null, filter, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithExtendedInfoAndPage()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?extended={extendedInfo.ToString()}&page={page}",
                                                                popularMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(extendedInfo, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithExtendedInfoAndPageFiltered()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/popular?extended={extendedInfo.ToString()}&{filter.ToString()}&page={page}",
                popularMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(extendedInfo, filter, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithLimit()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?limit={limit}", popularMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithLimitFiltered()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?limit={limit}&{filter.ToString()}",
                                                                popularMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(null, filter, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithExtendedInfoAndLimit()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?extended={extendedInfo.ToString()}&limit={limit}",
                                                                popularMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(extendedInfo, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithExtendedInfoAndLimitFiltered()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/popular?extended={extendedInfo.ToString()}&limit={limit}&{filter.ToString()}",
                popularMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(extendedInfo, filter, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithPageAndLimit()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?page={page}&limit={limit}",
                                                                popularMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithPageAndLimitFiltered()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?page={page}&limit={limit}&{filter.ToString()}",
                                                                popularMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(null, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesComplete()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                popularMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(extendedInfo, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesCompleteFiltered()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/popular?extended={extendedInfo.ToString()}&{filter.ToString()}&page={page}&limit={limit}",
                popularMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(extendedInfo, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesExceptions()
        {
            var uri = $"movies/popular";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviesMostPlayed

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMovies()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played", mostPlayedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?{filter.ToString()}", mostPlayedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriod()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}",
                                                                mostPlayedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?{filter.ToString()}",
                                                                mostPlayedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedInfo()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?extended={extendedInfo.ToString()}",
                                                                mostPlayedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedInfoFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?extended={extendedInfo.ToString()}&{filter.ToString()}",
                                                                mostPlayedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPage()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?page={page}", mostPlayedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPageFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?page={page}&{filter.ToString()}",
                                                                mostPlayedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, filter, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithLimit()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?limit={limit}", mostPlayedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithLimitFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?limit={limit}&{filter.ToString()}",
                                                                mostPlayedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, filter, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndExtendedOption()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?extended={extendedInfo.ToString()}",
                                                                mostPlayedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndExtendedOptionFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played/{period.UriName}?extended={extendedInfo.ToString()}&{filter.ToString()}",
                mostPlayedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndPage()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?page={page}",
                                                                mostPlayedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndPageFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?{filter.ToString()}&page={page}",
                                                                mostPlayedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, filter, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndLimit()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?limit={limit}",
                                                                mostPlayedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndLimitFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?limit={limit}&{filter.ToString()}",
                                                                mostPlayedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, filter, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedInfoAndPage()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?extended={extendedInfo.ToString()}&page={page}",
                                                                mostPlayedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedInfoAndPageFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played?extended={extendedInfo.ToString()}&page={page}&{filter.ToString()}",
                mostPlayedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, filter, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedInfoAndLimit()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?extended={extendedInfo.ToString()}&limit={limit}",
                                                                mostPlayedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedInfoAndLimitFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played?extended={extendedInfo.ToString()}&limit={limit}&{filter.ToString()}",
                mostPlayedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, filter, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPageAndLimit()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?page={page}&limit={limit}",
                                                                mostPlayedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPageAndLimitFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?page={page}&limit={limit}&{filter.ToString()}",
                                                                mostPlayedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedInfoAndPageAndLimit()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                mostPlayedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedInfoAndPageAndLimitFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                mostPlayedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndPageAndLimit()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?page={page}&limit={limit}",
                                                                mostPlayedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndPageAndLimitFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played/{period.UriName}?page={page}&limit={limit}&{filter.ToString()}",
                mostPlayedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesComplete()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                mostPlayedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, extendedInfo, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesCompleteFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                mostPlayedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, extendedInfo, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesExceptions()
        {
            var uri = $"movies/played";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktMostPlayedMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviesMostWatched

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMovies()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched", mostWatchedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?{filter.ToString()}", mostWatchedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriod()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}",
                                                                mostWatchedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?{filter.ToString()}",
                                                                mostWatchedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedInfo()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?extended={extendedInfo.ToString()}",
                                                                mostWatchedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedInfoFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched?extended={extendedInfo.ToString()}&{filter.ToString()}",
                mostWatchedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPage()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?page={page}", mostWatchedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPageFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?page={page}&{filter.ToString()}",
                                                                mostWatchedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, filter, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithLimit()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?limit={limit}", mostWatchedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithLimitFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?limit={limit}&{filter.ToString()}",
                                                                mostWatchedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, filter, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndExtendedOption()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?extended={extendedInfo.ToString()}",
                                                                mostWatchedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndExtendedOptionFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched/{period.UriName}?extended={extendedInfo.ToString()}&{filter.ToString()}",
                mostWatchedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndPage()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?page={page}",
                                                                mostWatchedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndPageFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?{filter.ToString()}&page={page}",
                                                                mostWatchedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, filter, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndLimit()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?limit={limit}",
                                                                mostWatchedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndLimitFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?limit={limit}&{filter.ToString()}",
                                                                mostWatchedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, filter, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedInfoAndPage()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?extended={extendedInfo.ToString()}&page={page}",
                                                                mostWatchedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedInfoAndPageFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched?extended={extendedInfo.ToString()}&page={page}&{filter.ToString()}",
                mostWatchedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, filter, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedInfoAndLimit()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?extended={extendedInfo.ToString()}&limit={limit}",
                                                                mostWatchedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedInfoAndLimitFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched?extended={extendedInfo.ToString()}&limit={limit}&{filter.ToString()}",
                mostWatchedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, filter, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPageAndLimit()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?page={page}&limit={limit}",
                                                                mostWatchedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPageAndLimitFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched?page={page}&limit={limit}&{filter.ToString()}",
                mostWatchedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedInfoAndPageAndLimit()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                mostWatchedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedInfoAndPageAndLimitFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched?extended={extendedInfo.ToString()}&page={page}&{filter.ToString()}&limit={limit}",
                mostWatchedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndPageAndLimit()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?page={page}&limit={limit}",
                                                                mostWatchedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndPageAndLimitFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched/{period.UriName}?page={page}&limit={limit}&{filter.ToString()}",
                mostWatchedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesComplete()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                mostWatchedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, extendedInfo, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesCompleteFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                mostWatchedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, extendedInfo, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesExceptions()
        {
            var uri = $"movies/watched";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktMostWatchedMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviesMostCollected

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMovies()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected", mostCollectedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?{filter.ToString()}",
                                                                mostCollectedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriod()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}",
                                                                mostCollectedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?{filter.ToString()}",
                                                                mostCollectedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedInfo()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?extended={extendedInfo.ToString()}",
                                                                mostCollectedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedInfoFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected?extended={extendedInfo.ToString()}&{filter.ToString()}",
                mostCollectedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPage()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?page={page}", mostCollectedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPageFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?page={page}&{filter.ToString()}",
                                                                mostCollectedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, filter, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithLimit()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?limit={limit}", mostCollectedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithLimitFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?limit={limit}&{filter.ToString()}",
                                                                mostCollectedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, filter, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndExtendedOption()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?extended={extendedInfo.ToString()}",
                                                                mostCollectedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndExtendedOptionFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected/{period.UriName}?{filter.ToString()}&extended={extendedInfo.ToString()}",
                mostCollectedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndPage()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?page={page}",
                                                                mostCollectedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndPageFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?page={page}&{filter.ToString()}",
                                                                mostCollectedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, filter, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndLimit()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?limit={limit}",
                                                                mostCollectedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndLimitFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?limit={limit}&{filter.ToString()}",
                                                                mostCollectedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, filter, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedInfoAndPage()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?extended={extendedInfo.ToString()}&page={page}",
                                                                mostCollectedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedInfoAndPageFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected?extended={extendedInfo.ToString()}&{filter.ToString()}&page={page}",
                mostCollectedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, filter, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedInfoAndLimit()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?extended={extendedInfo.ToString()}&limit={limit}",
                                                                mostCollectedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedInfoAndLimitFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected?extended={extendedInfo.ToString()}&{filter.ToString()}&limit={limit}",
                mostCollectedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, filter, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPageAndLimit()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?page={page}&limit={limit}",
                                                                mostCollectedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPageAndLimitFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected?page={page}&limit={limit}&{filter.ToString()}",
                mostCollectedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedInfoAndPageAndLimit()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                mostCollectedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedInfoAndPageAndLimitFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                mostCollectedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndPageAndLimit()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?page={page}&limit={limit}",
                                                                mostCollectedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndPageAndLimitFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected/{period.UriName}?page={page}&{filter.ToString()}&limit={limit}",
                mostCollectedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesComplete()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                mostCollectedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, extendedInfo, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesCompleteFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                mostCollectedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, extendedInfo, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesExceptions()
        {
            var uri = $"movies/collected";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktMostCollectedMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviesMostAnticipated

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMovies()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated", mostAnticipatedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesFiltered()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?{filter.ToString()}",
                                                                mostAnticipatedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(null, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithExtendedInfo()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?extended={extendedInfo.ToString()}",
                                                                mostAnticipatedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithExtendedInfoFiltered()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/anticipated?extended={extendedInfo.ToString()}&{filter.ToString()}",
                mostAnticipatedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithPage()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?page={page}", mostAnticipatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithPageFiltered()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?page={page}&{filter.ToString()}",
                                                                mostAnticipatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(null, filter, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithExtendedInfoAndPage()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?extended={extendedInfo.ToString()}&page={page}",
                                                                mostAnticipatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithExtendedInfoAndPageFiltered()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/anticipated?extended={extendedInfo.ToString()}&{filter.ToString()}&page={page}",
                mostAnticipatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, filter, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithLimit()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?limit={limit}", mostAnticipatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithLimitFiltered()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?limit={limit}&{filter.ToString()}",
                                                                mostAnticipatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(null, filter, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithExtendedInfoAndLimit()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?extended={extendedInfo.ToString()}&limit={limit}",
                                                                mostAnticipatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithExtendedInfoAndLimitFiltered()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/anticipated?extended={extendedInfo.ToString()}&limit={limit}&{filter.ToString()}",
                mostAnticipatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, filter, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithPageAndLimit()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?page={page}&limit={limit}",
                                                                mostAnticipatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithPageAndLimitFiltered()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/anticipated?page={page}&limit={limit}&{filter.ToString()}",
                mostAnticipatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(null, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesComplete()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                mostAnticipatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesCompleteFiltered()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated movie")
                .WithYears(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/anticipated?extended={extendedInfo.ToString()}&page={page}&{filter.ToString()}&limit={limit}",
                mostAnticipatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, filter, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesExceptions()
        {
            var uri = $"movies/anticipated";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktMostAnticipatedMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviesBoxOffice

        [TestMethod]
        public void TestTraktMoviesModuleGetBoxOfficeMovies()
        {
            var boxOfficeMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesBoxOffice.json");
            boxOfficeMovies.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithoutOAuth($"movies/boxoffice", boxOfficeMovies);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetBoxOfficeMoviesAsync().Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetBoxOfficeMoviesWithExtendedInfo()
        {
            var boxOfficeMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesBoxOffice.json");
            boxOfficeMovies.Should().NotBeNullOrEmpty();

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"movies/boxoffice?extended={extendedInfo.ToString()}", boxOfficeMovies);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetBoxOfficeMoviesAsync(extendedInfo).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetBoxOfficeMoviesExceptions()
        {
            var uri = $"movies/boxoffice";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktBoxOfficeMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetBoxOfficeMoviesAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviesRecentlyUpdated

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMovies()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates", recentlyUpdatedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithStartDate()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var today = DateTime.UtcNow;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates/{today.ToTraktDateString()}",
                                                                recentlyUpdatedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(today).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithExtendedInfo()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates?extended={extendedInfo.ToString()}",
                                                                recentlyUpdatedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithPage()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates?page={page}", recentlyUpdatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithLimit()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates?limit={limit}", recentlyUpdatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithStartDateAndExtendedOption()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var today = DateTime.UtcNow;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/updates/{today.ToTraktDateString()}?extended={extendedInfo.ToString()}",
                recentlyUpdatedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(today, extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithStartDateAndPage()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var today = DateTime.UtcNow;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates/{today.ToTraktDateString()}?page={page}",
                                                                recentlyUpdatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(today, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithStartDateAndLimit()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;
            var today = DateTime.UtcNow;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates/{today.ToTraktDateString()}?limit={limit}",
                                                                recentlyUpdatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(today, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithExtendedInfoAndPage()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates?extended={extendedInfo.ToString()}&page={page}",
                                                                recentlyUpdatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(null, extendedInfo, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithExtendedInfoAndLimit()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates?extended={extendedInfo.ToString()}&limit={limit}",
                                                                recentlyUpdatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(null, extendedInfo, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithPageAndLimit()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates?page={page}&limit={limit}",
                                                                recentlyUpdatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithExtendedInfoAndPageAndLimit()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                recentlyUpdatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(null, extendedInfo, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithStartDateAndPageAndLimit()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;
            var today = DateTime.UtcNow;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates/{today.ToTraktDateString()}?page={page}&limit={limit}",
                                                                recentlyUpdatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(today, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesComplete()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var page = 2;
            var limit = 4;
            var today = DateTime.UtcNow;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/updates/{today.ToTraktDateString()}?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                recentlyUpdatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(today, extendedInfo, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesExceptions()
        {
            var uri = $"movies/updates";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktRecentlyUpdatedMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync();
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion
    }
}
