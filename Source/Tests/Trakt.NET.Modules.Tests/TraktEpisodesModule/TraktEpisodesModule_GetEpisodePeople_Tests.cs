namespace TraktNet.Modules.Tests.TraktEpisodesModule
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

    [Category("Modules.Episodes")]
    public partial class TraktEpisodesModule_Tests
    {
        private readonly string GET_EPISODE_PEOPLE_URI = $"shows/{SHOW_ID}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/people";

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, EPISODE_PEOPLE_JSON);
            TraktResponse<ITraktCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktCastAndCrew responseValue = response.Value;

            responseValue.Cast.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Should().NotBeNull();
            responseValue.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Art.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Crew.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.CostumeAndMakeup.Should().BeNull();
            responseValue.Crew.Directing.Should().BeNull();
            responseValue.Crew.Writing.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Sound.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Camera.Should().BeNull();
            responseValue.Crew.Lighting.Should().BeNull();
            responseValue.Crew.VisualEffects.Should().BeNull();
            responseValue.Crew.Editing.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_EPISODE_PEOPLE_URI}?extended={EXTENDED_INFO}",
                EPISODE_PEOPLE_JSON);

            TraktResponse<ITraktCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktCastAndCrew responseValue = response.Value;

            responseValue.Cast.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Should().NotBeNull();
            responseValue.Crew.Production.Should().NotBeNull().And.HaveCount(2);
            responseValue.Crew.Art.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Crew.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.CostumeAndMakeup.Should().BeNull();
            responseValue.Crew.Directing.Should().BeNull();
            responseValue.Crew.Writing.Should().NotBeNull().And.HaveCount(3);
            responseValue.Crew.Sound.Should().NotBeNull().And.HaveCount(1);
            responseValue.Crew.Camera.Should().BeNull();
            responseValue.Crew.Lighting.Should().BeNull();
            responseValue.Crew.VisualEffects.Should().BeNull();
            responseValue.Crew.Editing.Should().BeNull();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodePeople_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktEpisodeNotFoundException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodePeople_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodePeople_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodePeople_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodePeople_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodePeople_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodePeople_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodePeople_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodePeople_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodePeople_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodePeople_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodePeople_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodePeople_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodePeople_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodePeople_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodePeople_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodePeople_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, EPISODE_PEOPLE_JSON);

            Func<Task<TraktResponse<ITraktCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(null, SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodePeopleAsync(string.Empty, SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodePeopleAsync("show id", SEASON_NR, EPISODE_NR);
            act.Should().Throw<ArgumentException>();

            act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
