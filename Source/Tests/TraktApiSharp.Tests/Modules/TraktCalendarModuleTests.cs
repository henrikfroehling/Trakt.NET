namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests.Params;
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

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows?{filter.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, null, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithStartDate()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/{today.ToTraktDateString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithStartDateFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/{today.ToTraktDateString()}?{filter.ToString()}",
                                                      calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today, null, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/{today.ToTraktDateString()}/{days}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, days).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithDaysFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/{today.ToTraktDateString()}/{days}?{filter.ToString()}",
                                                      calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, days, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithStartDateAndDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/{today.ToTraktDateString()}/{days}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today, days).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithStartDateAndDaysFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/{today.ToTraktDateString()}/{days}?{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today, days, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithExtendedOptionFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, null, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/{today.ToTraktDateString()}?extended={extendedOption.ToString()}",
                                                      calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today, null, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithExtendedOptionAndStartDateFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/{today.ToTraktDateString()}?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today, null, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithExtendedOptionAndDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, days, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithExtendedOptionAndDaysFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, days, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today, days, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsWithExtendedOptionAndStartDateAndDaysFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/{today.ToTraktDateString()}/{days}" +
                $"?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today, days, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllShowsExceptions()
        {
            var uri = $"calendars/all/shows";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<IEnumerable<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

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
        public void TestTraktCalendarModuleGetAllShowsArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, 32);
            act.ShouldThrow<ArgumentOutOfRangeException>();
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

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsFiltered()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar new show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/new?{filter.ToString()}", calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(null, null, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithStartDate()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/new/{today.ToTraktDateString()}", calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(today).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithStartDateFiltered()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar new show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/new/{today.ToTraktDateString()}?{filter.ToString()}",
                                                      calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(today, null, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithDays()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/new/{today.ToTraktDateString()}/{days}", calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(null, days).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithDaysFiltered()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar new show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/new/{today.ToTraktDateString()}/{days}?{filter.ToString()}",
                                                      calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(null, days, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithStartDateAndDays()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/new/{today.ToTraktDateString()}/{days}", calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(today, days).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithStartDateAndDaysFiltered()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar new show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/new/{today.ToTraktDateString()}/{days}?{filter.ToString()}",
                calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(today, days, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithExtendedOptionFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar new show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/new?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(null, null, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/new/{today.ToTraktDateString()}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(today, null, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithExtendedOptionAndStartDateFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar new show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/new/{today.ToTraktDateString()}" +
                $"?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(today, null, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithExtendedOptionAndDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/new/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(null, days, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithExtendedOptionAndDaysFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar new show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/new/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(null, days, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/new/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(today, days, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsWithExtendedOptionAndStartDateAndDaysFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar new show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/new/{today.ToTraktDateString()}/{days}" +
                $"?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(today, days, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllNewShowsExceptions()
        {
            var uri = $"calendars/all/shows/new";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<IEnumerable<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

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
        public void TestTraktCalendarModuleGetAllNewShowsArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(null, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllNewShowsAsync(null, 32);
            act.ShouldThrow<ArgumentOutOfRangeException>();
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

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresFiltered()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar season premiere")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/premieres?{filter.ToString()}",
                                                      calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, null, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithStartDate()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/premieres/{today.ToTraktDateString()}",
                                                      calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithStartDateFiltered()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar season premiere")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}?{filter.ToString()}",
                calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today, null, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithDays()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}/{days}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, days).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithDaysFiltered()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar season premiere")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}/{days}?{filter.ToString()}",
                calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, days, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithStartDateAndDays()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/premieres/{today.ToTraktDateString()}/{days}",
                                                      calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today, days).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithStartDateAndDaysFiltered()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar season premiere")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}/{days}?{filter.ToString()}",
                calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today, days, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithExtendedOption()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/premieres?extended={extendedOption.ToString()}",
                                                      calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, null, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithExtendedOptionFiltered()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar season premiere")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/premieres?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, null, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/premieres/{today.ToTraktDateString()}?extended={extendedOption.ToString()}",
                                                      calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today, null, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithExtendedOptionAndStartDateFiltered()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar season premiere")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}" +
                $"?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today, null, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithExtendedOptionAndDays()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}",
                calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, days, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithExtendedOptionAndDaysFiltered()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar season premiere")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, days, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/shows/premieres/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}",
                                                      calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today, days, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresWithExtendedOptionAndStartDateAndDaysFiltered()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar season premiere")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}/{days}" +
                $"?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today, days, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllSeasonPremieresExceptions()
        {
            var uri = $"calendars/all/shows/premieres";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<IEnumerable<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

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
        public void TestTraktCalendarModuleGetAllSeasonPremieresArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, 32);
            act.ShouldThrow<ArgumentOutOfRangeException>();
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

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesFiltered()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar movie")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/movies?{filter.ToString()}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, null, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithStartDate()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/movies/{today.ToTraktDateString()}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithStartDateFiltered()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar movie")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/movies/{today.ToTraktDateString()}?{filter.ToString()}",
                                                      calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today, null, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithDays()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/movies/{today.ToTraktDateString()}/{days}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, days).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithDaysFiltered()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar movie")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/movies/{today.ToTraktDateString()}/{days}?{filter.ToString()}",
                                                      calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, days, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithStartDateAndDays()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/movies/{today.ToTraktDateString()}/{days}",
                                                      calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today, days).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithStartDateAndDaysFiltered()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar movie")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/movies/{today.ToTraktDateString()}/{days}?{filter.ToString()}",
                calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today, days, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithExtendedOption()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/movies?extended={extendedOption.ToString()}",
                                                      calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, null, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithExtendedOptionFiltered()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar movie")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/movies?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, null, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(3);
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

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/movies/{today.ToTraktDateString()}?extended={extendedOption.ToString()}",
                                                      calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today, null, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithExtendedOptionAndStartDateFiltered()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar movie")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/movies/{today.ToTraktDateString()}" +
                $"?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today, null, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithExtendedOptionAndDays()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/movies/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}",
                calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, days, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithExtendedOptionAndDaysFiltered()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar movie")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/movies/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, days, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(3);
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

            TestUtility.SetupMockResponseWithoutOAuth($"calendars/all/movies/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}",
                                                      calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today, days, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesWithExtendedOptionAndStartDateAndDaysFiltered()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar movie")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuth(
                $"calendars/all/movies/{today.ToTraktDateString()}/{days}" +
                $"?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today, days, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetAllMoviesExceptions()
        {
            var uri = $"calendars/all/movies";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<IEnumerable<TraktCalendarMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

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
        public void TestTraktCalendarModuleGetAllMoviesArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktCalendarMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, 32);
            act.ShouldThrow<ArgumentOutOfRangeException>();
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

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows?{filter.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(null, null, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithStartDate()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/{today.ToTraktDateString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(today).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithStartDateFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/{today.ToTraktDateString()}?{filter.ToString()}",
                                                   calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(today, null, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/{today.ToTraktDateString()}/{days}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(null, days).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithDaysFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/{today.ToTraktDateString()}/{days}?{filter.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(null, days, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithStartDateAndDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/{today.ToTraktDateString()}/{days}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(today, days).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithStartDateAndDaysFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/{today.ToTraktDateString()}/{days}?{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(today, days, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithExtendedOptionFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(null, null, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/{today.ToTraktDateString()}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(today, null, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithExtendedOptionAndStartDateFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/{today.ToTraktDateString()}?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(today, null, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithExtendedOptionAndDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(null, days, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithExtendedOptionAndDaysFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(null, days, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(today, days, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsWithExtendedOptionAndStartDateAndDaysFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(today, days, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsExceptions()
        {
            var uri = $"calendars/my/shows";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<IEnumerable<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserShowsArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(null, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserShowsAsync(null, 32);
            act.ShouldThrow<ArgumentOutOfRangeException>();
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

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsFiltered()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user new show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/new?{filter.ToString()}", calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(null, null, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithStartDate()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/new/{today.ToTraktDateString()}", calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(today).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithStartDateFiltered()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user new show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/new/{today.ToTraktDateString()}?{filter.ToString()}",
                                                   calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(today, null, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithDays()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/new/{today.ToTraktDateString()}/{days}", calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(null, days).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithDaysFiltered()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user new show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/new/{today.ToTraktDateString()}/{days}?{filter.ToString()}", calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(null, days, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithStartDateAndDays()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/new/{today.ToTraktDateString()}/{days}", calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(today, days).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithStartDateAndDaysFiltered()
        {
            var calendarNewShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarNewShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user new show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/new/{today.ToTraktDateString()}/{days}?{filter.ToString()}",
                calendarNewShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(today, days, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithExtendedOptionFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user new show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/new?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(null, null, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/new/{today.ToTraktDateString()}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(today, null, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithExtendedOptionAndStartDateFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user new show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/new/{today.ToTraktDateString()}?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(today, null, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithExtendedOptionAndDays()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/new/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(null, days, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithExtendedOptionAndDaysFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user new show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/new/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(null, days, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/new/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}", calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(today, days, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsWithExtendedOptionAndStartDateAndDaysFiltered()
        {
            var calendarShowsJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarShowsJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user new show")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/new/{today.ToTraktDateString()}/{days}" +
                $"?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarShowsJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(today, days, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsExceptions()
        {
            var uri = $"calendars/my/shows/new";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<IEnumerable<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserNewShowsArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(null, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserNewShowsAsync(null, 32);
            act.ShouldThrow<ArgumentOutOfRangeException>();
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

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresFiltered()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user season premiere")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/premieres?{filter.ToString()}",
                                                   calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, null, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithStartDate()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/premieres/{today.ToTraktDateString()}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithStartDateFiltered()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user season premiere")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/premieres/{today.ToTraktDateString()}?{filter.ToString()}",
                                                   calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today, null, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithDays()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/premieres/{today.ToTraktDateString()}/{days}",
                                                   calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, days).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithDaysFiltered()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user season premiere")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/premieres/{today.ToTraktDateString()}/{days}?{filter.ToString()}",
                                                   calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, days, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithStartDateAndDays()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/premieres/{today.ToTraktDateString()}/{days}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today, days).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithStartDateAndDaysFiltered()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user season premiere")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/premieres/{today.ToTraktDateString()}/{days}?{filter.ToString()}",
                calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today, days, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithExtendedOptionFiltered()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user season premiere")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/premieres?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, null, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/premieres/{today.ToTraktDateString()}?extended={extendedOption.ToString()}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today, null, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithExtendedOptionAndStartDateFiltered()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user season premiere")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/premieres/{today.ToTraktDateString()}" +
                $"?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today, null, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithExtendedOptionAndDays()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/premieres/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, days, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithExtendedOptionAndDaysFiltered()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user season premiere")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/premieres/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, days, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
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

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/shows/premieres/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}", calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today, days, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresWithExtendedOptionAndStartDateAndDaysFiltered()
        {
            var calendarSeasonPremieresJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllShows.json");
            calendarSeasonPremieresJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user season premiere")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/shows/premieres/{today.ToTraktDateString()}/{days}" +
                $"?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarSeasonPremieresJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today, days, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresExceptions()
        {
            var uri = $"calendars/my/shows/premieres";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<IEnumerable<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserSeasonPremieresArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, 32);
            act.ShouldThrow<ArgumentOutOfRangeException>();
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

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesFiltered()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user movie")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/movies?{filter.ToString()}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(null, null, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithStartDate()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/movies/{today.ToTraktDateString()}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(today).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithStartDateFiltered()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user movie")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/movies/{today.ToTraktDateString()}?{filter.ToString()}",
                                                   calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(today, null, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithDays()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/movies/{today.ToTraktDateString()}/{days}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(null, days).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithDaysFiltered()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user movie")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/movies/{today.ToTraktDateString()}/{days}?{filter.ToString()}",
                                                   calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(null, days, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithStartDateAndDays()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/movies/{today.ToTraktDateString()}/{days}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(today, days).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithStartDateAndDaysFiltered()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user movie")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/movies/{today.ToTraktDateString()}/{days}?{filter.ToString()}",
                calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(today, days, null, filter).Result;

            response.Should().NotBeNull().And.HaveCount(3);
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

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithExtendedOptionFiltered()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user movie")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/movies?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(null, null, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(3);
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

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/movies/{today.ToTraktDateString()}?extended={extendedOption.ToString()}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(today, null, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithExtendedOptionAndStartDateFiltered()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user movie")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/movies/{today.ToTraktDateString()}" +
                $"?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(today, null, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithExtendedOptionAndDays()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/movies/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(null, days, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithExtendedOptionAndDaysFiltered()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user movie")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/movies/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(null, days, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(3);
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

            TestUtility.SetupMockResponseWithOAuth($"calendars/my/movies/{today.ToTraktDateString()}/{days}?extended={extendedOption.ToString()}", calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(today, days, extendedOption).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesWithExtendedOptionAndStartDateAndDaysFiltered()
        {
            var calendarMoviesJson = TestUtility.ReadFileContents(@"Objects\Get\Calendars\CalendarAllMovies.json");
            calendarMoviesJson.Should().NotBeNullOrEmpty();

            var today = DateTime.UtcNow;
            var days = 14;

            var extendedOption = new TraktExtendedOption();

            extendedOption.Full = true;
            extendedOption.Images = true;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user movie")
                .WithYears(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuth(
                $"calendars/my/movies/{today.ToTraktDateString()}/{days}" +
                $"?extended={extendedOption.ToString()}&{filter.ToString()}",
                calendarMoviesJson);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(today, days, extendedOption, filter).Result;

            response.Should().NotBeNull().And.HaveCount(3);
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesExceptions()
        {
            var uri = $"calendars/my/movies";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<IEnumerable<TraktCalendarMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktCalendarModuleGetUserMoviesArgumentExceptions()
        {
            Func<Task<IEnumerable<TraktCalendarMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(null, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserMoviesAsync(null, 32);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        #endregion
    }
}
