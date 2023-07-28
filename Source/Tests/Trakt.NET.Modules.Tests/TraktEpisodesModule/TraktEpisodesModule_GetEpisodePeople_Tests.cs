namespace TraktNet.Modules.Tests.TraktEpisodesModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Responses;
    using Xunit;

    [TestCategory("Modules.Episodes")]
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
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_With_TraktID()
        {
            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/people",
                EPISODE_PEOPLE_JSON);

            TraktResponse<ITraktShowCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(TRAKT_SHOD_ID, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_With_ShowIds_TraktID()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/people",
                EPISODE_PEOPLE_JSON);

            TraktResponse<ITraktShowCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(showIds, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_With_ShowIds_Slug()
        {
            var showIds = new TraktShowIds
            {
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{SHOW_SLUG}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/people",
                EPISODE_PEOPLE_JSON);

            TraktResponse<ITraktShowCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(showIds, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_With_ShowIds()
        {
            var showIds = new TraktShowIds
            {
                Trakt = TRAKT_SHOD_ID,
                Slug = SHOW_SLUG
            };

            TraktClient client = TestUtility.GetMockClient($"shows/{TRAKT_SHOD_ID}/seasons/{SEASON_NR}/episodes/{EPISODE_NR}/people",
                EPISODE_PEOPLE_JSON);

            TraktResponse<ITraktShowCastAndCrew> response = await client.Episodes.GetEpisodePeopleAsync(showIds, SEASON_NR, EPISODE_NR);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();
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
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, statusCode);

            try
            {
                await client.Episodes.GetEpisodePeopleAsync(SHOW_ID, SEASON_NR, EPISODE_NR);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_TraktEpisodesModule_GetEpisodePeople_Throws_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_EPISODE_PEOPLE_URI, EPISODE_PEOPLE_JSON);

            Func<Task<TraktResponse<ITraktShowCastAndCrew>>> act = () => client.Episodes.GetEpisodePeopleAsync(default(ITraktShowIds), SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<ArgumentNullException>();

            act = () => client.Episodes.GetEpisodePeopleAsync(new TraktShowIds(), SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<ArgumentException>();

            act = () => client.Episodes.GetEpisodePeopleAsync(0, SEASON_NR, EPISODE_NR);
            await act.Should().ThrowAsync<ArgumentException>();
        }
    }
}
