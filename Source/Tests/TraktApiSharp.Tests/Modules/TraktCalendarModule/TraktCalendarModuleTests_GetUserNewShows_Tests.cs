namespace TraktNet.Tests.Modules.TraktCalendarModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Calendars;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Calendar")]
    public partial class TraktCalendarModule_Tests
    {
        private const string GET_USER_NEW_SHOWS_URI = "calendars/my/shows/new";

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserNewShows()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI,
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserNewShowsAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserNewShows_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_NEW_SHOWS_URI}?{FILTER}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserNewShowsAsync(null, null, null, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserNewShows_WithStartDate()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_NEW_SHOWS_URI}/{TODAY.ToTraktDateString()}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserNewShowsAsync(TODAY);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserNewShows_WithStartDateFiltered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_NEW_SHOWS_URI}/{TODAY.ToTraktDateString()}?{FILTER}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserNewShowsAsync(TODAY, null, null, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserNewShows_WithDays()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_NEW_SHOWS_URI}/{TODAY.ToTraktDateString()}/{DAYS}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserNewShowsAsync(null, DAYS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserNewShows_WithDaysFiltered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_NEW_SHOWS_URI}/{TODAY.ToTraktDateString()}/{DAYS}?{FILTER}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserNewShowsAsync(null, DAYS, null, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserNewShows_WithStartDateAndDays()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_NEW_SHOWS_URI}/{TODAY.ToTraktDateString()}/{DAYS}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserNewShowsAsync(TODAY, DAYS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserNewShows_WithStartDateAndDaysFiltered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_NEW_SHOWS_URI}/{TODAY.ToTraktDateString()}/{DAYS}?{FILTER}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserNewShowsAsync(TODAY, DAYS, null, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserNewShows_WithExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_NEW_SHOWS_URI}?extended={EXTENDED_INFO}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserNewShowsAsync(null, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserNewShows_WithExtendedInfoFiltered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_NEW_SHOWS_URI}?extended={EXTENDED_INFO}&{FILTER}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserNewShowsAsync(null, null, EXTENDED_INFO, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserNewShows_WithExtendedInfoAndStartDate()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_NEW_SHOWS_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserNewShowsAsync(TODAY, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserNewShows_WithExtendedInfoAndStartDateFiltered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_NEW_SHOWS_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&{FILTER}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserNewShowsAsync(TODAY, null, EXTENDED_INFO, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserNewShows_WithExtendedInfoAndDays()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_NEW_SHOWS_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserNewShowsAsync(null, DAYS, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserNewShows_WithExtendedInfoAndDaysFiltered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_NEW_SHOWS_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}&{FILTER}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserNewShowsAsync(null, DAYS, EXTENDED_INFO, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserNewShows_WithExtendedInfoAndStartDateAndDays()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_NEW_SHOWS_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserNewShowsAsync(TODAY, DAYS, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserNewShows_WithExtendedInfoAndStartDateAndDaysFiltered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_NEW_SHOWS_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}&{FILTER}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserNewShowsAsync(TODAY, DAYS, EXTENDED_INFO, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(2);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserNewShows_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserNewShowsAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserNewShows_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserNewShowsAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserNewShows_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserNewShowsAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserNewShows_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserNewShowsAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserNewShows_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserNewShowsAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserNewShows_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserNewShowsAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserNewShows_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserNewShowsAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserNewShows_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserNewShowsAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserNewShows_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserNewShowsAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserNewShows_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserNewShowsAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserNewShows_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserNewShowsAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserNewShows_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserNewShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserNewShows_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserNewShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserNewShows_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserNewShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserNewShows_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserNewShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserNewShows_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserNewShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserNewShows_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI,
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserNewShowsAsync(null, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => client.Calendar.GetUserNewShowsAsync(null, 32);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
