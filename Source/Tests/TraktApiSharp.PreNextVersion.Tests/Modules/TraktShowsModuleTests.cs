namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Utils;

    [TestClass]
    public class TraktShowsModuleTests
    {
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

        #region SingleShow

        [TestMethod]
        public void TestTraktShowsModuleGetShow()
        {
            var show = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowSummaryFull.json");
            show.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}", show);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAsync(showId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Title.Should().Be("Game of Thrones");
            responseValue.Year.Should().Be(2011);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(1390U);
            responseValue.Ids.Slug.Should().Be("game-of-thrones");
            responseValue.Ids.Tvdb.Should().Be(121361U);
            responseValue.Ids.Imdb.Should().Be("tt0944947");
            responseValue.Ids.Tmdb.Should().Be(1399U);
            responseValue.Ids.TvRage.Should().Be(24493U);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWithExtendedInfo()
        {
            var show = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowSummaryFull.json");
            show.Should().NotBeNullOrEmpty();

            var showId = "1390";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}?extended={extendedInfo.ToString()}", show);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAsync(showId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Title.Should().Be("Game of Thrones");
            responseValue.Year.Should().Be(2011);
            responseValue.Airs.Should().NotBeNull();
            responseValue.Airs.Day.Should().Be("Sunday");
            responseValue.Airs.Time.Should().Be("21:00");
            responseValue.Airs.TimeZoneId.Should().Be("America/New_York");
            responseValue.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(1390U);
            responseValue.Ids.Slug.Should().Be("game-of-thrones");
            responseValue.Ids.Tvdb.Should().Be(121361U);
            responseValue.Ids.Imdb.Should().Be("tt0944947");
            responseValue.Ids.Tmdb.Should().Be(1399U);
            responseValue.Ids.TvRage.Should().Be(24493U);
            responseValue.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            responseValue.Seasons.Should().BeNull();
            responseValue.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            responseValue.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            responseValue.Runtime.Should().Be(60);
            responseValue.Certification.Should().Be("TV-MA");
            responseValue.Network.Should().Be("HBO");
            responseValue.CountryCode.Should().Be("us");
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            responseValue.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            responseValue.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            responseValue.Status.Should().Be(TraktShowStatus.ReturningSeries);
            responseValue.Rating.Should().Be(9.38327f);
            responseValue.Votes.Should().Be(44773);
            responseValue.LanguageCode.Should().Be("en");
            responseValue.AiredEpisodes.Should().Be(50);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAsync(showId);
            act.Should().Throw<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowArgumentExceptions()
        {
            var show = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowSummaryFull.json");
            show.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}", show);

            Func<Task<TraktResponse<ITraktShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAsync("show id");
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MultipleShows

        [TestMethod]
        public void TestTraktShowsModuleGetShowsArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktResponse<ITraktShow>>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetMultipleShowsAsync(null);
            act.Should().NotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetMultipleShowsAsync(
                new TraktMultipleObjectsQueryParams());
            act.Should().NotThrow();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetMultipleShowsAsync(
                new TraktMultipleObjectsQueryParams { { null } });
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetMultipleShowsAsync(
                new TraktMultipleObjectsQueryParams { { string.Empty } });
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetMultipleShowsAsync(
                new TraktMultipleObjectsQueryParams { { "show id" } });
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowAliases

        [TestMethod]
        public void TestTraktShowsModuleGetShowAliases()
        {
            var showAliases = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowAliases.json");
            showAliases.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/aliases", showAliases);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAliasesAsync(showId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(8);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowAliasesExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/aliases";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktShowAlias>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAliasesAsync(showId);
            act.Should().Throw<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowAliasesArgumentExceptions()
        {
            var showAliases = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowAliases.json");
            showAliases.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/aliases", showAliases);

            Func<Task<TraktListResponse<ITraktShowAlias>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAliasesAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAliasesAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowAliasesAsync("show id");
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowTranslations

        [TestMethod]
        public void TestTraktShowsModuleGetShowTranslations()
        {
            var showTranslations = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowTranslations.json");
            showTranslations.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/translations", showTranslations);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowTranslationsAsync(showId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowTranslationsExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/translations";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktShowTranslation>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowTranslationsAsync(showId);
            act.Should().Throw<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowTranslationsArgumentExceptions()
        {
            var showTranslations = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowTranslations.json");
            showTranslations.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/translations", showTranslations);

            Func<Task<TraktListResponse<ITraktShowTranslation>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowTranslationsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowTranslationsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowTranslationsAsync("show id");
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowSingleTranslation

        [TestMethod]
        public void TestTraktShowsModuleGetShowSingleTranslation()
        {
            var showTranslations = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowTranslations.json");
            showTranslations.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var languageCode = "en";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/translations/{languageCode}", showTranslations);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowTranslationsAsync(showId, languageCode).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowSingleTranslationExceptions()
        {
            var showId = "1390";
            var languageCode = "en";
            var uri = $"shows/{showId}/translations/{languageCode}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktShowTranslation>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowTranslationsAsync(showId, languageCode);
            act.Should().Throw<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowSingleTranslationArgumentExceptions()
        {
            var showTranslations = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowTranslations.json");
            showTranslations.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var languageCode = "en";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/translations/{languageCode}", showTranslations);

            Func<Task<TraktListResponse<ITraktShowTranslation>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowTranslationsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowTranslationsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowTranslationsAsync("show id");
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowTranslationsAsync(showId, "eng");
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowTranslationsAsync(showId, "e");
            act.Should().Throw<ArgumentOutOfRangeException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowComments

        [TestMethod]
        public void TestTraktShowsModuleGetShowComments()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments",
                                                                showComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId).Result;

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
        public void TestTraktShowsModuleGetShowCommentsWithSortOrder()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            var sortOrder = TraktCommentSortOrder.Likes;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments/{sortOrder.UriName}",
                                                                showComments, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId, sortOrder).Result;

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
        public void TestTraktShowsModuleGetShowCommentsWithPage()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments?page={page}",
                                                                showComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowCommentsWithSortOrderAndPage()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var sortOrder = TraktCommentSortOrder.Likes;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments/{sortOrder.UriName}?page={page}",
                                                                showComments, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId, sortOrder, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowCommentsWithLimit()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments?limit={limit}",
                                                                showComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowCommentsWithSortOrderAndLimit()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var sortOrder = TraktCommentSortOrder.Likes;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments/{sortOrder.UriName}?limit={limit}",
                                                                showComments, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId, sortOrder, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowCommentsWithPageAndLimit()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments?page={page}&limit={limit}",
                                                                showComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowCommentsComplete()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var sortOrder = TraktCommentSortOrder.Likes;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments/{sortOrder.UriName}?page={page}&limit={limit}",
                                                                showComments, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId, sortOrder, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowCommentsExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/comments";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(showId);
            act.Should().Throw<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCommentsArgumentExceptions()
        {
            var showComments = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowComments.json");
            showComments.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/comments", showComments);

            Func<Task<TraktPagedResponse<ITraktComment>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCommentsAsync("show id");
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowLists

        [TestMethod]
        public void TestTraktShowsModuleGetShowLists()
        {
            var showLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowLists.json");
            showLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 10;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/lists", showLists, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowListsAsync(showId).Result;

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
        public void TestTraktShowsModuleGetShowListsWithType()
        {
            var showLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowLists.json");
            showLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 10;
            var type = TraktListType.Official;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/lists/{type.UriName}",
                                                                showLists, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowListsAsync(showId, type).Result;

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
        public void TestTraktShowsModuleGetShowListsWithSortOrderAndWithoutType()
        {
            var showLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowLists.json");
            showLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 10;
            var sortOrder = TraktListSortOrder.Comments;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/lists",
                                                                showLists, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowListsAsync(showId, null, sortOrder).Result;

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
        public void TestTraktShowsModuleGetShowListsWithPage()
        {
            var showLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowLists.json");
            showLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 10;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/lists?page={page}",
                                                                showLists, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowListsAsync(showId, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowListsWithLimit()
        {
            var showLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowLists.json");
            showLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 10;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/lists?limit={limit}",
                                                                showLists, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowListsAsync(showId, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowListsWithPageAndLimit()
        {
            var showLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowLists.json");
            showLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 10;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/lists?page={page}&limit={limit}",
                                                                showLists, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowListsAsync(showId, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowListsWithTypeAndSortOrder()
        {
            var showLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowLists.json");
            showLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/lists/{type.UriName}/{sortOrder.UriName}",
                                                                showLists, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowListsAsync(showId, type, sortOrder).Result;

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
        public void TestTraktShowsModuleGetShowListsWithTypeAndPage()
        {
            var showLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowLists.json");
            showLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 10;
            var type = TraktListType.Official;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/lists/{type.UriName}?page={page}",
                                                                showLists, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowListsAsync(showId, type, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowListsWithTypeAndLimit()
        {
            var showLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowLists.json");
            showLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 10;
            var type = TraktListType.Official;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/lists/{type.UriName}?limit={limit}",
                                                                showLists, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowListsAsync(showId, type, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowListsWithTypeAndPageAndLimit()
        {
            var showLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowLists.json");
            showLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 10;
            var type = TraktListType.Official;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/lists/{type.UriName}?page={page}&limit={limit}",
                                                                showLists, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowListsAsync(showId, type, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowListsWithTypeAndSortOrderAndPage()
        {
            var showLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowLists.json");
            showLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/lists/{type.UriName}/{sortOrder.UriName}?page={page}",
                                                                showLists, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowListsAsync(showId, type, sortOrder, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowListsWithTypeAndSortOrderAndLimit()
        {
            var showLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowLists.json");
            showLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/{showId}/lists/{type.UriName}/{sortOrder.UriName}?limit={limit}",
                showLists, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowListsAsync(showId, type, sortOrder, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowListsComplete()
        {
            var showLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowLists.json");
            showLists.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 10;
            var type = TraktListType.Official;
            var sortOrder = TraktListSortOrder.Comments;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/lists/{type.UriName}/{sortOrder.UriName}" +
                                                                $"?page={page}&limit={limit}",
                                                                showLists, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowListsAsync(showId, type, sortOrder, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowListsExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/lists";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowListsAsync(showId);
            act.Should().Throw<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowListsArgumentsExceptions()
        {
            var showLists = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowLists.json");
            showLists.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/lists", showLists);

            Func<Task<TraktPagedResponse<ITraktList>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowListsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowListsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowListsAsync("show id");
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowPeople

        [TestMethod]
        public void TestTraktShowsModuleGetShowPeople()
        {
            var showPeople = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowPeople.json");
            showPeople.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/people", showPeople);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowPeopleAsync(showId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Cast.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Should().NotBeNull();
            responseValue.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Art.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Crew.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.CostumeAndMakeup.Should().BeNull();
            responseValue.Crew.Directing.Should().BeNull();
            responseValue.Crew.Writing.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Sound.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Camera.Should().BeNull();
            responseValue.Crew.Lighting.Should().BeNull();
            responseValue.Crew.VisualEffects.Should().BeNull();
            responseValue.Crew.Editing.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowPeopleWithExtendedInfo()
        {
            var showPeople = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowPeople.json");
            showPeople.Should().NotBeNullOrEmpty();

            var showId = "1390";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/people?extended={extendedInfo.ToString()}", showPeople);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowPeopleAsync(showId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Cast.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Should().NotBeNull();
            responseValue.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Art.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Crew.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.CostumeAndMakeup.Should().BeNull();
            responseValue.Crew.Directing.Should().BeNull();
            responseValue.Crew.Writing.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Sound.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Camera.Should().BeNull();
            responseValue.Crew.Lighting.Should().BeNull();
            responseValue.Crew.VisualEffects.Should().BeNull();
            responseValue.Crew.Editing.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowPeopleExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/people";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktCastAndCrew>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowPeopleAsync(showId);
            act.Should().Throw<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowPeopleArgumentExceptions()
        {
            var showPeople = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowPeople.json");
            showPeople.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/people", showPeople);

            Func<Task<TraktResponse<ITraktCastAndCrew>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowPeopleAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowPeopleAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowPeopleAsync("show id");
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowRatings

        [TestMethod]
        public void TestTraktShowsModuleGetShowRatings()
        {
            var showRatings = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRatings.json");
            showRatings.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/ratings", showRatings);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRatingsAsync(showId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Rating.Should().Be(9.38231f);
            responseValue.Votes.Should().Be(44590);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  258 }, { "2", 57 }, { "3", 59 }, { "4", 116 }, { "5", 262 },
                { "6",  448 }, { "7", 1427 }, { "8", 3893 }, { "9", 8467 }, { "10", 29590 }
            };

            responseValue.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRatingsExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/ratings";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktRating>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRatingsAsync(showId);
            act.Should().Throw<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRatingsArgumentExceptions()
        {
            var showRatings = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRatings.json");
            showRatings.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/ratings", showRatings);

            Func<Task<TraktResponse<ITraktRating>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRatingsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRatingsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRatingsAsync("show id");
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowRelatedShows

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShows()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFull.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related", showRelatedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId).Result;

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
        public void TestTraktShowsModuleGetShowRelatedShowsWithExtendedInfo()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFull.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related?extended={extendedInfo.ToString()}",
                                                                showRelatedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId, extendedInfo).Result;

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
        public void TestTraktShowsModuleGetShowRelatedShowsWithPage()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFull.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related?page={page}", showRelatedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowRelatedShowsWithExtendedInfoAndPage()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFull.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related?extended={extendedInfo.ToString()}&page={page}",
                                                                showRelatedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId, extendedInfo, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowRelatedShowsWithLimit()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFull.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related?limit={limit}", showRelatedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowRelatedShowsWithExtendedInfoAndLimit()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFull.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related?extended={extendedInfo.ToString()}&limit={limit}",
                                                                showRelatedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId, extendedInfo, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowRelatedShowsWithPageAndLimit()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFull.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related?page={page}&limit={limit}",
                                                                showRelatedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowRelatedShowsComplete()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFull.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                showRelatedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId, extendedInfo, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetShowRelatedShowsExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/related";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(showId);
            act.Should().Throw<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowRelatedShowsArgumentExceptions()
        {
            var showRelatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowRelatedShowsFull.json");
            showRelatedShows.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/{showId}/related", showRelatedShows);

            Func<Task<TraktPagedResponse<ITraktShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowRelatedShowsAsync("show id");
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowStatistics

        [TestMethod]
        public void TestTraktShowsModuleGetShowStatistics()
        {
            var showStatistics = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowStatistics.json");
            showStatistics.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/stats", showStatistics);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowStatisticsAsync(showId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Watchers.Should().Be(265955);
            responseValue.Plays.Should().Be(12491168);
            responseValue.Collectors.Should().Be(106028);
            responseValue.CollectedEpisodes.Should().Be(4092901);
            responseValue.Comments.Should().Be(233);
            responseValue.Lists.Should().Be(103943);
            responseValue.Votes.Should().Be(44590);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowStatisticsExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/stats";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktStatistics>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowStatisticsAsync(showId);
            act.Should().Throw<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowStatisticsArgumentExceptions()
        {
            var showStatistics = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowStatistics.json");
            showStatistics.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/stats", showStatistics);

            Func<Task<TraktResponse<ITraktStatistics>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowStatisticsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowStatisticsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowStatisticsAsync("show id");
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowWatchingUsers

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchingUsers()
        {
            var showWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchingUsers.json");
            showWatchingUsers.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/watching", showWatchingUsers);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchingUsersAsync(showId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchingUsersWithExtendedInfo()
        {
            var showWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchingUsers.json");
            showWatchingUsers.Should().NotBeNullOrEmpty();

            var showId = "1390";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/watching?extended={extendedInfo.ToString()}", showWatchingUsers);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchingUsersAsync(showId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchingUsersExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/watching";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktListResponse<ITraktUser>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchingUsersAsync(showId);
            act.Should().Throw<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchingUsersArgumentExceptions()
        {
            var showWatchingUsers = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchingUsers.json");
            showWatchingUsers.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/watching", showWatchingUsers);

            Func<Task<TraktListResponse<ITraktUser>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchingUsersAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchingUsersAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchingUsersAsync("show id");
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowCollectionProgress

        [TestMethod]
        public void TestTraktShowsModuleGetShowCollectionProgress()
        {
            var showCollectionProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowCollectionProgressComplete.json");
            showCollectionProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithOAuth($"shows/{showId}/progress/collection", showCollectionProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCollectionProgressAsync(showId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            var seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCollectionProgressWithHidden()
        {
            var showCollectionProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowCollectionProgressComplete.json");
            showCollectionProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var hidden = true;

            TestUtility.SetupMockResponseWithOAuth($"shows/{showId}/progress/collection?hidden={hidden.ToString().ToLower()}",
                                                   showCollectionProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCollectionProgressAsync(showId, hidden).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            var seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCollectionProgressWithHiddenAndSpecials()
        {
            var showCollectionProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowCollectionProgressComplete.json");
            showCollectionProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var hidden = true;
            var specials = true;

            TestUtility.SetupMockResponseWithOAuth(
                $"shows/{showId}/progress/collection?hidden={hidden.ToString().ToLower()}&specials={specials.ToString().ToLower()}",
                showCollectionProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCollectionProgressAsync(showId, hidden, specials).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            var seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCollectionProgressWithHiddenAndCountSpecials()
        {
            var showCollectionProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowCollectionProgressComplete.json");
            showCollectionProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var hidden = true;
            var countSpecials = true;

            TestUtility.SetupMockResponseWithOAuth(
                $"shows/{showId}/progress/collection?hidden={hidden.ToString().ToLower()}&count_specials={countSpecials.ToString().ToLower()}",
                showCollectionProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCollectionProgressAsync(showId, hidden, null, countSpecials).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            var seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCollectionProgressWithSpecials()
        {
            var showCollectionProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowCollectionProgressComplete.json");
            showCollectionProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var specials = true;

            TestUtility.SetupMockResponseWithOAuth($"shows/{showId}/progress/collection?specials={specials.ToString().ToLower()}",
                                                   showCollectionProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCollectionProgressAsync(showId, null, specials).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            var seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCollectionProgressWithSpecialsAndCountSpecials()
        {
            var showCollectionProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowCollectionProgressComplete.json");
            showCollectionProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var specials = true;
            var countSpecials = true;

            TestUtility.SetupMockResponseWithOAuth(
                $"shows/{showId}/progress/collection?specials={specials.ToString().ToLower()}&count_specials={countSpecials.ToString().ToLower()}",
                showCollectionProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCollectionProgressAsync(showId, null, specials, countSpecials).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            var seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCollectionProgressWithCountSpecials()
        {
            var showCollectionProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowCollectionProgressComplete.json");
            showCollectionProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var countSpecials = true;

            TestUtility.SetupMockResponseWithOAuth($"shows/{showId}/progress/collection?count_specials={countSpecials.ToString().ToLower()}",
                                                   showCollectionProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCollectionProgressAsync(showId, null, null, countSpecials).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            var seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCollectionProgressComplete()
        {
            var showCollectionProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowCollectionProgressComplete.json");
            showCollectionProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var hidden = true;
            var specials = true;
            var countSpecials = true;

            TestUtility.SetupMockResponseWithOAuth(
                $"shows/{showId}/progress/collection?hidden={hidden.ToString().ToLower()}" +
                $"&specials={specials.ToString().ToLower()}&count_specials={countSpecials.ToString().ToLower()}",
                showCollectionProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCollectionProgressAsync(showId, hidden, specials, countSpecials).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastCollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            var seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].CollectedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCollectionProgressExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/progress/collection";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCollectionProgressAsync(showId);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowCollectionProgressArgumentExceptions()
        {
            var showCollectionProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowCollectionProgressComplete.json");
            showCollectionProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithOAuth($"shows/{showId}/progress/collection", showCollectionProgress);

            Func<Task<TraktResponse<ITraktShowCollectionProgress>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCollectionProgressAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCollectionProgressAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowCollectionProgressAsync("show id");
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region ShowWatchedProgress

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchedProgress()
        {
            var showWatchedProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchedProgressComplete.json");
            showWatchedProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithOAuth($"shows/{showId}/progress/watched", showWatchedProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchedProgressAsync(showId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            var seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchedProgressWithHidden()
        {
            var showWatchedProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchedProgressComplete.json");
            showWatchedProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var hidden = true;

            TestUtility.SetupMockResponseWithOAuth($"shows/{showId}/progress/watched?hidden={hidden.ToString().ToLower()}",
                                                   showWatchedProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchedProgressAsync(showId, hidden).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            var seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchedProgressWithHiddenAndSpecials()
        {
            var showWatchedProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchedProgressComplete.json");
            showWatchedProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var hidden = true;
            var specials = true;

            TestUtility.SetupMockResponseWithOAuth(
                $"shows/{showId}/progress/watched?hidden={hidden.ToString().ToLower()}&specials={specials.ToString().ToLower()}",
                showWatchedProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchedProgressAsync(showId, hidden, specials).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            var seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchedProgressWithHiddenAndCountSpecials()
        {
            var showWatchedProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchedProgressComplete.json");
            showWatchedProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var hidden = true;
            var countSpecials = true;

            TestUtility.SetupMockResponseWithOAuth(
                $"shows/{showId}/progress/watched?hidden={hidden.ToString().ToLower()}&count_specials={countSpecials.ToString().ToLower()}",
                showWatchedProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchedProgressAsync(showId, hidden, null, countSpecials).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            var seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchedProgressWithSpecials()
        {
            var showWatchedProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchedProgressComplete.json");
            showWatchedProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var specials = true;

            TestUtility.SetupMockResponseWithOAuth($"shows/{showId}/progress/watched?specials={specials.ToString().ToLower()}",
                                                   showWatchedProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchedProgressAsync(showId, null, specials).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            var seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchedProgressWithSpecialsAndCountSpecials()
        {
            var showWatchedProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchedProgressComplete.json");
            showWatchedProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var specials = true;
            var countSpecials = true;

            TestUtility.SetupMockResponseWithOAuth(
                $"shows/{showId}/progress/watched?specials={specials.ToString().ToLower()}&count_specials={countSpecials.ToString().ToLower()}",
                showWatchedProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchedProgressAsync(showId, null, specials, countSpecials).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            var seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchedProgressWithCountSpecials()
        {
            var showWatchedProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchedProgressComplete.json");
            showWatchedProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var countSpecials = true;

            TestUtility.SetupMockResponseWithOAuth($"shows/{showId}/progress/watched?count_specials={countSpecials.ToString().ToLower()}",
                                                   showWatchedProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchedProgressAsync(showId, null, null, countSpecials).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            var seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchedProgressComplete()
        {
            var showWatchedProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchedProgressComplete.json");
            showWatchedProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";
            var hidden = true;
            var specials = true;
            var countSpecials = true;

            TestUtility.SetupMockResponseWithOAuth(
                $"shows/{showId}/progress/watched?hidden={hidden.ToString().ToLower()}" +
                $"&specials={specials.ToString().ToLower()}&count_specials={countSpecials.ToString().ToLower()}",
                showWatchedProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchedProgressAsync(showId, hidden, specials, countSpecials).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Aired.Should().Be(6);
            responseValue.Completed.Should().Be(6);
            responseValue.LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());
            responseValue.Seasons.Should().NotBeNull();
            responseValue.Seasons.Should().HaveCount(1);

            var seasons = responseValue.Seasons.ToArray();

            seasons[0].Number.Should().Be(1);
            seasons[0].Aired.Should().Be(6);
            seasons[0].Completed.Should().Be(6);
            seasons[0].Episodes.Should().NotBeNull();
            seasons[0].Episodes.Should().HaveCount(6);

            var episodes = seasons[0].Episodes.ToArray();

            episodes[0].Number.Should().Be(1);
            episodes[0].Completed.Should().BeTrue();
            episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[1].Number.Should().Be(2);
            episodes[1].Completed.Should().BeTrue();
            episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[2].Number.Should().Be(3);
            episodes[2].Completed.Should().BeTrue();
            episodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[3].Number.Should().Be(4);
            episodes[3].Completed.Should().BeTrue();
            episodes[3].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[4].Number.Should().Be(5);
            episodes[4].Completed.Should().BeTrue();
            episodes[4].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            episodes[5].Number.Should().Be(6);
            episodes[5].Completed.Should().BeTrue();
            episodes[5].LastWatchedAt.Should().Be(DateTime.Parse("2015-03-21T19:03:58.000Z").ToUniversalTime());

            responseValue.HiddenSeasons.Should().NotBeNull();
            responseValue.HiddenSeasons.Should().HaveCount(1);

            var hiddenSeasons = responseValue.HiddenSeasons.ToArray();

            hiddenSeasons[0].Number.Should().Be(2);
            hiddenSeasons[0].Ids.Should().NotBeNull();
            hiddenSeasons[0].Ids.Trakt.Should().Be(3051U);
            hiddenSeasons[0].Ids.Tvdb.Should().Be(498968U);
            hiddenSeasons[0].Ids.Tmdb.Should().Be(53334U);
            hiddenSeasons[0].Ids.TvRage.Should().BeNull();

            responseValue.NextEpisode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchedProgressExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/progress/watched";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktResponse<ITraktShowWatchedProgress>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchedProgressAsync(showId);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowWatchedProgressArgumentExceptions()
        {
            var showWatchedProgress = TestUtility.ReadFileContents(@"Objects\Get\Shows\ShowWatchedProgressComplete.json");
            showWatchedProgress.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithOAuth($"shows/{showId}/progress/watched", showWatchedProgress);

            Func<Task<TraktResponse<ITraktShowWatchedProgress>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchedProgressAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchedProgressAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowWatchedProgressAsync("show id");
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region NextEpisode

        [TestMethod]
        public void TestTraktShowsModuleGetShowNextEpisode()
        {
            var episode = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeSummaryMinimal.json");
            episode.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/next_episode", episode);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowNextEpisodeAsync(showId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Title.Should().Be("Winter Is Coming");
            responseValue.SeasonNumber.Should().Be(1);
            responseValue.Number.Should().Be(1);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(73640U);
            responseValue.Ids.Tvdb.Should().Be(3254641U);
            responseValue.Ids.Imdb.Should().Be("tt1480055");
            responseValue.Ids.Tmdb.Should().Be(63056U);
            responseValue.Ids.TvRage.Should().Be(1065008299U);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowNextEpisodeWithExtendedInfo()
        {
            var episode = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeSummaryFull.json");
            episode.Should().NotBeNullOrEmpty();

            var showId = "1390";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/next_episode?extended={extendedInfo.ToString()}", episode);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowNextEpisodeAsync(showId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Title.Should().Be("Winter Is Coming");
            responseValue.SeasonNumber.Should().Be(1);
            responseValue.Number.Should().Be(1);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(73640U);
            responseValue.Ids.Tvdb.Should().Be(3254641U);
            responseValue.Ids.Imdb.Should().Be("tt1480055");
            responseValue.Ids.Tmdb.Should().Be(63056U);
            responseValue.Ids.TvRage.Should().Be(1065008299U);
            responseValue.NumberAbsolute.Should().Be(50);
            responseValue.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            responseValue.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            responseValue.Rating.Should().Be(9.0f);
            responseValue.Votes.Should().Be(111);
            responseValue.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowNextEpisodeExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/next_episode";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktEpisode>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowNextEpisodeAsync(showId);
            act.Should().Throw<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowNextEpisodeArgumentExceptions()
        {
            var show = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeSummaryMinimal.json");
            show.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/next_episode", show);

            Func<Task<TraktResponse<ITraktEpisode>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowNextEpisodeAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowNextEpisodeAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowNextEpisodeAsync("show id");
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region LastEpisode

        [TestMethod]
        public void TestTraktShowsModuleGetShowLastEpisode()
        {
            var episode = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeSummaryMinimal.json");
            episode.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/last_episode", episode);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowLastEpisodeAsync(showId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Title.Should().Be("Winter Is Coming");
            responseValue.SeasonNumber.Should().Be(1);
            responseValue.Number.Should().Be(1);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(73640U);
            responseValue.Ids.Tvdb.Should().Be(3254641U);
            responseValue.Ids.Imdb.Should().Be("tt1480055");
            responseValue.Ids.Tmdb.Should().Be(63056U);
            responseValue.Ids.TvRage.Should().Be(1065008299U);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowLastEpisodeWithExtendedInfo()
        {
            var episode = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeSummaryFull.json");
            episode.Should().NotBeNullOrEmpty();

            var showId = "1390";

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/last_episode?extended={extendedInfo.ToString()}", episode);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowLastEpisodeAsync(showId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Title.Should().Be("Winter Is Coming");
            responseValue.SeasonNumber.Should().Be(1);
            responseValue.Number.Should().Be(1);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(73640U);
            responseValue.Ids.Tvdb.Should().Be(3254641U);
            responseValue.Ids.Imdb.Should().Be("tt1480055");
            responseValue.Ids.Tmdb.Should().Be(63056U);
            responseValue.Ids.TvRage.Should().Be(1065008299U);
            responseValue.NumberAbsolute.Should().Be(50);
            responseValue.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            responseValue.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            responseValue.Rating.Should().Be(9.0f);
            responseValue.Votes.Should().Be(111);
            responseValue.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(1);
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowLastEpisodeExceptions()
        {
            var showId = "1390";
            var uri = $"shows/{showId}/last_episode";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktEpisode>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowLastEpisodeAsync(showId);
            act.Should().Throw<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktShowsModuleGetShowLastEpisodeArgumentExceptions()
        {
            var show = TestUtility.ReadFileContents(@"Objects\Get\Shows\Episodes\EpisodeSummaryMinimal.json");
            show.Should().NotBeNullOrEmpty();

            var showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/last_episode", show);

            Func<Task<TraktResponse<ITraktEpisode>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowLastEpisodeAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowLastEpisodeAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowLastEpisodeAsync("show id");
            act.Should().Throw<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region TrendingShows

        [TestMethod]
        public void TestTraktShowsModuleGetTrendingShows()
        {
            var showsTrending = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsTrending.json");
            showsTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending", showsTrending, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync().Result;

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
        public void TestTraktShowsModuleGetTrendingShowsFiltered()
        {
            var showsTrending = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsTrending.json");
            showsTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?{filter.ToString()}",
                                                                showsTrending, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(null, filter).Result;

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
        public void TestTraktShowsModuleGetTrendingShowsWithExtendedInfo()
        {
            var showsTrending = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsTrending.json");
            showsTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?extended={extendedInfo.ToString()}",
                                                                showsTrending, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(extendedInfo).Result;

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
        public void TestTraktShowsModuleGetTrendingShowsWithExtendedInfoFiltered()
        {
            var showsTrending = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsTrending.json");
            showsTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/trending?extended={extendedInfo.ToString()}&{filter.ToString()}",
                showsTrending, 1, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(extendedInfo, filter).Result;

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
        public void TestTraktShowsModuleGetTrendingShowsWithPage()
        {
            var showsTrending = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsTrending.json");
            showsTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?page={page}", showsTrending, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetTrendingShowsWithPageFiltered()
        {
            var showsTrending = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsTrending.json");
            showsTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?{filter.ToString()}&page={page}",
                                                                showsTrending, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetTrendingShowsWithExtendedInfoAndPage()
        {
            var showsTrending = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsTrending.json");
            showsTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?extended={extendedInfo.ToString()}&page={page}",
                                                                showsTrending, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetTrendingShowsWithExtendedInfoAndPageFiltered()
        {
            var showsTrending = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsTrending.json");
            showsTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/trending?extended={extendedInfo.ToString()}&page={page}&{filter.ToString()}",
                showsTrending, page, 10, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetTrendingShowsWithLimit()
        {
            var showsTrending = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsTrending.json");
            showsTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?limit={limit}", showsTrending, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetTrendingShowsWithLimitFiltered()
        {
            var showsTrending = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsTrending.json");
            showsTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?limit={limit}&{filter.ToString()}",
                                                                showsTrending, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetTrendingShowsWithExtendedInfoAndLimit()
        {
            var showsTrending = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsTrending.json");
            showsTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?extended={extendedInfo.ToString()}&limit={limit}",
                                                                showsTrending, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetTrendingShowsWithExtendedInfoAndLimitFiltered()
        {
            var showsTrending = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsTrending.json");
            showsTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/trending?extended={extendedInfo.ToString()}&{filter.ToString()}&limit={limit}",
                showsTrending, 1, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetTrendingShowsWithPageAndLimit()
        {
            var showsTrending = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsTrending.json");
            showsTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?page={page}&limit={limit}",
                                                                showsTrending, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetTrendingShowsWithPageAndLimitFiltered()
        {
            var showsTrending = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsTrending.json");
            showsTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?page={page}&limit={limit}&{filter.ToString()}",
                                                                showsTrending, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetTrendingShowsComplete()
        {
            var showsTrending = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsTrending.json");
            showsTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/trending?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                showsTrending, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetTrendingShowsCompleteFiltered()
        {
            var showsTrending = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsTrending.json");
            showsTrending.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var userCount = 300;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("trending show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/trending?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                showsTrending, page, limit, 1, itemCount, userCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync(extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetTrendingShowsExceptions()
        {
            var uri = $"shows/trending";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktTrendingShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetTrendingShowsAsync();
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PopularShows

        [TestMethod]
        public void TestTraktShowsModuleGetPopularShows()
        {
            var popularShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsPopular.json");
            popularShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/popular", popularShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetPopularShowsAsync().Result;

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
        public void TestTraktShowsModuleGetPopularShowsFiltered()
        {
            var popularShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsPopular.json");
            popularShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/popular?{filter.ToString()}",
                                                                popularShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetPopularShowsAsync(null, filter).Result;

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
        public void TestTraktShowsModuleGetPopularShowsWithExtendedInfo()
        {
            var popularShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsPopular.json");
            popularShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/popular?extended={extendedInfo.ToString()}",
                                                                popularShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetPopularShowsAsync(extendedInfo).Result;

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
        public void TestTraktShowsModuleGetPopularShowsWithExtendedInfoFiltered()
        {
            var popularShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsPopular.json");
            popularShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/popular?extended={extendedInfo.ToString()}&{filter.ToString()}",
                popularShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetPopularShowsAsync(extendedInfo, filter).Result;

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
        public void TestTraktShowsModuleGetPopularShowsWithPage()
        {
            var popularShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsPopular.json");
            popularShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/popular?page={page}", popularShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetPopularShowsAsync(null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetPopularShowsWithPageFiltered()
        {
            var popularShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsPopular.json");
            popularShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/popular?{filter.ToString()}&page={page}",
                                                                popularShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetPopularShowsAsync(null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetPopularShowsWithExtendedInfoAndPage()
        {
            var popularShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsPopular.json");
            popularShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/popular?extended={extendedInfo.ToString()}&page={page}",
                                                                popularShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetPopularShowsAsync(extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetPopularShowsWithExtendedInfoAndPageFiltered()
        {
            var popularShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsPopular.json");
            popularShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/popular?extended={extendedInfo.ToString()}&page={page}&{filter.ToString()}",
                popularShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetPopularShowsAsync(extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetPopularShowsWithLimit()
        {
            var popularShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsPopular.json");
            popularShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/popular?limit={limit}", popularShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetPopularShowsAsync(null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetPopularShowsWithLimitFiltered()
        {
            var popularShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsPopular.json");
            popularShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/popular?limit={limit}&{filter.ToString()}",
                                                                popularShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetPopularShowsAsync(null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetPopularShowsWithExtendedInfoAndLimit()
        {
            var popularShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsPopular.json");
            popularShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/popular?extended={extendedInfo.ToString()}&limit={limit}",
                                                                popularShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetPopularShowsAsync(extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetPopularShowsWithExtendedInfoAndLimitFiltered()
        {
            var popularShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsPopular.json");
            popularShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/popular?extended={extendedInfo.ToString()}&{filter.ToString()}&limit={limit}",
                popularShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetPopularShowsAsync(extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetPopularShowsWithPageAndLimit()
        {
            var popularShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsPopular.json");
            popularShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/popular?page={page}&limit={limit}", popularShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetPopularShowsAsync(null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetPopularShowsWithPageAndLimitFiltered()
        {
            var popularShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsPopular.json");
            popularShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/popular?page={page}&limit={limit}&{filter.ToString()}",
                                                                popularShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetPopularShowsAsync(null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetPopularShowsComplete()
        {
            var popularShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsPopular.json");
            popularShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/popular?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                popularShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetPopularShowsAsync(extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetPopularShowsCompleteFiltered()
        {
            var popularShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsPopular.json");
            popularShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("popular show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/popular?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                popularShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetPopularShowsAsync(extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetPopularShowsExceptions()
        {
            var uri = $"shows/popular";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetPopularShowsAsync();
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MostPlayedShows

        [TestMethod]
        public void TestTraktShowsModuleGetMostPlayedShows()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played", mostPlayedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync().Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsFiltered()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?{filter.ToString()}",
                                                                mostPlayedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, null, filter).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithPeriod()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played/{period.UriName}",
                                                                mostPlayedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithPeriodFiltered()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played/{period.UriName}?{filter.ToString()}",
                                                                mostPlayedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, null, filter).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithExtendedInfo()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?extended={extendedInfo.ToString()}",
                                                                mostPlayedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, extendedInfo).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithExtendedInfoFiltered()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/played?extended={extendedInfo.ToString()}&{filter.ToString()}",
                mostPlayedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, extendedInfo, filter).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithPage()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?page={page}", mostPlayedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithPageFiltered()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?page={page}&{filter.ToString()}",
                                                                mostPlayedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithLimit()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?limit={limit}", mostPlayedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithLimitFiltered()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?limit={limit}&{filter.ToString()}",
                                                                mostPlayedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithPeriodAndExtendedOption()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played/{period.UriName}?extended={extendedInfo.ToString()}",
                                                                mostPlayedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, extendedInfo).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithPeriodAndExtendedOptionFiltered()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/played/{period.UriName}?extended={extendedInfo.ToString()}&{filter.ToString()}",
                mostPlayedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, extendedInfo, filter).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithPeriodAndPage()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played/{period.UriName}?page={page}",
                                                                mostPlayedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithPeriodAndPageFiltered()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played/{period.UriName}?{filter.ToString()}&page={page}",
                                                                mostPlayedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithPeriodAndLimit()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played/{period.UriName}?limit={limit}",
                                                                mostPlayedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithPeriodAndLimitFiltered()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played/{period.UriName}?limit={limit}&{filter.ToString()}",
                                                                mostPlayedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithExtendedInfoAndPage()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?extended={extendedInfo.ToString()}&page={page}",
                                                                mostPlayedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithExtendedInfoAndPageFiltered()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/played?extended={extendedInfo.ToString()}&{filter.ToString()}&page={page}",
                mostPlayedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithExtendedInfoAndLimit()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?extended={extendedInfo.ToString()}&limit={limit}",
                                                                mostPlayedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithExtendedInfoAndLimitFiltered()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/played?extended={extendedInfo.ToString()}&limit={limit}&{filter.ToString()}",
                mostPlayedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithPageAndLimit()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?page={page}&limit={limit}",
                                                                mostPlayedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithPageAndLimitFiltered()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?page={page}&limit={limit}&{filter.ToString()}",
                                                                mostPlayedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithExtendedInfoAndPageAndLimit()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                mostPlayedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithExtendedInfoAndPageAndLimitFiltered()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/played?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                mostPlayedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithPeriodAndPageAndLimit()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/played/{period.UriName}?page={page}&limit={limit}",
                                                                mostPlayedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsWithPeriodAndPageAndLimitFiltered()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/played/{period.UriName}?page={page}&{filter.ToString()}&limit={limit}",
                mostPlayedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsComplete()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/played/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                mostPlayedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsCompleteFiltered()
        {
            var mostPlayedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostPlayed.json");
            mostPlayedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most played show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/played/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                mostPlayedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync(period, extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostPlayedShowsExceptions()
        {
            var uri = $"shows/played";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktMostPWCShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetMostPlayedShowsAsync();
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MostWatchedShows

        [TestMethod]
        public void TestTraktShowsModuleGetMostWatchedShows()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched", mostWatchedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync().Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsFiltered()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched?{filter.ToString()}",
                                                                mostWatchedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(null, null, filter).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithPeriod()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched/{period.UriName}",
                                                                mostWatchedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(period).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithPeriodFiltered()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched/{period.UriName}?{filter.ToString()}",
                                                                mostWatchedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(period, null, filter).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithExtendedInfo()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched?extended={extendedInfo.ToString()}",
                                                                mostWatchedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(null, extendedInfo).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithExtendedInfoFiltered()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/watched?extended={extendedInfo.ToString()}&{filter.ToString()}",
                mostWatchedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(null, extendedInfo, filter).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithPage()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched?page={page}", mostWatchedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(null, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithPageFiltered()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched?page={page}&{filter.ToString()}",
                                                                mostWatchedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(null, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithLimit()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched?limit={limit}", mostWatchedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(null, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithLimitFiltered()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched?limit={limit}&{filter.ToString()}",
                                                                mostWatchedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(null, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithPeriodAndExtendedOption()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched/{period.UriName}?extended={extendedInfo.ToString()}",
                                                                mostWatchedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(period, extendedInfo).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithPeriodAndExtendedOptionFiltered()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/watched/{period.UriName}?extended={extendedInfo.ToString()}&{filter.ToString()}",
                mostWatchedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(period, extendedInfo, filter).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithPeriodAndPage()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched/{period.UriName}?page={page}",
                                                                mostWatchedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(period, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithPeriodAndPageFiltered()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched/{period.UriName}?page={page}&{filter.ToString()}",
                                                                mostWatchedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(period, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithPeriodAndLimit()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched/{period.UriName}?limit={limit}",
                                                                mostWatchedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(period, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithPeriodAndLimitFiltered()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched/{period.UriName}?limit={limit}&{filter.ToString()}",
                                                                mostWatchedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(period, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithExtendedInfoAndPage()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched?extended={extendedInfo.ToString()}&page={page}",
                                                                mostWatchedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithExtendedInfoAndPageFiltered()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/watched?extended={extendedInfo.ToString()}&{filter.ToString()}&page={page}",
                mostWatchedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithExtendedInfoAndLimit()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched?extended={extendedInfo.ToString()}&limit={limit}",
                                                                mostWatchedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithExtendedInfoAndLimitFiltered()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/watched?extended={extendedInfo.ToString()}&limit={limit}&{filter.ToString()}",
                mostWatchedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithPageAndLimit()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched?page={page}&limit={limit}",
                                                                mostWatchedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(null, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithPageAndLimitFiltered()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/watched?page={page}&limit={limit}&{filter.ToString()}",
                mostWatchedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(null, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithExtendedInfoAndPageAndLimit()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                mostWatchedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithExtendedInfoAndPageAndLimitFiltered()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/watched?extended={extendedInfo.ToString()}&page={page}&{filter.ToString()}&limit={limit}",
                mostWatchedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithPeriodAndPageAndLimit()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/watched/{period.UriName}?page={page}&limit={limit}",
                                                                mostWatchedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(period, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsWithPeriodAndPageAndLimitFiltered()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/watched/{period.UriName}?page={page}&limit={limit}&{filter.ToString()}",
                mostWatchedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(period, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsComplete()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/watched/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                mostWatchedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(period, extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsCompleteFiltered()
        {
            var mostWatchedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostWatched.json");
            mostWatchedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most watched show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/watched/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                mostWatchedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync(period, extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostWatchedShowsExceptions()
        {
            var uri = $"shows/watched";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktMostPWCShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetMostWatchedShowsAsync();
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MostCollectedShows

        [TestMethod]
        public void TestTraktShowsModuleGetMostCollectedShows()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected", mostCollectedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync().Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsFiltered()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected?{filter.ToString()}",
                                                                mostCollectedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(null, null, filter).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithPeriod()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected/{period.UriName}",
                                                                mostCollectedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(period).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithPeriodFiltered()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected/{period.UriName}?{filter.ToString()}",
                                                                mostCollectedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(period, null, filter).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithExtendedInfo()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected?extended={extendedInfo.ToString()}",
                                                                mostCollectedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(null, extendedInfo).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithExtendedInfoFiltered()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/collected?extended={extendedInfo.ToString()}&{filter.ToString()}",
                mostCollectedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(null, extendedInfo, filter).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithPage()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected?page={page}", mostCollectedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(null, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithPageFiltered()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected?page={page}&{filter.ToString()}",
                                                                mostCollectedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(null, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithLimit()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected?limit={limit}", mostCollectedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(null, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithLimitFiltered()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected?limit={limit}&{filter.ToString()}",
                                                                mostCollectedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(null, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithPeriodAndExtendedOption()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected/{period.UriName}?extended={extendedInfo.ToString()}",
                                                                mostCollectedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(period, extendedInfo).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithPeriodAndExtendedOptionFiltered()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/collected/{period.UriName}?extended={extendedInfo.ToString()}&{filter.ToString()}",
                mostCollectedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(period, extendedInfo, filter).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithPeriodAndPage()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected/{period.UriName}?page={page}",
                                                                mostCollectedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(period, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithPeriodAndPageFiltered()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected/{period.UriName}?page={page}&{filter.ToString()}",
                                                                mostCollectedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(period, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithPeriodAndLimit()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected/{period.UriName}?limit={limit}",
                                                                mostCollectedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(period, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithPeriodAndLimitFiltered()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected/{period.UriName}?{filter.ToString()}&limit={limit}",
                                                                mostCollectedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(period, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithExtendedInfoAndPage()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected?extended={extendedInfo.ToString()}&page={page}",
                                                                mostCollectedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithExtendedInfoAndPageFiltered()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/collected?extended={extendedInfo.ToString()}&{filter.ToString()}&page={page}",
                mostCollectedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithExtendedInfoAndLimit()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected?extended={extendedInfo.ToString()}&limit={limit}",
                                                                mostCollectedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithExtendedInfoAndLimitFiltered()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/collected?extended={extendedInfo.ToString()}&limit={limit}&{filter.ToString()}",
                mostCollectedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithPageAndLimit()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected?page={page}&limit={limit}",
                                                                mostCollectedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(null, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithPageAndLimitFiltered()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/collected?page={page}&limit={limit}&{filter.ToString()}",
                mostCollectedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(null, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithExtendedInfoAndPageAndLimit()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                mostCollectedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(null, extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithExtendedInfoAndPageAndLimitFiltered()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/collected?extended={extendedInfo.ToString()}&page={page}&{filter.ToString()}&limit={limit}",
                mostCollectedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(null, extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithPeriodAndPageAndLimit()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var period = TraktTimePeriod.Monthly;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/collected/{period.UriName}?page={page}&limit={limit}",
                                                                mostCollectedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(period, null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsWithPeriodAndPageAndLimitFiltered()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var period = TraktTimePeriod.Monthly;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/collected/{period.UriName}?page={page}&limit={limit}&{filter.ToString()}",
                mostCollectedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(period, null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsComplete()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/collected/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                mostCollectedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(period, extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsCompleteFiltered()
        {
            var mostCollectedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostCollected.json");
            mostCollectedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var period = TraktTimePeriod.Monthly;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most collected show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/collected/{period.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                mostCollectedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync(period, extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostCollectedShowsExceptions()
        {
            var uri = $"shows/collected";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktMostPWCShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetMostCollectedShowsAsync();
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region MostAnticipatedShows

        [TestMethod]
        public void TestTraktShowsModuleGetMostAnticipatedShows()
        {
            var mostAnticipatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostAnticipated.json");
            mostAnticipatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/anticipated", mostAnticipatedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostAnticipatedShowsAsync().Result;

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
        public void TestTraktShowsModuleGetMostAnticipatedShowsFiltered()
        {
            var mostAnticipatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostAnticipated.json");
            mostAnticipatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/anticipated?{filter.ToString()}",
                                                                mostAnticipatedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostAnticipatedShowsAsync(null, filter).Result;

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
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithExtendedInfo()
        {
            var mostAnticipatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostAnticipated.json");
            mostAnticipatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/anticipated?extended={extendedInfo.ToString()}",
                                                                mostAnticipatedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostAnticipatedShowsAsync(extendedInfo).Result;

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
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithExtendedInfoFiltered()
        {
            var mostAnticipatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostAnticipated.json");
            mostAnticipatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/anticipated?extended={extendedInfo.ToString()}&{filter.ToString()}",
                mostAnticipatedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostAnticipatedShowsAsync(extendedInfo, filter).Result;

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
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithPage()
        {
            var mostAnticipatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostAnticipated.json");
            mostAnticipatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/anticipated?page={page}", mostAnticipatedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostAnticipatedShowsAsync(null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithPageFiltered()
        {
            var mostAnticipatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostAnticipated.json");
            mostAnticipatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/anticipated?page={page}&{filter.ToString()}",
                                                                mostAnticipatedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostAnticipatedShowsAsync(null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithExtendedInfoAndPage()
        {
            var mostAnticipatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostAnticipated.json");
            mostAnticipatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/anticipated?extended={extendedInfo.ToString()}&page={page}",
                                                                mostAnticipatedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostAnticipatedShowsAsync(extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithExtendedInfoAndPageFiltered()
        {
            var mostAnticipatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostAnticipated.json");
            mostAnticipatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/anticipated?extended={extendedInfo.ToString()}&{filter.ToString()}&page={page}",
                mostAnticipatedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostAnticipatedShowsAsync(extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithLimit()
        {
            var mostAnticipatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostAnticipated.json");
            mostAnticipatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/anticipated?limit={limit}", mostAnticipatedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostAnticipatedShowsAsync(null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithLimitFiltered()
        {
            var mostAnticipatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostAnticipated.json");
            mostAnticipatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/anticipated?limit={limit}&{filter.ToString()}",
                                                                mostAnticipatedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostAnticipatedShowsAsync(null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithExtendedInfoAndLimit()
        {
            var mostAnticipatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostAnticipated.json");
            mostAnticipatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/anticipated?extended={extendedInfo.ToString()}&limit={limit}",
                                                                mostAnticipatedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostAnticipatedShowsAsync(extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithExtendedInfoAndLimitFiltered()
        {
            var mostAnticipatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostAnticipated.json");
            mostAnticipatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/anticipated?extended={extendedInfo.ToString()}&{filter.ToString()}&limit={limit}",
                mostAnticipatedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostAnticipatedShowsAsync(extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithPageAndLimit()
        {
            var mostAnticipatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostAnticipated.json");
            mostAnticipatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/anticipated?page={page}&limit={limit}",
                                                                mostAnticipatedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostAnticipatedShowsAsync(null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostAnticipatedShowsWithPageAndLimitFiltered()
        {
            var mostAnticipatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostAnticipated.json");
            mostAnticipatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/anticipated?page={page}&limit={limit}&{filter.ToString()}",
                mostAnticipatedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostAnticipatedShowsAsync(null, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostAnticipatedShowsComplete()
        {
            var mostAnticipatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostAnticipated.json");
            mostAnticipatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/anticipated?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                mostAnticipatedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostAnticipatedShowsAsync(extendedInfo, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostAnticipatedShowsCompleteFiltered()
        {
            var mostAnticipatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsMostAnticipated.json");
            mostAnticipatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktShowFilter()
                .WithCertifications("TV-MA")
                .WithQuery("most anticipated show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95)
                .WithNetworks("HBO", "Showtime")
                .WithStates(TraktShowStatus.ReturningSeries, TraktShowStatus.InProduction);

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/anticipated?extended={extendedInfo.ToString()}&page={page}&limit={limit}&{filter.ToString()}",
                mostAnticipatedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetMostAnticipatedShowsAsync(extendedInfo, filter, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetMostAnticipatedShowsExceptions()
        {
            var uri = $"shows/anticipated";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktMostAnticipatedShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetMostAnticipatedShowsAsync();
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RecentlyUpdatedShows

        [TestMethod]
        public void TestTraktShowsModuleGetRecentlyUpdatedShowss()
        {
            var recentlyUpdatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsRecentlyUpdated.json");
            recentlyUpdatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/updates", recentlyUpdatedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetRecentlyUpdatedShowsAsync().Result;

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
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithStartDate()
        {
            var recentlyUpdatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsRecentlyUpdated.json");
            recentlyUpdatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var today = DateTime.UtcNow;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/updates/{today.ToTraktDateString()}",
                                                                recentlyUpdatedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetRecentlyUpdatedShowsAsync(today).Result;

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
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithExtendedInfo()
        {
            var recentlyUpdatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsRecentlyUpdated.json");
            recentlyUpdatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/updates?extended={extendedInfo.ToString()}",
                                                                recentlyUpdatedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetRecentlyUpdatedShowsAsync(null, extendedInfo).Result;

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
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithPage()
        {
            var recentlyUpdatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsRecentlyUpdated.json");
            recentlyUpdatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/updates?page={page}", recentlyUpdatedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetRecentlyUpdatedShowsAsync(null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithLimit()
        {
            var recentlyUpdatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsRecentlyUpdated.json");
            recentlyUpdatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/updates?limit={limit}", recentlyUpdatedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetRecentlyUpdatedShowsAsync(null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithStartDateAndExtendedOption()
        {
            var recentlyUpdatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsRecentlyUpdated.json");
            recentlyUpdatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            var today = DateTime.UtcNow;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/updates/{today.ToTraktDateString()}?extended={extendedInfo.ToString()}",
                recentlyUpdatedShows, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetRecentlyUpdatedShowsAsync(today, extendedInfo).Result;

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
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithStartDateAndPage()
        {
            var recentlyUpdatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsRecentlyUpdated.json");
            recentlyUpdatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);
            var today = DateTime.UtcNow;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/updates/{today.ToTraktDateString()}?page={page}",
                                                                recentlyUpdatedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetRecentlyUpdatedShowsAsync(today, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithStartDateAndLimit()
        {
            var recentlyUpdatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsRecentlyUpdated.json");
            recentlyUpdatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);
            var today = DateTime.UtcNow;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/updates/{today.ToTraktDateString()}?limit={limit}",
                                                                recentlyUpdatedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetRecentlyUpdatedShowsAsync(today, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithExtendedInfoAndPage()
        {
            var recentlyUpdatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsRecentlyUpdated.json");
            recentlyUpdatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            var pagedParameters = new TraktPagedParameters(page);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/updates?extended={extendedInfo.ToString()}&page={page}",
                                                                recentlyUpdatedShows, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetRecentlyUpdatedShowsAsync(null, extendedInfo, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithExtendedInfoAndLimit()
        {
            var recentlyUpdatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsRecentlyUpdated.json");
            recentlyUpdatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(null, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/updates?extended={extendedInfo.ToString()}&limit={limit}",
                                                                recentlyUpdatedShows, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetRecentlyUpdatedShowsAsync(null, extendedInfo, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithPageAndLimit()
        {
            var recentlyUpdatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsRecentlyUpdated.json");
            recentlyUpdatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/updates?page={page}&limit={limit}",
                                                                recentlyUpdatedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetRecentlyUpdatedShowsAsync(null, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithExtendedInfoAndPageAndLimit()
        {
            var recentlyUpdatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsRecentlyUpdated.json");
            recentlyUpdatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/updates?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                                recentlyUpdatedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetRecentlyUpdatedShowsAsync(null, extendedInfo, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsWithStartDateAndPageAndLimit()
        {
            var recentlyUpdatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsRecentlyUpdated.json");
            recentlyUpdatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var today = DateTime.UtcNow;

            TestUtility.SetupMockPaginationResponseWithoutOAuth($"shows/updates/{today.ToTraktDateString()}?page={page}&limit={limit}",
                                                                recentlyUpdatedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetRecentlyUpdatedShowsAsync(today, null, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsComplete()
        {
            var recentlyUpdatedShows = TestUtility.ReadFileContents(@"Objects\Get\Shows\Common\ShowsRecentlyUpdated.json");
            recentlyUpdatedShows.Should().NotBeNullOrEmpty();

            var itemCount = 2;
            uint page = 2;
            uint limit = 4;
            var pagedParameters = new TraktPagedParameters(page, limit);
            var today = DateTime.UtcNow;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockPaginationResponseWithoutOAuth(
                $"shows/updates/{today.ToTraktDateString()}?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                recentlyUpdatedShows, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetRecentlyUpdatedShowsAsync(today, extendedInfo, pagedParameters).Result;

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
        public void TestTraktShowsModuleGetRecentlyUpdatedShowsExceptions()
        {
            var uri = $"shows/updates";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktPagedResponse<ITraktRecentlyUpdatedShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetRecentlyUpdatedShowsAsync();
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        #endregion
    }
}
