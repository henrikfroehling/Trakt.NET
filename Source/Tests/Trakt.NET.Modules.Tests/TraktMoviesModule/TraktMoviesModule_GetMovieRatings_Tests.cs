﻿namespace TraktNet.Modules.Tests.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        private readonly string GET_MOVIE_RATINGS_URI = $"movies/{MOVIE_ID}/ratings";

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieRatings()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, MOVIE_RATINGS_JSON);
            TraktResponse<ITraktRating> response = await client.Movies.GetMovieRatingsAsync(MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktRating responseValue = response.Value;

            responseValue.Rating.Should().Be(8.31325f);
            responseValue.Votes.Should().Be(10359);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  185 }, { "2", 28 }, { "3", 34 }, { "4", 89 }, { "5", 184 },
                { "6",  630 }, { "7", 1244 }, { "8", 2509 }, { "9", 2622 }, { "10", 2834 }
            };

            responseValue.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieRatings_With_TraktID()
        {
            TraktClient client = TestUtility.GetMockClient($"movies/{TRAKT_MOVIE_ID}/ratings", MOVIE_RATINGS_JSON);
            TraktResponse<ITraktRating> response = await client.Movies.GetMovieRatingsAsync(TRAKT_MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieRatings_With_MovieIds_TraktID()
        {
            var movieIds = new TraktMovieIds
            {
                Trakt = TRAKT_MOVIE_ID
            };

            TraktClient client = TestUtility.GetMockClient($"movies/{TRAKT_MOVIE_ID}/ratings", MOVIE_RATINGS_JSON);
            TraktResponse<ITraktRating> response = await client.Movies.GetMovieRatingsAsync(movieIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieRatings_With_MovieIds_Slug()
        {
            var movieIds = new TraktMovieIds
            {
                Slug = MOVIE_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"movies/{MOVIE_SLUG}/ratings", MOVIE_RATINGS_JSON);
            TraktResponse<ITraktRating> response = await client.Movies.GetMovieRatingsAsync(movieIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieRatings_With_MovieIds()
        {
            var movieIds = new TraktMovieIds
            {
                Trakt = TRAKT_MOVIE_ID,
                Slug = MOVIE_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"movies/{TRAKT_MOVIE_ID}/ratings", MOVIE_RATINGS_JSON);
            TraktResponse<ITraktRating> response = await client.Movies.GetMovieRatingsAsync(movieIds);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
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
        public async Task Test_TraktMoviesModule_GetMovieRatings_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, statusCode);

            try
            {
                await client.Movies.GetMovieRatingsAsync(MOVIE_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMovieRatings_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_RATINGS_URI, MOVIE_RATINGS_JSON);

            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Movies.GetMovieRatingsAsync(default(ITraktMovieIds));
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Movies.GetMovieRatingsAsync(0);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
