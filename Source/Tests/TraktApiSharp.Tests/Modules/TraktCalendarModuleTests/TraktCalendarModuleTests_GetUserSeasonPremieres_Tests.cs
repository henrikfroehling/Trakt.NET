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
        public void Test_TraktCalendarModule_GetUserSeasonPremieres()
        {
            TestUtility.SetupMockResponseWithOAuthWithHeaders(
                "calendars/my/shows/premieres",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync().Result;

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
        public void Test_TraktCalendarModule_GetUserSeasonPremieresFiltered()
        {
            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user season premiere")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuthWithHeaders(
                $"calendars/my/shows/premieres?{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, null, null, filter).Result;

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
        public void Test_TraktCalendarModule_GetUserSeasonPremieresWithStartDate()
        {
            var today = DateTime.UtcNow;

            TestUtility.SetupMockResponseWithOAuthWithHeaders(
                $"calendars/my/shows/premieres/{today.ToTraktDateString()}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today).Result;

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
        public void Test_TraktCalendarModule_GetUserSeasonPremieresWithStartDateFiltered()
        {
            var today = DateTime.UtcNow;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user season premiere")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuthWithHeaders(
                $"calendars/my/shows/premieres/{today.ToTraktDateString()}?{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today, null, null, filter).Result;

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
        public void Test_TraktCalendarModule_GetUserSeasonPremieresWithDays()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            TestUtility.SetupMockResponseWithOAuthWithHeaders(
                $"calendars/my/shows/premieres/{today.ToTraktDateString()}/{days}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, days).Result;

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
        public void Test_TraktCalendarModule_GetUserSeasonPremieresWithDaysFiltered()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user season premiere")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuthWithHeaders(
                $"calendars/my/shows/premieres/{today.ToTraktDateString()}/{days}?{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, days, null, filter).Result;

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
        public void Test_TraktCalendarModule_GetUserSeasonPremieresWithStartDateAndDays()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            TestUtility.SetupMockResponseWithOAuthWithHeaders(
                $"calendars/my/shows/premieres/{today.ToTraktDateString()}/{days}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today, days).Result;

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
        public void Test_TraktCalendarModule_GetUserSeasonPremieresWithStartDateAndDaysFiltered()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user season premiere")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuthWithHeaders(
                $"calendars/my/shows/premieres/{today.ToTraktDateString()}/{days}?{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today, days, null, filter).Result;

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
        public void Test_TraktCalendarModule_GetUserSeasonPremieresWithExtendedInfo()
        {
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithOAuthWithHeaders(
                $"calendars/my/shows/premieres?extended={extendedInfo}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, null, extendedInfo).Result;

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
        public void Test_TraktCalendarModule_GetUserSeasonPremieresWithExtendedInfoFiltered()
        {
            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user season premiere")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuthWithHeaders(
                $"calendars/my/shows/premieres?extended={extendedInfo}&{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, null, extendedInfo, filter).Result;

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
        public void Test_TraktCalendarModule_GetUserSeasonPremieresWithExtendedInfoAndStartDate()
        {
            var today = DateTime.UtcNow;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithOAuthWithHeaders(
                $"calendars/my/shows/premieres/{today.ToTraktDateString()}?extended={extendedInfo}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today, null, extendedInfo).Result;

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
        public void Test_TraktCalendarModule_GetUserSeasonPremieresWithExtendedInfoAndStartDateFiltered()
        {
            var today = DateTime.UtcNow;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user season premiere")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuthWithHeaders(
                $"calendars/my/shows/premieres/{today.ToTraktDateString()}" +
                $"?extended={extendedInfo}&{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today, null, extendedInfo, filter).Result;

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
        public void Test_TraktCalendarModule_GetUserSeasonPremieresWithExtendedInfoAndDays()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithOAuthWithHeaders(
                $"calendars/my/shows/premieres/{today.ToTraktDateString()}/{days}?extended={extendedInfo}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, days, extendedInfo).Result;

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
        public void Test_TraktCalendarModule_GetUserSeasonPremieresWithExtendedInfoAndDaysFiltered()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user season premiere")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuthWithHeaders(
                $"calendars/my/shows/premieres/{today.ToTraktDateString()}/{days}?extended={extendedInfo}&{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, days, extendedInfo, filter).Result;

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
        public void Test_TraktCalendarModule_GetUserSeasonPremieresWithExtendedInfoAndStartDateAndDays()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithOAuthWithHeaders(
                $"calendars/my/shows/premieres/{today.ToTraktDateString()}/{days}?extended={extendedInfo}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today, days, extendedInfo).Result;

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
        public void Test_TraktCalendarModule_GetUserSeasonPremieresWithExtendedInfoAndStartDateAndDaysFiltered()
        {
            var today = DateTime.UtcNow;
            const int days = 14;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            var filter = new TraktCalendarFilter()
                .WithQuery("calendar user season premiere")
                .WithStartYear(2016)
                .WithGenres("drama", "fantasy")
                .WithLanguages("en", "de")
                .WithCountries("us")
                .WithRuntimes(30, 60)
                .WithRatings(80, 95);

            TestUtility.SetupMockResponseWithOAuthWithHeaders(
                $"calendars/my/shows/premieres/{today.ToTraktDateString()}/{days}" +
                $"?extended={extendedInfo}&{filter}",
                CALENDAR_ALL_SHOWS_JSON, START_DATE, END_DATE);

            var response = TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(today, days, extendedInfo, filter).Result;

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
        public void Test_TraktCalendarModule_GetUserSeasonPremieresExceptions()
        {
            const string uri = "calendars/my/shows/premieres";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktListResponse<ITraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync();
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktNotFoundException>();

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

        [Fact]
        public void Test_TraktCalendarModule_GetUserSeasonPremieresArgumentExceptions()
        {
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Calendar.GetUserSeasonPremieresAsync(null, 32);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
