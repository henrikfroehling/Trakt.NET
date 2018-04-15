namespace TraktApiSharp.Tests.Modules.TraktShowsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Shows")]
    public partial class TraktShowsModule_Tests
    {
        [Fact]
        public void Test_TraktShowsModule_GetShowNextEpisode()
        {
            const string showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/next_episode", SHOW_EPISODE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowNextEpisodeAsync(showId).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

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
        public void Test_TraktShowsModule_GetShowNextEpisodeWithExtendedInfo()
        {
            const string showId = "1390";
            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/next_episode?extended={extendedInfo}", SHOW_EPISODE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Shows.GetShowNextEpisodeAsync(showId, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

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
        public void Test_TraktShowsModule_GetShowNextEpisodeExceptions()
        {
            const string showId = "1390";
            var uri = $"shows/{showId}/next_episode";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktEpisode>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowNextEpisodeAsync(showId);
            act.Should().Throw<TraktShowNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktShowsModule_GetShowNextEpisodeArgumentExceptions()
        {
            const string showId = "1390";

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/next_episode", SHOW_EPISODE_JSON);

            Func<Task<TraktResponse<ITraktEpisode>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowNextEpisodeAsync(null);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowNextEpisodeAsync(string.Empty);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Shows.GetShowNextEpisodeAsync("show id");
            act.Should().Throw<ArgumentException>();
        }
    }
}
