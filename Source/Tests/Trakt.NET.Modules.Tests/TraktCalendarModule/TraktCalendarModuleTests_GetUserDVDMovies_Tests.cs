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
        private const string GET_USER_DVD_MOVIES_URI = "calendars/my/dvd";

        [Fact]
        public async Task Test_TraktCalendarModule_GetUserDVDMovies()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_DVD_MOVIES_URI,
                                                                CALENDAR_DVD_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            TraktListResponse<ITraktCalendarMovie> response = await client.Calendar.GetUserDVDMoviesAsync();

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
        public async Task Test_TraktCalendarModule_GetUserDVDMovies_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_DVD_MOVIES_URI}?{FILTER}",
                                                                CALENDAR_DVD_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            var response = await client.Calendar.GetUserDVDMoviesAsync(null, null, null, FILTER);

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
        public async Task Test_TraktCalendarModule_GetUserDVDMovies_With_StartDate()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_DVD_MOVIES_URI}/{TODAY.ToTraktDateString()}",
                                                                CALENDAR_DVD_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            var response = await client.Calendar.GetUserDVDMoviesAsync(TODAY);

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
        public async Task Test_TraktCalendarModule_GetUserDVDMovies_With_StartDate_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_DVD_MOVIES_URI}/{TODAY.ToTraktDateString()}?{FILTER}",
                                                                CALENDAR_DVD_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            var response = await client.Calendar.GetUserDVDMoviesAsync(TODAY, null, null, FILTER);

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
        public async Task Test_TraktCalendarModule_GetUserDVDMovies_With_Days()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_DVD_MOVIES_URI}/{TODAY.ToTraktDateString()}/{DAYS}",
                                                                CALENDAR_DVD_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            var response = await client.Calendar.GetUserDVDMoviesAsync(null, DAYS);

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
        public async Task Test_TraktCalendarModule_GetUserDVDMovies_With_Days_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_DVD_MOVIES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?{FILTER}",
                                                                CALENDAR_DVD_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            var response = await client.Calendar.GetUserDVDMoviesAsync(null, DAYS, null, FILTER);

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
        public async Task Test_TraktCalendarModule_GetUserDVDMovies_With_StartDate_And_Days()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_DVD_MOVIES_URI}/{TODAY.ToTraktDateString()}/{DAYS}",
                                                                CALENDAR_DVD_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            var response = await client.Calendar.GetUserDVDMoviesAsync(TODAY, DAYS);

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
        public async Task Test_TraktCalendarModule_GetUserDVDMovies_With_StartDate_And_Days_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_DVD_MOVIES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?{FILTER}",
                                                                CALENDAR_DVD_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            var response = await client.Calendar.GetUserDVDMoviesAsync(TODAY, DAYS, null, FILTER);

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
        public async Task Test_TraktCalendarModule_GetUserDVDMovies_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_DVD_MOVIES_URI}?extended={EXTENDED_INFO}",
                                                                CALENDAR_DVD_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            var response = await client.Calendar.GetUserDVDMoviesAsync(null, null, EXTENDED_INFO);

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
        public async Task Test_TraktCalendarModule_GetUserDVDMovies_With_ExtendedInfo_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_DVD_MOVIES_URI}?extended={EXTENDED_INFO}&{FILTER}",
                                                                CALENDAR_DVD_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            var response = await client.Calendar.GetUserDVDMoviesAsync(null, null, EXTENDED_INFO, FILTER);

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
        public async Task Test_TraktCalendarModule_GetUserDVDMovies_With_ExtendedInfo_And_StartDate()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_DVD_MOVIES_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}",
                                                                CALENDAR_DVD_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            var response = await client.Calendar.GetUserDVDMoviesAsync(TODAY, null, EXTENDED_INFO);

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
        public async Task Test_TraktCalendarModule_GetUserDVDMovies_With_ExtendedInfo_And_StartDate_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_DVD_MOVIES_URI}/{TODAY.ToTraktDateString()}?extended={EXTENDED_INFO}&{FILTER}",
                                                                CALENDAR_DVD_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            var response = await client.Calendar.GetUserDVDMoviesAsync(TODAY, null, EXTENDED_INFO, FILTER);

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
        public async Task Test_TraktCalendarModule_GetUserDVDMovies_With_ExtendedInfo_And_Days()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_DVD_MOVIES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}",
                                                                CALENDAR_DVD_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            var response = await client.Calendar.GetUserDVDMoviesAsync(null, DAYS, EXTENDED_INFO);

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
        public async Task Test_TraktCalendarModule_GetUserDVDMovies_With_ExtendedInfo_And_Days_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_DVD_MOVIES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}&{FILTER}",
                                                                CALENDAR_DVD_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            var response = await client.Calendar.GetUserDVDMoviesAsync(null, DAYS, EXTENDED_INFO, FILTER);

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
        public async Task Test_TraktCalendarModule_GetUserDVDMovies_With_ExtendedInfo_And_StartDate_And_Days()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_DVD_MOVIES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}",
                                                                CALENDAR_DVD_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            var response = await client.Calendar.GetUserDVDMoviesAsync(TODAY, DAYS, EXTENDED_INFO);

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
        public async Task Test_TraktCalendarModule_GetUserDVDMovies_With_ExtendedInfo_And_StartDate_And_Days_Filtered()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_USER_DVD_MOVIES_URI}/{TODAY.ToTraktDateString()}/{DAYS}?extended={EXTENDED_INFO}&{FILTER}",
                                                                CALENDAR_DVD_MOVIES_JSON,
                                                                startDate: START_DATE, endDate: END_DATE);

            var response = await client.Calendar.GetUserDVDMoviesAsync(TODAY, DAYS, EXTENDED_INFO, FILTER);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
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
        public async Task Test_TraktCalendarModule_GetUserDVDMovies_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_USER_DVD_MOVIES_URI, statusCode);

            try
            {
                await client.Calendar.GetUserDVDMoviesAsync();
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
