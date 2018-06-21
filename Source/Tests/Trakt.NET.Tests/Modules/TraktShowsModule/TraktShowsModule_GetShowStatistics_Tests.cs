namespace TraktNet.Tests.Modules.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private readonly string GET_SHOW_STATISTICS_URI = $"shows/{SHOW_ID}/stats";

        [Fact]
        public async Task Test_TraktShowsModule_GetShowStatistics()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, SHOW_STATISTICS_JSON);
            TraktResponse<ITraktStatistics> response = await client.Shows.GetShowStatisticsAsync(SHOW_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktStatistics responseValue = response.Value;

            responseValue.Watchers.Should().Be(265955);
            responseValue.Plays.Should().Be(12491168);
            responseValue.Collectors.Should().Be(106028);
            responseValue.CollectedEpisodes.Should().Be(4092901);
            responseValue.Comments.Should().Be(233);
            responseValue.Lists.Should().Be(103943);
            responseValue.Votes.Should().Be(44590);
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowStatistics_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(SHOW_ID);
            act.Should().Throw<TraktShowNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowStatistics_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(SHOW_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowStatistics_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(SHOW_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowStatistics_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(SHOW_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowStatistics_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(SHOW_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowStatistics_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(SHOW_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowStatistics_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(SHOW_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowStatistics_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(SHOW_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowStatistics_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(SHOW_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowStatistics_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(SHOW_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowStatistics_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(SHOW_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowStatistics_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowStatistics_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowStatistics_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowStatistics_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowStatistics_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowStatistics_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_STATISTICS_URI, SHOW_STATISTICS_JSON);

            Func<Task<TraktResponse<ITraktStatistics>>> act = () => client.Shows.GetShowStatisticsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowStatisticsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowStatisticsAsync("show id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
