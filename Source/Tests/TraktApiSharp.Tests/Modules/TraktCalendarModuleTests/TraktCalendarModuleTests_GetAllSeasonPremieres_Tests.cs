namespace TraktApiSharp.Tests.Modules.TraktCalendarModuleTests
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
    public partial class TraktCalendarModuleTests_Tests
    {
        [Fact]
        public void Test_TraktCalendarModule_GetAllSeasonPremieres()
        {
            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                "calendars/all/shows/premieres",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync().Result;

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
        public void Test_TraktCalendarModule_GetAllSeasonPremieresFiltered()
        {
            var filter = new TraktCalendarFilter()
                .WithQuery("calendar season premiere")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/premieres?{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, null, null, filter).Result;

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
        public void Test_TraktCalendarModule_GetAllSeasonPremieresWithStartDate()
        {
            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today).Result;

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
        public void Test_TraktCalendarModule_GetAllSeasonPremieresWithStartDateFiltered()
        {
            var today = DateTime.UtcNow;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar season premiere")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}?{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today, null, null, filter).Result;

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
        public void Test_TraktCalendarModule_GetAllSeasonPremieresWithDays()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}/{days}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, days).Result;

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
        public void Test_TraktCalendarModule_GetAllSeasonPremieresWithDaysFiltered()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar season premiere")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}/{days}?{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, days, null, filter).Result;

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
        public void Test_TraktCalendarModule_GetAllSeasonPremieresWithStartDateAndDays()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}/{days}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today, days).Result;

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
        public void Test_TraktCalendarModule_GetAllSeasonPremieresWithStartDateAndDaysFiltered()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar season premiere")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}/{days}?{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today, days, null, filter).Result;

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
        public void Test_TraktCalendarModule_GetAllSeasonPremieresWithExtendedInfo()
        {
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/premieres?extended={extendedInfo}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, null, extendedInfo).Result;

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
        public void Test_TraktCalendarModule_GetAllSeasonPremieresWithExtendedInfoFiltered()
        {
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar season premiere")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/premieres?extended={extendedInfo}&{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, null, extendedInfo, filter).Result;

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
        public void Test_TraktCalendarModule_GetAllSeasonPremieresWithExtendedInfoAndStartDate()
        {
            var today = DateTime.UtcNow;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}?extended={extendedInfo}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today, null, extendedInfo).Result;

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
        public void Test_TraktCalendarModule_GetAllSeasonPremieresWithExtendedInfoAndStartDateFiltered()
        {
            var today = DateTime.UtcNow;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar season premiere")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}" +
                $"?extended={extendedInfo}&{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today, null, extendedInfo, filter).Result;

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
        public void Test_TraktCalendarModule_GetAllSeasonPremieresWithExtendedInfoAndDays()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}/{days}?extended={extendedInfo}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, days, extendedInfo).Result;

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
        public void Test_TraktCalendarModule_GetAllSeasonPremieresWithExtendedInfoAndDaysFiltered()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar season premiere")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}/{days}?extended={extendedInfo}&{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, days, extendedInfo, filter).Result;

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
        public void Test_TraktCalendarModule_GetAllSeasonPremieresWithExtendedInfoAndStartDateAndDays()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}/{days}?extended={extendedInfo}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today, days, extendedInfo).Result;

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
        public void Test_TraktCalendarModule_GetAllSeasonPremieresWithExtendedInfoAndStartDateAndDaysFiltered()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar season premiere")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithoutOAuthWithHeaders(
                $"calendars/all/shows/premieres/{today.ToTraktDateString()}/{days}" +
                $"?extended={extendedInfo}&{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(today, days, extendedInfo, filter).Result;

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
        public void Test_TraktCalendarModule_GetAllSeasonPremieresExceptions()
        {
            const string uri = "calendars/all/shows/premieres";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);

            Func<Task<TraktListResponse<ITraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync();
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
        public void Test_TraktCalendarModule_GetAllSeasonPremieresArgumentExceptions()
        {
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetAllSeasonPremieresAsync(null, 32);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
