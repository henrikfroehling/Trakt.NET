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
        public void Test_TraktCalendarModule_GetAllMovies()
        {
            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                "calendars/all/movies",
                CALENDAR_ALL_MOVIES_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync().Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllMoviesFiltered()
        {
            var filter = new TraktCalendarFilter()
                .WithQuery("calendar movie")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/movies?{filter}",
                CALENDAR_ALL_MOVIES_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, null, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllMoviesWithStartDate()
        {
            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/movies/{today.ToTraktDateString()}",
                CALENDAR_ALL_MOVIES_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllMoviesWithStartDateFiltered()
        {
            var today = DateTime.UtcNow;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar movie")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/movies/{today.ToTraktDateString()}?{filter}",
                CALENDAR_ALL_MOVIES_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today, null, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllMoviesWithDays()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/movies/{today.ToTraktDateString()}/{days}",
                CALENDAR_ALL_MOVIES_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, days).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllMoviesWithDaysFiltered()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar movie")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/movies/{today.ToTraktDateString()}/{days}?{filter}",
                CALENDAR_ALL_MOVIES_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, days, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllMoviesWithStartDateAndDays()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/movies/{today.ToTraktDateString()}/{days}",
                CALENDAR_ALL_MOVIES_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today, days).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllMoviesWithStartDateAndDaysFiltered()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar movie")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/movies/{today.ToTraktDateString()}/{days}?{filter}",
                CALENDAR_ALL_MOVIES_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today, days, null, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllMoviesWithExtendedInfo()
        {
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/movies?extended={extendedInfo}",
                CALENDAR_ALL_MOVIES_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllMoviesWithExtendedInfoFiltered()
        {
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar movie")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/movies?extended={extendedInfo}&{filter}",
                CALENDAR_ALL_MOVIES_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, null, extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllMoviesWithExtendedInfoAndStartDate()
        {
            var today = DateTime.UtcNow;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/movies/{today.ToTraktDateString()}?extended={extendedInfo}",
                CALENDAR_ALL_MOVIES_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today, null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllMoviesWithExtendedInfoAndStartDateFiltered()
        {
            var today = DateTime.UtcNow;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar movie")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/movies/{today.ToTraktDateString()}" +
                $"?extended={extendedInfo}&{filter}",
                CALENDAR_ALL_MOVIES_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today, null, extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllMoviesWithExtendedInfoAndDays()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/movies/{today.ToTraktDateString()}/{days}?extended={extendedInfo}",
                CALENDAR_ALL_MOVIES_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, days, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllMoviesWithExtendedInfoAndDaysFiltered()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar movie")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/movies/{today.ToTraktDateString()}/{days}?extended={extendedInfo}&{filter}",
                CALENDAR_ALL_MOVIES_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, days, extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllMoviesWithExtendedInfoAndStartDateAndDays()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/movies/{today.ToTraktDateString()}/{days}?extended={extendedInfo}",
                CALENDAR_ALL_MOVIES_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today, days, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllMoviesWithExtendedInfoAndStartDateAndDaysFiltered()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar movie")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/movies/{today.ToTraktDateString()}/{days}" +
                $"?extended={extendedInfo}&{filter}",
                CALENDAR_ALL_MOVIES_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(today, days, extendedInfo, filter).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(DT_START_DATE).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(DT_END_DATE).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllMoviesExceptions()
        {
            const string uri = "calendars/all/movies";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync();
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
        public void Test_TraktCalendarModule_GetAllMoviesArgumentExceptions()
        {
            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllMoviesAsync(null, 32);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
