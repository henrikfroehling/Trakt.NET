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
        public async Task Test_TraktScrobbleModule_PauseEpisode()
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

            const float progress = 75.0f;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress
            };

            string postJson = await TestUtility.SerializeObject<ITraktEpisodeScrobblePost>(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, EPISODE_PAUSE_SCROBBLE_POST_RESPONSE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(0);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Pause);
            responseValue.Progress.Should().Be(progress);
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeFalse();
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
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_PauseEpisodeWithAppVersion()
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

            const float progress = 75.0f;
            const string appVersion = "app_version";

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppVersion = appVersion
            };

            string postJson = await TestUtility.SerializeObject<ITraktEpisodeScrobblePost>(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, EPISODE_PAUSE_SCROBBLE_POST_RESPONSE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, appVersion).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(0);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Pause);
            responseValue.Progress.Should().Be(progress);
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeFalse();
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
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_PauseEpisodeWithAppDate()
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

            const float progress = 75.0f;
            var appBuildDate = DateTime.UtcNow;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppDate = appBuildDate.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject<ITraktEpisodeScrobblePost>(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, EPISODE_PAUSE_SCROBBLE_POST_RESPONSE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, null, appBuildDate).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(0);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Pause);
            responseValue.Progress.Should().Be(progress);
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeFalse();
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
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_PauseEpisodeWithAppVersionAndAppDate()
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

            const float progress = 75.0f;
            const string appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject<ITraktEpisodeScrobblePost>(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, EPISODE_PAUSE_SCROBBLE_POST_RESPONSE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, appVersion, appBuildDate).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(0);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Pause);
            responseValue.Progress.Should().Be(progress);
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeFalse();
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
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_PauseEpisodeComplete()
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

            const float progress = 75.0f;
            const string appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject<ITraktEpisodeScrobblePost>(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, EPISODE_PAUSE_SCROBBLE_POST_RESPONSE_JSON);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, appVersion, appBuildDate).Result;

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            var responseValue = response.Value;

            responseValue.Id.Should().Be(0);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Pause);
            responseValue.Progress.Should().Be(progress);
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeFalse();
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
        }

        [Fact]
        public void Test_TraktScrobbleModule_PauseEpisodeExceptions()
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

            const float progress = 75.0f;
            const string uri = "scrobble/pause";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress);
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

        [Fact]
        public async Task Test_TraktScrobbleModule_PauseEpisodeArgumentExceptions()
        {
            var episode = new TraktEpisode
            {
                SeasonNumber = 0,
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

            const float progress = 10.0f;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress
            };

            string postJson = await TestUtility.SerializeObject<ITraktEpisodeScrobblePost>(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, EPISODE_PAUSE_SCROBBLE_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(null, progress);

            act.Should().Throw<ArgumentNullException>();

            episode.Ids = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress);
            act.Should().Throw<ArgumentNullException>();

            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress);
            act.Should().Throw<ArgumentNullException>();

            episode.Ids = new TraktEpisodeIds
            {
                Trakt = 16,
                Tvdb = 349232,
                Imdb = "tt0959621",
                Tmdb = 62085,
                TvRage = 637041
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, -0.0001f);
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, 100.0001f);
            act.Should().Throw<ArgumentOutOfRangeException>();

            episode.Ids = null;
            episode.SeasonNumber = -1;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeWithShowAsync(episode, show, progress);
            act.Should().Throw<ArgumentOutOfRangeException>();

            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeWithShowAsync(episode, show, progress);
            act.Should().Throw<ArgumentOutOfRangeException>();

            episode.Ids = null;
            episode.SeasonNumber = 0;
            episode.Number = 0;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeWithShowAsync(episode, show, progress);
            act.Should().Throw<ArgumentOutOfRangeException>();

            episode.Ids = new TraktEpisodeIds();
            episode.Number = 0;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeWithShowAsync(episode, show, progress);
            act.Should().Throw<ArgumentOutOfRangeException>();

            episode.Ids = null;
            episode.Number = 1;
            show.Title = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeWithShowAsync(episode, show, progress);
            act.Should().Throw<ArgumentException>();

            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeWithShowAsync(episode, show, progress);
            act.Should().Throw<ArgumentException>();

            episode.Ids = null;
            show.Title = "Breaking Bad";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeWithShowAsync(episode, show, -0.0001f);
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeWithShowAsync(episode, show, 100.0001f);
            act.Should().Throw<ArgumentOutOfRangeException>();

            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeWithShowAsync(episode, show, -0.0001f);
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeWithShowAsync(episode, show, 100.0001f);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
