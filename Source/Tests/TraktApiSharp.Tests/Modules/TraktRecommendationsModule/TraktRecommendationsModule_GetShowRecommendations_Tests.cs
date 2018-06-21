namespace TraktNet.Tests.Modules.TraktRecommendationsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Recommendations")]
    public partial class TraktRecommendationsModule_Tests
    {
        private const string GET_SHOW_RECOMMENDATIONS_URI = "recommendations/shows";

        [Fact]
        public async Task Test_TraktRecommendationsModule_GetShowRecommendations()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_RECOMMENDATIONS_URI,
                                                                SHOW_RECOMMENDATIONS_JSON, 1, 10);

            TraktPagedResponse<ITraktShow> response = await client.Recommendations.GetShowRecommendationsAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.Page.Should().Be(1u);
            response.Limit.Should().Be(10u);
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_GetShowRecommendations_With_Limit()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_SHOW_RECOMMENDATIONS_URI}?limit={LIMIT}",
                                                                SHOW_RECOMMENDATIONS_JSON, 1, LIMIT);

            TraktPagedResponse<ITraktShow> response = await client.Recommendations.GetShowRecommendationsAsync(LIMIT);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.Page.Should().Be(1u);
            response.Limit.Should().Be(LIMIT);
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_GetShowRecommendations_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_SHOW_RECOMMENDATIONS_URI}?extended={EXTENDED_INFO}",
                                                                SHOW_RECOMMENDATIONS_JSON, 1, 10);

            TraktPagedResponse<ITraktShow> response = await client.Recommendations.GetShowRecommendationsAsync(null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.Page.Should().Be(1u);
            response.Limit.Should().Be(10u);
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_GetShowRecommendations_Complete()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"{GET_SHOW_RECOMMENDATIONS_URI}?extended={EXTENDED_INFO}&limit={LIMIT}",
                                                                SHOW_RECOMMENDATIONS_JSON, 1, LIMIT);

            TraktPagedResponse<ITraktShow> response = await client.Recommendations.GetShowRecommendationsAsync(LIMIT, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(3);
            response.Page.Should().Be(1u);
            response.Limit.Should().Be(LIMIT);
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetShowRecommendations_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_RECOMMENDATIONS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetShowRecommendations_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_RECOMMENDATIONS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetShowRecommendations_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_RECOMMENDATIONS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetShowRecommendations_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_RECOMMENDATIONS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetShowRecommendations_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_RECOMMENDATIONS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetShowRecommendations_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_RECOMMENDATIONS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetShowRecommendations_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_RECOMMENDATIONS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetShowRecommendations_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_RECOMMENDATIONS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetShowRecommendations_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_RECOMMENDATIONS_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetShowRecommendations_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_RECOMMENDATIONS_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetShowRecommendations_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_RECOMMENDATIONS_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetShowRecommendations_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_RECOMMENDATIONS_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetShowRecommendations_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_RECOMMENDATIONS_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetShowRecommendations_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_RECOMMENDATIONS_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetShowRecommendations_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_RECOMMENDATIONS_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_GetShowRecommendations_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(GET_SHOW_RECOMMENDATIONS_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktShow>>> act = () => client.Recommendations.GetShowRecommendationsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
