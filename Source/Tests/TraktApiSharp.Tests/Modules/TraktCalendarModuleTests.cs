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
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests;
    using Utils;

    [TestClass]
    public class TraktCalendarModuleTests
    {
        [TestMethod]
        public void TestTraktCalendarModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktCalendarModule)).Should().BeTrue();
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

        #region AllShows

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShows()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithoutOAuth("calendars/all/shows", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithStartDate()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/{today.ToString("yyyy-MM-dd")}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var days = 14;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/{days}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithStartDateAndDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/{today.ToString("yyyy-MM-dd")}/{days}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithExtendedOption()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithExtendedOptionAndStartDate()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/{today.ToString("yyyy-MM-dd")}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithExtendedOptionAndDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/{days}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, days, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithExtendedOptionAndStartDateAndDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/{today.ToString("yyyy-MM-dd")}/{days}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today, days, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsExceptions()
        {
            var uri = $"calendars/all/shows";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<TraktListResult<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AllNewShows

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShows()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithoutOAuth("calendars/all/shows/new", calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithStartDate()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/new/{today.ToString("yyyy-MM-dd")}", calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(today).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithDays()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var days = 14;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/new/{days}", calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(null, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithStartDateAndDays()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/new/{today.ToString("yyyy-MM-dd")}/{days}", calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(today, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithExtendedOption()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/new?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithExtendedOptionAndStartDate()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/new/{today.ToString("yyyy-MM-dd")}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(today, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithExtendedOptionAndDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/new/{days}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(null, days, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithExtendedOptionAndStartDateAndDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/new/{today.ToString("yyyy-MM-dd")}/{days}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(today, days, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsExceptions()
        {
            var uri = $"calendars/all/shows/new";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<TraktListResult<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AllSeasonPremieres

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieres()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithoutOAuth("calendars/all/shows/premieres", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithStartDate()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/premieres/{today.ToString("yyyy-MM-dd")}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithDays()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var days = 14;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/premieres/{days}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithStartDateAndDays()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/premieres/{today.ToString("yyyy-MM-dd")}/{days}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithExtendedOption()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/premieres?extended={extendedOption.ToString()}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithExtendedOptionAndStartDate()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/premieres/{today.ToString("yyyy-MM-dd")}?extended={extendedOption.ToString()}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithExtendedOptionAndDays()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/premieres/{days}?extended={extendedOption.ToString()}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, days, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithExtendedOptionAndStartDateAndDays()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/premieres/{today.ToString("yyyy-MM-dd")}/{days}?extended={extendedOption.ToString()}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today, days, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresExceptions()
        {
            var uri = $"calendars/all/shows/premieres";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<TraktListResult<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AllMovies

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMovies()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithoutOAuth("calendars/all/movies", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithStartDate()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/movies/{today.ToString("yyyy-MM-dd")}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithDays()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var days = 14;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/movies/{days}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithStartDateAndDays()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/movies/{today.ToString("yyyy-MM-dd")}/{days}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithExtendedOption()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/movies?extended={extendedOption.ToString()}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithExtendedOptionAndStartDate()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/movies/{today.ToString("yyyy-MM-dd")}?extended={extendedOption.ToString()}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithExtendedOptionAndDays()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/movies/{days}?extended={extendedOption.ToString()}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, days, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithExtendedOptionAndStartDateAndDays()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/movies/{today.ToString("yyyy-MM-dd")}/{days}?extended={extendedOption.ToString()}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today, days, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesExceptions()
        {
            var uri = $"calendars/all/movies";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<TraktListResult<TraktCalendarMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserShows

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShows()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("calendars/my/shows", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithStartDate()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/{today.ToString("yyyy-MM-dd")}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(today).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var days = 14;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/{days}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(null, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithStartDateAndDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/{today.ToString("yyyy-MM-dd")}/{days}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(today, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithExtendedOption()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithExtendedOptionAndStartDate()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/{today.ToString("yyyy-MM-dd")}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(today, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithExtendedOptionAndDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/{days}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(null, days, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithExtendedOptionAndStartDateAndDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/{today.ToString("yyyy-MM-dd")}/{days}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(today, days, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsExceptions()
        {
            var uri = $"calendars/my/shows";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktListResult<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserNewShows

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShows()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("calendars/my/shows/new", calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithStartDate()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/new/{today.ToString("yyyy-MM-dd")}", calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(today).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithDays()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var days = 14;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/new/{days}", calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(null, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithStartDateAndDays()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/new/{today.ToString("yyyy-MM-dd")}/{days}", calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(today, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithExtendedOption()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/new?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithExtendedOptionAndStartDate()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/new/{today.ToString("yyyy-MM-dd")}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(today, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithExtendedOptionAndDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/new/{days}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(null, days, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithExtendedOptionAndStartDateAndDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/new/{today.ToString("yyyy-MM-dd")}/{days}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(today, days, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsExceptions()
        {
            var uri = $"calendars/my/shows/new";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktListResult<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserSeasonPremieres

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieres()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("calendars/my/shows/premieres", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithStartDate()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/premieres/{today.ToString("yyyy-MM-dd")}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithDays()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var days = 14;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/premieres/{days}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithStartDateAndDays()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/premieres/{today.ToString("yyyy-MM-dd")}/{days}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithExtendedOption()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/premieres?extended={extendedOption.ToString()}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithExtendedOptionAndStartDate()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/premieres/{today.ToString("yyyy-MM-dd")}?extended={extendedOption.ToString()}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithExtendedOptionAndDays()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/premieres/{days}?extended={extendedOption.ToString()}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, days, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithExtendedOptionAndStartDateAndDays()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/premieres/{today.ToString("yyyy-MM-dd")}/{days}?extended={extendedOption.ToString()}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today, days, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresExceptions()
        {
            var uri = $"calendars/my/shows/premieres";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktListResult<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region UserMovies

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMovies()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("calendars/my/movies", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithStartDate()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/movies/{today.ToString("yyyy-MM-dd")}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(today).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithDays()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var days = 14;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/movies/{days}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(null, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithStartDateAndDays()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/movies/{today.ToString("yyyy-MM-dd")}/{days}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(today, days).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithExtendedOption()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/movies?extended={extendedOption.ToString()}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithExtendedOptionAndStartDate()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/movies/{today.ToString("yyyy-MM-dd")}?extended={extendedOption.ToString()}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(today, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithExtendedOptionAndDays()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/movies/{days}?extended={extendedOption.ToString()}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(null, days, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithExtendedOptionAndStartDateAndDays()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/movies/{today.ToString("yyyy-MM-dd")}/{days}?extended={extendedOption.ToString()}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(today, days, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesExceptions()
        {
            var uri = $"calendars/my/movies";

            TestUtility.SetupMockErrorResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktListResult<TraktCalendarMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth(uri, (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync();
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion
    }
}
