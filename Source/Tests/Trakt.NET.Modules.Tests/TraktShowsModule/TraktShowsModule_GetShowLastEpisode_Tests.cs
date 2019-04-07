namespace TraktNet.Modules.Tests.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        private readonly string GET_SHOW_LAST_EPISODE_URI = $"shows/{SHOW_ID}/last_episode";

        [Fact]
        public async Task Test_TraktShowsModule_GetShowLastEpisode()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, SHOW_EPISODE_JSON);
            TraktResponse<ITraktEpisode> response = await client.Shows.GetShowLastEpisodeAsync(SHOW_ID);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisode responseValue = response.Value;

            responseValue.Title.Should().Be("Winter Is Coming");
            responseValue.SeasonNumber.Should().Be(1);
            responseValue.Number.Should().Be(1);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(73640U);
            responseValue.Ids.Tvdb.Should().Be(3254641U);
            responseValue.Ids.Imdb.Should().Be("tt1480055");
            responseValue.Ids.Tmdb.Should().Be(63056U);
            responseValue.Ids.TvRage.Should().Be(1065008299U);
        }

        [Fact]
        public async Task Test_TraktShowsModule_GetShowLastEpisode_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_LAST_EPISODE_URI}?extended={EXTENDED_INFO}",
                SHOW_EPISODE_JSON);

            TraktResponse<ITraktEpisode> response = await client.Shows.GetShowLastEpisodeAsync(SHOW_ID, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisode responseValue = response.Value;

            responseValue.Title.Should().Be("Winter Is Coming");
            responseValue.SeasonNumber.Should().Be(1);
            responseValue.Number.Should().Be(1);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(73640U);
            responseValue.Ids.Tvdb.Should().Be(3254641U);
            responseValue.Ids.Imdb.Should().Be("tt1480055");
            responseValue.Ids.Tmdb.Should().Be(63056U);
            responseValue.Ids.TvRage.Should().Be(1065008299U);
            responseValue.NumberAbsolute.Should().Be(50);
            responseValue.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            responseValue.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            responseValue.Rating.Should().Be(9.0f);
            responseValue.Votes.Should().Be(111);
            responseValue.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(1);
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowLastEpisode_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(SHOW_ID);
            act.Should().Throw<TraktShowNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowLastEpisode_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(SHOW_ID);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowLastEpisode_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(SHOW_ID);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowLastEpisode_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(SHOW_ID);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowLastEpisode_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(SHOW_ID);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowLastEpisode_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(SHOW_ID);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowLastEpisode_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(SHOW_ID);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowLastEpisode_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(SHOW_ID);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowLastEpisode_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(SHOW_ID);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowLastEpisode_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(SHOW_ID);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowLastEpisode_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(SHOW_ID);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowLastEpisode_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowLastEpisode_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowLastEpisode_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowLastEpisode_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowLastEpisode_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(SHOW_ID);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowLastEpisode_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_LAST_EPISODE_URI, SHOW_EPISODE_JSON);

            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowLastEpisodeAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowLastEpisodeAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowLastEpisodeAsync("show id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
