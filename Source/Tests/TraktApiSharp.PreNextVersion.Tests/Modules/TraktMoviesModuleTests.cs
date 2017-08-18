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
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Utils;

    [TestClass]
    public class TraktMoviesModuleTests
    {
        [TestMethod]
        public void TestTraktMoviesModuleIsModule()
        {
            typeof(TraktMoviesModule).GetInterfaces().Should().Contain(typeof(ITraktModule));
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
            var movie = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieSummaryFull.json");
            movie.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}", movie);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAsync(movieId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Title.Should().Be("Star Wars: The Force Awakens");
            responseValue.Year.Should().Be(2015);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(94024U);
            responseValue.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            responseValue.Ids.Imdb.Should().Be("tt2488496");
            responseValue.Ids.Tmdb.Should().Be(140607U);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetSingleMovieWithExtendedInfo()
        {
            var movie = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieSummaryFull.json");
            movie.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}?extended={extendedInfo.ToString()}", movie);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieAsync(movieId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Title.Should().Be("Star Wars: The Force Awakens");
            responseValue.Year.Should().Be(2015);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(94024U);
            responseValue.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            responseValue.Ids.Imdb.Should().Be("tt2488496");
            responseValue.Ids.Tmdb.Should().Be(140607U);
            responseValue.Tagline.Should().Be("Every generation has a story.");
            responseValue.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            responseValue.Released.Should().Be(DateTime.Parse("2015-12-18"));
            responseValue.Runtime.Should().Be(136);
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            responseValue.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            responseValue.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            responseValue.Rating.Should().Be(8.31988f);
            responseValue.Votes.Should().Be(9338);
            responseValue.LanguageCode.Should().Be("en");
            responseValue.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            responseValue.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            responseValue.Certification.Should().Be("PG-13");
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetSingleMovieExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktMovie>>> act =
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
            var movie = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieSummaryFull.json");
            movie.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}", movie);

            Func<Task<TraktResponse<ITraktMovie>>> act =
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
            Func<Task<IEnumerable<TraktResponse<ITraktMovie>>>> act =
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

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieAliasesExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/aliases";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktMovieAlias>>> act =
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

            Func<Task<TraktListResponse<ITraktMovieAlias>>> act =
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

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieReleasesExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/releases";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktMovieRelease>>> act =
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

            Func<Task<TraktListResponse<ITraktMovieRelease>>> act =
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
            var movieReleases = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieReleases.json");
            movieReleases.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var countryCode = "us";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/releases/{countryCode}", movieReleases);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(movieId, countryCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieSingleReleaseExceptions()
        {
            var movieId = "94024";
            var countryCode = "us";
            var uri = $"movies/{movieId}/releases/{countryCode}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktMovieRelease>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(movieId, countryCode);
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
            var movieReleases = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieReleases.json");
            movieReleases.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var countryCode = "us";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/releases/{countryCode}", movieReleases);

            Func<Task<TraktListResponse<ITraktMovieRelease>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync("movie id");
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(movieId, "usa");
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieReleasesAsync(movieId, "u");
            act.ShouldThrow<ArgumentOutOfRangeException>();
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieTranslationsExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/translations";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act =
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

            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act =
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
            var movieTranslations = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieTranslations.json");
            movieTranslations.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var languagecode = "en";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/translations/{languagecode}", movieTranslations);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieTranslationsAsync(movieId, languagecode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieSingleTranslationExceptions()
        {
            var movieId = "94024";
            var languagecode = "en";
            var uri = $"movies/{movieId}/translations/{languagecode}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieTranslationsAsync(movieId, languagecode);
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
            var movieTranslations = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieTranslations.json");
            movieTranslations.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var languagecode = "en";

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/translations/{languagecode}", movieTranslations);

            Func<Task<TraktListResponse<ITraktMovieTranslation>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieTranslationsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieTranslationsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieTranslationsAsync("movie id");
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieTranslationsAsync(movieId, "eng");
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieTranslationsAsync(movieId, "e");
            act.ShouldThrow<ArgumentOutOfRangeException>();
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsWithPage()
        {
            var movieComments = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieComments.json");
            movieComments.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments?page={page}",
                                                                movieComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
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
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments/{sortOrder.UriName}?page={page}",
                                                                movieComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, sortOrder, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsWithLimit()
        {
            var movieComments = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieComments.json");
            movieComments.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments?limit={limit}",
                                                                movieComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
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
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments/{sortOrder.UriName}?limit={limit}",
                                                                movieComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, sortOrder, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsWithPageAndLimit()
        {
            var movieComments = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieComments.json");
            movieComments.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments?page={page}&limit={limit}",
                                                                movieComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
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
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/comments/{sortOrder.UriName}?page={page}&limit={limit}",
                                                                movieComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(movieId, sortOrder, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/comments";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktComment>>> act =
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

            Func<Task<TraktPagedResponse<ITraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieCommentsAsync("movie id");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        #region MovieLists

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieLists()
        {
            var movieLists = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieLists.json");
            movieLists.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 10;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists", movieLists, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieListsWithType()
        {
            var movieLists = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieLists.json");
            movieLists.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 10;
            var type = TraktListType.Official;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists/{type.UriName}",
                                                                movieLists, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, type).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieListsWithSortOrderAndWithoutType()
        {
            var movieLists = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieLists.json");
            movieLists.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 10;
            var sortOrder = TraktListSortOrder.Comments;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists",
                                                                movieLists, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, null, sortOrder).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieListsWithPage()
        {
            var movieLists = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieLists.json");
            movieLists.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 10;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists?page={page}",
                                                                movieLists, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieListsWithLimit()
        {
            var movieLists = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieLists.json");
            movieLists.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 10;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists?limit={limit}",
                                                                movieLists, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieListsWithPageAndLimit()
        {
            var movieLists = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieLists.json");
            movieLists.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 10;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists?page={page}&limit={limit}",
                                                                movieLists, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieListsWithTypeAndSortOrder()
        {
            var movieLists = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieLists.json");
            movieLists.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists/{type.UriName}/{sortOrder.UriName}",
                                                                movieLists, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, type, sortOrder).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieListsWithTypeAndPage()
        {
            var movieLists = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieLists.json");
            movieLists.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 10;
            var type = TraktListType.Official;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists/{type.UriName}?page={page}",
                                                                movieLists, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, type, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieListsWithTypeAndLimit()
        {
            var movieLists = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieLists.json");
            movieLists.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 10;
            var type = TraktListType.Official;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists/{type.UriName}?limit={limit}",
                                                                movieLists, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, type, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieListsWithTypeAndPageAndLimit()
        {
            var movieLists = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieLists.json");
            movieLists.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 10;
            var type = TraktListType.Official;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists/{type.UriName}?page={page}&limit={limit}",
                                                                movieLists, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, type, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieListsWithTypeAndSortOrderAndPage()
        {
            var movieLists = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieLists.json");
            movieLists.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists/{type.UriName}/{sortOrder.UriName}?page={page}",
                                                                movieLists, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, type, sortOrder, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieListsWithTypeAndSortOrderAndLimit()
        {
            var movieLists = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieLists.json");
            movieLists.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/{movieId}/lists/{type.UriName}/{sortOrder.UriName}?limit={limit}",
                movieLists, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, type, sortOrder, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieListsComplete()
        {
            var movieLists = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieLists.json");
            movieLists.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists/{type.UriName}/{sortOrder.UriName}" +
                                                                $"?page={page}&limit={limit}",
                                                                movieLists, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId, type, sortOrder, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieListsExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/lists";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(movieId);
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
        public void TestTraktMoviesModuleGetMovieListsArgumentsExceptions()
        {
            var movieLists = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieLists.json");
            movieLists.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/lists", movieLists);

            Func<Task<TraktPagedResponse<ITraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieListsAsync("movie id");
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Cast.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Should().NotBeNull();
            responseValue.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Art.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Crew.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Directing.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Writing.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Sound.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Camera.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Lighting.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Editing.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMoviePeopleWithExtendedInfo()
        {
            var moviePeople = TestUtility.ReadFileContents(@"Objects\Get\Movies\MoviePeople.json");
            moviePeople.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/people?extended={extendedInfo.ToString()}", moviePeople);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMoviePeopleAsync(movieId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Cast.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Should().NotBeNull();
            responseValue.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Art.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Crew.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Directing.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Writing.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Sound.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Camera.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Lighting.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Editing.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMoviePeopleExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/people";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktCastAndCrew>>> act =
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

            Func<Task<TraktResponse<ITraktCastAndCrew>>> act =
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Rating.Should().Be(8.31325f);
            responseValue.Votes.Should().Be(10359);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  185 }, { "2", 28 }, { "3", 34 }, { "4", 89 }, { "5", 184 },
                { "6",  630 }, { "7", 1244 }, { "8", 2509 }, { "9", 2622 }, { "10", 2834 }
            };

            responseValue.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRatingsExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/ratings";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktRating>>> act =
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

            Func<Task<TraktResponse<ITraktRating>>> act =
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
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFull.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related", movieRelatedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithExtendedInfo()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFull.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?extended={extendedInfo.ToString()}",
                                                                movieRelatedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithPage()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFull.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?page={page}",
                                                                movieRelatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithExtendedInfoAndPage()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFull.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?extended={extendedInfo.ToString()}&page={page}",
                                                                movieRelatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithLimit()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFull.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?limit={limit}",
                                                                movieRelatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithExtendedInfoAndLimit()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFull.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?extended={extendedInfo.ToString()}&limit={limit}",
                                                                movieRelatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithPageAndLimit()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFull.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?page={page}&limit={limit}",
                                                                movieRelatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesComplete()
        {
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFull.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";
            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                movieRelatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieRelatedMoviesAsync(movieId, extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/related";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktMovie>>> act =
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
            var movieRelatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieRelatedMoviesFull.json");
            movieRelatedMovies.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/{movieId}/related", movieRelatedMovies);

            Func<Task<TraktPagedResponse<ITraktMovie>>> act =
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();

            var responseValue = response.Value;

            responseValue.Watchers.Should().Be(40619);
            responseValue.Plays.Should().Be(64620);
            responseValue.Collectors.Should().Be(17519);
            responseValue.CollectedEpisodes.Should().NotHaveValue();
            responseValue.Comments.Should().Be(99);
            responseValue.Lists.Should().Be(17089);
            responseValue.Votes.Should().Be(10359);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieStatisticsExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/stats";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktStatistics>>> act =
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

            Func<Task<TraktResponse<ITraktStatistics>>> act =
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

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieWatchingUsersWithExtendedInfo()
        {
            var movieWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Movies\MovieWatchingUsers.json");
            movieWatchingUsers.Should().NotBeNullOrEmpty();

            var movieId = "94024";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"movies/{movieId}/watching?extended={extendedInfo.ToString()}", movieWatchingUsers);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMovieWatchingUsersAsync(movieId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieWatchingUsersExceptions()
        {
            var movieId = "94024";
            var uri = $"movies/{movieId}/watching";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktUser>>> act =
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

            Func<Task<TraktListResponse<ITraktUser>>> act =
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
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
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?{filter.ToString()}",
                                                                moviesTrending, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithExtendedInfo()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?extended={extendedInfo.ToString()}",
                                                                moviesTrending, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithExtendedInfoFiltered()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?extended={extendedInfo.ToString()}&{filter.ToString()}",
                                                                moviesTrending, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithPage()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?page={page}", moviesTrending, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithPageFiltered()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?{filter.ToString()}&page={page}",
                                                                moviesTrending, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithExtendedInfoAndPage()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?extended={extendedInfo.ToString()}&page={page}",
                                                                moviesTrending, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithExtendedInfoAndPageFiltered()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/trending?extended={extendedInfo.ToString()}&page={page}&{filter.ToString()}",
                moviesTrending, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithLimit()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?limit={limit}", moviesTrending, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithLimitFiltered()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?{filter.ToString()}&limit={limit}",
                                                                moviesTrending, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithExtendedInfoAndLimit()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?extended={extendedInfo.ToString()}&limit={limit}",
                                                                moviesTrending, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithExtendedInfoAndLimitFiltered()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/trending?extended={extendedInfo.ToString()}&limit={limit}&{filter.ToString()}",
                moviesTrending, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithPageAndLimit()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?page={page}&limit={limit}",
                                                                moviesTrending, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesWithPageAndLimitFiltered()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?page={page}&limit={limit}&{filter.ToString()}",
                                                                moviesTrending, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesComplete()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/trending?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                moviesTrending, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesCompleteFiltered()
        {
            var moviesTrending = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesTrending.json");
            moviesTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/trending?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                moviesTrending, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetTrendingMoviesAsync(extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.TrendingUserCount.Should().HaveValue().And.Be(userCount);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesExceptions()
        {
            var uri = $"movies/trending";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktTrendingMovie>>> act =
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
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
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?{filter.ToString()}", popularMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithExtendedInfo()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?extended={extendedInfo.ToString()}",
                                                                popularMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithExtendedInfoFiltered()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?extended={extendedInfo.ToString()}&{filter.ToString()}",
                                                                popularMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithPage()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?page={page}", popularMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithPageFiltered()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?page={page}&{filter.ToString()}",
                                                                popularMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithExtendedInfoAndPage()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?extended={extendedInfo.ToString()}&page={page}",
                                                                popularMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithExtendedInfoAndPageFiltered()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/popular?extended={extendedInfo.ToString()}&{filter.ToString()}&page={page}",
                popularMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithLimit()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?limit={limit}", popularMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithLimitFiltered()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?limit={limit}&{filter.ToString()}",
                                                                popularMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithExtendedInfoAndLimit()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?extended={extendedInfo.ToString()}&limit={limit}",
                                                                popularMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithExtendedInfoAndLimitFiltered()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/popular?extended={extendedInfo.ToString()}&limit={limit}&{filter.ToString()}",
                popularMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithPageAndLimit()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?page={page}&limit={limit}",
                                                                popularMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesWithPageAndLimitFiltered()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?page={page}&limit={limit}&{filter.ToString()}",
                                                                popularMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesComplete()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/popular?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                popularMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesCompleteFiltered()
        {
            var popularMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesPopular.json");
            popularMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/popular?extended={extendedInfo.ToString()}&{filter.ToString()}&page={page}&limit={limit}",
                popularMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetPopularMoviesAsync(extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesExceptions()
        {
            var uri = $"movies/popular";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktMovie>>> act =
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
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
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?{filter.ToString()}", mostPlayedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
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
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?{filter.ToString()}",
                                                                mostPlayedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedInfo()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?extended={extendedInfo.ToString()}",
                                                                mostPlayedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedInfoFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?extended={extendedInfo.ToString()}&{filter.ToString()}",
                                                                mostPlayedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPage()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?page={page}", mostPlayedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPageFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?page={page}&{filter.ToString()}",
                                                                mostPlayedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithLimit()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?limit={limit}", mostPlayedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithLimitFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?limit={limit}&{filter.ToString()}",
                                                                mostPlayedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndExtendedOption()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?extended={extendedInfo.ToString()}",
                                                                mostPlayedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndExtendedOptionFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndPage()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?page={page}",
                                                                mostPlayedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndPageFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?{filter.ToString()}&page={page}",
                                                                mostPlayedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndLimit()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?limit={limit}",
                                                                mostPlayedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndLimitFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?limit={limit}&{filter.ToString()}",
                                                                mostPlayedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedInfoAndPage()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?extended={extendedInfo.ToString()}&page={page}",
                                                                mostPlayedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedInfoAndPageFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played?extended={extendedInfo.ToString()}&page={page}&{filter.ToString()}",
                mostPlayedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedInfoAndLimit()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?extended={extendedInfo.ToString()}&limit={limit}",
                                                                mostPlayedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedInfoAndLimitFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played?extended={extendedInfo.ToString()}&limit={limit}&{filter.ToString()}",
                mostPlayedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPageAndLimit()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?page={page}&limit={limit}",
                                                                mostPlayedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPageAndLimitFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?page={page}&limit={limit}&{filter.ToString()}",
                                                                mostPlayedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedInfoAndPageAndLimit()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                mostPlayedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithExtendedInfoAndPageAndLimitFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                mostPlayedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndPageAndLimit()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/played/{period.UriName}?page={page}&limit={limit}",
                                                                mostPlayedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesWithPeriodAndPageAndLimitFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played/{period.UriName}?page={page}&limit={limit}&{filter.ToString()}",
                mostPlayedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesComplete()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                mostPlayedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesCompleteFiltered()
        {
            var mostPlayedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");
            mostPlayedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/played/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                mostPlayedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostPlayedMoviesAsync(period, extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesExceptions()
        {
            var uri = $"movies/played";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktMostPWCMovie>>> act =
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
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
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?{filter.ToString()}", mostWatchedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
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
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?{filter.ToString()}",
                                                                mostWatchedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedInfo()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?extended={extendedInfo.ToString()}",
                                                                mostWatchedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedInfoFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPage()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?page={page}", mostWatchedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPageFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?page={page}&{filter.ToString()}",
                                                                mostWatchedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithLimit()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?limit={limit}", mostWatchedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithLimitFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?limit={limit}&{filter.ToString()}",
                                                                mostWatchedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndExtendedOption()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?extended={extendedInfo.ToString()}",
                                                                mostWatchedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndExtendedOptionFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndPage()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?page={page}",
                                                                mostWatchedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndPageFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?{filter.ToString()}&page={page}",
                                                                mostWatchedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndLimit()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?limit={limit}",
                                                                mostWatchedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndLimitFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?limit={limit}&{filter.ToString()}",
                                                                mostWatchedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedInfoAndPage()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?extended={extendedInfo.ToString()}&page={page}",
                                                                mostWatchedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedInfoAndPageFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched?extended={extendedInfo.ToString()}&page={page}&{filter.ToString()}",
                mostWatchedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedInfoAndLimit()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?extended={extendedInfo.ToString()}&limit={limit}",
                                                                mostWatchedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedInfoAndLimitFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched?extended={extendedInfo.ToString()}&limit={limit}&{filter.ToString()}",
                mostWatchedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPageAndLimit()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?page={page}&limit={limit}",
                                                                mostWatchedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPageAndLimitFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched?page={page}&limit={limit}&{filter.ToString()}",
                mostWatchedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedInfoAndPageAndLimit()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                mostWatchedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithExtendedInfoAndPageAndLimitFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched?extended={extendedInfo.ToString()}&page={page}&{filter.ToString()}&limit={limit}",
                mostWatchedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndPageAndLimit()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/watched/{period.UriName}?page={page}&limit={limit}",
                                                                mostWatchedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesWithPeriodAndPageAndLimitFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched/{period.UriName}?page={page}&limit={limit}&{filter.ToString()}",
                mostWatchedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesComplete()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                mostWatchedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesCompleteFiltered()
        {
            var mostWatchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");
            mostWatchedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/watched/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                mostWatchedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostWatchedMoviesAsync(period, extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostWatchedMoviesExceptions()
        {
            var uri = $"movies/watched";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktMostPWCMovie>>> act =
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
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
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?{filter.ToString()}",
                                                                mostCollectedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
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
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?{filter.ToString()}",
                                                                mostCollectedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedInfo()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?extended={extendedInfo.ToString()}",
                                                                mostCollectedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedInfoFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPage()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?page={page}", mostCollectedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPageFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?page={page}&{filter.ToString()}",
                                                                mostCollectedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithLimit()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?limit={limit}", mostCollectedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithLimitFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?limit={limit}&{filter.ToString()}",
                                                                mostCollectedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndExtendedOption()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?extended={extendedInfo.ToString()}",
                                                                mostCollectedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndExtendedOptionFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndPage()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?page={page}",
                                                                mostCollectedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndPageFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?page={page}&{filter.ToString()}",
                                                                mostCollectedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndLimit()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?limit={limit}",
                                                                mostCollectedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndLimitFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?limit={limit}&{filter.ToString()}",
                                                                mostCollectedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedInfoAndPage()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?extended={extendedInfo.ToString()}&page={page}",
                                                                mostCollectedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedInfoAndPageFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected?extended={extendedInfo.ToString()}&{filter.ToString()}&page={page}",
                mostCollectedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedInfoAndLimit()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?extended={extendedInfo.ToString()}&limit={limit}",
                                                                mostCollectedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedInfoAndLimitFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected?extended={extendedInfo.ToString()}&{filter.ToString()}&limit={limit}",
                mostCollectedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPageAndLimit()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?page={page}&limit={limit}",
                                                                mostCollectedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPageAndLimitFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected?page={page}&limit={limit}&{filter.ToString()}",
                mostCollectedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedInfoAndPageAndLimit()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                mostCollectedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithExtendedInfoAndPageAndLimitFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                mostCollectedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(null, extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndPageAndLimit()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/collected/{period.UriName}?page={page}&limit={limit}",
                                                                mostCollectedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesWithPeriodAndPageAndLimitFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected/{period.UriName}?page={page}&{filter.ToString()}&limit={limit}",
                mostCollectedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesComplete()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                mostCollectedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesCompleteFiltered()
        {
            var mostCollectedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");
            mostCollectedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/collected/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                mostCollectedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostCollectedMoviesAsync(period, extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostCollectedMoviesExceptions()
        {
            var uri = $"movies/collected";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktMostPWCMovie>>> act =
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
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
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?{filter.ToString()}",
                                                                mostAnticipatedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithExtendedInfo()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?extended={extendedInfo.ToString()}",
                                                                mostAnticipatedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithExtendedInfoFiltered()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated movie")
                .WithStartYear(2016)
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithPage()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?page={page}", mostAnticipatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithPageFiltered()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?page={page}&{filter.ToString()}",
                                                                mostAnticipatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithExtendedInfoAndPage()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?extended={extendedInfo.ToString()}&page={page}",
                                                                mostAnticipatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithExtendedInfoAndPageFiltered()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/anticipated?extended={extendedInfo.ToString()}&{filter.ToString()}&page={page}",
                mostAnticipatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithLimit()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?limit={limit}", mostAnticipatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithLimitFiltered()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?limit={limit}&{filter.ToString()}",
                                                                mostAnticipatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithExtendedInfoAndLimit()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?extended={extendedInfo.ToString()}&limit={limit}",
                                                                mostAnticipatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithExtendedInfoAndLimitFiltered()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/anticipated?extended={extendedInfo.ToString()}&limit={limit}&{filter.ToString()}",
                mostAnticipatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithPageAndLimit()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?page={page}&limit={limit}",
                                                                mostAnticipatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesWithPageAndLimitFiltered()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/anticipated?page={page}&limit={limit}&{filter.ToString()}",
                mostAnticipatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(null, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesComplete()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/anticipated?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                mostAnticipatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesCompleteFiltered()
        {
            var mostAnticipatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");
            mostAnticipatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktMovieFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated movie")
                .WithStartYear(2016)
                .WithGenres("action", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(90, 180)
                .WithRatings(70, 90);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/anticipated?extended={extendedInfo.ToString()}&page={page}&{filter.ToString()}&limit={limit}",
                mostAnticipatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetMostAnticipatedMoviesAsync(extendedInfo, filter, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesExceptions()
        {
            var uri = $"movies/anticipated";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktMostAnticipatedMovie>>> act =
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

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetBoxOfficeMoviesWithExtendedInfo()
        {
            var boxOfficeMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesBoxOffice.json");
            boxOfficeMovies.Should().NotBeNullOrEmpty();

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"movies/boxoffice?extended={extendedInfo.ToString()}", boxOfficeMovies);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetBoxOfficeMoviesAsync(extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetBoxOfficeMoviesExceptions()
        {
            var uri = $"movies/boxoffice";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktBoxOfficeMovie>>> act =
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
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
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithExtendedInfo()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates?extended={extendedInfo.ToString()}",
                                                                recentlyUpdatedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithPage()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates?page={page}", recentlyUpdatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithLimit()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates?limit={limit}", recentlyUpdatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithStartDateAndExtendedOption()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var today = DateTime.UtcNow;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/updates/{today.ToTraktDateString()}?extended={extendedInfo.ToString()}",
                recentlyUpdatedMovies, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(today, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithStartDateAndPage()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var today = DateTime.UtcNow;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates/{today.ToTraktDateString()}?page={page}",
                                                                recentlyUpdatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(today, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithStartDateAndLimit()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var today = DateTime.UtcNow;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates/{today.ToTraktDateString()}?limit={limit}",
                                                                recentlyUpdatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(today, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithExtendedInfoAndPage()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates?extended={extendedInfo.ToString()}&page={page}",
                                                                recentlyUpdatedMovies, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(null, extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithExtendedInfoAndLimit()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates?extended={extendedInfo.ToString()}&limit={limit}",
                                                                recentlyUpdatedMovies, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(null, extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithPageAndLimit()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates?page={page}&limit={limit}",
                                                                recentlyUpdatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(null, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithExtendedInfoAndPageAndLimit()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                recentlyUpdatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(null, extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesWithStartDateAndPageAndLimit()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var today = DateTime.UtcNow;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"movies/updates/{today.ToTraktDateString()}?page={page}&limit={limit}",
                                                                recentlyUpdatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(today, null, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesComplete()
        {
            var recentlyUpdatedMovies = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");
            recentlyUpdatedMovies.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var today = DateTime.UtcNow;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"movies/updates/{today.ToTraktDateString()}?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                recentlyUpdatedMovies, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Movies.GetRecentlyUpdatedMoviesAsync(today, extendedInfo, pagedParameters).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesExceptions()
        {
            var uri = $"movies/updates";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedMovie>>> act =
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
