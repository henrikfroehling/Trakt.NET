﻿namespace TraktNet.Modules.Tests.TraktEpisodesModule
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
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Episodes")]
    public partial class TraktEpisodesModule_Tests
    {
        private readonly string GET_EPISODE_RATINGS_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/ratings";

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeRatings()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, EPISODE_RATINGS_JSON);
            TraktResponse<ITraktRating> response = await client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktRating responseValue = response.Value;

            responseValue.Rating.Should().Be(8.54044f);
            responseValue.Votes.Should().Be(3919);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  59 }, { "2", 11 }, { "3", 2 }, { "4", 14 }, { "5", 58 },
                { "6",  233 }, { "7", 492 }, { "8", 835 }, { "9", 635 }, { "10", 1580 }
            };

            responseValue.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeRatings_With_TraktID()
        {
            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/ratings",
                EPISODE_RATINGS_JSON);

            TraktResponse<ITraktRating> response = await client.Episodes.GetEpisodeRatingsAsync(TRAKT_SHOD_ID, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeRatings_With_ShowIds_TraktID()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/ratings",
                EPISODE_RATINGS_JSON);

            TraktResponse<ITraktRating> response = await client.Episodes.GetEpisodeRatingsAsync(showIds, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeRatings_With_ShowIds_Slug()
        {
            var showIds = new TraktShowIds
            {
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{SHOW_SLUG}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/ratings",
                EPISODE_RATINGS_JSON);

            TraktResponse<ITraktRating> response = await client.Episodes.GetEpisodeRatingsAsync(showIds, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeRatings_With_ShowIds()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID,
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/ratings",
                EPISODE_RATINGS_JSON);

            TraktResponse<ITraktRating> response = await client.Episodes.GetEpisodeRatingsAsync(showIds, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktEpisodeNotFoundException))]
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
        public async Task Test_TraktEpisodesModule_GetEpisodeRatings_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, statusCode);

            try
            {
                await client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodeRatings_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, EPISODE_RATINGS_JSON);

            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(default(ITraktShowIds), SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodeRatingsAsync(new TraktShowIds(), SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodeRatingsAsync(0, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
