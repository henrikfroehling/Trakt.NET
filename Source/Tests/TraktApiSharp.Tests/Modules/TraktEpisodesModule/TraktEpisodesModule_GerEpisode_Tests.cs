namespace TraktApiSharp.Tests.Modules.TraktEpisodesModule
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

    [Category("Modules.Episodes")]
    public partial class TraktEpisodesModule_Tests
    {
        [Fact]
        public void Test_TraktEpisodesModule_GetEpisode()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", EPISODE_SUMMARY_FULL_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Title.Should().Be("Winter Is Coming");
            responseValue.SeasonNumber.Should().Be(1);
            responseValue.Number.Should().Be(1);
            responseValue.NumberAbsolute.Should().Be(50);
            responseValue.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            responseValue.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            responseValue.Rating.Should().Be(9.0f);
            responseValue.Votes.Should().Be(111);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(73640U);
            responseValue.Ids.Tvdb.Should().Be(3254641U);
            responseValue.Ids.Imdb.Should().Be("tt1480055");
            responseValue.Ids.Tmdb.Should().Be(63056U);
            responseValue.Ids.TvRage.Should().Be(1065008299U);
            responseValue.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(1);
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeWithExtendedInfo()
        {
            const string showId = "1390";
            const uint seasonNr = 1U;
            const uint episodeNr = 1U;

            var extendedInfo = new TraktExtendedInfo { Full = true };

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}?extended={extendedInfo}",
                                                      EPISODE_SUMMARY_FULL_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr, extendedInfo).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Title.Should().Be("Winter Is Coming");
            responseValue.SeasonNumber.Should().Be(1);
            responseValue.Number.Should().Be(1);
            responseValue.NumberAbsolute.Should().Be(50);
            responseValue.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            responseValue.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            responseValue.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            responseValue.Rating.Should().Be(9.0f);
            responseValue.Votes.Should().Be(111);
            responseValue.Ids.Should().NotBeNull();
            responseValue.Ids.Trakt.Should().Be(73640U);
            responseValue.Ids.Tvdb.Should().Be(3254641U);
            responseValue.Ids.Imdb.Should().Be("tt1480055");
            responseValue.Ids.Tmdb.Should().Be(63056U);
            responseValue.Ids.TvRage.Should().Be(1065008299U);
            responseValue.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(1);
        }

        [Fact]
        public void Test_TraktEpisodesModule_GetEpisodeExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 0U;
            const uint episodeNr = 1U;
            var uri = $"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);

            Func<Task<TraktResponse<ITraktEpisode>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, episodeNr);
            act.Should().Throw<TraktEpisodeNotFoundException>();

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
        public void Test_TraktEpisodesModule_GetEpisodeArgumentExceptions()
        {
            const string showId = "1390";
            const uint seasonNr = 0U;
            const uint episodeNr = 1U;

            TestUtility.SetupMockResponseWithoutOAuth($"shows/{showId}/seasons/{seasonNr}/episodes/{episodeNr}", EPISODE_SUMMARY_FULL_JSON);

            Func<Task<TraktResponse<ITraktEpisode>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(null, seasonNr, episodeNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(string.Empty, seasonNr, episodeNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync("show id", seasonNr, episodeNr);
            act.Should().Throw<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Episodes.GetEpisodeAsync(showId, seasonNr, 0);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
