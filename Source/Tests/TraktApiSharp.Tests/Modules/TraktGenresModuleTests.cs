namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktGenresModuleTests
    {
        [TestMethod]
        public void TestTraktCalendarModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktGenresModule)).Should().BeTrue();
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

        [TestMethod]
        public void TestTraktGenresModuleGetMovieGenres()
        {
            var movieGenres = TestUtility.ReadFileContents(@"Objects\Basic\Genres\Movies.json");
            movieGenres.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithoutOAuth("genres/movies", movieGenres);

            var response = TestUtility.MOCK_TEST_CLIENT.Genres.GetMovieGenresAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(32);
        }

        [TestMethod]
        public void TestTraktGenresModuleGetMovieGenresExceptions()
        {
            TestUtility.SetupMockErrorResponseWithoutOAuth("genres/movies", HttpStatusCode.BadRequest);

            Func<Task<TraktListResult<TraktGenre>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Genres.GetMovieGenresAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth("genres/movies", HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Genres.GetMovieGenresAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth("genres/movies", (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Genres.GetMovieGenresAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth("genres/movies", (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Genres.GetMovieGenresAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth("genres/movies", HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Genres.GetMovieGenresAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth("genres/movies", (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Genres.GetMovieGenresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth("genres/movies", (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Genres.GetMovieGenresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth("genres/movies", (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Genres.GetMovieGenresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth("genres/movies", (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Genres.GetMovieGenresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth("genres/movies", (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Genres.GetMovieGenresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
        }
    }
}
