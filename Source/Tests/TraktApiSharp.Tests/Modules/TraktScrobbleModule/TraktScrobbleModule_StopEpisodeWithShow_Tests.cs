namespace TraktApiSharp.Tests.Modules.TraktScrobbleModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Objects.Get.Shows.Implementations;
    using TraktApiSharp.Objects.Post.Scrobbles;
    using TraktApiSharp.Objects.Post.Scrobbles.Implementations;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Scrobble")]
    public partial class TraktScrobbleModule_Tests
    {
        [Fact]
        public async Task Test_TraktScrobbleModule_StopEpisodeWithShow()
        {
            var episode = new TraktEpisode
            {
                SeasonNumber = 1,
                Number = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow
            {
                Title = "Breaking Bad"
            };

            const float progress = 85.0f;

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress
            };

            string postJson = await TestUtility.SerializeObject<ITraktEpisodeScrobblePost>(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, EPISODE_STOP_SCROBBLE_POST_RESPONSE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeWithShowAsync(episode, show, progress).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(3373536623);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Stop);
            responseValue.Progress.Should().Be(progress);
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_StopEpisodeWithShowAndAppVersion()
        {
            var episode = new TraktEpisode
            {
                SeasonNumber = 1,
                Number = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow
            {
                Title = "Breaking Bad"
            };

            const float progress = 85.0f;
            const string appVersion = "app_version";

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppVersion = appVersion
            };

            string postJson = await TestUtility.SerializeObject<ITraktEpisodeScrobblePost>(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, EPISODE_STOP_SCROBBLE_POST_RESPONSE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeWithShowAsync(episode, show, progress, appVersion).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(3373536623);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Stop);
            responseValue.Progress.Should().Be(progress);
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_StopEpisodeWithShowAndAppDate()
        {
            var episode = new TraktEpisode
            {
                SeasonNumber = 1,
                Number = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow
            {
                Title = "Breaking Bad"
            };

            const float progress = 85.0f;
            var appBuildDate = DateTime.UtcNow;

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppDate = appBuildDate.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject<ITraktEpisodeScrobblePost>(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, EPISODE_STOP_SCROBBLE_POST_RESPONSE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeWithShowAsync(episode, show, progress, null, appBuildDate).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(3373536623);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Stop);
            responseValue.Progress.Should().Be(progress);
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_StopEpisodeWithShowAndAppVersionAndAppDate()
        {
            var episode = new TraktEpisode
            {
                SeasonNumber = 1,
                Number = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow
            {
                Title = "Breaking Bad"
            };

            const float progress = 85.0f;
            const string appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject<ITraktEpisodeScrobblePost>(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, EPISODE_STOP_SCROBBLE_POST_RESPONSE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeWithShowAsync(episode, show, progress, appVersion, appBuildDate).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(3373536623);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Stop);
            responseValue.Progress.Should().Be(progress);
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_StopEpisodeWithShowComplete()
        {
            var episode = new TraktEpisode
            {
                SeasonNumber = 1,
                Number = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow
            {
                Title = "Breaking Bad"
            };

            const float progress = 85.0f;
            const string appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject<ITraktEpisodeScrobblePost>(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, EPISODE_STOP_SCROBBLE_POST_RESPONSE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeWithShowAsync(episode, show, progress, appVersion, appBuildDate).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(3373536623);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Stop);
            responseValue.Progress.Should().Be(progress);
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeTrue();
            responseValue.Sharing.Twitter.Should().BeTrue();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Episode.Should().NotBeNull();
            responseValue.Episode.SeasonNumber.Should().Be(1);
            responseValue.Episode.Number.Should().Be(1);
            responseValue.Episode.Title.Should().Be("Pilot");
            responseValue.Episode.Ids.Should().NotBeNull();
            responseValue.Episode.Ids.Trakt.Should().Be(16U);
            responseValue.Episode.Ids.Tvdb.Should().Be(349232U);
            responseValue.Episode.Ids.Imdb.Should().Be("tt0959621");
            responseValue.Episode.Ids.Tmdb.Should().Be(62085U);
            responseValue.Episode.Ids.TvRage.Should().Be(637041U);
            responseValue.Show.Title.Should().Be("Breaking Bad");
            responseValue.Show.Year.Should().Be(2008);
            responseValue.Show.Ids.Should().NotBeNull();
            responseValue.Show.Ids.Trakt.Should().Be(1U);
            responseValue.Show.Ids.Slug.Should().Be("breaking-bad");
            responseValue.Show.Ids.Tvdb.Should().Be(81189U);
            responseValue.Show.Ids.Imdb.Should().Be("tt0903747");
            responseValue.Show.Ids.Tmdb.Should().Be(1396U);
            responseValue.Show.Ids.TvRage.Should().Be(18164U);
        }

        [Fact]
        public void Test_TraktScrobbleModule_StopEpisodeWithShowExceptions()
        {
            var episode = new TraktEpisode
            {
                SeasonNumber = 1,
                Number = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow
            {
                Title = "Breaking Bad"
            };

            const float progress = 75.0f;
            const string uri = "scrobble/stop";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeWithShowAsync(episode, show, progress);
            act.Should().Throw<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.Should().Throw<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.Should().Throw<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.Should().Throw<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.Should().Throw<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.Should().Throw<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.Should().Throw<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.Should().Throw<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.Should().Throw<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.Should().Throw<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.Should().Throw<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.Should().Throw<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
