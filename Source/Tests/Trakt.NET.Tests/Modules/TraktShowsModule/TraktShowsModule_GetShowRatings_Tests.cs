namespace TraktNet.Tests.Modules.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
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
        private readonly string GET_SHOW_RATINGS_URI = $"shows/{SHOW_ID}/ratings";

        [Fact]
        public async Task Test_TraktShowsModule_GetShowRatings()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, SHOW_RATINGS_JSON);
            TraktResponse<ITraktRating> response = await client.Shows.GetShowRatingsAsync(SHOW_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktRating responseValue = response.Value;

            responseValue.Rating.Should().Be(9.38231f);
            responseValue.Votes.Should().Be(44590);

            IDictionary<string, int> distribution = new Dictionary<string, int>()
            {
                { "1",  258 }, { "2", 57 }, { "3", 59 }, { "4", 116 }, { "5", 262 },
                { "6",  448 }, { "7", 1427 }, { "8", 3893 }, { "9", 8467 }, { "10", 29590 }
            };

            responseValue.Distribution.Should().HaveCount(10).And.Contain(distribution);
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRatings_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Shows.GetShowRatingsAsync(SHOW_ID);
            act.Should().Throw<TraktShowNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRatings_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Shows.GetShowRatingsAsync(SHOW_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRatings_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Shows.GetShowRatingsAsync(SHOW_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRatings_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Shows.GetShowRatingsAsync(SHOW_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRatings_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Shows.GetShowRatingsAsync(SHOW_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRatings_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Shows.GetShowRatingsAsync(SHOW_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRatings_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Shows.GetShowRatingsAsync(SHOW_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRatings_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Shows.GetShowRatingsAsync(SHOW_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRatings_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Shows.GetShowRatingsAsync(SHOW_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRatings_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Shows.GetShowRatingsAsync(SHOW_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRatings_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Shows.GetShowRatingsAsync(SHOW_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRatings_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Shows.GetShowRatingsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRatings_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Shows.GetShowRatingsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRatings_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Shows.GetShowRatingsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRatings_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Shows.GetShowRatingsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRatings_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Shows.GetShowRatingsAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowRatings_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_RATINGS_URI, SHOW_RATINGS_JSON);

            Func<Task<TraktResponse<ITraktRating>>> act = () => client.Shows.GetShowRatingsAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowRatingsAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowRatingsAsync("show id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
