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
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Requests.Params;
    using TraktApiSharp.Responses;
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
            var seasonNr = 1U;
            var episodeNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", episode);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Title.Should().Be("Winter Is Coming");
            responseValue.SeasonNumber.Should().Be(1);
            responseValue.Number.Should().Be(1);
            responseValue.NumberAbsolute.Should().Be(50);
            responseValue.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            responseValue.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            responseValue.Rating.Should().Be(9.0f);
            responseValue.Votes.Should().Be(111);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(73640U);
            responseValue.Ids.Tvdb.Should().Be(3254641U);
            responseValue.Ids.Imdb.Should().Be("tt1480055");
            responseValue.Ids.Tmdb.Should().Be(63056U);
            responseValue.Ids.TvRage.Should().Be(1065008299U);
            responseValue.Images.Should().NotBeNull();
            responseValue.Images.Screenshot.Should().NotBeNull();
            responseValue.Images.Screenshot.Full.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/original/dd3fc55725.jpg");
            responseValue.Images.Screenshot.Medium.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/medium/dd3fc55725.jpg");
            responseValue.Images.Screenshot.Thumb.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/thumb/dd3fc55725.jpg");
            responseValue.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeWithExtendedInfo()
        {
            var episode = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeSummaryFullAndImages.json");
            episode.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}?extended={extendedInfo.ToString()}",
                                                      episode);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Title.Should().Be("Winter Is Coming");
            responseValue.SeasonNumber.Should().Be(1);
            responseValue.Number.Should().Be(1);
            responseValue.NumberAbsolute.Should().Be(50);
            responseValue.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            responseValue.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            responseValue.Rating.Should().Be(9.0f);
            responseValue.Votes.Should().Be(111);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(73640U);
            responseValue.Ids.Tvdb.Should().Be(3254641U);
            responseValue.Ids.Imdb.Should().Be("tt1480055");
            responseValue.Ids.Tmdb.Should().Be(63056U);
            responseValue.Ids.TvRage.Should().Be(1065008299U);
            responseValue.Images.Should().NotBeNull();
            responseValue.Images.Screenshot.Should().NotBeNull();
            responseValue.Images.Screenshot.Full.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/original/dd3fc55725.jpg");
            responseValue.Images.Screenshot.Medium.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/medium/dd3fc55725.jpg");
            responseValue.Images.Screenshot.Thumb.Should().Be("https://walter.trakt.us/images/episodes/000/073/640/screenshots/thumb/dd3fc55725.jpg");
            responseValue.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeExceptions()
        {
            var showId = "1390";
            var seasonNr = 0U;
            var episodeNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<TraktEpisode>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktEpisodeNotFoundException>();

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
        public void TestTraktEpisodesModuleGetEpisodeArgumentExceptions()
        {
            var episode = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeSummaryFullAndImages.json");
            episode.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 0U;
            var episodeNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", episode);

            Func<Task<TraktResponse<TraktEpisode>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(null, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(string.Empty, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync("show id", seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MultipleEpisodes

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodesArgumentExceptions()
        {
            var showId = "1390";
            var seasonNr = 0U;
            var episodeNr = 1U;

            Func<Task<IEnumerable<TraktResponse<TraktEpisode>>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetMultipleEpisodesAsync(null);
            act.ShouldNotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetMultipleEpisodesAsync(
                new TraktMultipleEpisodesQueryParams());
            act.ShouldNotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetMultipleEpisodesAsync(
                new TraktMultipleEpisodesQueryParams { { null, seasonNr, episodeNr } });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetMultipleEpisodesAsync(
                new TraktMultipleEpisodesQueryParams { { string.Empty, seasonNr, episodeNr } });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetMultipleEpisodesAsync(
                new TraktMultipleEpisodesQueryParams { { "show id", seasonNr, episodeNr } });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetMultipleEpisodesAsync(
                new TraktMultipleEpisodesQueryParams { { showId, seasonNr, 0 } });
            act.ShouldThrow<ArgumentOutOfRangeException>();
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
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments",
                                                                episodeComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithSortOrder()
        {
            var episodeComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeComments.json");
            episodeComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 4;
            var sortOrder = TraktCommentSortOrder.Likes;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments/{sortOrder.UriName}",
                                                                episodeComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, sortOrder).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithPage()
        {
            var episodeComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeComments.json");
            episodeComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments?page={page}",
                                                                episodeComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, null, page).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithSortOrderAndPage()
        {
            var episodeComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeComments.json");
            episodeComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 4;
            var sortOrder = TraktCommentSortOrder.Likes;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments/{sortOrder.UriName}?page={page}",
                                                                episodeComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, sortOrder, page).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithLimit()
        {
            var episodeComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeComments.json");
            episodeComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments?limit={limit}",
                                                                episodeComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, null, null, limit).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithSortOrderAndLimit()
        {
            var episodeComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeComments.json");
            episodeComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 4;
            var sortOrder = TraktCommentSortOrder.Likes;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments/{sortOrder.UriName}?limit={limit}",
                                                                episodeComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, sortOrder, null, limit).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsWithPageAndLimit()
        {
            var episodeComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeComments.json");
            episodeComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 4;
            var page = 2;
            var limit = 20;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments?page={page}&limit={limit}",
                                                                episodeComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, null, page, limit).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsComplete()
        {
            var episodeComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeComments.json");
            episodeComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 4;
            var sortOrder = TraktCommentSortOrder.Likes;
            var page = 2;
            var limit = 20;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments/{sortOrder.UriName}?page={page}&limit={limit}",
                                                                episodeComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr, sortOrder, page, limit).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeCommmentsExceptions()
        {
            var showId = "1390";
            var seasonNr = 0U;
            var episodeNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<TraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktEpisodeNotFoundException>();

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
        public void TestTraktEpisodesModuleGetEpisodeCommmentsArgumentExceptions()
        {
            var episodeComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeComments.json");
            episodeComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 0U;
            var episodeNr = 1U;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/comments", episodeComments);

            Func<Task<TraktPagedResponse<TraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(null, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(string.Empty, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync("show id", seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeCommentsAsync(showId, seasonNr, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region EpisodeLists

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeLists()
        {
            var episodeLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeLists.json");
            episodeLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 10;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists",
                                                                episodeLists, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeListsWithType()
        {
            var episodeLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeLists.json");
            episodeLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 10;
            var type = TraktListType.Official;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists/{type.UriName}",
                episodeLists, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr, type).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeListsWithSortOrderAndWithoutType()
        {
            var episodeLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeLists.json");
            episodeLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 10;
            var sortOrder = TraktListSortOrder.Comments;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists",
                episodeLists, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr,
                                                                                      null, sortOrder).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeListsWithPage()
        {
            var episodeLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeLists.json");
            episodeLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 10;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists?page={page}",
                episodeLists, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr,
                                                                                      null, null, page).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeListsWithLimit()
        {
            var episodeLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeLists.json");
            episodeLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 10;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists?limit={limit}",
                episodeLists, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr,
                                                                                      null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeListsWithPageAndLimit()
        {
            var episodeLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeLists.json");
            episodeLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 10;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists?page={page}&limit={limit}",
                episodeLists, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr,
                                                                                      null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeListsWithTypeAndSortOrder()
        {
            var episodeLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeLists.json");
            episodeLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists/{type.UriName}/{sortOrder.UriName}",
                episodeLists, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr,
                                                                                      type, sortOrder).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeListsWithTypeAndPage()
        {
            var episodeLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeLists.json");
            episodeLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 10;
            var type = TraktListType.Official;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists/{type.UriName}?page={page}",
                episodeLists, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr, type,
                                                                                      null, page).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeListsWithTypeAndLimit()
        {
            var episodeLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeLists.json");
            episodeLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 10;
            var type = TraktListType.Official;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists/{type.UriName}?limit={limit}",
                episodeLists, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr, type,
                                                                                      null, null, limit).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeListsWithTypeAndPageAndLimit()
        {
            var episodeLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeLists.json");
            episodeLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 10;
            var type = TraktListType.Official;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists/{type.UriName}?page={page}&limit={limit}",
                episodeLists, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr, type,
                                                                                      null, page, limit).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeListsWithTypeAndSortOrderAndPage()
        {
            var episodeLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeLists.json");
            episodeLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists/{type.UriName}/{sortOrder.UriName}?page={page}",
                episodeLists, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr, type,
                                                                                      sortOrder, page).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeListsWithTypeAndSortOrderAndLimit()
        {
            var episodeLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeLists.json");
            episodeLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists/{type.UriName}/{sortOrder.UriName}?limit={limit}",
                episodeLists, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr, type,
                                                                                      sortOrder, null, limit).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeListsComplete()
        {
            var episodeLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeLists.json");
            episodeLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists/{type.UriName}/{sortOrder.UriName}" +
                $"?page={page}&limit={limit}",
                episodeLists, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr, type,
                                                                                      sortOrder, page, limit).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeListsExceptions()
        {
            var showId = "1390";
            var seasonNr = 0U;
            var episodeNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<TraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktEpisodeNotFoundException>();

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
        public void TestTraktEpisodesModuleGetEpisodeListsArgumentsExceptions()
        {
            var episodeLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeLists.json");
            episodeLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 0U;
            var episodeNr = 1U;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/lists", episodeLists);

            Func<Task<TraktPagedResponse<TraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(null, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(string.Empty, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync("show id", seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeListsAsync(showId, seasonNr, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();
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
            var seasonNr = 1U;
            var episodeNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/ratings", episodeRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync(showId, seasonNr, episodeNr).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Rating.Should().Be(8.54044f);
            responseValue.Votes.Should().Be(3919);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  59 }, { "2", 11 }, { "3", 2 }, { "4", 14 }, { "5", 58 },
                { "6",  233 }, { "7", 492 }, { "8", 835 }, { "9", 635 }, { "10", 1580 }
            };

            responseValue.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeRatingsExceptions()
        {
            var showId = "1390";
            var seasonNr = 0U;
            var episodeNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/ratings";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<TraktRating>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktEpisodeNotFoundException>();

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
        public void TestTraktEpisodesModuleGetEpisodeRatingsArgumentExceptions()
        {
            var episodeRatings = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeRatings.json");
            episodeRatings.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 0U;
            var episodeNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/ratings", episodeRatings);

            Func<Task<TraktResponse<TraktRating>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync(null, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync(string.Empty, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync("show id", seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeRatingsAsync(showId, seasonNr, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();
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
            var seasonNr = 1U;
            var episodeNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/stats", episodeStatistics);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeStatisticsAsync(showId, seasonNr, episodeNr).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Watchers.Should().Be(233273);
            responseValue.Plays.Should().Be(303464);
            responseValue.Collectors.Should().Be(92759);
            responseValue.CollectedEpisodes.Should().NotHaveValue();
            responseValue.Comments.Should().Be(4);
            responseValue.Lists.Should().Be(418);
            responseValue.Votes.Should().Be(3919);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeStatisticsExceptions()
        {
            var showId = "1390";
            var seasonNr = 0U;
            var episodeNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/stats";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<TraktStatistics>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeStatisticsAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktEpisodeNotFoundException>();

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
        public void TestTraktEpisodesModuleGetEpisodeStatisticsArgumentExceptions()
        {
            var episodeStatistics = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeStatistics.json");
            episodeStatistics.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 0U;
            var episodeNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/stats", episodeStatistics);

            Func<Task<TraktResponse<TraktStatistics>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeStatisticsAsync(null, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeStatisticsAsync(string.Empty, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeStatisticsAsync("show id", seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeStatisticsAsync(showId, seasonNr, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region EpisodeTranslations

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeTranslations()
        {
            var episodeTranslations = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeTranslations.json");
            episodeTranslations.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/translations",
                episodeTranslations);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeTranslationsAsync(showId, seasonNr, episodeNr).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeTranslationsExceptions()
        {
            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/translations";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<TraktEpisodeTranslation>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeTranslationsAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktEpisodeNotFoundException>();

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
        public void TestTraktEpisodesModuleGetEpisodeTranslationsArgumentExceptions()
        {
            var episodeTranslations = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeTranslations.json");
            episodeTranslations.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 0U;
            var episodeNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/translations",
                                                      episodeTranslations);

            Func<Task<TraktListResponse<TraktEpisodeTranslation>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeTranslationsAsync(null, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeTranslationsAsync(string.Empty, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeTranslationsAsync("show id", seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeTranslationsAsync(showId, seasonNr, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region EpisodeSingleTranslations

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeSingleTranslation()
        {
            var episodeSingleTranslation = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeTranslations.json");
            episodeSingleTranslation.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var languageCode = "en";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/translations/{languageCode}",
                episodeSingleTranslation);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeTranslationsAsync(showId, seasonNr, episodeNr, languageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeSingleTranslationExceptions()
        {
            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;
            var languageCode = "en";
            var uri = $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/translations/{languageCode}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<TraktEpisodeTranslation>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeTranslationsAsync(showId, seasonNr, episodeNr, languageCode);
            act.ShouldThrow<TraktEpisodeNotFoundException>();

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
        public void TestTraktEpisodesModuleGetEpisodeSingleTranslationArgumentExceptions()
        {
            var episodeSingleTranslation = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeTranslations.json");
            episodeSingleTranslation.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 0U;
            var episodeNr = 1U;
            var languageCode = "en";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/translations/{languageCode}",
                                                      episodeSingleTranslation);

            Func<Task<TraktListResponse<TraktEpisodeTranslation>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeTranslationsAsync(null, seasonNr, episodeNr, languageCode);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeTranslationsAsync(string.Empty, seasonNr, episodeNr, languageCode);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeTranslationsAsync("show id", seasonNr, episodeNr, languageCode);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeTranslationsAsync(showId, seasonNr, 0, languageCode);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeTranslationsAsync(showId, seasonNr, episodeNr, "eng");
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeTranslationsAsync(showId, seasonNr, episodeNr, "e");
            act.ShouldThrow<ArgumentOutOfRangeException>();
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
            var seasonNr = 1U;
            var episodeNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/watching", episodeWatchingUsers);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeWatchingUsersAsync(showId, seasonNr, episodeNr).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeWatchingUsersWithExtendedInfo()
        {
            var episodeWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeWatchingUsers.json");
            episodeWatchingUsers.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var episodeNr = 1U;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/watching?extended={extendedInfo.ToString()}",
                                                      episodeWatchingUsers);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeWatchingUsersAsync(showId, seasonNr, episodeNr, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktEpisodesModuleGetEpisodeWatchingUsersExceptions()
        {
            var showId = "1390";
            var seasonNr = 0U;
            var episodeNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/watching";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<TraktUser>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeWatchingUsersAsync(showId, seasonNr, episodeNr);
            act.ShouldThrow<TraktEpisodeNotFoundException>();

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
        public void TestTraktEpisodesModuleGetEpisodeWatchingUsersArgumentExceptions()
        {
            var episodeWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeWatchingUsers.json");
            episodeWatchingUsers.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 0U;
            var episodeNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}/watching", episodeWatchingUsers);

            Func<Task<TraktListResponse<TraktUser>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeWatchingUsersAsync(null, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeWatchingUsersAsync(string.Empty, seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeWatchingUsersAsync("show id", seasonNr, episodeNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeWatchingUsersAsync(showId, seasonNr, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}
