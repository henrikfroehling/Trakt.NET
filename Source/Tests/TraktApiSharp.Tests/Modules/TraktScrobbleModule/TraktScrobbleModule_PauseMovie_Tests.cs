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
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Post.Scrobbles;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Scrobble")]
    public partial class TraktScrobbleModule_Tests
    {
        [Fact]
        public async Task Test_TraktScrobbleModule_PauseMovie()
        {
            ITraktMovieScrobblePost moviePauseScrobblePost = new TraktMovieScrobblePost
            {
                Movie = Movie,
                Progress = PAUSE_PROGRESS
            };

            string postJson = await TestUtility.SerializeObject(moviePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, postJson, MOVIE_PAUSE_SCROBBLE_POST_RESPONSE_JSON);
            TraktResponse<ITraktMovieScrobblePostResponse> response = await client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieScrobblePostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(0);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Pause);
            responseValue.Progress.Should().Be(PAUSE_PROGRESS);
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeFalse();
            responseValue.Sharing.Twitter.Should().BeFalse();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_PauseMovie_With_AppVersion()
        {
            ITraktMovieScrobblePost moviePauseScrobblePost = new TraktMovieScrobblePost
            {
                Movie = Movie,
                Progress = PAUSE_PROGRESS,
                AppVersion = APP_VERSION
            };

            string postJson = await TestUtility.SerializeObject(moviePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, postJson, MOVIE_PAUSE_SCROBBLE_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieScrobblePostResponse> response =
                await client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS, APP_VERSION);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieScrobblePostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(0);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Pause);
            responseValue.Progress.Should().Be(PAUSE_PROGRESS);
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeFalse();
            responseValue.Sharing.Twitter.Should().BeFalse();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_PauseMovie_With_AppDate()
        {
            ITraktMovieScrobblePost moviePauseScrobblePost = new TraktMovieScrobblePost
            {
                Movie = Movie,
                Progress = PAUSE_PROGRESS,
                AppDate = APP_BUILD_DATE.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject(moviePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, postJson, MOVIE_PAUSE_SCROBBLE_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieScrobblePostResponse> response =
                await client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS, null, APP_BUILD_DATE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieScrobblePostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(0);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Pause);
            responseValue.Progress.Should().Be(PAUSE_PROGRESS);
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeFalse();
            responseValue.Sharing.Twitter.Should().BeFalse();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_PauseMovie_With_AppVersion_And_AppDate()
        {
            ITraktMovieScrobblePost moviePauseScrobblePost = new TraktMovieScrobblePost
            {
                Movie = Movie,
                Progress = PAUSE_PROGRESS,
                AppVersion = APP_VERSION,
                AppDate = APP_BUILD_DATE.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject(moviePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, postJson, MOVIE_PAUSE_SCROBBLE_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieScrobblePostResponse> response =
                await client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS, APP_VERSION, APP_BUILD_DATE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieScrobblePostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(0);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Pause);
            responseValue.Progress.Should().Be(PAUSE_PROGRESS);
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeFalse();
            responseValue.Sharing.Twitter.Should().BeFalse();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_PauseMovie_Complete()
        {
            ITraktMovieScrobblePost moviePauseScrobblePost = new TraktMovieScrobblePost
            {
                Movie = Movie,
                Progress = PAUSE_PROGRESS,
                AppVersion = APP_VERSION,
                AppDate = APP_BUILD_DATE.ToTraktDateString()
            };

            string postJson = await TestUtility.SerializeObject(moviePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, postJson, MOVIE_PAUSE_SCROBBLE_POST_RESPONSE_JSON);

            TraktResponse<ITraktMovieScrobblePostResponse> response =
                await client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS, APP_VERSION, APP_BUILD_DATE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull();

            ITraktMovieScrobblePostResponse responseValue = response.Value;

            responseValue.Id.Should().Be(0);
            responseValue.Action.Should().Be(TraktScrobbleActionType.Pause);
            responseValue.Progress.Should().Be(PAUSE_PROGRESS);
            responseValue.Sharing.Should().NotBeNull();
            responseValue.Sharing.Facebook.Should().BeFalse();
            responseValue.Sharing.Twitter.Should().BeFalse();
            responseValue.Sharing.Tumblr.Should().BeFalse();
            responseValue.Movie.Should().NotBeNull();
            responseValue.Movie.Title.Should().Be("Guardians of the Galaxy");
            responseValue.Movie.Year.Should().Be(2014);
            responseValue.Movie.Ids.Should().NotBeNull();
            responseValue.Movie.Ids.Trakt.Should().Be(28U);
            responseValue.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            responseValue.Movie.Ids.Imdb.Should().Be("tt2015381");
            responseValue.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [Fact]
        public void Test_TraktScrobbleModule_PauseMovie_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, HttpStatusCode.NotFound);
            Func<Task<TraktResponse<ITraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS);
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_PauseMovie_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktResponse<ITraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS);
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_PauseMovie_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktResponse<ITraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS);
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_PauseMovie_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktResponse<ITraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS);
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_PauseMovie_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktResponse<ITraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS);
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_PauseMovie_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, HttpStatusCode.Conflict);
            Func<Task<TraktResponse<ITraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS);
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_PauseMovie_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktResponse<ITraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS);
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_PauseMovie_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktResponse<ITraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS);
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_PauseMovie_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, (HttpStatusCode)412);
            Func<Task<TraktResponse<ITraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS);
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_PauseMovie_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, (HttpStatusCode)422);
            Func<Task<TraktResponse<ITraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS);
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_PauseMovie_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, (HttpStatusCode)429);
            Func<Task<TraktResponse<ITraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS);
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_PauseMovie_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, (HttpStatusCode)503);
            Func<Task<TraktResponse<ITraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_PauseMovie_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, (HttpStatusCode)504);
            Func<Task<TraktResponse<ITraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_PauseMovie_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, (HttpStatusCode)520);
            Func<Task<TraktResponse<ITraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_PauseMovie_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, (HttpStatusCode)521);
            Func<Task<TraktResponse<ITraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktScrobbleModule_PauseMovie_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, (HttpStatusCode)522);
            Func<Task<TraktResponse<ITraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(Movie, PAUSE_PROGRESS);
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public async Task Test_TraktScrobbleModule_PauseMovie_ArgumentExceptions()
        {
            ITraktMovie movie = new TraktMovie
            {
                Title = "Guardians of the Galaxy",
                Year = 2014,
                Ids = new TraktMovieIds
                {
                    Trakt = 28,
                    Slug = "guardians-of-the-galaxy-2014",
                    Imdb = "tt2015381",
                    Tmdb = 118340
                }
            };

            ITraktMovieScrobblePost moviePauseScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = PAUSE_PROGRESS
            };

            string postJson = await TestUtility.SerializeObject(moviePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TraktClient client = TestUtility.GetOAuthMockClient(SCROBBLE_PAUSE_URI, postJson, MOVIE_PAUSE_SCROBBLE_POST_RESPONSE_JSON);

            Func<Task<TraktResponse<ITraktMovieScrobblePostResponse>>> act = () => client.Scrobble.PauseMovieAsync(null, PAUSE_PROGRESS);
            act.Should().Throw<ArgumentNullException>();

            movie.Title = string.Empty;

            act = () => client.Scrobble.PauseMovieAsync(movie, PAUSE_PROGRESS);
            act.Should().Throw<ArgumentException>();

            movie.Title = "Guardians of the Galaxy";
            movie.Year = 0;

            act = () => client.Scrobble.PauseMovieAsync(movie, PAUSE_PROGRESS);
            act.Should().Throw<ArgumentOutOfRangeException>();

            movie.Year = 123;

            act = () => client.Scrobble.PauseMovieAsync(movie, PAUSE_PROGRESS);
            act.Should().Throw<ArgumentOutOfRangeException>();

            movie.Year = 12345;

            act = () => client.Scrobble.PauseMovieAsync(movie, PAUSE_PROGRESS);
            act.Should().Throw<ArgumentOutOfRangeException>();

            movie.Year = 2014;
            movie.Ids = null;

            act = () => client.Scrobble.PauseMovieAsync(movie, PAUSE_PROGRESS);
            act.Should().Throw<ArgumentNullException>();

            movie.Ids = new TraktMovieIds();

            act = () => client.Scrobble.PauseMovieAsync(movie, PAUSE_PROGRESS);
            act.Should().Throw<ArgumentException>();

            movie.Ids = new TraktMovieIds
            {
                Trakt = 28,
                Slug = "guardians-of-the-galaxy-2014",
                Imdb = "tt2015381",
                Tmdb = 118340
            };

            act = () => client.Scrobble.PauseMovieAsync(movie, -0.0001f);
            act.Should().Throw<ArgumentOutOfRangeException>();

            act = () => client.Scrobble.PauseMovieAsync(movie, 100.0001f);
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}
