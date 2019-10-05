namespace TraktNet.Modules.Tests.TraktRecommendationsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Responses;
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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktShowNotFoundException))]
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
        public async Task Test_TraktRecommendationsModule_HideShowRecommendation_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_SHOW_RECOMMENDATION_URI, statusCode);

            try
            {
                await client.Recommendations.HideShowRecommendationAsync(SHOW_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
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
