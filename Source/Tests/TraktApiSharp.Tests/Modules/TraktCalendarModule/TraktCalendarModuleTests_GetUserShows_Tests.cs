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
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Calendar")]
    public partial class TraktCalendarModule_Tests
    {
        private const string GET_USER_SHOWS_URI = "calendars/my/shows";

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserShows()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI,
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserShowsAsync();

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
        public async Task Test_TraktCalendarModule_GetUserShows_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_SHOWS_URI}?{FILTER}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserShowsAsync(null, null, null, FILTER);

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
        public async Task Test_TraktCalendarModule_GetUserShows_With_StartDate()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_SHOWS_URI}/{TODAY.ToTraktDateString()}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserShowsAsync(TODAY);

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
        public async Task Test_TraktCalendarModule_GetUserShows_With_StartDate_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_SHOWS_URI}/{TODAY.ToTraktDateString()}?{FILTER}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserShowsAsync(TODAY, null, null, FILTER);

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
        public async Task Test_TraktCalendarModule_GetUserShows_With_Days()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_SHOWS_URI}/{TODAY.ToTraktDateString()}/{DAYS}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserShowsAsync(null, DAYS);

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
        public async Task Test_TraktCalendarModule_GetUserShows_With_Days_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_SHOWS_URI}/{TODAY.ToTraktDateString()}/{DAYS}?{FILTER}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserShowsAsync(null, DAYS, null, FILTER);

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
        public async Task Test_TraktCalendarModule_GetUserShows_With_StartDate_And_Days()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_SHOWS_URI}/{TODAY.ToTraktDateString()}/{DAYS}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserShowsAsync(TODAY, DAYS);

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
        public async Task Test_TraktCalendarModule_GetUserShows_With_StartDate_And_Days_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_SHOWS_URI}/{TODAY.ToTraktDateString()}/{DAYS}?{FILTER}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserShowsAsync(TODAY, DAYS, null, FILTER);

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
        public async Task Test_TraktCalendarModule_GetUserShows_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_SHOWS_URI}?extended={EXTENDED_INFO}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserShowsAsync(null, null, EXTENDED_INFO);

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
        public async Task Test_TraktCalendarModule_GetUserShows_With_ExtendedInfo_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_SHOWS_URI}?extended={EXTENDED_INFO}&{FILTER}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserShowsAsync(null, null, EXTENDED_INFO, FILTER);

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
        public async Task Test_TraktCalendarModule_GetUserShows_With_ExtendedInfo_And_StartDate()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_SHOWS_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserShowsAsync(TODAY, null, EXTENDED_INFO);

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
        public async Task Test_TraktCalendarModule_GetUserShows_With_ExtendedInfo_And_StartDate_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_SHOWS_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&{FILTER}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserShowsAsync(TODAY, null, EXTENDED_INFO, FILTER);

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
        public async Task Test_TraktCalendarModule_GetUserShows_With_ExtendedInfo_And_Days()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_SHOWS_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserShowsAsync(null, DAYS, EXTENDED_INFO);

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
        public async Task Test_TraktCalendarModule_GetUserShows_With_ExtendedInfo_And_Days_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_SHOWS_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}&{FILTER}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserShowsAsync(null, DAYS, EXTENDED_INFO, FILTER);

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
        public async Task Test_TraktCalendarModule_GetUserShows_With_ExtendedInfo_And_StartDate_And_Days()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_SHOWS_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserShowsAsync(TODAY, DAYS, EXTENDED_INFO);

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
        public async Task Test_TraktCalendarModule_GetUserShows_With_ExtendedInfo_And_StartDate_And_Days_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_SHOWS_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}&{FILTER}",
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetUserShowsAsync(TODAY, DAYS, EXTENDED_INFO, FILTER);

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
        public void Test_TraktCalendarModule_GetUserShows_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserShowsAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserShows_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserShowsAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserShows_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserShowsAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserShows_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserShowsAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserShows_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserShowsAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserShows_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserShowsAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserShows_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserShowsAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserShows_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserShowsAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserShows_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserShowsAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserShows_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserShowsAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserShows_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserShowsAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserShows_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserShows_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserShows_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserShows_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserShows_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserShowsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserShows_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_SHOWS_URI,
                                                                CALENDAR_ALL_SHOWS_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetUserShowsAsync(null, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => client.Calendar.GetUserShowsAsync(null, 32);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
