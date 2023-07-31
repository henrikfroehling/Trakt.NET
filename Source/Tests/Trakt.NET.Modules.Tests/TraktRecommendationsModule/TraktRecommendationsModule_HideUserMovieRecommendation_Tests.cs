namespace TraktNet.Modules.Tests.TraktRecommendationsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Recommendations")]
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

        [Fact]
        public async Task Test_TraktRecommendationsModule_HideMovieRecommendationRatings_With_TraktID()
        {
            TraktClient client = TestUtility.GetOAuthMockClient($"recommendations/movies/{TRAKT_MOVIE_ID}", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Recommendations.HideMovieRecommendationAsync(TRAKT_MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_HideMovieRecommendationRatings_With_MovieIds_TraktID()
        {
            var movieIds = new TraktMovieIds
            {
                Trakt = TRAKT_MOVIE_ID
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"recommendations/movies/{TRAKT_MOVIE_ID}", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Recommendations.HideMovieRecommendationAsync(movieIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_HideMovieRecommendationRatings_With_MovieIds_Slug()
        {
            var movieIds = new TraktMovieIds
            {
                Slug = MOVIE_SLUG
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"recommendations/movies/{MOVIE_SLUG}", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Recommendations.HideMovieRecommendationAsync(movieIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_HideMovieRecommendationRatings_With_MovieIds()
        {
            var movieIds = new TraktMovieIds
            {
                Trakt = TRAKT_MOVIE_ID,
                Slug = MOVIE_SLUG
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"recommendations/movies/{TRAKT_MOVIE_ID}", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Recommendations.HideMovieRecommendationAsync(movieIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Test_TraktRecommendationsModule_HideMovieRecommendationRatings_With_Movie()
        {
            var movie = new TraktMovie
            {
                Ids = new TraktMovieIds
                {
                    Trakt = TRAKT_MOVIE_ID,
                    Slug = MOVIE_SLUG
                }
            };

            TraktClient client = TestUtility.GetOAuthMockClient($"recommendations/movies/{TRAKT_MOVIE_ID}", HttpStatusCode.NoContent);
            TraktNoContentResponse response = await client.Recommendations.HideMovieRecommendationAsync(movie);

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
        public async Task Test_TraktRecommendationsModule_GetMovieRatings_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(HIDE_MOVIE_RECOMMENDATION_URI, HttpStatusCode.NoContent);

            Func<Task<TraktNoContentResponse>> act = () => client.Recommendations.HideMovieRecommendationAsync(default(ITraktMovieIds));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Recommendations.HideMovieRecommendationAsync(default(ITraktMovie));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Recommendations.HideMovieRecommendationAsync(new TraktMovieIds());
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Recommendations.HideMovieRecommendationAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
