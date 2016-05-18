namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Post.Checkins;
    using TraktApiSharp.Objects.Post.Checkins.Responses;
    using Utils;

    [TestClass]
    public class TraktCheckinsModuleTests
    {
        [TestMethod]
        public void TestTraktCheckinsModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktCheckinsModule)).Should().BeTrue();
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

        #region CheckinMovie

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovie()
        {
            var checkinMovieResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\MovieCheckinPostResponse.json");
            checkinMovieResponse.Should().NotBeNullOrEmpty();

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

            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd")
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
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
        public void TestTraktCheckinsModuleCheckinMovieWithMessage()
        {
            var checkinMovieResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\MovieCheckinPostResponse.json");
            checkinMovieResponse.Should().NotBeNullOrEmpty();

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

            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;
            var message = "checkin message";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd"),
                Message = message
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate, message).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
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
        public void TestTraktCheckinsModuleCheckinMovieWithSharing()
        {
            var checkinMovieResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\MovieCheckinPostResponse.json");
            checkinMovieResponse.Should().NotBeNullOrEmpty();

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

            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd"),
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate, null, sharing).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
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
        public void TestTraktCheckinsModuleCheckinMovieWithFoursquareVenueId()
        {
            var checkinMovieResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\MovieCheckinPostResponse.json");
            checkinMovieResponse.Should().NotBeNullOrEmpty();

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

            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;
            var foursquareVenueId = "venue id";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd"),
                FoursquareVenueId = foursquareVenueId
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate, null, null,
                                                                                   foursquareVenueId).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
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
        public void TestTraktCheckinsModuleCheckinMovieWithFoursquareVenueName()
        {
            var checkinMovieResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\MovieCheckinPostResponse.json");
            checkinMovieResponse.Should().NotBeNullOrEmpty();

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

            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;
            var foursquareVenueName = "venue name";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd"),
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate, null, null,
                                                                                   null, foursquareVenueName).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
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
        public void TestTraktCheckinsModuleCheckinMovieComplete()
        {
            var checkinMovieResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\MovieCheckinPostResponse.json");
            checkinMovieResponse.Should().NotBeNullOrEmpty();

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

            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;
            var message = "checkin message";

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var foursquareVenueId = "venue id";
            var foursquareVenueName = "venue name";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd"),
                Message = message,
                Sharing = sharing,
                FoursquareVenueId = foursquareVenueId,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate, message, sharing,
                                                                                   foursquareVenueId, foursquareVenueName).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T01:11:37.953Z").ToUniversalTime());
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
        public void TestTraktCheckinsModuleCheckinMovieExceptions()
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

            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            TestUtility.SetupMockErrorResponseWithoutOAuth("checkin", HttpStatusCode.Unauthorized);

            Func<Task<TraktMovieCheckinPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth("checkin", HttpStatusCode.BadRequest);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth("checkin", HttpStatusCode.Forbidden);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth("checkin", HttpStatusCode.Conflict);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth("checkin", (HttpStatusCode)412);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth("checkin", (HttpStatusCode)429);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate);
            act.ShouldThrow<TraktRateLimitException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth("checkin", HttpStatusCode.InternalServerError);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth("checkin", (HttpStatusCode)503);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth("checkin", (HttpStatusCode)504);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth("checkin", (HttpStatusCode)520);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth("checkin", (HttpStatusCode)521);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate);
            act.ShouldThrow<TraktServerUnavailableException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockErrorResponseWithOAuth("checkin", (HttpStatusCode)522);

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate);
            act.ShouldThrow<TraktServerUnavailableException>();
        }

        #endregion
    }
}
