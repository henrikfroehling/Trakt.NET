namespace TraktNet.Modules.Tests.TraktEpisodesModule
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
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Episodes")]
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
        public void Test_TraktEpisodesModule_GetEpisodeRatings_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktEpisodeNotFoundException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatings_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatings_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatings_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatings_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatings_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatings_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatings_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatings_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatings_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatings_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatings_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatings_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatings_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatings_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatings_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeRatings_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_RATINGS_URI, EPISODE_RATINGS_JSON);

            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Episodes.GetEpisodeRatingsAsync(null, SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodeRatingsAsync(string.Empty, SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodeRatingsAsync("show id", SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodeRatingsAsync(SHOW_ID, SEASON_NR, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
