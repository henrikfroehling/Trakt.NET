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
    using TraktApiSharp.Requests;
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie).Result;

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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion).Result;

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
        public void TestTraktCheckinsModuleCheckinMovieWithAppVersionAndAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppVersionAndMessage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppVersionAndSharing()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppVersionAndFoursquareVenueId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppVersionFoursquareVenueName()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppVersionAndExtendedOption()
        {
            Assert.Fail();
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, null, appBuildDate).Result;

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
        public void TestTraktCheckinsModuleCheckinMovieWithAppDateAndMessage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppDateAndSharing()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppDateAndFoursquareVenueId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppDateAndFoursquareVenueName()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithAppDateAndExtendedOption()
        {
            Assert.Fail();
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, null, null, message).Result;

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
        public void TestTraktCheckinsModuleCheckinMovieWithMessageAndSharing()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithMessageAndFoursquareVenueId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithMessageAndFoursquareVenueName()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithMessageAndExtendedOption()
        {
            Assert.Fail();
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, null, null, null, sharing).Result;

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
        public void TestTraktCheckinsModuleCheckinMovieWithSharingAndFoursquareVenueId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithSharingAndFoursquareVenueName()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithSharingAndExtendedOption()
        {
            Assert.Fail();
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, null, null, null, null,
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
        public void TestTraktCheckinsModuleCheckinMovieWithFoursquareVenueIdAndFoursquareVenueName()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithFoursquareVenueIdAndExtendedOption()
        {
            Assert.Fail();
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, null, null, null, null,
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
        public void TestTraktCheckinsModuleCheckinMovieWithFoursquareVenueNameAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinMovieWithExtendedOption()
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

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"checkin?extended={extendedOption.ToString()}", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, null, null, null, null,
                                                                                   null, null, extendedOption).Result;

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

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"checkin?extended={extendedOption.ToString()}", postJson, checkinMovieResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie, appVersion, appBuildDate, message, sharing,
                                                                                   foursquareVenueId, foursquareVenueName, extendedOption).Result;

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

            var uri = "checkin";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktMovieCheckinPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktCheckinException>();

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
                async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(null);

            act.ShouldThrow<ArgumentNullException>();

            movie.Year = 0;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie);
            act.ShouldThrow<ArgumentException>();

            movie.Year = 2014;
            movie.Ids = null;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie);
            act.ShouldThrow<ArgumentNullException>();

            movie.Ids = new TraktMovieIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinMovieAsync(movie);
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeAsync(episode, appVersion, appBuildDate).Result;

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
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeAsync(episode, appVersion).Result;

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
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppVersionAndAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppVersionAndMessage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppVersionAndSharing()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppVersionAndFoursquareVenueId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppVersionFoursquareVenueName()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppVersionAndExtendedOption()
        {
            Assert.Fail();
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeAsync(episode, null, appBuildDate).Result;

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
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppDateAndMessage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppDateAndSharing()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppDateAndFoursquareVenueId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppDateAndFoursquareVenueName()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithAppDateAndExtendedOption()
        {
            Assert.Fail();
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeAsync(episode, null, null, message).Result;

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
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithMessageAndSharing()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithMessageAndFoursquareVenueId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithMessageAndFoursquareVenueName()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithMessageAndExtendedOption()
        {
            Assert.Fail();
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeAsync(episode, null, null, null, sharing).Result;

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
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithSharingAndFoursquareVenueId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithSharingAndFoursquareVenueName()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithSharingAndExtendedOption()
        {
            Assert.Fail();
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeAsync(episode, null, null,
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
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithFoursquareVenueIdAndFoursquareVenueName()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithFoursquareVenueIdAndExtendedOption()
        {
            Assert.Fail();
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeAsync(episode, null, null, null, null,
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
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithFoursquareVenueNameAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeWithExtendedOption()
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

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"checkin?extended={extendedOption.ToString()}", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeAsync(episode, null, null, null, null,
                                                                                     null, null, extendedOption).Result;

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
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
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

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"checkin?extended={extendedOption.ToString()}", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeAsync(episode, appVersion, appBuildDate, message, sharing,
                                                                                     foursquareVenueId, foursquareVenueName, extendedOption).Result;

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
            response.Episode.Ids.Trakt.Should().Be(16);
            response.Episode.Ids.Tvdb.Should().Be(349232);
            response.Episode.Ids.Imdb.Should().Be("tt0959621");
            response.Episode.Ids.Tmdb.Should().Be(62085);
            response.Episode.Ids.TvRage.Should().Be(637041);
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
                async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeAsync(episode);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktCheckinException>();

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
                async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeAsync(null);

            act.ShouldThrow<ArgumentNullException>();

            episode.Number = -1;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeAsync(episode);
            act.ShouldThrow<ArgumentException>();

            episode.Number = 1;
            episode.SeasonNumber = -1;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeAsync(episode);
            act.ShouldThrow<ArgumentException>();

            episode.SeasonNumber = 1;
            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeAsync(episode);
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeWithShowAsync(episode, show).Result;

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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeWithShowAsync(episode, show, appVersion).Result;

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
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppVersionAndAppDate()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppVersionAndMessage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppVersionAndSharing()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppVersionAndFoursquareVenueId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppVersionFoursquareVenueName()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppVersionAndExtendedOption()
        {
            Assert.Fail();
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeWithShowAsync(episode, show, null, appBuildDate).Result;

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
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppDateAndMessage()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppDateAndSharing()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppDateAndFoursquareVenueId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppDateAndFoursquareVenueName()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithAppDateAndExtendedOption()
        {
            Assert.Fail();
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeWithShowAsync(episode, show, null, null, message).Result;

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
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithMessageAndSharing()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithMessageAndFoursquareVenueId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithMessageAndFoursquareVenueName()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithMessageAndExtendedOption()
        {
            Assert.Fail();
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeWithShowAsync(episode, show, null, null, null, sharing).Result;

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
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithSharingAndFoursquareVenueId()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithSharingAndFoursquareVenueName()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithSharingAndExtendedOption()
        {
            Assert.Fail();
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeWithShowAsync(episode, show, null, null,
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
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithFoursquareVenueIdAndFoursquareVenueName()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithFoursquareVenueIdAndExtendedOption()
        {
            Assert.Fail();
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

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeWithShowAsync(episode, show, null, null, null, null,
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
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithFoursquareVenueNameAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleCheckinEpisodeShowWithExtendedOption()
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

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"checkin?extended={extendedOption.ToString()}", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeWithShowAsync(episode, show, null, null, null, null,
                                                                                             null, null, extendedOption).Result;

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

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"checkin?extended={extendedOption.ToString()}", postJson, checkinEpisodeResponse);

            var response = TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeWithShowAsync(episode, show, appVersion, appBuildDate, message, sharing,
                                                                                             foursquareVenueId, foursquareVenueName, extendedOption).Result;

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
                async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeWithShowAsync(episode, show);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktCheckinException>();

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
        public void TestTraktCheckinsModuleCheckinEpisodeShowArgumentExceptions()
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

            Func<Task<TraktEpisodeCheckinPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeWithShowAsync(null, show);

            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeWithShowAsync(episode, null);
            act.ShouldThrow<ArgumentNullException>();

            episode.Number = -1;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeWithShowAsync(episode, show);
            act.ShouldThrow<ArgumentException>();

            episode.Number = 1;
            episode.SeasonNumber = -1;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeWithShowAsync(episode, show);
            act.ShouldThrow<ArgumentException>();

            episode.SeasonNumber = 1;
            episode.Ids = new TraktEpisodeIds();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeWithShowAsync(episode, show);
            act.ShouldThrow<ArgumentException>();

            episode.Ids = new TraktEpisodeIds
            {
                Trakt = 16,
                Tvdb = 349232,
                Imdb = "tt0959621",
                Tmdb = 62085,
                TvRage = 637041
            };

            show.Title = string.Empty;

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Checkins.CheckinEpisodeWithShowAsync(episode, show);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region DeleteCheckins

        [TestMethod]
        public void TestTraktCheckinsModuleDeleteCheckins()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktCheckinsModuleDeleteCheckinsExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
