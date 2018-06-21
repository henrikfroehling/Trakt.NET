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
        private const string GET_USER_MOVIES_URI = "calendars/my/movies";

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserMovies()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI,
                                                                CALENDAR_ALL_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarMovie> response = await client.Calendar.GetUserMoviesAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserMovies_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_MOVIES_URI}?{FILTER}",
                                                                CALENDAR_ALL_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarMovie> response = await client.Calendar.GetUserMoviesAsync(null, null, null, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserMovies_With_StartDate()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_MOVIES_URI}/{TODAY.ToTraktDateString()}",
                                                                CALENDAR_ALL_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarMovie> response = await client.Calendar.GetUserMoviesAsync(TODAY);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserMovies_With_StartDate_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_MOVIES_URI}/{TODAY.ToTraktDateString()}?{FILTER}",
                                                                CALENDAR_ALL_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarMovie> response = await client.Calendar.GetUserMoviesAsync(TODAY, null, null, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserMovies_With_Days()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_MOVIES_URI}/{TODAY.ToTraktDateString()}/{DAYS}",
                                                                CALENDAR_ALL_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarMovie> response = await client.Calendar.GetUserMoviesAsync(null, DAYS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserMovies_With_Days_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_MOVIES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?{FILTER}",
                                                                CALENDAR_ALL_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarMovie> response = await client.Calendar.GetUserMoviesAsync(null, DAYS, null, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserMovies_With_StartDate_And_Days()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_MOVIES_URI}/{TODAY.ToTraktDateString()}/{DAYS}",
                                                                CALENDAR_ALL_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarMovie> response = await client.Calendar.GetUserMoviesAsync(TODAY, DAYS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserMovies_With_StartDate_And_Days_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_MOVIES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?{FILTER}",
                                                                CALENDAR_ALL_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarMovie> response = await client.Calendar.GetUserMoviesAsync(TODAY, DAYS, null, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserMovies_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_MOVIES_URI}?extended={EXTENDED_INFO}",
                                                                CALENDAR_ALL_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarMovie> response = await client.Calendar.GetUserMoviesAsync(null, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserMovies_With_ExtendedInfo_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_MOVIES_URI}?extended={EXTENDED_INFO}&{FILTER}",
                                                                CALENDAR_ALL_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarMovie> response = await client.Calendar.GetUserMoviesAsync(null, null, EXTENDED_INFO, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserMovies_With_ExtendedInfo_And_StartDate()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_MOVIES_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}",
                                                                CALENDAR_ALL_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarMovie> response = await client.Calendar.GetUserMoviesAsync(TODAY, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserMovies_With_ExtendedInfo_And_StartDate_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_MOVIES_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&{FILTER}",
                                                                CALENDAR_ALL_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarMovie> response = await client.Calendar.GetUserMoviesAsync(TODAY, null, EXTENDED_INFO, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserMovies_With_ExtendedInfo_And_Days()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_MOVIES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}",
                                                                CALENDAR_ALL_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarMovie> response = await client.Calendar.GetUserMoviesAsync(null, DAYS, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserMovies_With_ExtendedInfo_And_Days_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_MOVIES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}&{FILTER}",
                                                                CALENDAR_ALL_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarMovie> response = await client.Calendar.GetUserMoviesAsync(null, DAYS, EXTENDED_INFO, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserMovies_With_ExtendedInfo_And_StartDate_And_Days()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_MOVIES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}",
                                                                CALENDAR_ALL_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarMovie> response = await client.Calendar.GetUserMoviesAsync(TODAY, DAYS, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserMovies_With_ExtendedInfo_And_StartDate_And_Days_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_MOVIES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}&{FILTER}",
                                                                CALENDAR_ALL_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarMovie> response = await client.Calendar.GetUserMoviesAsync(TODAY, DAYS, EXTENDED_INFO, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.StartDate.Should().HaveValue();
            response.StartDate.Equals(StartDateTime).Should().BeTrue();
            response.EndDate.Should().HaveValue();
            response.EndDate.Equals(EndDateTime).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserMovies_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act = () => client.Calendar.GetUserMoviesAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserMovies_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act = () => client.Calendar.GetUserMoviesAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserMovies_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act = () => client.Calendar.GetUserMoviesAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserMovies_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act = () => client.Calendar.GetUserMoviesAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserMovies_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act = () => client.Calendar.GetUserMoviesAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserMovies_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act = () => client.Calendar.GetUserMoviesAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserMovies_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act = () => client.Calendar.GetUserMoviesAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserMovies_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act = () => client.Calendar.GetUserMoviesAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserMovies_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act = () => client.Calendar.GetUserMoviesAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserMovies_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act = () => client.Calendar.GetUserMoviesAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserMovies_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act = () => client.Calendar.GetUserMoviesAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserMovies_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act = () => client.Calendar.GetUserMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserMovies_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act = () => client.Calendar.GetUserMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserMovies_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act = () => client.Calendar.GetUserMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserMovies_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act = () => client.Calendar.GetUserMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserMovies_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act = () => client.Calendar.GetUserMoviesAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetUserMovies_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_MOVIES_URI,
                                                                CALENDAR_ALL_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            Func<Task<TraktListResponse<ITraktCalendarMovie>>> act = () => client.Calendar.GetUserMoviesAsync(null, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => client.Calendar.GetUserMoviesAsync(null, 32);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
