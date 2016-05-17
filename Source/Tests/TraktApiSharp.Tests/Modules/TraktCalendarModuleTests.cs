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
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows", HttpStatusCode.BadRequest);

            Func<Task<TraktListResult<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows", HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows", (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows", (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows", HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows", (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows", (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows", (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows", (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows", (HttpStatusCode)522);

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
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/new", HttpStatusCode.BadRequest);

            Func<Task<TraktListResult<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/new", HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/new", (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/new", (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/new", HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/new", (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/new", (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/new", (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/new", (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/new", (HttpStatusCode)522);

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
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/premieres", HttpStatusCode.BadRequest);

            Func<Task<TraktListResult<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/premieres", HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/premieres", (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/premieres", (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/premieres", HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/premieres", (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/premieres", (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/premieres", (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/premieres", (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/shows/premieres", (HttpStatusCode)522);

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
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/movies", HttpStatusCode.BadRequest);

            Func<Task<TraktListResult<TraktCalendarMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/movies", HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/movies", (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/movies", (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/movies", HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/movies", (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/movies", (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/movies", (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/movies", (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithoutOAuth($"calendars/all/movies", (HttpStatusCode)522);

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
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithExtendedOptionAndStartDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithExtendedOptionAndDays()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithExtendedOptionAndStartDateAndDays()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsExceptions()
        {
            Assert.Fail();
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
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithExtendedOptionAndStartDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithExtendedOptionAndDays()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithExtendedOptionAndStartDateAndDays()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsExceptions()
        {
            Assert.Fail();
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
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithExtendedOptionAndStartDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithExtendedOptionAndDays()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithExtendedOptionAndStartDateAndDays()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresExceptions()
        {
            Assert.Fail();
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
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithExtendedOptionAndStartDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithExtendedOptionAndDays()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithExtendedOptionAndStartDateAndDays()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
