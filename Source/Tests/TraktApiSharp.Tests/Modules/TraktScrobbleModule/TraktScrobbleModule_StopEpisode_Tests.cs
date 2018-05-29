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
    using TraktApiSharp.Objects.Post.Scrobbles;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Scrobble")]
    public partial class TraktScrobbleModule_Tests
    {
        [Fact]
        public async Task Test_TraktScrobbleModule_StopEpisode()
        {
            ITraktEpisodeScrobblePost episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = Episode,
                Progress = STOP_PROGRESS
            };

            string postJson = await TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, postJson, EPISODE_STOP_SCROBBLE_POST_RESPONSE_JSON);
            TraktResponse<ITraktEpisodeScrobblePostResponse> response = await client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeScrobblePostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536623);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Stop);
            responseValue.Progress.Should().Be(STOP_PROGRESS);
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
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_StopEpisode_With_AppVersion()
        {
            ITraktEpisodeScrobblePost episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = Episode,
                Progress = STOP_PROGRESS,
                AppVersion = APP_VERSION
            };

            string postJson = await TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, postJson, EPISODE_STOP_SCROBBLE_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeScrobblePostResponse> response =
                await client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS, APP_VERSION);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeScrobblePostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536623);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Stop);
            responseValue.Progress.Should().Be(STOP_PROGRESS);
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
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_StopEpisode_With_AppDate()
        {
            ITraktEpisodeScrobblePost episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = Episode,
                Progress = STOP_PROGRESS,
                AppDate = APP_BUILD_DATE.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, postJson, EPISODE_STOP_SCROBBLE_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeScrobblePostResponse> response =
                await client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS, null, APP_BUILD_DATE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeScrobblePostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536623);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Stop);
            responseValue.Progress.Should().Be(STOP_PROGRESS);
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
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_StopEpisode_With_AppVersion_And_AppDate()
        {
            ITraktEpisodeScrobblePost episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = Episode,
                Progress = STOP_PROGRESS,
                AppVersion = APP_VERSION,
                AppDate = APP_BUILD_DATE.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, postJson, EPISODE_STOP_SCROBBLE_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeScrobblePostResponse> response =
                await client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS, APP_VERSION, APP_BUILD_DATE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeScrobblePostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536623);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Stop);
            responseValue.Progress.Should().Be(STOP_PROGRESS);
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
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_StopEpisode_Complete()
        {
            ITraktEpisodeScrobblePost episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = Episode,
                Progress = STOP_PROGRESS,
                AppVersion = APP_VERSION,
                AppDate = APP_BUILD_DATE.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, postJson, EPISODE_STOP_SCROBBLE_POST_RESPONSE_JSON);

            TraktResponse<ITraktEpisodeScrobblePostResponse> response =
                await client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS, APP_VERSION, APP_BUILD_DATE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktEpisodeScrobblePostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(3373536623);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Stop);
            responseValue.Progress.Should().Be(STOP_PROGRESS);
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
        }

        [Fact]
        public void Test_TraktScrobbleModule_StopEpisode_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StopEpisode_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StopEpisode_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StopEpisode_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StopEpisode_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StopEpisode_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StopEpisode_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StopEpisode_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StopEpisode_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StopEpisode_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StopEpisode_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StopEpisode_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StopEpisode_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StopEpisode_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StopEpisode_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_StopEpisode_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_STOP_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktEpisodeScrobblePostResponse>>> act = () => client.Scrobble.StopEpisodeAsync(Episode, STOP_PROGRESS);
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
