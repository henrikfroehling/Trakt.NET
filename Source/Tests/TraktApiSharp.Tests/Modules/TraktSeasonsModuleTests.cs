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
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using TraktApiSharp.Objects.Get.Shows.Seasons;
    using TraktApiSharp.Requests;
    using Utils;

    [TestClass]
    public class TraktSeasonsModuleTests
    {
        [TestMethod]
        public void TestTraktSeasonsModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktSeasonsModule)).Should().BeTrue();
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

        #region SeasonsAll

        [TestMethod]
        public void TestTraktSeasonsModuleGetAllSeasons()
        {
            var seasons = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\FullAndImages\SeasonsAllFullAndImages.json");
            seasons.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons", seasons);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonsAllAsync(showId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetAllSeasonsWithExtendedOption()
        {
            var seasons = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\FullAndImages\SeasonsAllFullAndImages.json");
            seasons.Should().NotBeNullOrEmpty();

            var showId = "1390";

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons?extended={extendedOption.ToString()}", seasons);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonsAllAsync(showId, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetAllSeasonsExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/seasons";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<TraktListResult<TraktSeason>>> act =
                act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonsAllAsync(showId);
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
        public void TestTraktSeasonsModuleGetAllSeasonsArgumentExceptions()
        {
            var seasons = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\FullAndImages\SeasonsAllFullAndImages.json");
            seasons.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons", seasons);

            Func<Task<TraktListResult<TraktSeason>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonsAllAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonsAllAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region Season

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeason()
        {
            var season = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonEpisodes.json");
            season.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}", season);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(10);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonWithExtendedOption()
        {
            var season = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonEpisodes.json");
            season.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true,
            };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}?extended={extendedOption.ToString()}", season);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(10);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonExceptions()
        {
            var showId = "1390";
            var seasonNr = 1;
            var uri = $"shows/{showId}/seasons/{seasonNr}";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResult<TraktEpisode>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr);
            act.ShouldThrow<TraktSeasonNotFoundException>();

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
        public void TestTraktSeasonsModuleGetSeasonArgumentExceptions()
        {
            var season = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonEpisodes.json");
            season.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}", season);

            Func<Task<TraktListResult<TraktEpisode>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(null, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(string.Empty, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, -1);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region SeasonComments

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithSortOrder()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithSortOrderAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithSortOrderAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommmentsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommmentsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommmentsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region SeasonRatings

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonRatings()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonRatingsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonRatingsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region SeasonStatistics

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonStatistics()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonStatisticsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonStatisticsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region SeasonWatchingUsers

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonWatchingUsers()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonWatchingUsersWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonWatchingUsersExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonWatchingUsersArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
