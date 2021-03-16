namespace TraktNet.Modules.Tests.TraktCalendarModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktNotFoundException))]
        [InlineData(HttpStatusCode.Unauthorized, typeof(TraktAuthorizationException))]
        [InlineData(HttpStatusCode.BadRequest, typeof(TraktBadRequestException))]
        [InlineData(HttpStatusCode.Forbidden, typeof(TraktForbiddenException))]
        [InlineData(HttpStatusCode.MethodNotAllowed, typeof(TraktMethodNotFoundException))]
        [InlineData(HttpStatusCode.Conflict, typeof(TraktConflictException))]
        [InlineData(HttpStatusCode.InternalServerError, typeof(TraktServerException))]
        [InlineData(HttpStatusCode.BadGateway, typeof(TraktBadGatewayException))]
        [InlineData(HttpStatusCode.PreconditionFailed, typeof(TraktPreconditionFailedException))]
        [InlineData(HttpStatusCode.UnprocessableEntity, typeof(TraktValidationException))]
        [InlineData(HttpStatusCode.TooManyRequests, typeof(TraktRateLimitException))]
        [InlineData(HttpStatusCode.ServiceUnavailable, typeof(TraktServerUnavailableException))]
        [InlineData(HttpStatusCode.GatewayTimeout, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)520, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)521, typeof(TraktServerUnavailableException))]
        [InlineData((HttpStatusCode)522, typeof(TraktServerUnavailableException))]
        public async Task Test_TraktCalendarModule_GetUserNewShows_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_NEW_SHOWS_URI, statusCode);

            try
            {
                await client.Calendar.GetUserNewShowsAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
