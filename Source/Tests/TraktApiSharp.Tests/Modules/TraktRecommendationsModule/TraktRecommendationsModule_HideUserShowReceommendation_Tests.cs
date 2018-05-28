namespace TraktApiSharp.Tests.Modules.TraktRecommendationsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Recommendations")]
    public partial class TraktRecommendationsModule_Tests
    {
        private readonly string HIDE_SHOW_RECOMMENDATION_URI = $"recommendations/shows/{SHOW_ID}";

        [Fact]
        public async Task Test_TraktRecommendationsModule_HideShowRecommendation()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Recommendations.HideShowRecommendationAsync(SHOW_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_HideShowRecommendation_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, HttpStatusCode.NotFound);
            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(SHOW_ID);
            act.Should().Throw<TraktShowNotFoundException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_HideShowRecommendation_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(SHOW_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_HideShowRecommendation_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(SHOW_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_HideShowRecommendation_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(SHOW_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_HideShowRecommendation_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(SHOW_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_HideShowRecommendation_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, HttpStatusCode.Conflict);
            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(SHOW_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_HideShowRecommendation_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(SHOW_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_HideShowRecommendation_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(SHOW_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_HideShowRecommendation_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, (HttpStatusCode)412);
            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(SHOW_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_HideShowRecommendation_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, (HttpStatusCode)422);
            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(SHOW_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_HideShowRecommendation_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, (HttpStatusCode)429);
            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(SHOW_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_HideShowRecommendation_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, (HttpStatusCode)503);
            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_HideShowRecommendation_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, (HttpStatusCode)504);
            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_HideShowRecommendation_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, (HttpStatusCode)520);
            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_HideShowRecommendation_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, (HttpStatusCode)521);
            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_HideShowRecommendation_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, (HttpStatusCode)522);
            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktRecommendationsModule_HideShowRecommendation_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, HttpStatusCode.NoContent);

            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideShowRecommendationAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Recommendations.HideShowRecommendationAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Recommendations.HideShowRecommendationAsync("show id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
