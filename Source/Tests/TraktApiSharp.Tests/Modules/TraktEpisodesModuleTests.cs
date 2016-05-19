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

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}?extended={extendedOption.ToString()}",
                                                      episode);

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
            var uri = $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktEpisode>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktEpisodeNotFoundException>();

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
        public void TestTraktEpisodesModuleGetEpisodeArgumentExceptions()
        {
            var episode = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeSummaryFullAndImages.json");
            episode.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", episode);

            Func<Task<TraktEpisode>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(null, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(string.Empty, seasonNr, episodeNr);
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
            var episodeComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeComments.json");
            episodeComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments",
                                                                episodeComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithSortOrder()
        {
            var episodeComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeComments.json");
            episodeComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;
            var itemCount = 4;
            var sortOrder = TraktCommentSortOrder.Likes;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments/{sortOrder.AsString()}",
                                                                episodeComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, sortOrder).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithPage()
        {
            var episodeComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeComments.json");
            episodeComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments?page={page}",
                                                                episodeComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithSortOrderAndPage()
        {
            var episodeComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeComments.json");
            episodeComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;
            var itemCount = 4;
            var sortOrder = TraktCommentSortOrder.Likes;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments/{sortOrder.AsString()}?page={page}",
                                                                episodeComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, sortOrder, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(10);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithLimit()
        {
            var episodeComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeComments.json");
            episodeComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments?limit={limit}",
                                                                episodeComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithSortOrderAndLimit()
        {
            var episodeComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeComments.json");
            episodeComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;
            var itemCount = 4;
            var sortOrder = TraktCommentSortOrder.Likes;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments/{sortOrder.AsString()}?limit={limit}",
                                                                episodeComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, sortOrder, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(1);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithPageAndLimit()
        {
            var episodeComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeComments.json");
            episodeComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;
            var itemCount = 4;
            var page = 2;
            var limit = 20;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments?page={page}&limit={limit}",
                                                                episodeComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsComplete()
        {
            var episodeComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeComments.json");
            episodeComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;
            var itemCount = 4;
            var sortOrder = TraktCommentSortOrder.Likes;
            var page = 2;
            var limit = 20;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments/{sortOrder.AsString()}?page={page}&limit={limit}",
                                                                episodeComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, sortOrder, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().Be(itemCount);
            response.Limit.Should().Be(limit);
            response.Page.Should().Be(page);
            response.PageCount.Should().Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsExceptions()
        {
            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;
            var uri = $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktEpisodeComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktEpisodeNotFoundException>();

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
        public void TestTraktEpisodesModuleGetEpisodeCommmentsArgumentExceptions()
        {
            var episodeComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeComments.json");
            episodeComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments", episodeComments);

            Func<Task<TraktPaginationListResult<TraktEpisodeComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(null, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(string.Empty, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, -1, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, -1);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region EpisodeRatings

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeRatings()
        {
            var episodeRatings = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeRatings.json");
            episodeRatings.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/ratings", episodeRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync(showId, seasonNr, episodeNr).Result;

            response.Should().NotBeNull();
            response.Rating.Should().Be(8.54044f);
            response.Votes.Should().Be(3919);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  59 }, { "2", 11 }, { "3", 2 }, { "4", 14 }, { "5", 58 },
                { "6",  233 }, { "7", 492 }, { "8", 835 }, { "9", 635 }, { "10", 1580 }
            };

            response.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeRatingsExceptions()
        {
            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;
            var uri = $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/ratings";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktEpisodeRating>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktEpisodeNotFoundException>();

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
        public void TestTraktEpisodesModuleGetEpisodeRatingsArgumentExceptions()
        {
            var episodeRatings = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeRatings.json");
            episodeRatings.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/ratings", episodeRatings);

            Func<Task<TraktEpisodeRating>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync(null, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync(string.Empty, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync(showId, -1, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync(showId, seasonNr, -1);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region EpisodeStatistics

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeStatistics()
        {
            var episodeStatistics = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeStatistics.json");
            episodeStatistics.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/stats", episodeStatistics);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeStatisticsAsync(showId, seasonNr, episodeNr).Result;

            response.Should().NotBeNull();
            response.Watchers.Should().Be(233273);
            response.Plays.Should().Be(303464);
            response.Collectors.Should().Be(92759);
            response.CollectedEpisodes.Should().NotHaveValue();
            response.Comments.Should().Be(4);
            response.Lists.Should().Be(418);
            response.Votes.Should().Be(3919);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeStatisticsExceptions()
        {
            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;
            var uri = $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/stats";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktEpisodeStatistics>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeStatisticsAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktEpisodeNotFoundException>();

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
        public void TestTraktEpisodesModuleGetEpisodeStatisticsArgumentExceptions()
        {
            var episodeStatistics = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeStatistics.json");
            episodeStatistics.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/stats", episodeStatistics);

            Func<Task<TraktEpisodeStatistics>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeStatisticsAsync(null, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeStatisticsAsync(string.Empty, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeStatisticsAsync(showId, -1, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeStatisticsAsync(showId, seasonNr, -1);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region EpisodeWatchingUsers

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeWatchingUsers()
        {
            var episodeWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeWatchingUsers.json");
            episodeWatchingUsers.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/watching", episodeWatchingUsers);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeWatchingUsersAsync(showId, seasonNr, episodeNr).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeWatchingUsersWithExtendedOption()
        {
            var episodeWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeWatchingUsers.json");
            episodeWatchingUsers.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/watching?extended={extendedOption.ToString()}",
                                                      episodeWatchingUsers);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeWatchingUsersAsync(showId, seasonNr, episodeNr, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeWatchingUsersExceptions()
        {
            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;
            var uri = $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/watching";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResult<TraktEpisodeWatchingUser>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeWatchingUsersAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktEpisodeNotFoundException>();

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
        public void TestTraktEpisodesModuleGetEpisodeWatchingUsersArgumentExceptions()
        {
            var episodeWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeWatchingUsers.json");
            episodeWatchingUsers.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var episodeNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/watching", episodeWatchingUsers);

            Func<Task<TraktListResult<TraktEpisodeWatchingUser>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeWatchingUsersAsync(null, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeWatchingUsersAsync(string.Empty, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeWatchingUsersAsync(showId, -1, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeWatchingUsersAsync(showId, seasonNr, -1);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion
    }
}
