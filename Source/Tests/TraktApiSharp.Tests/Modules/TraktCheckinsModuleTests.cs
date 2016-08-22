namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
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

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie).Result;

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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppVersion()
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

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, appVersion).Result;

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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppVersionAndAppDate()
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
                AppDate = appBuildDate.ToTraktDateString()
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, appVersion, appBuildDate).Result;

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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppVersionAndMessage()
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
            var message = "checkin message";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                AppVersion = appVersion,
                Message = message
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, appVersion, null, message).Result;

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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppVersionAndSharing()
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

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var appVersion = "app_version";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                AppVersion = appVersion,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, appVersion, null, null, sharing).Result;

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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppVersionAndFoursquareVenueId()
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
            var foursquareVenueId = "venue id";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                AppVersion = appVersion,
                FoursquareVenueId = foursquareVenueId
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, appVersion, null, null, null,
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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppVersionFoursquareVenueName()
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
            var foursquareVenueName = "venue name";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                AppVersion = appVersion,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, appVersion, null, null, null,
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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppDate()
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

            var appBuildDate = DateTime.UtcNow;

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                AppDate = appBuildDate.ToTraktDateString()
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, null, appBuildDate).Result;

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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppDateAndMessage()
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

            var appBuildDate = DateTime.UtcNow;
            var message = "checkin message";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                AppDate = appBuildDate.ToTraktDateString(),
                Message = message
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, null, appBuildDate, message).Result;

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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppDateAndSharing()
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

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var appBuildDate = DateTime.UtcNow;

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                AppDate = appBuildDate.ToTraktDateString(),
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, null, appBuildDate, null, sharing).Result;

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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppDateAndFoursquareVenueId()
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

            var appBuildDate = DateTime.UtcNow;
            var foursquareVenueId = "venue id";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                AppDate = appBuildDate.ToTraktDateString(),
                FoursquareVenueId = foursquareVenueId
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, null, appBuildDate, null, null,
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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppDateAndFoursquareVenueName()
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

            var appBuildDate = DateTime.UtcNow;
            var foursquareVenueName = "venue name";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                AppDate = appBuildDate.ToTraktDateString(),
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, null, appBuildDate, null, null,
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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
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

            var message = "checkin message";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                Message = message
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, null, null, message).Result;

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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithMessageAndSharing()
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

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var message = "checkin message";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                Message = message,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, null, null, message, sharing).Result;

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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithMessageAndFoursquareVenueId()
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

            var message = "checkin message";
            var foursquareVenueId = "venue id";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                Message = message,
                FoursquareVenueId = foursquareVenueId
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, null, null, message, null,
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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithMessageAndFoursquareVenueName()
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

            var message = "checkin message";
            var foursquareVenueName = "venue name";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                Message = message,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, null, null, message, null,
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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
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

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, null, null, null, sharing).Result;

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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithSharingAndFoursquareVenueId()
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

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var foursquareVenueId = "venue id";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                Sharing = sharing,
                FoursquareVenueId = foursquareVenueId
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, null, null, null, sharing,
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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithSharingAndFoursquareVenueName()
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

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var foursquareVenueName = "venue name";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                Sharing = sharing,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, null, null, null, sharing,
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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
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

            var foursquareVenueId = "venue id";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                FoursquareVenueId = foursquareVenueId
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, null, null, null, null,
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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithFoursquareVenueIdAndFoursquareVenueName()
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

            var foursquareVenueId = "venue id";
            var foursquareVenueName = "venue name";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                FoursquareVenueId = foursquareVenueId,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, null, null, null, null,
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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
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

            var foursquareVenueName = "venue name";

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, null, null, null, null,
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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie, appVersion, appBuildDate, message, sharing,
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
            response.Movie.Ids.Trakt.Should().Be(28U);
            response.Movie.Ids.Slug.Should().Be("guardians-of-the-galaxy-2014");
            response.Movie.Ids.Imdb.Should().Be("tt2015381");
            response.Movie.Ids.Tmdb.Should().Be(118340U);
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

            var uri = "checkin";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktMovieCheckinPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktCheckinException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktCheckinsModuleCheckinMovieArgumentExceptions()
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

            var movieCheckinPost = new TraktMovieCheckinPost
            {
                Movie = movie
            };

            var postJson = TestUtility.SerializeObject(movieCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinMovieResponse);

            Func<Task<TraktMovieCheckinPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(null);

            act.ShouldThrow<ArgumentNullException>();

            movie.Year = 0;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            movie.Year = 123;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            movie.Year = 12345;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            movie.Year = 2014;
            movie.Ids = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie);
            act.ShouldThrow<ArgumentNullException>();

            movie.Ids = new TraktMovieIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoMovieAsync(movie);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region CheckinEpisode

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisode()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToTraktDateString()
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, appVersion, appBuildDate).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppVersion()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var appVersion = "app_version";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, appVersion).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppVersionAndAppDate()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToTraktDateString()
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, appVersion, appBuildDate).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppVersionAndMessage()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var appVersion = "app_version";
            var message = "checkin message";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                AppVersion = appVersion,
                Message = message
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, appVersion, null, message).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppVersionAndSharing()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var appVersion = "app_version";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                AppVersion = appVersion,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, appVersion, null, null, sharing).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppVersionAndFoursquareVenueId()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var appVersion = "app_version";
            var foursquareVenueId = "venue id";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                AppVersion = appVersion,
                FoursquareVenueId = foursquareVenueId
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, appVersion, null, null, null,
                                                                                     foursquareVenueId).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppVersionFoursquareVenueName()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var appVersion = "app_version";
            var foursquareVenueName = "venue name";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                AppVersion = appVersion,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, appVersion, null, null, null,
                                                                                     null, foursquareVenueName).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppDate()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var appBuildDate = DateTime.UtcNow;

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                AppDate = appBuildDate.ToTraktDateString()
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, null, appBuildDate).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppDateAndMessage()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var appBuildDate = DateTime.UtcNow;
            var message = "checkin message";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                AppDate = appBuildDate.ToTraktDateString(),
                Message = message
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, null, appBuildDate, message).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppDateAndSharing()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var appBuildDate = DateTime.UtcNow;

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                AppDate = appBuildDate.ToTraktDateString(),
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, null, appBuildDate, null, sharing).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppDateAndFoursquareVenueId()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var appBuildDate = DateTime.UtcNow;
            var foursquareVenueId = "venue id";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                AppDate = appBuildDate.ToTraktDateString(),
                FoursquareVenueId = foursquareVenueId
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, null, appBuildDate, null, null,
                                                                                     foursquareVenueId).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppDateAndFoursquareVenueName()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var appBuildDate = DateTime.UtcNow;
            var foursquareVenueName = "venue name";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                AppDate = appBuildDate.ToTraktDateString(),
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, null, appBuildDate, null, null,
                                                                                     null, foursquareVenueName).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithMessage()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var message = "checkin message";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Message = message
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, null, null, message).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithMessageAndSharing()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var message = "checkin message";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Message = message,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, null, null, message, sharing).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithMessageAndFoursquareVenueId()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var message = "checkin message";
            var foursquareVenueId = "venue id";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Message = message,
                FoursquareVenueId = foursquareVenueId
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, null, null, message, null,
                                                                                     foursquareVenueId).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithMessageAndFoursquareVenueName()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var message = "checkin message";
            var foursquareVenueName = "venue name";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Message = message,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, null, null, message, null,
                                                                                     null, foursquareVenueName).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithSharing()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, null, null, null, sharing).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithSharingAndFoursquareVenueId()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var foursquareVenueId = "venue id";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Sharing = sharing,
                FoursquareVenueId = foursquareVenueId
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, null, null, null, sharing,
                                                                                     foursquareVenueId).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithSharingAndFoursquareVenueName()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var foursquareVenueName = "venue name";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Sharing = sharing,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, null, null, null, sharing,
                                                                                     null, foursquareVenueName).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithFoursquareVenueId()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var foursquareVenueId = "venue id";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                FoursquareVenueId = foursquareVenueId
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, null, null,
                                                                                     null, null, foursquareVenueId).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithFoursquareVenueIdAndFoursquareVenueName()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var foursquareVenueId = "venue id";
            var foursquareVenueName = "venue name";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                FoursquareVenueId = foursquareVenueId,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, null, null, null, null,
                                                                                     foursquareVenueId, foursquareVenueName).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithFoursquareVenueName()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var foursquareVenueName = "venue name";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, null, null, null, null,
                                                                                     null, foursquareVenueName).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeComplete()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
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

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd"),
                Message = message,
                Sharing = sharing,
                FoursquareVenueId = foursquareVenueId,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode, appVersion, appBuildDate, message, sharing,
                                                                                       foursquareVenueId, foursquareVenueName).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeExceptions()
        {
            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var uri = "checkin";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktEpisodeCheckinPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktCheckinException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktCheckinsModuleCheckinEpisodeArgumentExceptions()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            Func<Task<TraktEpisodeCheckinPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(null);

            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(new TraktEpisode());
            act.ShouldThrow<ArgumentNullException>();

            episode = new TraktEpisode
            {
                Ids = new TraktEpisodeIds()
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeAsync(episode);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region CheckinEpisodeShow

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShow()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppVersion()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var appVersion = "app_version";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                AppVersion = appVersion
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, appVersion).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppVersionAndAppDate()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var appVersion = "app_version";
            var appBuildDate = DateTime.UtcNow;

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToTraktDateString()
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, appVersion,
                                                                                             appBuildDate).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppVersionAndMessage()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var appVersion = "app_version";
            var message = "checkin message";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                AppVersion = appVersion,
                Message = message
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, appVersion,
                                                                                             null, message).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppVersionAndSharing()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var appVersion = "app_version";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                AppVersion = appVersion,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, appVersion,
                                                                                             null, null, sharing).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppVersionAndFoursquareVenueId()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var appVersion = "app_version";
            var foursquareVenueId = "venue id";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                AppVersion = appVersion,
                FoursquareVenueId = foursquareVenueId
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, appVersion,
                                                                                             null, null, null,
                                                                                             foursquareVenueId).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppVersionFoursquareVenueName()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var appVersion = "app_version";
            var foursquareVenueName = "venue name";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                AppVersion = appVersion,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, appVersion,
                                                                                             null, null, null,
                                                                                             null, foursquareVenueName).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppDate()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var appBuildDate = DateTime.UtcNow;

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                AppDate = appBuildDate.ToTraktDateString()
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, null, appBuildDate).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppDateAndMessage()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var appBuildDate = DateTime.UtcNow;
            var message = "checkin message";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                AppDate = appBuildDate.ToTraktDateString(),
                Message = message
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, null,
                                                                                             appBuildDate, message).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppDateAndSharing()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var appBuildDate = DateTime.UtcNow;

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                AppDate = appBuildDate.ToTraktDateString(),
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, null,
                                                                                             appBuildDate, null, sharing).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppDateAndFoursquareVenueId()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var appBuildDate = DateTime.UtcNow;
            var foursquareVenueId = "venue id";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                AppDate = appBuildDate.ToTraktDateString(),
                FoursquareVenueId = foursquareVenueId
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, null,
                                                                                             appBuildDate, null, null,
                                                                                             foursquareVenueId).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppDateAndFoursquareVenueName()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var appBuildDate = DateTime.UtcNow;
            var foursquareVenueName = "venue name";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                AppDate = appBuildDate.ToTraktDateString(),
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, null,
                                                                                             appBuildDate, null, null,
                                                                                             null, foursquareVenueName).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithMessage()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var message = "checkin message";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                Message = message
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, null, null, message).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithMessageAndSharing()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var message = "checkin message";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                Message = message,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, null,
                                                                                             null, message, sharing).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithMessageAndFoursquareVenueId()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var message = "checkin message";
            var foursquareVenueId = "venue id";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                Message = message,
                FoursquareVenueId = foursquareVenueId
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, null,
                                                                                             null, message, null,
                                                                                             foursquareVenueId).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithMessageAndFoursquareVenueName()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var message = "checkin message";
            var foursquareVenueName = "venue name";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                Message = message,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, null,
                                                                                             null, message, null,
                                                                                             null, foursquareVenueName).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithSharing()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                Sharing = sharing
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, null, null, null, sharing).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithSharingAndFoursquareVenueId()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var foursquareVenueId = "venue id";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                Sharing = sharing,
                FoursquareVenueId = foursquareVenueId
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, null,
                                                                                             null, null, sharing,
                                                                                             foursquareVenueId).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithSharingAndFoursquareVenueName()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var sharing = new TraktSharing
            {
                Facebook = true,
                Google = false,
                Twitter = true
            };

            var foursquareVenueName = "venue name";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                Sharing = sharing,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, null,
                                                                                             null, null, sharing,
                                                                                             null, foursquareVenueName).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithFoursquareVenueId()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var foursquareVenueId = "venue id";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                FoursquareVenueId = foursquareVenueId
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, null, null,
                                                                                             null, null, foursquareVenueId).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithFoursquareVenueIdAndFoursquareVenueName()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var foursquareVenueId = "venue id";
            var foursquareVenueName = "venue name";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                FoursquareVenueId = foursquareVenueId,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, null,
                                                                                             null, null, null,
                                                                                             foursquareVenueId, foursquareVenueName).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithFoursquareVenueName()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var foursquareVenueName = "venue name";

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, null, null, null, null,
                                                                                             null, foursquareVenueName).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowComplete()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

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

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show,
                AppVersion = appVersion,
                AppDate = appBuildDate.ToString("yyyy-MM-dd"),
                Message = message,
                Sharing = sharing,
                FoursquareVenueId = foursquareVenueId,
                FoursquareVenueName = foursquareVenueName
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show, appVersion, appBuildDate, message, sharing,
                                                                                               foursquareVenueId, foursquareVenueName).Result;

            response.Should().NotBeNull();

            response.WatchedAt.Should().Be(DateTime.Parse("2014-08-06T06:54:36.859Z").ToUniversalTime());
            response.Sharing.Should().NotBeNull();
            response.Sharing.Facebook.Should().BeTrue();
            response.Sharing.Twitter.Should().BeTrue();
            response.Sharing.Tumblr.Should().BeFalse();
            response.Episode.Should().NotBeNull();
            response.Episode.SeasonNumber.Should().Be(1);
            response.Episode.Number.Should().Be(1);
            response.Episode.Title.Should().Be("Pilot");
            response.Episode.Ids.Should().NotBeNull();
            response.Episode.Ids.Trakt.Should().Be(16U);
            response.Episode.Ids.Tvdb.Should().Be(349232U);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085U);
            response.Episode.Ids.TvRage.Should().Be(637041U);
            response.Show.Should().NotBeNull();
            response.Show.Title.Should().Be("Breaking Bad");
            response.Show.Year.Should().Be(2008);
            response.Show.Ids.Should().NotBeNull();
            response.Show.Ids.Trakt.Should().Be(1U);
            response.Show.Ids.Slug.Should().Be("breaking-bad");
            response.Show.Ids.Tvdb.Should().Be(81189U);
            response.Show.Ids.Imdb.Should().Be("tt0903747");
            response.Show.Ids.Tmdb.Should().Be(1396U);
            response.Show.Ids.TvRage.Should().Be(18164U);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowExceptions()
        {
            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1,
                Ids = new TraktEpisodeIds
                {
                    Trakt = 16,
                    Tvdb = 349232,
                    Imdb = "tt0959621",
                    Tmdb = 62085,
                    TvRage = 637041
                }
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var uri = "checkin";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktEpisodeCheckinPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktCheckinException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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
        public void TestTraktCheckinsModuleCheckinEpisodeShowArgumentExceptions()
        {
            var checkinEpisodeResponse = TestUtility.ReadFileContents(@"Objects\Post\Checkins\Responses\EpisodeCheckinPostResponse.json");
            checkinEpisodeResponse.Should().NotBeNullOrEmpty();

            var episode = new TraktEpisode
            {
                Number = 1,
                SeasonNumber = 1
            };

            var show = new TraktShow { Title = "Breaking Bad" };

            var episodeCheckinPost = new TraktEpisodeCheckinPost
            {
                Episode = episode,
                Show = show
            };

            var postJson = TestUtility.SerializeObject(episodeCheckinPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("checkin", postJson, checkinEpisodeResponse);

            Func<Task<TraktEpisodeCheckinPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(null, show);

            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, null);
            act.ShouldThrow<ArgumentNullException>();

            episode.Number = -1;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            episode.Number = 1;
            episode.SeasonNumber = -1;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            episode.SeasonNumber = 1;

            show.Title = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckIntoEpisodeWithShowAsync(episode, show);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region DeleteCheckins

        [TestMethod]
        public void TestTraktCheckinsModuleDeleteCheckins()
        {
            TestUtility.SetupMockResponseWithOAuth("checkin", HttpStatusCode.NoContent);
            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.DeleteAnyActiveCheckinsAsync();
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleDeleteCheckinsExceptions()
        {
            var uri = "checkin";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.DeleteAnyActiveCheckinsAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.MethodNotAllowed);
            act.ShouldThrow<TraktMethodNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.InternalServerError);
            act.ShouldThrow<TraktServerException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadGateway);
            act.ShouldThrow<TraktBadGatewayException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)412);
            act.ShouldThrow<TraktPreconditionFailedException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)422);
            act.ShouldThrow<TraktValidationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, (HttpStatusCode)429);
            act.ShouldThrow<TraktRateLimitException>();

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

        #endregion
    }
}
