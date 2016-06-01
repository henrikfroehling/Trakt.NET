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
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
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

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(movie, -0.0001f);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartMovieAsync(movie, 100.0001f);
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

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(movie, -0.0001f);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseMovieAsync(movie, 100.0001f);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region StopMovie

        [TestMethod]
        public void TestTraktScrobbleModuleStopMovie()
        {
            var movieStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStopScrobblePostResponse.json");
            movieStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;

            var movieStopScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(movieStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, movieStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopMovieAsync(movie, progress).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
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
        public void TestTraktScrobbleModuleStopMovieWithAppVersion()
        {
            var movieStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStopScrobblePostResponse.json");
            movieStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appVersion = "app_version";

            var movieStopScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(movieStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, movieStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopMovieAsync(movie, progress, appVersion).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
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
        public void TestTraktScrobbleModulevMovieWithAppDate()
        {
            var movieStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStopScrobblePostResponse.json");
            movieStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appBuildDate = DateTime.UtcNow;

            var movieStopScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(movieStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, movieStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopMovieAsync(movie, progress, null, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
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
        public void TestTraktScrobbleModuleStopMovieWithExtendedOption()
        {
            var movieStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStopScrobblePostResponse.json");
            movieStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;

            var movieStopScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(movieStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/stop?extended={extendedOption.ToString()}", postJson, movieStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopMovieAsync(movie, progress, null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
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
        public void TestTraktScrobbleModuleStopMovieWithAppVersionAndAppDate()
        {
            var movieStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStopScrobblePostResponse.json");
            movieStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var movieStopScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(movieStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, movieStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopMovieAsync(movie, progress, appVersion, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
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
        public void TestTraktScrobbleModuleStopMovieWithAppVersionAndExtendedOption()
        {
            var movieStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStopScrobblePostResponse.json");
            movieStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appVersion = "app_version";

            var movieStopScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(movieStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/stop?extended={extendedOption.ToString()}", postJson, movieStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopMovieAsync(movie, progress, appVersion, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
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
        public void TestTraktScrobbleModuleStopMovieWithAppDateAndExtendedOption()
        {
            var movieStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStopScrobblePostResponse.json");
            movieStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appBuildDate = DateTime.UtcNow;

            var movieStopScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(movieStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/stop?extended={extendedOption.ToString()}", postJson, movieStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopMovieAsync(movie, progress, null, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
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
        public void TestTraktScrobbleModuleStopMovieComplete()
        {
            var movieStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStopScrobblePostResponse.json");
            movieStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var movieStopScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(movieStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/stop?extended={extendedOption.ToString()}", postJson, movieStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopMovieAsync(movie, progress, appVersion, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
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
        public void TestTraktScrobbleModuleStopMovieExceptions()
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

            var uri = "scrobble/stop";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktMovieScrobblePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopMovieAsync(movie, progress);
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
        public void TestTraktScrobbleModuleStopMovieArgumentExceptions()
        {
            var movieStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\MovieStopScrobblePostResponse.json");
            movieStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var movieStopScrobblePost = new TraktMovieScrobblePost
            {
                Movie = movie,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(movieStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, movieStopScrobbleResponse);

            Func<Task<TraktMovieScrobblePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopMovieAsync(null, progress);

            act.ShouldThrow<ArgumentException>();

            movie.Title = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopMovieAsync(movie, progress);
            act.ShouldThrow<ArgumentException>();

            movie.Title = "Guardians of the Galaxy";
            movie.Year = 0;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopMovieAsync(movie, progress);
            act.ShouldThrow<ArgumentException>();

            movie.Year = 2014;
            movie.Ids = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopMovieAsync(movie, progress);
            act.ShouldThrow<ArgumentException>();

            movie.Ids = new TraktMovieIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopMovieAsync(movie, progress);
            act.ShouldThrow<ArgumentException>();

            movie.Ids = new TraktMovieIds
            {
                Trakt = 28,
                Slug = "guardians-of-the-galaxy-2014",
                Imdb = "tt2015381",
                Tmdb = 118340
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopMovieAsync(movie, -0.0001f);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopMovieAsync(movie, 100.0001f);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region StartEpisode

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisode()
        {
            var episodeStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStartScrobblePostResponse.json");
            episodeStartScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;

            var episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/start", postJson, episodeStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithShow()
        {
            var episodeStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStartScrobblePostResponse.json");
            episodeStartScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;

            var episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/start", postJson, episodeStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, show).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithAppVersion()
        {
            var episodeStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStartScrobblePostResponse.json");
            episodeStartScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;
            var appVersion = "app_version";

            var episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/start", postJson, episodeStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, null, appVersion).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithShowAndAppVersion()
        {
            var episodeStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStartScrobblePostResponse.json");
            episodeStartScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;
            var appVersion = "app_version";

            var episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/start", postJson, episodeStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, show, appVersion).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithAppDate()
        {
            var episodeStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStartScrobblePostResponse.json");
            episodeStartScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;
            var appBuildDate = DateTime.UtcNow;

            var episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/start", postJson, episodeStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, null, null, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithShowAndAppDate()
        {
            var episodeStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStartScrobblePostResponse.json");
            episodeStartScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;
            var appBuildDate = DateTime.UtcNow;

            var episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/start", postJson, episodeStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, show, null, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithExtendedOption()
        {
            var episodeStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStartScrobblePostResponse.json");
            episodeStartScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;

            var episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/start?extended={extendedOption.ToString()}", postJson, episodeStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, null, null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithShowAndExtendedOption()
        {
            var episodeStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStartScrobblePostResponse.json");
            episodeStartScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;

            var episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/start?extended={extendedOption.ToString()}", postJson, episodeStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, show, null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithAppVersionAndAppDate()
        {
            var episodeStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStartScrobblePostResponse.json");
            episodeStartScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/start", postJson, episodeStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, null, appVersion, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithShowAndAppVersionAndAppDate()
        {
            var episodeStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStartScrobblePostResponse.json");
            episodeStartScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/start", postJson, episodeStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, show, appVersion, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithAppVersionAndExtendedOption()
        {
            var episodeStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStartScrobblePostResponse.json");
            episodeStartScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;
            var appVersion = "app_version";

            var episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/start?extended={extendedOption.ToString()}", postJson, episodeStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, null, appVersion, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithShowAndAppVersionAndExtendedOption()
        {
            var episodeStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStartScrobblePostResponse.json");
            episodeStartScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;
            var appVersion = "app_version";

            var episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/start?extended={extendedOption.ToString()}", postJson, episodeStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, show, appVersion, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithAppDateAndExtendedOption()
        {
            var episodeStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStartScrobblePostResponse.json");
            episodeStartScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;
            var appBuildDate = DateTime.UtcNow;

            var episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/start?extended={extendedOption.ToString()}", postJson, episodeStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, null, null, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithShowAndAppDateAndExtendedOption()
        {
            var episodeStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStartScrobblePostResponse.json");
            episodeStartScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;
            var appBuildDate = DateTime.UtcNow;

            var episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/start?extended={extendedOption.ToString()}", postJson, episodeStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, show, null, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeComplete()
        {
            var episodeStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStartScrobblePostResponse.json");
            episodeStartScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/start?extended={extendedOption.ToString()}", postJson, episodeStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, null, appVersion, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeWithShowComplete()
        {
            var episodeStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStartScrobblePostResponse.json");
            episodeStartScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/start?extended={extendedOption.ToString()}", postJson, episodeStartScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, show, appVersion, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Start);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStartEpisodeExceptions()
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

            var progress = 10.0f;

            var uri = "scrobble/start";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktEpisodeScrobblePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress);
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
        public void TestTraktScrobbleModuleStartEpisodeWithShowExceptions()
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

            var progress = 10.0f;

            var uri = "scrobble/start";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktEpisodeScrobblePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, show);
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
        public void TestTraktScrobbleModuleStartEpisodeArgumentExceptions()
        {
            var episodeStartScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStartScrobblePostResponse.json");
            episodeStartScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;

            var episodeStartScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(episodeStartScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/start", postJson, episodeStartScrobbleResponse);

            Func<Task<TraktEpisodeScrobblePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(null, progress);

            act.ShouldThrow<ArgumentException>();

            episode.Ids = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds
            {
                Trakt = 16,
                Tvdb = 349232,
                Imdb = "tt0959621",
                Tmdb = 62085,
                TvRage = 637041
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, -0.0001f);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, 100.0001f);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = null;
            episode.SeasonNumber = -1;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = null;
            episode.SeasonNumber = 0;
            episode.Number = 0;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds();
            episode.Number = 0;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = null;
            episode.Number = 1;
            show.Title = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = null;
            show.Title = "Breaking Bad";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, -0.0001f, show);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, 100.0001f, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, -0.0001f, show);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StartEpisodeAsync(episode, 100.0001f, show);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region PauseEpisode

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisode()
        {
            var episodePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodePauseScrobblePostResponse.json");
            episodePauseScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 75.0f;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, episodePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithShow()
        {
            var episodePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodePauseScrobblePostResponse.json");
            episodePauseScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 75.0f;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, episodePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, show).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithAppVersion()
        {
            var episodePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodePauseScrobblePostResponse.json");
            episodePauseScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 75.0f;
            var appVersion = "app_version";

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, episodePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, null, appVersion).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithShowAndAppVersion()
        {
            var episodePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodePauseScrobblePostResponse.json");
            episodePauseScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 75.0f;
            var appVersion = "app_version";

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, episodePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, show, appVersion).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithAppDate()
        {
            var episodePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodePauseScrobblePostResponse.json");
            episodePauseScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 75.0f;
            var appBuildDate = DateTime.UtcNow;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, episodePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, null, null, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithShowAndAppDate()
        {
            var episodePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodePauseScrobblePostResponse.json");
            episodePauseScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 75.0f;
            var appBuildDate = DateTime.UtcNow;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, episodePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, show, null, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithExtendedOption()
        {
            var episodePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodePauseScrobblePostResponse.json");
            episodePauseScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 75.0f;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/pause?extended={extendedOption.ToString()}", postJson, episodePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, null, null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithShowAndExtendedOption()
        {
            var episodePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodePauseScrobblePostResponse.json");
            episodePauseScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 75.0f;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/pause?extended={extendedOption.ToString()}", postJson, episodePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, show, null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithAppVersionAndAppDate()
        {
            var episodePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodePauseScrobblePostResponse.json");
            episodePauseScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 75.0f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, episodePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, null, appVersion, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithShowAndAppVersionAndAppDate()
        {
            var episodePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodePauseScrobblePostResponse.json");
            episodePauseScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 75.0f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, episodePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, show, appVersion, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithAppVersionAndExtendedOption()
        {
            var episodePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodePauseScrobblePostResponse.json");
            episodePauseScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 75.0f;
            var appVersion = "app_version";

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/pause?extended={extendedOption.ToString()}", postJson, episodePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, null, appVersion, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithShowAndAppVersionAndExtendedOption()
        {
            var episodePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodePauseScrobblePostResponse.json");
            episodePauseScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 75.0f;
            var appVersion = "app_version";

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/pause?extended={extendedOption.ToString()}", postJson, episodePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, show, appVersion, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithAppDateAndExtendedOption()
        {
            var episodePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodePauseScrobblePostResponse.json");
            episodePauseScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 75.0f;
            var appBuildDate = DateTime.UtcNow;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/pause?extended={extendedOption.ToString()}", postJson, episodePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, null, null, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithShowAndAppDateAndExtendedOption()
        {
            var episodePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodePauseScrobblePostResponse.json");
            episodePauseScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 75.0f;
            var appBuildDate = DateTime.UtcNow;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/pause?extended={extendedOption.ToString()}", postJson, episodePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, show, null, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeComplete()
        {
            var episodePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodePauseScrobblePostResponse.json");
            episodePauseScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 75.0f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/pause?extended={extendedOption.ToString()}", postJson, episodePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, null, appVersion, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeWithShowComplete()
        {
            var episodePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodePauseScrobblePostResponse.json");
            episodePauseScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 75.0f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/pause?extended={extendedOption.ToString()}", postJson, episodePauseScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, show, appVersion, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Pause);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeFalse();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModulePauseEpisodeExceptions()
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

            var progress = 75.0f;

            var uri = "scrobble/pause";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktEpisodeScrobblePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress);
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
        public void TestTraktScrobbleModulePauseEpisodeWithShowExceptions()
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

            var progress = 75.0f;

            var uri = "scrobble/pause";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktEpisodeScrobblePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, show);
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
        public void TestTraktScrobbleModulePauseEpisodeArgumentExceptions()
        {
            var episodePauseScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodePauseScrobblePostResponse.json");
            episodePauseScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 10.0f;

            var episodePauseScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(episodePauseScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/pause", postJson, episodePauseScrobbleResponse);

            Func<Task<TraktEpisodeScrobblePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(null, progress);

            act.ShouldThrow<ArgumentException>();

            episode.Ids = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds
            {
                Trakt = 16,
                Tvdb = 349232,
                Imdb = "tt0959621",
                Tmdb = 62085,
                TvRage = 637041
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, -0.0001f);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, 100.0001f);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = null;
            episode.SeasonNumber = -1;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = null;
            episode.SeasonNumber = 0;
            episode.Number = 0;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds();
            episode.Number = 0;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = null;
            episode.Number = 1;
            show.Title = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = null;
            show.Title = "Breaking Bad";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, -0.0001f, show);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, 100.0001f, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, -0.0001f, show);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.PauseEpisodeAsync(episode, 100.0001f, show);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region StopEpisode

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisode()
        {
            var episodeStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStopScrobblePostResponse.json");
            episodeStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, episodeStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithShow()
        {
            var episodeStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStopScrobblePostResponse.json");
            episodeStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, episodeStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, show).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithAppVersion()
        {
            var episodeStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStopScrobblePostResponse.json");
            episodeStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appVersion = "app_version";

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, episodeStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, null, appVersion).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithShowAndAppVersion()
        {
            var episodeStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStopScrobblePostResponse.json");
            episodeStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appVersion = "app_version";

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, episodeStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, show, appVersion).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModulevEpisodeWithAppDate()
        {
            var episodeStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStopScrobblePostResponse.json");
            episodeStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appBuildDate = DateTime.UtcNow;

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, episodeStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, null, null, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModulevEpisodeWithShowAndAppDate()
        {
            var episodeStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStopScrobblePostResponse.json");
            episodeStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appBuildDate = DateTime.UtcNow;

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, episodeStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, show, null, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithExtendedOption()
        {
            var episodeStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStopScrobblePostResponse.json");
            episodeStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/stop?extended={extendedOption.ToString()}", postJson, episodeStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, null, null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithShowAndExtendedOption()
        {
            var episodeStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStopScrobblePostResponse.json");
            episodeStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/stop?extended={extendedOption.ToString()}", postJson, episodeStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, show, null, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithAppVersionAndAppDate()
        {
            var episodeStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStopScrobblePostResponse.json");
            episodeStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, episodeStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, null, appVersion, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithShowAndAppVersionAndAppDate()
        {
            var episodeStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStopScrobblePostResponse.json");
            episodeStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, episodeStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, show, appVersion, appBuildDate).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithAppVersionAndExtendedOption()
        {
            var episodeStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStopScrobblePostResponse.json");
            episodeStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appVersion = "app_version";

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/stop?extended={extendedOption.ToString()}", postJson, episodeStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, null, appVersion, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithShowAndAppVersionAndExtendedOption()
        {
            var episodeStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStopScrobblePostResponse.json");
            episodeStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appVersion = "app_version";

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/stop?extended={extendedOption.ToString()}", postJson, episodeStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, show, appVersion, null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithAppDateAndExtendedOption()
        {
            var episodeStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStopScrobblePostResponse.json");
            episodeStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appBuildDate = DateTime.UtcNow;

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/stop?extended={extendedOption.ToString()}", postJson, episodeStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, null, null, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithShowAndAppDateAndExtendedOption()
        {
            var episodeStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStopScrobblePostResponse.json");
            episodeStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appBuildDate = DateTime.UtcNow;

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/stop?extended={extendedOption.ToString()}", postJson, episodeStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, show, null, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeComplete()
        {
            var episodeStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStopScrobblePostResponse.json");
            episodeStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/stop?extended={extendedOption.ToString()}", postJson, episodeStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, null, appVersion, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeWithShowComplete()
        {
            var episodeStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStopScrobblePostResponse.json");
            episodeStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;
            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"scrobble/stop?extended={extendedOption.ToString()}", postJson, episodeStopScrobbleResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, show, appVersion, appBuildDate, extendedOption).Result;

            response.Should().NotBeNull();
            response.Action.Should().Be(TraktScrobbleActionType.Stop);
            response.Progress.Should().Be(progress);
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396);
            response.Show.Ids.TvRage.Should().Be(18164);
        }

        [TestMethod]
        public void TestTraktScrobbleModuleStopEpisodeExceptions()
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

            var progress = 75.0f;

            var uri = "scrobble/stop";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktEpisodeScrobblePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress);
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
        public void TestTraktScrobbleModuleStopEpisodeWithShowExceptions()
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

            var progress = 75.0f;

            var uri = "scrobble/stop";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktEpisodeScrobblePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, show);
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
        public void TestTraktScrobbleModuleStopEpisodeArgumentExceptions()
        {
            var episodeStopScrobbleResponse = TestUtility.ReadFileContents(@"Objects\Post\Scrobbles\Responses\EpisodeStopScrobblePostResponse.json");
            episodeStopScrobbleResponse.Should().NotBeNullOrEmpty();

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

            var progress = 85.0f;

            var episodeStopScrobblePost = new TraktEpisodeScrobblePost
            {
                Episode = episode,
                Show = show,
                Progress = progress
            };

            var postJson = TestUtility.SerializeObject(episodeStopScrobblePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("scrobble/stop", postJson, episodeStopScrobbleResponse);

            Func<Task<TraktEpisodeScrobblePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(null, progress);

            act.ShouldThrow<ArgumentException>();

            episode.Ids = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds
            {
                Trakt = 16,
                Tvdb = 349232,
                Imdb = "tt0959621",
                Tmdb = 62085,
                TvRage = 637041
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, -0.0001f);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, 100.0001f);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = null;
            episode.SeasonNumber = -1;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = null;
            episode.SeasonNumber = 0;
            episode.Number = 0;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds();
            episode.Number = 0;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = null;
            episode.Number = 1;
            show.Title = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, progress, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = null;
            show.Title = "Breaking Bad";

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, -0.0001f, show);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, 100.0001f, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, -0.0001f, show);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Scrobble.StopEpisodeAsync(episode, 100.0001f, show);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion
    }
}
