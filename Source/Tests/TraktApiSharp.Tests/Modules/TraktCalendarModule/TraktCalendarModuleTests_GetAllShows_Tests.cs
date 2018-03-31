namespace TraktApiSharp.Tests.Modules.TraktCalendarModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Calendar")]
    public partial class TraktCalendarModule_Tests
    {
        [Fact]
        public void Test_TraktCalendarModule_GetAllShows()
        {
            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                "calendars/all/shows", CALENDAR_ALL_SHOWS_JSON,
                START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync().Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllShowsFiltered()
        {
            var filter = new TraktCalendarFilter()
                .WithQuery("calendar show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows?{filter}", CALENDAR_ALL_SHOWS_JSON,
                START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, null, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllShowsWithStartDate()
        {
            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/{today.ToTraktDateString()}", CALENDAR_ALL_SHOWS_JSON,
                START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllShowsWithStartDateFiltered()
        {
            var today = DateTime.UtcNow;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/{today.ToTraktDateString()}?{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today, null, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllShowsWithDays()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/{today.ToTraktDateString()}/{days}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, days).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllShowsWithDaysFiltered()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/{today.ToTraktDateString()}/{days}?{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, days, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllShowsWithStartDateAndDays()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/{today.ToTraktDateString()}/{days}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today, days).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllShowsWithStartDateAndDaysFiltered()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/{today.ToTraktDateString()}/{days}?{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today, days, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllShowsWithExtendedInfo()
        {
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows?extended={extendedInfo}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllShowsWithExtendedInfoFiltered()
        {
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows?extended={extendedInfo}&{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, null, extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllShowsWithExtendedInfoAndStartDate()
        {
            var today = DateTime.UtcNow;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/{today.ToTraktDateString()}?extended={extendedInfo}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today, null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllShowsWithExtendedInfoAndStartDateFiltered()
        {
            var today = DateTime.UtcNow;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/{today.ToTraktDateString()}?extended={extendedInfo}&{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today, null, extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllShowsWithExtendedInfoAndDays()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/{today.ToTraktDateString()}/{days}?extended={extendedInfo}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, days, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllShowsWithExtendedInfoAndDaysFiltered()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/{today.ToTraktDateString()}/{days}?extended={extendedInfo}&{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, days, extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllShowsWithExtendedInfoAndStartDateAndDays()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/{today.ToTraktDateString()}/{days}?extended={extendedInfo}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today, days, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllShowsWithExtendedInfoAndStartDateAndDaysFiltered()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar show")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/{today.ToTraktDateString()}/{days}" +
                $"?extended={extendedInfo}&{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(today, days, extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllShowsExceptions()
        {
            const string uri = "calendars/all/shows";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<TraktListResponse<ITraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync();
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktNotFoundException>();

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

        [Fact]
        public void Test_TraktCalendarModule_GetAllShowsArgumentExceptions()
        {
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllShowsAsync(null, 32);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
