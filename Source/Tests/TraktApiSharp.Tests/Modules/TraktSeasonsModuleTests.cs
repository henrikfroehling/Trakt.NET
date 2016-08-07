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
    using TraktApiSharp.Objects.Get.Shows.Seasons;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Params;
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

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetAllSeasonsExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/seasons";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktSeason>>> act =
                act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId);
            act.ShouldThrow<TraktShowNotFoundException>();

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
        public void TestTraktSeasonsModuleGetAllSeasonsArgumentExceptions()
        {
            var seasons = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\FullAndImages\SeasonsAllFullAndImages.json");
            seasons.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons", seasons);

            Func<Task<IEnumerable<TraktSeason>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync("show id");
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

            response.Should().NotBeNull().And.HaveCount(10);
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

            response.Should().NotBeNull().And.HaveCount(10);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonExceptions()
        {
            var showId = "1390";
            var seasonNr = 1;
            var uri = $"shows/{showId}/seasons/{seasonNr}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktEpisode>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr);
            act.ShouldThrow<TraktSeasonNotFoundException>();

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
        public void TestTraktSeasonsModuleGetSeasonArgumentExceptions()
        {
            var season = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonEpisodes.json");
            season.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}", season);

            Func<Task<IEnumerable<TraktEpisode>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(null, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(string.Empty, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync("show id", seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, -1);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MultipleSeasons

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonsArgumentExceptions()
        {
            var showId = "1390";
            var seasonNr = 1;

            Func<Task<IEnumerable<IEnumerable<TraktEpisode>>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(null);
            act.ShouldNotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(
                new TraktMultipleSeasonsQueryParams());
            act.ShouldNotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(
                new TraktMultipleSeasonsQueryParams { { null, seasonNr } });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(
                new TraktMultipleSeasonsQueryParams { { string.Empty, seasonNr } });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(
                new TraktMultipleSeasonsQueryParams { { "show id", seasonNr } });
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(
                new TraktMultipleSeasonsQueryParams { { showId, -1 } });
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region SeasonComments

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommments()
        {
            var seasonComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonComments.json");
            seasonComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var itemCount = 3;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments",
                                                                seasonComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, seasonNr).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithSortOrder()
        {
            var seasonComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonComments.json");
            seasonComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var itemCount = 3;
            var sortOrder = TraktCommentSortOrder.Likes;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments/{sortOrder.UriName}",
                                                                seasonComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, seasonNr, sortOrder).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithPage()
        {
            var seasonComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonComments.json");
            seasonComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var itemCount = 3;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments?page={page}",
                                                                seasonComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, seasonNr, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithSortOrderAndPage()
        {
            var seasonComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonComments.json");
            seasonComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var itemCount = 3;
            var sortOrder = TraktCommentSortOrder.Likes;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments/{sortOrder.UriName}?page={page}",
                                                                seasonComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, seasonNr, sortOrder, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithLimit()
        {
            var seasonComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonComments.json");
            seasonComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var itemCount = 3;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments?limit={limit}",
                                                                seasonComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, seasonNr, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithSortOrderAndLimit()
        {
            var seasonComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonComments.json");
            seasonComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var itemCount = 3;
            var sortOrder = TraktCommentSortOrder.Likes;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments/{sortOrder.UriName}?limit={limit}",
                                                                seasonComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, seasonNr, sortOrder, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithPageAndLimit()
        {
            var seasonComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonComments.json");
            seasonComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var itemCount = 3;
            var page = 2;
            var limit = 20;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments?page={page}&limit={limit}",
                                                                seasonComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, seasonNr, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommmentsComplete()
        {
            var seasonComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonComments.json");
            seasonComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;
            var itemCount = 3;
            var sortOrder = TraktCommentSortOrder.Likes;
            var page = 2;
            var limit = 20;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments/{sortOrder.UriName}?page={page}&limit={limit}",
                                                                seasonComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, seasonNr, sortOrder, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonCommmentsExceptions()
        {
            var showId = "1390";
            var seasonNr = 1;
            var uri = $"shows/{showId}/seasons/{seasonNr}/comments";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPaginationListResult<TraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, seasonNr);
            act.ShouldThrow<TraktSeasonNotFoundException>();

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
        public void TestTraktSeasonsModuleGetSeasonCommmentsArgumentExceptions()
        {
            var seasonComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonComments.json");
            seasonComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments", seasonComments);

            Func<Task<TraktPaginationListResult<TraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(null, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(string.Empty, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync("show id", seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, -1);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region SeasonRatings

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonRatings()
        {
            var seasonRatings = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonRatings.json");
            seasonRatings.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/ratings", seasonRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonRatingsAsync(showId, seasonNr).Result;

            response.Should().NotBeNull();
            response.Rating.Should().Be(9.12881f);
            response.Votes.Should().Be(1149);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  7 }, { "2", 5 }, { "3", 4 }, { "4", 2 }, { "5", 9 },
                { "6",  23 }, { "7", 45 }, { "8", 152 }, { "9", 282 }, { "10", 620 }
            };

            response.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonRatingsExceptions()
        {
            var showId = "1390";
            var seasonNr = 1;
            var uri = $"shows/{showId}/seasons/{seasonNr}/ratings";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktRating>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonRatingsAsync(showId, seasonNr);
            act.ShouldThrow<TraktSeasonNotFoundException>();

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
        public void TestTraktSeasonsModuleGetSeasonRatingsArgumentExceptions()
        {
            var seasonRatings = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonRatings.json");
            seasonRatings.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/ratings", seasonRatings);

            Func<Task<TraktRating>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonRatingsAsync(null, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonRatingsAsync(string.Empty, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonRatingsAsync("show id", seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonRatingsAsync(showId, -1);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region SeasonStatistics

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonStatistics()
        {
            var seasonStatistics = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonStatistics.json");
            seasonStatistics.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/stats", seasonStatistics);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonStatisticsAsync(showId, seasonNr).Result;

            response.Should().NotBeNull();
            response.Watchers.Should().Be(232215);
            response.Plays.Should().Be(2719701);
            response.Collectors.Should().Be(91770);
            response.CollectedEpisodes.Should().Be(907358);
            response.Comments.Should().Be(6);
            response.Lists.Should().Be(250);
            response.Votes.Should().Be(1149);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonStatisticsExceptions()
        {
            var showId = "1390";
            var seasonNr = 1;
            var uri = $"shows/{showId}/seasons/{seasonNr}/stats";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktStatistics>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonStatisticsAsync(showId, seasonNr);
            act.ShouldThrow<TraktSeasonNotFoundException>();

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
        public void TestTraktSeasonsModuleGetSeasonStatisticsArgumentExceptions()
        {
            var seasonStatistics = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonStatistics.json");
            seasonStatistics.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/stats", seasonStatistics);

            Func<Task<TraktStatistics>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonStatisticsAsync(null, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonStatisticsAsync(string.Empty, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonStatisticsAsync("show id", seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonStatisticsAsync(showId, -1);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region SeasonWatchingUsers

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonWatchingUsers()
        {
            var seasonWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonWatchingUsers.json");
            seasonWatchingUsers.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/watching", seasonWatchingUsers);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonWatchingUsersAsync(showId, seasonNr).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonWatchingUsersWithExtendedOption()
        {
            var seasonWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonWatchingUsers.json");
            seasonWatchingUsers.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/watching?extended={extendedOption.ToString()}",
                                                      seasonWatchingUsers);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonWatchingUsersAsync(showId, seasonNr, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonWatchingUsersExceptions()
        {
            var showId = "1390";
            var seasonNr = 1;
            var uri = $"shows/{showId}/seasons/{seasonNr}/watching";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<IEnumerable<TraktUser>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonWatchingUsersAsync(showId, seasonNr);
            act.ShouldThrow<TraktSeasonNotFoundException>();

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
        public void TestTraktSeasonsModuleGetSeasonWatchingUsersArgumentExceptions()
        {
            var seasonWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonWatchingUsers.json");
            seasonWatchingUsers.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/watching", seasonWatchingUsers);

            Func<Task<IEnumerable<TraktUser>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonWatchingUsersAsync(null, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonWatchingUsersAsync(string.Empty, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonWatchingUsersAsync("show id", seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonWatchingUsersAsync(showId, -1);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}
