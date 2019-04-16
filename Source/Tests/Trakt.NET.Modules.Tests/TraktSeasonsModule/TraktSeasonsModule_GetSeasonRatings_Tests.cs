namespace TraktNet.Modules.Tests.TraktSeasonsModule
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

    [Category("Modules.Seasons")]
    public partial class TraktSeasonsModule_Tests
    {
        private readonly string GET_SEASON_RATINGS_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}/ratings";

        [Fact]
        public async Task Test_TraktSeasonsModule_GetSeasonRatings()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, SEASON_RATINGS_JSON);
            TraktResponse<ITraktRating> response = await client.Seasons.GetSeasonRatingsAsync(SHOW_ID, SEASON_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktRating responseValue = response.Value;

            responseValue.Rating.Should().Be(9.12881f);
            responseValue.Votes.Should().Be(1149);

            var distribution = new Dictionary<string, int>()
            {
                { "1",  7 }, { "2", 5 }, { "3", 4 }, { "4", 2 }, { "5", 9 },
                { "6",  23 }, { "7", 45 }, { "8", 152 }, { "9", 282 }, { "10", 620 }
            };

            responseValue.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktSeasonNotFoundException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(SHOW_ID, SEASON_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktSeasonsModule_GetSeasonRatings_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SEASON_RATINGS_URI, SEASON_RATINGS_JSON);

            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Seasons.GetSeasonRatingsAsync(null, SEASON_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Seasons.GetSeasonRatingsAsync(string.Empty, SEASON_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Seasons.GetSeasonRatingsAsync("show id", SEASON_NR);
            act.Should().Throw<ArgumentException>();
        }
    }
}
