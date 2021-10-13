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
        private readonly string HIDE_MOVIE_RECOMMENDATION_URI = $"recommendations/movies/{MOVIE_ID}";

        [Fact]
        public async Task Test_TraktRecommendationsModule_HideMovieRecommendation()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_MOVIE_RECOMMENDATION_URI, HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Recommendations.HideMovieRecommendationAsync(MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktMovieNotFoundException))]
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
        public async Task Test_TraktRecommendationsModule_HideMovieRecommendation_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_MOVIE_RECOMMENDATION_URI, statusCode);

            try
            {
                await client.Recommendations.HideMovieRecommendationAsync(MOVIE_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_HideMovieRecommendation_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_MOVIE_RECOMMENDATION_URI, HttpStatusCode.NoContent);

            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideMovieRecommendationAsync(null);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Recommendations.HideMovieRecommendationAsync(string.Empty);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Recommendations.HideMovieRecommendationAsync("movie id");
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
