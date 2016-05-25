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
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieAliasesExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieAliasesArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieReleases

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieReleases()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieReleasesExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieReleasesArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieSingleRelease

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieSingleRelease()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieSingleReleaseExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieSingleReleaseArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieTranslations

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieTranslations()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieTranslationsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieTranslationsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieSingleTranslation

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieSingleTranslation()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieSingleTranslationExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieSingleTranslationArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieComments

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieComments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsWithSortOrder()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsWithSortOrderAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsWithSortOrderAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieCommentsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MoviePeople

        [TestMethod]
        public void TestTraktMoviesModuleGetMoviePeople()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMoviePeopleWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMoviePeopleExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMoviePeopleArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieRatings

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRatings()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRatingsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRatingsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieRelatedMovies

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMovies()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithExtendedOptionAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithExtendedOptionAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieRelatedMoviesArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieStatistics

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieStatistics()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieStatisticsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieStatisticsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MovieWatchingUsers

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieWatchingUsers()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieWatchingUsersWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieWatchingUsersExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktMoviesModuleGetMovieWatchingUsersArgumentExceptions()
        {
            Assert.Fail();
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

        [TestMethod]
        public void TestTraktMoviesModuleGetTrendingMoviesArgumentExceptions()
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

        [TestMethod]
        public void TestTraktMoviesModuleGetPopularMoviesArgumentExceptions()
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

        [TestMethod]
        public void TestTraktMoviesModuleGetMostPlayedMoviesArgumentExceptions()
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

        [TestMethod]
        public void TestTraktMoviesModuleGetMosWatchedMoviesArgumentExceptions()
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

        [TestMethod]
        public void TestTraktMoviesModuleGetMosCollectedMoviesArgumentExceptions()
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

        [TestMethod]
        public void TestTraktMoviesModuleGetMostAnticipatedMoviesArgumentExceptions()
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

        [TestMethod]
        public void TestTraktMoviesModuleGetBoxOfficeMoviesArgumentExceptions()
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

        [TestMethod]
        public void TestTraktMoviesModuleGetRecentlyUpdatedMoviesArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
