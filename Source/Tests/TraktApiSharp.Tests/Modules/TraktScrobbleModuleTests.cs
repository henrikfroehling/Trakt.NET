namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Post.Scrobbles;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses;
    using TraktApiSharp.Requests;
    using Utils;

    [TestClass]
    public class TraktScrobbleModuleTests
    {
        [TestMethod]
        public void TestTraktScrobbleModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktScrobbleModule)).Should().BeTrue();
        }

        [ClassInitialize]
        public static void InitializeTests(TestContext context)
        {
            TestUtility.SetupMockHttpClient();
        }

        [ClassCleanup]
        public static void CleanupTests()
        {
            TestUtility.ResetMockHttpClient();
        }

        [TestCleanup]
        public void CleanupSingleTest()
        {
            TestUtility.ClearMockHttpClient();
        }

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region StartMovie

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovie()
        {
            var movieStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStartScrobblePostResponse.json");
            movieStartScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 1.25f;

            var movieStartScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(movieStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/start", postJson, movieStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(movie, progress).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Guardians of the Galaxy");
            response.Movie.Year.Should().Be(2014);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(28);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieWithAppVersion()
        {
            var movieStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStartScrobblePostResponse.json");
            movieStartScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 1.25f;
            var appVersion = "app_version";

            var movieStartScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(movieStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/start", postJson, movieStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(movie, progress, appVersion).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Guardians of the Galaxy");
            response.Movie.Year.Should().Be(2014);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(28);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieWithAppDate()
        {
            var movieStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStartScrobblePostResponse.json");
            movieStartScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 1.25f;
            var appBuildDate = DateTime.UtcNow;

            var movieStartScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(movieStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/start", postJson, movieStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(movie, progress, null, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Guardians of the Galaxy");
            response.Movie.Year.Should().Be(2014);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(28);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieWithExtendedOption()
        {
            var movieStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStartScrobblePostResponse.json");
            movieStartScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 1.25f;

            var movieStartScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(movieStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/start?extended={extendedOption.ToString()}", postJson, movieStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(movie, progress, null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Guardians of the Galaxy");
            response.Movie.Year.Should().Be(2014);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(28);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieWithAppVersionAndAppDate()
        {
            var movieStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStartScrobblePostResponse.json");
            movieStartScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 1.25f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var movieStartScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(movieStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/start", postJson, movieStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(movie, progress, appVersion, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Guardians of the Galaxy");
            response.Movie.Year.Should().Be(2014);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(28);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieWithAppVersionAndExtendedOption()
        {
            var movieStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStartScrobblePostResponse.json");
            movieStartScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 1.25f;
            var appVersion = "app_version";

            var movieStartScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(movieStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/start?extended={extendedOption.ToString()}", postJson, movieStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(movie, progress, appVersion, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Guardians of the Galaxy");
            response.Movie.Year.Should().Be(2014);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(28);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieWithAppDateAndExtendedOption()
        {
            var movieStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStartScrobblePostResponse.json");
            movieStartScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 1.25f;
            var appBuildDate = DateTime.UtcNow;

            var movieStartScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(movieStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/start?extended={extendedOption.ToString()}", postJson, movieStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(movie, progress, null, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Guardians of the Galaxy");
            response.Movie.Year.Should().Be(2014);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(28);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieComplete()
        {
            var movieStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStartScrobblePostResponse.json");
            movieStartScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 1.25f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var movieStartScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(movieStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/start?extended={extendedOption.ToString()}", postJson, movieStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(movie, progress, appVersion, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Guardians of the Galaxy");
            response.Movie.Year.Should().Be(2014);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(28);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieExceptions()
        {
            var movie = new TraktMovie
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

            var progress = 1.25f;

            var uri = "scrobble/start";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktMovieScrobblePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(movie, progress);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartMovieArgumentExceptions()
        {
            var movieStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStartScrobblePostResponse.json");
            movieStartScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 1.25f;

            var movieStartScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(movieStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/start", postJson, movieStartScrobbleResponse);

            Func<Task<TraktMovieScrobblePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(null, progress);

            act.ShouldThrow<ArgumentException>();

            movie.Title = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(movie, progress);
            act.ShouldThrow<ArgumentException>();

            movie.Title = "Guardians of the Galaxy";
            movie.Year = 0;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(movie, progress);
            act.ShouldThrow<ArgumentException>();

            movie.Year = 2014;
            movie.Ids = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(movie, progress);
            act.ShouldThrow<ArgumentException>();

            movie.Ids = new TraktMovieIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(movie, progress);
            act.ShouldThrow<ArgumentException>();

            movie.Ids = new TraktMovieIds
            {
                Trakt = 28,
                Slug = "guardians-of-the-galaxy-2014",
                Imdb = "tt2015381",
                Tmdb = 118340
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(movie, -0.01f);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(movie, 100.01f);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PauseMovie

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovie()
        {
            var moviePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MoviePauseScrobblePostResponse.json");
            moviePauseScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 75.0f;

            var moviePauseScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(moviePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, moviePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(movie, progress).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeFalse();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Guardians of the Galaxy");
            response.Movie.Year.Should().Be(2014);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(28);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieWithAppVersion()
        {
            var moviePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MoviePauseScrobblePostResponse.json");
            moviePauseScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 75.0f;
            var appVersion = "app_version";

            var moviePauseScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(moviePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, moviePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(movie, progress, appVersion).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeFalse();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Guardians of the Galaxy");
            response.Movie.Year.Should().Be(2014);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(28);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieWithAppDate()
        {
            var moviePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MoviePauseScrobblePostResponse.json");
            moviePauseScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 75.0f;
            var appBuildDate = DateTime.UtcNow;

            var moviePauseScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(moviePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, moviePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(movie, progress, null, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeFalse();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Guardians of the Galaxy");
            response.Movie.Year.Should().Be(2014);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(28);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieWithExtendedOption()
        {
            var moviePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MoviePauseScrobblePostResponse.json");
            moviePauseScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 75.0f;

            var moviePauseScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(moviePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/pause?extended={extendedOption.ToString()}", postJson, moviePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(movie, progress, null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeFalse();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Guardians of the Galaxy");
            response.Movie.Year.Should().Be(2014);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(28);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieWithAppVersionAndAppDate()
        {
            var moviePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MoviePauseScrobblePostResponse.json");
            moviePauseScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 75.0f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var moviePauseScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(moviePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, moviePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(movie, progress, appVersion, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeFalse();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Guardians of the Galaxy");
            response.Movie.Year.Should().Be(2014);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(28);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieWithAppVersionAndExtendedOption()
        {
            var moviePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MoviePauseScrobblePostResponse.json");
            moviePauseScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 75.0f;
            var appVersion = "app_version";

            var moviePauseScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(moviePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/pause?extended={extendedOption.ToString()}", postJson, moviePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(movie, progress, appVersion, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeFalse();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Guardians of the Galaxy");
            response.Movie.Year.Should().Be(2014);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(28);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieWithAppDateAndExtendedOption()
        {
            var moviePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MoviePauseScrobblePostResponse.json");
            moviePauseScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 75.0f;
            var appBuildDate = DateTime.UtcNow;

            var moviePauseScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(moviePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/pause?extended={extendedOption.ToString()}", postJson, moviePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(movie, progress, null, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeFalse();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Guardians of the Galaxy");
            response.Movie.Year.Should().Be(2014);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(28);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieComplete()
        {
            var moviePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MoviePauseScrobblePostResponse.json");
            moviePauseScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 75.0f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var moviePauseScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(moviePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/pause?extended={extendedOption.ToString()}", postJson, moviePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(movie, progress, appVersion, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeFalse();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Movie.Should().NotBeNull();
            response.Movie.Title.Should().Be("Guardians of the Galaxy");
            response.Movie.Year.Should().Be(2014);
            response.Movie.Ids.Should().NotBeNull();
            response.Movie.Ids.Trakt.Should().Be(28);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieExceptions()
        {
            var movie = new TraktMovie
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

            var progress = 75.0f;

            var uri = "scrobble/pause";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktMovieScrobblePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(movie, progress);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)503);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)504);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)520);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)521);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)522);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseMovieArgumentExceptions()
        {
            var moviePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MoviePauseScrobblePostResponse.json");
            moviePauseScrobbleResponse.Should().NotBeNullOrEmpty();

            var movie = new TraktMovie
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

            var progress = 1.25f;

            var moviePauseScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(moviePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, moviePauseScrobbleResponse);

            Func<Task<TraktMovieScrobblePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(null, progress);

            act.ShouldThrow<ArgumentException>();

            movie.Title = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(movie, progress);
            act.ShouldThrow<ArgumentException>();

            movie.Title = "Guardians of the Galaxy";
            movie.Year = 0;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(movie, progress);
            act.ShouldThrow<ArgumentException>();

            movie.Year = 2014;
            movie.Ids = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(movie, progress);
            act.ShouldThrow<ArgumentException>();

            movie.Ids = new TraktMovieIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(movie, progress);
            act.ShouldThrow<ArgumentException>();

            movie.Ids = new TraktMovieIds
            {
                Trakt = 28,
                Slug = "guardians-of-the-galaxy-2014",
                Imdb = "tt2015381",
                Tmdb = 118340
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(movie, -0.01f);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(movie, 100.01f);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region StopMovie

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovie()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovieWithAppVersion()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulevMovieWithAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovieWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovieWithAppVersionAndAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovieWithAppVersionAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovieWithAppDateAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovieComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovieExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovieArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region StartEpisode

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisode()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithAppVersion()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithAppVersionAndAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithAppVersionAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithAppDateAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PauseMovie

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisode()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithAppVersion()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithAppVersionAndAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithAppVersionAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithAppDateAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region StopMovie

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisode()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithAppVersion()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModulevEpisodeWithAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithAppVersionAndAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithAppVersionAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithAppDateAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
