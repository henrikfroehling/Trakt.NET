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
        private const string GET_ALL_SEASON_PREMIERES_URI = "calendars/all/shows/premieres";

        [Fact]
        public async Task Test_TraktCalendarModule_GetAllSeasonPremieres()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI,
                                                           CALENDAR_ALL_SHOWS_JSON,
                                                           startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync();

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
        public async Task Test_TraktCalendarModule_GetAllSeasonPremieres_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASON_PREMIERES_URI}?{FILTER}",
                                                           CALENDAR_ALL_SHOWS_JSON,
                                                           startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync(null, null, null, FILTER);

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
        public async Task Test_TraktCalendarModule_GetAllSeasonPremieres_With_StartDate()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASON_PREMIERES_URI}/{TODAY.ToTraktDateString()}",
                                                           CALENDAR_ALL_SHOWS_JSON,
                                                           startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync(TODAY);

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
        public async Task Test_TraktCalendarModule_GetAllSeasonPremieres_With_StartDate_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASON_PREMIERES_URI}/{TODAY.ToTraktDateString()}?{FILTER}",
                                                           CALENDAR_ALL_SHOWS_JSON,
                                                           startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync(TODAY, null, null, FILTER);

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
        public async Task Test_TraktCalendarModule_GetAllSeasonPremieres_With_Days()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASON_PREMIERES_URI}/{TODAY.ToTraktDateString()}/{DAYS}",
                                                           CALENDAR_ALL_SHOWS_JSON,
                                                           startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync(null, DAYS);

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
        public async Task Test_TraktCalendarModule_GetAllSeasonPremieres_With_Days_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASON_PREMIERES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?{FILTER}",
                                                           CALENDAR_ALL_SHOWS_JSON,
                                                           startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync(null, DAYS, null, FILTER);

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
        public async Task Test_TraktCalendarModule_GetAllSeasonPremieres_With_StartDate_And_Days()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASON_PREMIERES_URI}/{TODAY.ToTraktDateString()}/{DAYS}",
                                                           CALENDAR_ALL_SHOWS_JSON,
                                                           startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync(TODAY, DAYS);

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
        public async Task Test_TraktCalendarModule_GetAllSeasonPremieres_With_StartDate_And_Days_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASON_PREMIERES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?{FILTER}",
                                                           CALENDAR_ALL_SHOWS_JSON,
                                                           startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync(TODAY, DAYS, null, FILTER);

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
        public async Task Test_TraktCalendarModule_GetAllSeasonPremieres_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASON_PREMIERES_URI}?extended={EXTENDED_INFO}",
                                                           CALENDAR_ALL_SHOWS_JSON,
                                                           startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync(null, null, EXTENDED_INFO);

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
        public async Task Test_TraktCalendarModule_GetAllSeasonPremieres_With_ExtendedInfo_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASON_PREMIERES_URI}?extended={EXTENDED_INFO}&{FILTER}",
                                                           CALENDAR_ALL_SHOWS_JSON,
                                                           startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync(null, null, EXTENDED_INFO, FILTER);

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
        public async Task Test_TraktCalendarModule_GetAllSeasonPremieres_With_ExtendedInfo_And_StartDate()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASON_PREMIERES_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}",
                                                           CALENDAR_ALL_SHOWS_JSON,
                                                           startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync(TODAY, null, EXTENDED_INFO);

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
        public async Task Test_TraktCalendarModule_GetAllSeasonPremieres_With_ExtendedInfo_And_StartDate_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASON_PREMIERES_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&{FILTER}",
                                                           CALENDAR_ALL_SHOWS_JSON,
                                                           startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync(TODAY, null, EXTENDED_INFO, FILTER);

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
        public async Task Test_TraktCalendarModule_GetAllSeasonPremieres_With_ExtendedInfo_And_Days()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASON_PREMIERES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}",
                                                           CALENDAR_ALL_SHOWS_JSON,
                                                           startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync(null, DAYS, EXTENDED_INFO);

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
        public async Task Test_TraktCalendarModule_GetAllSeasonPremieres_With_ExtendedInfo_And_Days_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASON_PREMIERES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}&{FILTER}",
                                                           CALENDAR_ALL_SHOWS_JSON,
                                                           startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync(null, DAYS, EXTENDED_INFO, FILTER);

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
        public async Task Test_TraktCalendarModule_GetAllSeasonPremieres_With_ExtendedInfo_And_StartDate_And_Days()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASON_PREMIERES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}",
                                                           CALENDAR_ALL_SHOWS_JSON,
                                                           startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync(TODAY, DAYS, EXTENDED_INFO);

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
        public async Task Test_TraktCalendarModule_GetAllSeasonPremieres_With_ExtendedInfo_And_StartDate_And_Days_Filtered()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_ALL_SEASON_PREMIERES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}&{FILTER}",
                                                           CALENDAR_ALL_SHOWS_JSON,
                                                           startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarShow> response = await client.Calendar.GetAllSeasonPremieresAsync(TODAY, DAYS, EXTENDED_INFO, FILTER);

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
        public void Test_TraktCalendarModule_GetAllSeasonPremieres_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI, HttpStatusCode.NotFound);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllSeasonPremieres_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllSeasonPremieres_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllSeasonPremieres_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllSeasonPremieres_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllSeasonPremieres_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI, HttpStatusCode.Conflict);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllSeasonPremieres_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllSeasonPremieres_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllSeasonPremieres_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI, (HttpStatusCode)412);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllSeasonPremieres_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI, (HttpStatusCode)422);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllSeasonPremieres_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI, (HttpStatusCode)429);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllSeasonPremieres_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI, (HttpStatusCode)503);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllSeasonPremieres_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI, (HttpStatusCode)504);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllSeasonPremieres_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI, (HttpStatusCode)520);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllSeasonPremieres_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI, (HttpStatusCode)521);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllSeasonPremieres_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI, (HttpStatusCode)522);
            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCalendarModule_GetAllSeasonPremieres_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_ALL_SEASON_PREMIERES_URI,
                                                           CALENDAR_ALL_SHOWS_JSON,
                                                           startDate: START_DATE, endDate: END_DATE);

            Func<Task<TraktListResponse<ITraktCalendarShow>>> act = () => client.Calendar.GetAllSeasonPremieresAsync(null, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => client.Calendar.GetAllSeasonPremieresAsync(null, 32);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
