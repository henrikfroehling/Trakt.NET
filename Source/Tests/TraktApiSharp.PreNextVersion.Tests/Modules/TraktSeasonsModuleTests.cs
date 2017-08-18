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
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Utils;

    [TestClass]
    public class TraktSeasonsModuleTests
    {
        [TestMethod]
        public void TestTraktSeasonsModuleIsModule()
        {
            typeof(TraktSeasonsModule).GetInterfaces().Should().Contain(typeof(ITraktModule));
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
            var seasons = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\Full\SeasonsAllFull.json");
            seasons.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons", seasons);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetAllSeasonsWithExtendedInfo()
        {
            var seasons = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\Full\SeasonsAllFull.json");
            seasons.Should().NotBeNullOrEmpty();

            var showId = "1390";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons?extended={extendedInfo.ToString()}", seasons);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetAllSeasonsWithTranslations()
        {
            var seasons = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\Full\SeasonsAllFull.json");
            seasons.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var translationLanguageCode = "en";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons?translations={translationLanguageCode}", seasons);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId, null, translationLanguageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetAllSeasonsWithExtendedInfoAndTranslations()
        {
            var seasons = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\Full\SeasonsAllFull.json");
            seasons.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var translationLanguageCode = "en";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons" +
                                                      $"?extended={extendedInfo.ToString()}" +
                                                      $"&translations={translationLanguageCode}",
                                                      seasons);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId, extendedInfo,
                                                                                   translationLanguageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetAllSeasonsWithAllTranslations()
        {
            var seasons = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\Full\SeasonsAllFull.json");
            seasons.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var translationLanguageCode = "all";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons?translations={translationLanguageCode}", seasons);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId, null, translationLanguageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetAllSeasonsWithExtendedInfoAndAllTranslations()
        {
            var seasons = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\Full\SeasonsAllFull.json");
            seasons.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var translationLanguageCode = "all";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons" +
                                                      $"?extended={extendedInfo.ToString()}" +
                                                      $"&translations={translationLanguageCode}",
                                                      seasons);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId, extendedInfo,
                                                                                   translationLanguageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetAllSeasonsExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/seasons";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktSeason>>> act =
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
            var seasons = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\All\Full\SeasonsAllFull.json");
            seasons.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons", seasons);

            Func<Task<TraktListResponse<ITraktSeason>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync("show id");
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId, null, "eng");
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId, null, "e");
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetAllSeasonsAsync(showId, null, "all");
            act.ShouldNotThrow();
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
            var seasonNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}", season);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonWithExtendedInfo()
        {
            var season = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonEpisodes.json");
            season.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}?extended={extendedInfo.ToString()}", season);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonWithTranslations()
        {
            var season = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonEpisodes.json");
            season.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var translationLanguageCode = "en";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}" +
                                                      $"?translations={translationLanguageCode}",
                                                      season);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr,
                                                                               null, translationLanguageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonWithExtendedInfoAndTranslations()
        {
            var season = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonEpisodes.json");
            season.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var translationLanguageCode = "en";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}" +
                                                      $"?extended={extendedInfo.ToString()}" +
                                                      $"&translations={translationLanguageCode}",
                                                      season);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr,
                                                                               extendedInfo, translationLanguageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonWithAllTranslations()
        {
            var season = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonEpisodes.json");
            season.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var translationLanguageCode = "all";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}" +
                                                      $"?translations={translationLanguageCode}",
                                                      season);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr,
                                                                               null, translationLanguageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonWithExtendedInfoAndAllTranslations()
        {
            var season = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonEpisodes.json");
            season.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var translationLanguageCode = "all";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}" +
                                                      $"?extended={extendedInfo.ToString()}" +
                                                      $"&translations={translationLanguageCode}",
                                                      season);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr,
                                                                               extendedInfo, translationLanguageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(10);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonExceptions()
        {
            var showId = "1390";
            var seasonNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktEpisode>>> act =
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
            var seasonNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}", season);

            Func<Task<TraktListResponse<ITraktEpisode>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(null, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(string.Empty, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync("show id", seasonNr);
            act.ShouldThrow<ArgumentException>();
            
            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr, null, "eng");
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr, null, "e");
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonAsync(showId, seasonNr, null, "all");
            act.ShouldNotThrow();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MultipleSeasons

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonsArgumentExceptions()
        {
            var showId = "1390";
            var seasonNr = 1U;

            Func<Task<IEnumerable<TraktListResponse<ITraktEpisode>>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(null);
            act.ShouldNotThrow();

            var queryParams = new TraktMultipleSeasonsQueryParams();
            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.ShouldNotThrow();

            queryParams = new TraktMultipleSeasonsQueryParams { { null, seasonNr } };
            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.ShouldThrow<ArgumentException>();

            queryParams = new TraktMultipleSeasonsQueryParams { { string.Empty, seasonNr } };
            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.ShouldThrow<ArgumentException>();

            queryParams = new TraktMultipleSeasonsQueryParams { { "show id", seasonNr } };
            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.ShouldThrow<ArgumentException>();
            
            queryParams = new TraktMultipleSeasonsQueryParams { { showId, seasonNr, "eng" } };
            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            queryParams = new TraktMultipleSeasonsQueryParams { { showId, seasonNr, "e" } };
            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            var season = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonEpisodes.json");
            season.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}?translations=all", season);

            queryParams = new TraktMultipleSeasonsQueryParams { { showId, seasonNr, "all" } };
            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetMultipleSeasonsAsync(queryParams);
            act.ShouldNotThrow();
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
            var seasonNr = 1U;
            var itemCount = 3;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments",
                                                                seasonComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, seasonNr).Result;

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
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithSortOrder()
        {
            var seasonComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonComments.json");
            seasonComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 3;
            var sortOrder = TraktCommentSortOrder.Likes;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments/{sortOrder.UriName}",
                                                                seasonComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, seasonNr, sortOrder).Result;

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
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithPage()
        {
            var seasonComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonComments.json");
            seasonComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 3;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments?page={page}",
                                                                seasonComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, seasonNr, null, pagedParameters).Result;

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
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithSortOrderAndPage()
        {
            var seasonComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonComments.json");
            seasonComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 3;
            var sortOrder = TraktCommentSortOrder.Likes;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments/{sortOrder.UriName}?page={page}",
                                                                seasonComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, seasonNr, sortOrder, pagedParameters).Result;

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
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithLimit()
        {
            var seasonComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonComments.json");
            seasonComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 3;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments?limit={limit}",
                                                                seasonComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, seasonNr, null, pagedParameters).Result;

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
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithSortOrderAndLimit()
        {
            var seasonComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonComments.json");
            seasonComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 3;
            var sortOrder = TraktCommentSortOrder.Likes;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments/{sortOrder.UriName}?limit={limit}",
                                                                seasonComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, seasonNr, sortOrder, pagedParameters).Result;

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
        public void TestTraktSeasonsModuleGetSeasonCommmentsWithPageAndLimit()
        {
            var seasonComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonComments.json");
            seasonComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 3;
            uint page = 2;
            uint limit = 20;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments?page={page}&limit={limit}",
                                                                seasonComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, seasonNr, null, pagedParameters).Result;

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
        public void TestTraktSeasonsModuleGetSeasonCommmentsComplete()
        {
            var seasonComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonComments.json");
            seasonComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 3;
            var sortOrder = TraktCommentSortOrder.Likes;
            uint page = 2;
            uint limit = 20;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments/{sortOrder.UriName}?page={page}&limit={limit}",
                                                                seasonComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(showId, seasonNr, sortOrder, pagedParameters).Result;

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
        public void TestTraktSeasonsModuleGetSeasonCommmentsExceptions()
        {
            var showId = "1390";
            var seasonNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/comments";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktComment>>> act =
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
            var seasonNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/comments", seasonComments);

            Func<Task<TraktPagedResponse<ITraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(null, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync(string.Empty, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonCommentsAsync("show id", seasonNr);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region SeasonLists

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonLists()
        {
            var seasonLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonLists.json");
            seasonLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 10;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/lists",
                                                                seasonLists, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr).Result;

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
        public void TestTraktSeasonsModuleGetSeasonListsWithType()
        {
            var seasonLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonLists.json");
            seasonLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 10;
            var type = TraktListType.Official;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/lists/{type.UriName}",
                                                                seasonLists, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, type).Result;

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
        public void TestTraktSeasonsModuleGetSeasonListsWithSortOrderAndWithoutType()
        {
            var seasonLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonLists.json");
            seasonLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 10;
            var sortOrder = TraktListSortOrder.Comments;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/lists",
                                                                seasonLists, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, null, sortOrder).Result;

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
        public void TestTraktSeasonsModuleGetSeasonListsWithPage()
        {
            var seasonLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonLists.json");
            seasonLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 10;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/lists?page={page}",
                                                                seasonLists, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, null, null, pagedParameters).Result;

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
        public void TestTraktSeasonsModuleGetSeasonListsWithLimit()
        {
            var seasonLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonLists.json");
            seasonLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 10;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/lists?limit={limit}",
                                                                seasonLists, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, null, null, pagedParameters).Result;

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
        public void TestTraktSeasonsModuleGetSeasonListsWithPageAndLimit()
        {
            var seasonLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonLists.json");
            seasonLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 10;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/lists?page={page}&limit={limit}",
                seasonLists, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, null, null, pagedParameters).Result;

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
        public void TestTraktSeasonsModuleGetSeasonListsWithTypeAndSortOrder()
        {
            var seasonLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonLists.json");
            seasonLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/lists/{type.UriName}/{sortOrder.UriName}",
                seasonLists, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, type, sortOrder).Result;

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
        public void TestTraktSeasonsModuleGetSeasonListsWithTypeAndPage()
        {
            var seasonLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonLists.json");
            seasonLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 10;
            var type = TraktListType.Official;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/lists/{type.UriName}?page={page}",
                seasonLists, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, type, null, pagedParameters).Result;

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
        public void TestTraktSeasonsModuleGetSeasonListsWithTypeAndLimit()
        {
            var seasonLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonLists.json");
            seasonLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 10;
            var type = TraktListType.Official;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/lists/{type.UriName}?limit={limit}",
                seasonLists, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, type, null, pagedParameters).Result;

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
        public void TestTraktSeasonsModuleGetSeasonListsWithTypeAndPageAndLimit()
        {
            var seasonLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonLists.json");
            seasonLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 10;
            var type = TraktListType.Official;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/lists/{type.UriName}?page={page}&limit={limit}",
                seasonLists, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, type, null, pagedParameters).Result;

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
        public void TestTraktSeasonsModuleGetSeasonListsWithTypeAndSortOrderAndPage()
        {
            var seasonLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonLists.json");
            seasonLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/lists/{type.UriName}/{sortOrder.UriName}?page={page}",
                seasonLists, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, type, sortOrder, pagedParameters).Result;

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
        public void TestTraktSeasonsModuleGetSeasonListsWithTypeAndSortOrderAndLimit()
        {
            var seasonLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonLists.json");
            seasonLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/lists/{type.UriName}/{sortOrder.UriName}?limit={limit}",
                seasonLists, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, type, sortOrder, pagedParameters).Result;

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
        public void TestTraktSeasonsModuleGetSeasonListsComplete()
        {
            var seasonLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonLists.json");
            seasonLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;
            var itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/seasons/{seasonNr}/lists/{type.UriName}/{sortOrder.UriName}" +
                $"?page={page}&limit={limit}",
                seasonLists, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr, type, sortOrder, pagedParameters).Result;

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
        public void TestTraktSeasonsModuleGetSeasonListsExceptions()
        {
            var showId = "1390";
            var seasonNr = 0U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/lists";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(showId, seasonNr);
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
        public void TestTraktSeasonsModuleGetSeasonListsArgumentsExceptions()
        {
            var seasonLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonLists.json");
            seasonLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 0U;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/lists", seasonLists);

            Func<Task<TraktPagedResponse<ITraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(null, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync(string.Empty, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonListsAsync("show id", seasonNr);
            act.ShouldThrow<ArgumentException>();
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
            var seasonNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/ratings", seasonRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonRatingsAsync(showId, seasonNr).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Rating.Should().Be(9.12881f);
            responseValue.Votes.Should().Be(1149);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  7 }, { "2", 5 }, { "3", 4 }, { "4", 2 }, { "5", 9 },
                { "6",  23 }, { "7", 45 }, { "8", 152 }, { "9", 282 }, { "10", 620 }
            };

            responseValue.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonRatingsExceptions()
        {
            var showId = "1390";
            var seasonNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/ratings";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktRating>>> act =
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
            var seasonNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/ratings", seasonRatings);

            Func<Task<TraktResponse<ITraktRating>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonRatingsAsync(null, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonRatingsAsync(string.Empty, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonRatingsAsync("show id", seasonNr);
            act.ShouldThrow<ArgumentException>();
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
            var seasonNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/stats", seasonStatistics);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonStatisticsAsync(showId, seasonNr).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Watchers.Should().Be(232215);
            responseValue.Plays.Should().Be(2719701);
            responseValue.Collectors.Should().Be(91770);
            responseValue.CollectedEpisodes.Should().Be(907358);
            responseValue.Comments.Should().Be(6);
            responseValue.Lists.Should().Be(250);
            responseValue.Votes.Should().Be(1149);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonStatisticsExceptions()
        {
            var showId = "1390";
            var seasonNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/stats";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktStatistics>>> act =
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
            var seasonNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/stats", seasonStatistics);

            Func<Task<TraktResponse<ITraktStatistics>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonStatisticsAsync(null, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonStatisticsAsync(string.Empty, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonStatisticsAsync("show id", seasonNr);
            act.ShouldThrow<ArgumentException>();
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
            var seasonNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/watching", seasonWatchingUsers);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonWatchingUsersAsync(showId, seasonNr).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonWatchingUsersWithExtendedInfo()
        {
            var seasonWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Shows\Seasons\Single\SeasonWatchingUsers.json");
            seasonWatchingUsers.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var seasonNr = 1U;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/watching?extended={extendedInfo.ToString()}",
                                                      seasonWatchingUsers);

            var response = TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonWatchingUsersAsync(showId, seasonNr, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktSeasonsModuleGetSeasonWatchingUsersExceptions()
        {
            var showId = "1390";
            var seasonNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/watching";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktUser>>> act =
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
            var seasonNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/watching", seasonWatchingUsers);

            Func<Task<TraktListResponse<ITraktUser>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonWatchingUsersAsync(null, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonWatchingUsersAsync(string.Empty, seasonNr);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Seasons.GetSeasonWatchingUsersAsync("show id", seasonNr);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion
    }
}
