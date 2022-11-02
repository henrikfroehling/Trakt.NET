namespace TraktNet.Modules.Tests.TraktMoviesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Basic;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Movies")]
    public partial class TraktMoviesModule_Tests
    {
        private readonly string GET_MOVIE_PEOPLE_URI = $"movies/{MOVIE_ID}/people";

        [Fact]
        public async Task Test_TraktMoviesModule_GetMoviePeople()
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, MOVIE_PEOPLE_JSON);
            TraktResponse<ITraktCastAndCrew> response = await client.Movies.GetMoviePeopleAsync(MOVIE_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktCastAndCrew responseValue = response.Value;

            responseValue.Cast.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Should().NotBeNull();
            responseValue.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Art.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Crew.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Directing.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Writing.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Sound.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Camera.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Lighting.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Editing.Should().NotBeNull().And.HaveCount(2);
        }

        [Fact]
        public async Task Test_TraktMoviesModule_GetMoviePeople_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient($"{GET_MOVIE_PEOPLE_URI}?extended={EXTENDED_INFO}", MOVIE_PEOPLE_JSON);
            TraktResponse<ITraktCastAndCrew> response = await client.Movies.GetMoviePeopleAsync(MOVIE_ID, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktCastAndCrew responseValue = response.Value;

            responseValue.Cast.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Should().NotBeNull();
            responseValue.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Art.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Crew.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.CostumeAndMakeup.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Directing.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Writing.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Sound.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Camera.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Lighting.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.VisualEffects.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Editing.Should().NotBeNull().And.HaveCount(2);
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
        public async Task Test_TraktMoviesModule_GetMoviePeople_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_MOVIE_PEOPLE_URI, statusCode);

            try
            {
                await client.Movies.GetMoviePeopleAsync(MOVIE_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }
    }
}
