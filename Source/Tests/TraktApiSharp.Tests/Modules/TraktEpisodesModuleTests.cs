namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using TraktApiSharp.Requests;
    using Utils;

    [TestClass]
    public class TraktEpisodesModuleTests
    {
        [TestMethod]
        public void TestTraktEpisodesModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktEpisodesModule)).Should().BeTrue();
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

        #region Episode

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisode()
        {
            var episode = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeSummaryFullAndImages.json");
            episode.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", episode);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr).Result;

            response.Should().NotBeNull();
            response.Title.Should().Be("Winter Is Coming");
            response.SeasonNumber.Should().Be(1);
            response.Number.Should().Be(1);
            response.NumberAbsolute.Should().Be(50);
            response.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            response.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            response.Rating.Should().Be(9.0f);
            response.Votes.Should().Be(111);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(73640);
            response.Ids.Tvdb.Should().Be(3254641);
            response.Ids.Imdb.Should().Be("tt1480055");
            response.Ids.Tmdb.Should().Be(63056);
            response.Ids.TvRage.Should().Be(1065008299);
            response.Images.Should().NotBeNull();
            response.Images.Screenshot.Should().NotBeNull();
            response.Images.Screenshot.Full.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/original/dd3fc55725.jpg");
            response.Images.Screenshot.Medium.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/medium/dd3fc55725.jpg");
            response.Images.Screenshot.Thumb.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/thumb/dd3fc55725.jpg");
            response.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeWithExtendedOption()
        {
            var episode = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeSummaryFullAndImages.json");
            episode.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}?extended=images,full", episode);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr, extendedOption).Result;

            response.Should().NotBeNull();
            response.Title.Should().Be("Winter Is Coming");
            response.SeasonNumber.Should().Be(1);
            response.Number.Should().Be(1);
            response.NumberAbsolute.Should().Be(50);
            response.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            response.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            response.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            response.Rating.Should().Be(9.0f);
            response.Votes.Should().Be(111);
            response.Ids.Should().NotBeNull();
            response.Ids.Trakt.Should().Be(73640);
            response.Ids.Tvdb.Should().Be(3254641);
            response.Ids.Imdb.Should().Be("tt1480055");
            response.Ids.Tmdb.Should().Be(63056);
            response.Ids.TvRage.Should().Be(1065008299);
            response.Images.Should().NotBeNull();
            response.Images.Screenshot.Should().NotBeNull();
            response.Images.Screenshot.Full.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/original/dd3fc55725.jpg");
            response.Images.Screenshot.Medium.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/medium/dd3fc55725.jpg");
            response.Images.Screenshot.Thumb.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/thumb/dd3fc55725.jpg");
            response.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeExceptions()
        {
            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;

            TestUtility.SetupMockErrorResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", HttpStatusCode.NotFound);

            Func<Task<TraktEpisode>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktEpisodeNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeArgumentExceptions()
        {
            var episode = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeSummaryFullAndImages.json");
            episode.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;

            TestUtility.SetupMockResponseWithOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", episode);

            Func<Task<TraktEpisode>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(null, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, -1, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, -1);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region EpisodeComments

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommments()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithSortOrder()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithSortOrderAndPage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithSortOrderAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithPageAndLimit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region EpisodeRatings

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeRatings()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeRatingsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeRatingsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region EpisodeStatistics

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeStatistics()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeStatisticsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeStatisticsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region EpisodeWatchingUsers

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeWatchingUsers()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeWatchingUsersWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeWatchingUsersExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeWatchingUsersArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
