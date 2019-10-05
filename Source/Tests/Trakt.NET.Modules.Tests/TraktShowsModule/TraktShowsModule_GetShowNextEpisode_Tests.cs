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
        private readonly string GET_SHOW_NEXT_EPISODE_URI = $"shows/{SHOW_ID}/next_episode";

        [Fact]
        public async Task Test_TraktShowsModule_GetShowNextEpisode()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_NEXT_EPISODE_URI, SHOW_EPISODE_JSON);
            TraktResponse<ITraktEpisode> response = await client.Shows.GetShowNextEpisodeAsync(SHOW_ID);

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
        public async Task Test_TraktShowsModule_GetShowNextEpisode_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_SHOW_NEXT_EPISODE_URI}?extended={EXTENDED_INFO}",
                SHOW_EPISODE_JSON);

            TraktResponse<ITraktEpisode> response = await client.Shows.GetShowNextEpisodeAsync(SHOW_ID, EXTENDED_INFO);

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

        [Theory]
        [InlineData(HttpStatusCode.NotFound, typeof(TraktShowNotFoundException))]
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
        public async Task Test_TraktShowsModule_GetShowNextEpisode_Throws_API_Exception(HttpStatusCode statusCode, Type exceptionType)
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_NEXT_EPISODE_URI, statusCode);

            try
            {
                await client.Shows.GetShowNextEpisodeAsync(SHOW_ID);
                Assert.False(true);
            }
            catch (Exception exception)
            {
                (exception.GetType() == exceptionType).Should().BeTrue();
            }
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowNextEpisode_ArgumentExceptions()
        {
            TraktClient client = TestUtility.GetMockClient(GET_SHOW_NEXT_EPISODE_URI, SHOW_EPISODE_JSON);

            Func<Task<TraktResponse<ITraktEpisode>>> act = () => client.Shows.GetShowNextEpisodeAsync(null);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowNextEpisodeAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = () => client.Shows.GetShowNextEpisodeAsync("show id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
