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
    using TraktNet.Objects.Get.Shows;
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
            TraktResponse<ITraktShowCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktShowCastAndCrew responseValue = response.Value;

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

            TraktResponse<ITraktShowCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktShowCastAndCrew responseValue = response.Value;

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
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<TraktEpisodeNotFoundException>();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<TraktAuthorizationException>();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<TraktBadRequestException>();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<TraktForbiddenException>();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<TraktMethodNotFoundException>();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<TraktConflictException>();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<TraktServerException>();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<TraktBadGatewayException>();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<TraktPreconditionFailedException>();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<TraktValidationException>();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<TraktRateLimitException>();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, EPISODE_PEOPLE_JSON);

            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(null, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodePeopleAsync(string.Empty, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodePeopleAsync("show id", SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, 0);
            await act.Should().ThrowAsync<ArgumentOutOfRangeException>();
        }
    }
}
