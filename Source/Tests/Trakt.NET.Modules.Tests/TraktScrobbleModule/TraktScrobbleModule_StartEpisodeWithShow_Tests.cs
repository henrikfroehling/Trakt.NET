namespace TraktNet.Modules.Tests.TraktScrobbleModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Exceptions;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Post.Scrobbles;
    using TraktNet.Objects.Post.Scrobbles.Responses;
    using TraktNet.Responses;
    using Xunit;

    [Category("Modules.Scrobble")]
    public partial class TraktScrobbleModule_Tests
    {
        [Fact]
        public async Task Test_TraktScrobbleModule_StartEpisodeWithShow()
        {
            ITraktEpisodeScrobblePost episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = Episode,
                Show = Show,
                Progress = START_PROGRESS
            };

            string postJson = await TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, postJson, EPISODE_START_SCROBBLE_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeScrobblePostResponse> response =
                await client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeScrobblePostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(0);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Start);
            responseValue.Progress.Should().Be(START_PROGRESS);
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
            responseValue.Show.Should().NotBeNull();
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
        public async Task Test_TraktScrobbleModule_StartEpisodeWithShow_And_AppVersion()
        {
            ITraktEpisodeScrobblePost episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = Episode,
                Show = Show,
                Progress = START_PROGRESS,
                AppVersion = APP_VERSION
            };

            string postJson = await TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, postJson, EPISODE_START_SCROBBLE_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeScrobblePostResponse> response =
                await client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS, APP_VERSION);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeScrobblePostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(0);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Start);
            responseValue.Progress.Should().Be(START_PROGRESS);
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
            responseValue.Show.Should().NotBeNull();
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
        public async Task Test_TraktScrobbleModule_StartEpisodeWithShow_And_AppDate()
        {
            ITraktEpisodeScrobblePost episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = Episode,
                Show = Show,
                Progress = START_PROGRESS,
                AppDate = APP_BUILD_DATE.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, postJson, EPISODE_START_SCROBBLE_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeScrobblePostResponse> response =
                await client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS, null, APP_BUILD_DATE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeScrobblePostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(0);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Start);
            responseValue.Progress.Should().Be(START_PROGRESS);
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
            responseValue.Show.Should().NotBeNull();
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
        public async Task Test_TraktScrobbleModule_StartEpisodeWithShow_And_AppVersion_And_AppDate()
        {
            ITraktEpisodeScrobblePost episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = Episode,
                Show = Show,
                Progress = START_PROGRESS,
                AppVersion = APP_VERSION,
                AppDate = APP_BUILD_DATE.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, postJson, EPISODE_START_SCROBBLE_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeScrobblePostResponse> response =
                await client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS, APP_VERSION, APP_BUILD_DATE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeScrobblePostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(0);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Start);
            responseValue.Progress.Should().Be(START_PROGRESS);
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
            responseValue.Show.Should().NotBeNull();
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
        public async Task Test_TraktScrobbleModule_StartEpisodeWithShow_Complete()
        {
            ITraktEpisodeScrobblePost episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = Episode,
                Show = Show,
                Progress = START_PROGRESS,
                AppVersion = APP_VERSION,
                AppDate = APP_BUILD_DATE.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, postJson, EPISODE_START_SCROBBLE_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeScrobblePostResponse> response =
                await client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS, APP_VERSION, APP_BUILD_DATE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeScrobblePostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(0);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Start);
            responseValue.Progress.Should().Be(START_PROGRESS);
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
            responseValue.Show.Should().NotBeNull();
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
        public void Test_TraktScrobbleModule_StartEpisodeWithShow_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StartEpisodeWithShow_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StartEpisodeWithShow_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StartEpisodeWithShow_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StartEpisodeWithShow_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StartEpisodeWithShow_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StartEpisodeWithShow_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StartEpisodeWithShow_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StartEpisodeWithShow_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StartEpisodeWithShow_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StartEpisodeWithShow_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StartEpisodeWithShow_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StartEpisodeWithShow_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StartEpisodeWithShow_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StartEpisodeWithShow_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StartEpisodeWithShow_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeWithShowAsync(Episode, Show, START_PROGRESS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_StartEpisodeWithShow_ArgumentExceptions()
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

            ITraktEpisodeScrobblePost episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = START_PROGRESS
            };

            string postJson = await TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_START_URI, postJson, EPISODE_START_SCROBBLE_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StartEpisodeAsync(null, START_PROGRESS);
            act.Should().Throw<ArgumentNullException>();

            episode.Ids = null;

            act = () => client.Scrobble.StartEpisodeAsync(episode, START_PROGRESS);
            act.Should().Throw<ArgumentNullException>();

            episode.Ids = new TraktEpisodeIds();

            act = () => client.Scrobble.StartEpisodeAsync(episode, START_PROGRESS);
            act.Should().Throw<ArgumentNullException>();

            episode.Ids = new TraktEpisodeIds
            {
                Trakt = 16,
                Tvdb = 349232,
                Imdb = "tt0959621",
                Tmdb = 62085,
                TvRage = 637041
            };

            act = () => client.Scrobble.StartEpisodeAsync(episode, -0.0001f);
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => client.Scrobble.StartEpisodeAsync(episode, 100.0001f);
            act.Should().Throw<ArgumentOutOfRangeException>();

            episode.Ids = null;
            episode.SeasonNumber = -1;

            act = () => client.Scrobble.StartEpisodeWithShowAsync(episode, show, START_PROGRESS);
            act.Should().Throw<ArgumentOutOfRangeException>();

            episode.Ids = new TraktEpisodeIds();

            act = () => client.Scrobble.StartEpisodeWithShowAsync(episode, show, START_PROGRESS);
            act.Should().Throw<ArgumentException>();

            episode.Ids = null;
            episode.SeasonNumber = 0;
            episode.Number = 0;

            act = () => client.Scrobble.StartEpisodeWithShowAsync(episode, show, START_PROGRESS);
            act.Should().Throw<ArgumentOutOfRangeException>();

            episode.Ids = new TraktEpisodeIds();
            episode.Number = 0;

            act = () => client.Scrobble.StartEpisodeWithShowAsync(episode, show, START_PROGRESS);
            act.Should().Throw<ArgumentOutOfRangeException>();

            episode.Ids = null;
            episode.Number = 1;
            show.Title = string.Empty;

            act = () => client.Scrobble.StartEpisodeWithShowAsync(episode, show, START_PROGRESS);
            act.Should().Throw<ArgumentException>();

            episode.Ids = new TraktEpisodeIds();

            act = () => client.Scrobble.StartEpisodeWithShowAsync(episode, show, START_PROGRESS);
            act.Should().Throw<ArgumentException>();

            episode.Ids = null;
            show.Title = "Breaking Bad";

            act = () => client.Scrobble.StartEpisodeWithShowAsync(episode, show, -0.0001f);
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => client.Scrobble.StartEpisodeWithShowAsync(episode, show, 100.0001f);
            act.Should().Throw<ArgumentOutOfRangeException>();

            episode.Ids = new TraktEpisodeIds();

            act = () => client.Scrobble.StartEpisodeWithShowAsync(episode, show, -0.0001f);
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => client.Scrobble.StartEpisodeWithShowAsync(episode, show, 100.0001f);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
