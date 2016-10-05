namespace TraktApiSharp.Tests.Modules
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Modules;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Collection;
    using TraktApiSharp.Objects.Get.History;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Ratings;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Objects.Get.Syncs.Playback;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Objects.Get.Watchlist;
    using TraktApiSharp.Objects.Post.Syncs.Collection;
    using TraktApiSharp.Objects.Post.Syncs.Collection.Responses;
    using TraktApiSharp.Objects.Post.Syncs.History;
    using TraktApiSharp.Objects.Post.Syncs.History.Responses;
    using TraktApiSharp.Objects.Post.Syncs.Ratings;
    using TraktApiSharp.Objects.Post.Syncs.Ratings.Responses;
    using TraktApiSharp.Objects.Post.Syncs.Watchlist;
    using TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses;
    using TraktApiSharp.Requests.Params;
    using Utils;

    [TestClass]
    public class TraktSyncModuleTests
    {
        [TestMethod]
        public void TestTraktSyncModuleIsModule()
        {
            typeof(TraktBaseModule).IsAssignableFrom(typeof(TraktSyncModule)).Should().BeTrue();
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

        #region GetLastActivities

        [TestMethod]
        public void TestTraktSyncModuleGetLastActivities()
        {
            var lastActivities = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Activities\SyncLastActivities.json");
            lastActivities.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/last_activities", lastActivities);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetLastActivitiesAsync().Result;

            response.Should().NotBeNull();

            response.All.Should().Be(DateTime.Parse("2014-11-20T07:01:32.378Z").ToUniversalTime());
            response.Movies.Should().NotBeNull();
            response.Movies.WatchedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.823Z").ToUniversalTime());
            response.Movies.CollectedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.243Z").ToUniversalTime());
            response.Movies.RatedAt.Should().Be(DateTime.Parse("2014-11-19T18:32:29.459Z").ToUniversalTime());
            response.Movies.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T21:42:41.844Z").ToUniversalTime());
            response.Movies.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            response.Movies.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

            response.Episodes.Should().NotBeNull();
            response.Episodes.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            response.Episodes.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            response.Episodes.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            response.Episodes.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            response.Episodes.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            response.Episodes.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());

            response.Shows.Should().NotBeNull();
            response.Shows.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:50:58.557Z").ToUniversalTime());
            response.Shows.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.262Z").ToUniversalTime());
            response.Shows.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.281Z").ToUniversalTime());

            response.Seasons.Should().NotBeNull();
            response.Seasons.RatedAt.Should().Be(DateTime.Parse("2014-11-19T19:54:24.537Z").ToUniversalTime());
            response.Seasons.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.297Z").ToUniversalTime());
            response.Seasons.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.301Z").ToUniversalTime());

            response.Comments.Should().NotBeNull();
            response.Comments.LikedAt.Should().Be(DateTime.Parse("2014-11-20T03:38:09.122Z").ToUniversalTime());

            response.Lists.Should().NotBeNull();
            response.Lists.LikedAt.Should().Be(DateTime.Parse("2014-11-20T00:36:48.506Z").ToUniversalTime());
            response.Lists.UpdatedAt.Should().Be(DateTime.Parse("2014-11-20T06:52:18.837Z").ToUniversalTime());
            response.Lists.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        [TestMethod]
        public void TestTraktSyncModuleGetLastActivitiesExceptions()
        {
            var uri = "sync/last_activities";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktSyncLastActivities>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetLastActivitiesAsync();
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

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetPlaybackProgress

        [TestMethod]
        public void TestTraktSyncModuleGetPlaybackProgress()
        {
            var playbackProgress = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Playback\SyncPlaybackProgress.json");
            playbackProgress.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/playback", playbackProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetPlaybackProgressAsync().Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetPlaybackProgressWithType()
        {
            var playbackProgress = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Playback\SyncPlaybackProgress.json");
            playbackProgress.Should().NotBeNullOrEmpty();

            var type = TraktSyncType.Episode;

            TestUtility.SetupMockResponseWithOAuth($"sync/playback/{type.UriName}", playbackProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetPlaybackProgressAsync(type).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetPlaybackProgressWithLimit()
        {
            var playbackProgress = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Playback\SyncPlaybackProgress.json");
            playbackProgress.Should().NotBeNullOrEmpty();

            var limit = 4;

            TestUtility.SetupMockResponseWithOAuth($"sync/playback?limit={limit}", playbackProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetPlaybackProgressAsync(null, limit).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetPlaybackProgressComplete()
        {
            var playbackProgress = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Playback\SyncPlaybackProgress.json");
            playbackProgress.Should().NotBeNullOrEmpty();

            var type = TraktSyncType.Episode;
            var limit = 4;

            TestUtility.SetupMockResponseWithOAuth($"sync/playback/{type.UriName}?limit={limit}", playbackProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetPlaybackProgressAsync(type, limit).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetPlaybackProgressExceptions()
        {
            var uri = "sync/playback";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<IEnumerable<TraktSyncPlaybackProgressItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetPlaybackProgressAsync();
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

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RemovePlaybackItem

        [TestMethod]
        public void TestTraktSyncModuleGetRemovePlaybackItem()
        {
            var playbackId = 13U;

            TestUtility.SetupMockResponseWithOAuth($"sync/playback/{playbackId}", HttpStatusCode.NoContent);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemovePlaybackItemAsync(playbackId);
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetRemovePlaybackItemExceptions()
        {
            var playbackId = 13U;

            var uri = $"sync/playback/{playbackId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemovePlaybackItemAsync(playbackId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktObjectNotFoundException>();

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

        [TestMethod]
        public void TestTraktSyncModuleGetRemovePlaybackItemArgumentExceptions()
        {
            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemovePlaybackItemAsync(0);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetCollectionMovies

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionMovies()
        {
            var collectionMovies = TestUtility.ReadFileContents(@"Objects\Get\Collection\CollectionMoviesMetadata.json");
            collectionMovies.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/collection/movies", collectionMovies);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetCollectionMoviesAsync().Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionMoviesComplete()
        {
            var collectionMovies = TestUtility.ReadFileContents(@"Objects\Get\Collection\CollectionMoviesMetadata.json");
            collectionMovies.Should().NotBeNullOrEmpty();

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true,
                Metadata = true
            };

            TestUtility.SetupMockResponseWithOAuth($"sync/collection/movies?extended={extendedInfo.ToString()}",
                                                   collectionMovies);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetCollectionMoviesAsync(extendedInfo).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionMoviesExceptions()
        {
            var uri = "sync/collection/movies";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<IEnumerable<TraktCollectionMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetCollectionMoviesAsync();
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

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetCollectionShows

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionShows()
        {
            var collectionShows = TestUtility.ReadFileContents(@"Objects\Get\Collection\CollectionShowsMetadata.json");
            collectionShows.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/collection/shows", collectionShows);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetCollectionShowsAsync().Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionShowsComplete()
        {
            var collectionShows = TestUtility.ReadFileContents(@"Objects\Get\Collection\CollectionShowsMetadata.json");
            collectionShows.Should().NotBeNullOrEmpty();

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true,
                Metadata = true
            };

            TestUtility.SetupMockResponseWithOAuth($"sync/collection/shows?extended={extendedInfo.ToString()}",
                                                   collectionShows);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetCollectionShowsAsync(extendedInfo).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionShowsExceptions()
        {
            var uri = "sync/collection/shows";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<IEnumerable<TraktCollectionShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetCollectionShowsAsync();
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

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AddCollectionItems

        [TestMethod]
        public void TestTraktSyncModuleAddCollectionItems()
        {
            var addedCollectionItems = TestUtility.ReadFileContents(@"Objects\Post\Syncs\Collection\Responses\SyncCollectionPostResponse.json");
            addedCollectionItems.Should().NotBeNullOrEmpty();

            var collectionPost = new TraktSyncCollectionPost
            {
                Movies = new List<TraktSyncCollectionPostMovie>()
                {
                    new TraktSyncCollectionPostMovie
                    {
                        CollectedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncCollectionPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<TraktSyncCollectionPostShow>()
                {
                    new TraktSyncCollectionPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncCollectionPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<TraktSyncCollectionPostShowSeason>()
                        {
                            new TraktSyncCollectionPostShowSeason
                            {
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncCollectionPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<TraktSyncCollectionPostShowSeason>()
                        {
                            new TraktSyncCollectionPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<TraktSyncCollectionPostShowEpisode>()
                                {
                                    new TraktSyncCollectionPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktSyncCollectionPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<TraktSyncCollectionPostEpisode>()
                {
                    new TraktSyncCollectionPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var postJson = TestUtility.SerializeObject(collectionPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/collection", postJson, addedCollectionItems);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.AddCollectionItemsAsync(collectionPost).Result;

            response.Should().NotBeNull();

            response.Added.Should().NotBeNull();
            response.Added.Movies.Should().Be(1);
            response.Added.Episodes.Should().Be(12);
            response.Added.Shows.Should().NotHaveValue();
            response.Added.Seasons.Should().NotHaveValue();

            response.Updated.Should().NotBeNull();
            response.Updated.Movies.Should().Be(3);
            response.Updated.Episodes.Should().Be(1);
            response.Updated.Shows.Should().NotHaveValue();
            response.Updated.Seasons.Should().NotHaveValue();

            response.Existing.Should().NotBeNull();
            response.Existing.Movies.Should().Be(2);
            response.Existing.Episodes.Should().Be(0);
            response.Existing.Shows.Should().NotHaveValue();
            response.Existing.Seasons.Should().NotHaveValue();

            response.NotFound.Should().NotBeNull();
            response.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = response.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            response.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddCollectionItemsExceptions()
        {
            var collectionPost = new TraktSyncCollectionPost
            {
                Movies = new List<TraktSyncCollectionPostMovie>()
                {
                    new TraktSyncCollectionPostMovie
                    {
                        CollectedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    }
                },
                Shows = new List<TraktSyncCollectionPostShow>()
                {
                    new TraktSyncCollectionPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    }
                },
                Episodes = new List<TraktSyncCollectionPostEpisode>()
                {
                    new TraktSyncCollectionPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var uri = "sync/collection";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktSyncCollectionPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddCollectionItemsAsync(collectionPost);
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

        [TestMethod]
        public void TestTraktSyncModuleAddCollectionItemsArgumentExceptions()
        {
            Func<Task<TraktSyncCollectionPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddCollectionItemsAsync(null);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddCollectionItemsAsync(new TraktSyncCollectionPost());
            act.ShouldThrow<ArgumentException>();

            var collectionPost = new TraktSyncCollectionPost
            {
                Movies = new List<TraktSyncCollectionPostMovie>(),
                Shows = new List<TraktSyncCollectionPostShow>(),
                Episodes = new List<TraktSyncCollectionPostEpisode>()
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddCollectionItemsAsync(collectionPost);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RemoveCollectionItems

        [TestMethod]
        public void TestTraktSyncModuleRemoveCollectionItems()
        {
            var removedCollectionItems = TestUtility.ReadFileContents(@"Objects\Post\Syncs\Collection\Responses\SyncCollectionRemovePostResponse.json");
            removedCollectionItems.Should().NotBeNullOrEmpty();

            var collectionRemovePost = new TraktSyncCollectionPost
            {
                Movies = new List<TraktSyncCollectionPostMovie>()
                {
                    new TraktSyncCollectionPostMovie
                    {
                        CollectedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncCollectionPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<TraktSyncCollectionPostShow>()
                {
                    new TraktSyncCollectionPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncCollectionPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<TraktSyncCollectionPostShowSeason>()
                        {
                            new TraktSyncCollectionPostShowSeason
                            {
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncCollectionPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<TraktSyncCollectionPostShowSeason>()
                        {
                            new TraktSyncCollectionPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<TraktSyncCollectionPostShowEpisode>()
                                {
                                    new TraktSyncCollectionPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktSyncCollectionPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<TraktSyncCollectionPostEpisode>()
                {
                    new TraktSyncCollectionPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var postJson = TestUtility.SerializeObject(collectionRemovePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/collection/remove", postJson, removedCollectionItems);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.RemoveCollectionItemsAsync(collectionRemovePost).Result;

            response.Should().NotBeNull();

            response.Deleted.Should().NotBeNull();
            response.Deleted.Movies.Should().Be(1);
            response.Deleted.Episodes.Should().Be(12);
            response.Deleted.Shows.Should().NotHaveValue();
            response.Deleted.Seasons.Should().NotHaveValue();

            response.NotFound.Should().NotBeNull();
            response.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = response.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            response.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveCollectionItemsExceptions()
        {
            var collectionRemovePost = new TraktSyncCollectionPost
            {
                Movies = new List<TraktSyncCollectionPostMovie>()
                {
                    new TraktSyncCollectionPostMovie
                    {
                        CollectedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    }
                },
                Shows = new List<TraktSyncCollectionPostShow>()
                {
                    new TraktSyncCollectionPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    }
                },
                Episodes = new List<TraktSyncCollectionPostEpisode>()
                {
                    new TraktSyncCollectionPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var uri = "sync/collection/remove";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktSyncCollectionRemovePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveCollectionItemsAsync(collectionRemovePost);
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

        [TestMethod]
        public void TestTraktSyncModuleRemoveCollectionItemsArgumentExceptions()
        {
            Func<Task<TraktSyncCollectionRemovePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveCollectionItemsAsync(null);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveCollectionItemsAsync(new TraktSyncCollectionPost());
            act.ShouldThrow<ArgumentException>();

            var collectionRemovePost = new TraktSyncCollectionPost
            {
                Movies = new List<TraktSyncCollectionPostMovie>(),
                Shows = new List<TraktSyncCollectionPostShow>(),
                Episodes = new List<TraktSyncCollectionPostEpisode>()
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveCollectionItemsAsync(collectionRemovePost);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetWatchedMovies

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedMovies()
        {
            var watchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Watched\WatchedMovies.json");
            watchedMovies.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/watched/movies", watchedMovies);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedMoviesAsync().Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedMoviesComplete()
        {
            var watchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Watched\WatchedMovies.json");
            watchedMovies.Should().NotBeNullOrEmpty();

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"sync/watched/movies?extended={extendedInfo.ToString()}",
                                                   watchedMovies);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedMoviesAsync(extendedInfo).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedMoviesExceptions()
        {
            var uri = "sync/watched/movies";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<IEnumerable<TraktWatchedMovie>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedMoviesAsync();
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

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetWatchedShows

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedShows()
        {
            var watchedShows = TestUtility.ReadFileContents(@"Objects\Get\Watched\WatchedShows.json");
            watchedShows.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/watched/shows", watchedShows);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedShowsAsync().Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedShowsComplete()
        {
            var watchedShows = TestUtility.ReadFileContents(@"Objects\Get\Watched\WatchedShows.json");
            watchedShows.Should().NotBeNullOrEmpty();

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"sync/watched/shows?extended={extendedInfo.ToString()}",
                                                   watchedShows);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedShowsAsync(extendedInfo).Result;

            response.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedShowsExceptions()
        {
            var uri = "sync/watched/shows";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<IEnumerable<TraktWatchedShow>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedShowsAsync();
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

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetWatchedHistory

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistory()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history", watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithType()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}",
                                                             watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndId()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}/{itemId}",
                                                             watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDate()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}?start_at={startAt.ToTraktLongDateTimeString()}",
                watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDateAndEndDate()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}",
                watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, endAt).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDateAndEndDateAndExtendedOption()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}",
                watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, endAt,
                                                                                    extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDateAndEndDateAndExtendedOptionAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, endAt,
                                                                                    extendedInfo, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDateAndEndDateAndExtendedOptionAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, endAt,
                                                                                    extendedInfo, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDateAndExtendedOption()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo.ToString()}",
                watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, null,
                                                                                    extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDateAndExtendedOptionAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo.ToString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, null,
                                                                                    extendedInfo, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDateAndExtendedOptionAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo.ToString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, null,
                                                                                    extendedInfo, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDateAndExtendedOptionAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo.ToString()}" +
                $"&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, null,
                                                                                    extendedInfo, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDateAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}?start_at={startAt.ToTraktLongDateTimeString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDateAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}?start_at={startAt.ToTraktLongDateTimeString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDateAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}?start_at={startAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndEndDateAndExtendedOptionAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo.ToString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, null, endAt,
                                                                                    extendedInfo, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndEndDateAndExtendedOptionAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo.ToString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, null, endAt,
                                                                                    extendedInfo, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, null, endAt,
                                                                                    extendedInfo, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndEndDateAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}?end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, null, endAt, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndEndDateAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}?end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, null, endAt, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndEndDateAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}?end_at={endAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, null, endAt, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDateAndExtendedOption()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo.ToString()}",
                watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, null,
                                                                                    extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDateAndExtendedOptionAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo.ToString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, null,
                                                                                    extendedInfo, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDateAndExtendedOptionAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo.ToString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, null,
                                                                                    extendedInfo, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDateAndExtendedOptionAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo.ToString()}" +
                $"&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, null,
                                                                                    extendedInfo, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDate()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?start_at={startAt.ToTraktLongDateTimeString()}",
                watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedOption()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}",
                watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt,
                                                                                    extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedOptionAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt,
                                                                                    extendedInfo, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedOptionAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt,
                                                                                    extendedInfo, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDateAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt,
                                                                                    extendedInfo, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDateAndEndDate()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}",
                watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDateAndEndDateAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDateAndEndDateAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDateAndEndDateAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndEndDateAndExtendedOption()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo.ToString()}",
                watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt,
                                                                                    extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndEndDateAndExtendedOptionAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo.ToString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt,
                                                                                    extendedInfo, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndEndDateAndExtendedOptionAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?end_at={endAt.ToTraktLongDateTimeString()}&extended={extendedInfo.ToString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt,
                                                                                    extendedInfo, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?end_at={endAt.ToTraktLongDateTimeString()}" +
                                                             $"&extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                                                             watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt,
                                                                                    extendedInfo, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndEndDate()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?end_at={endAt.ToTraktLongDateTimeString()}",
                                                             watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndEndDateAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndEndDateAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndEndDateAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?end_at={endAt.ToTraktLongDateTimeString()}" +
                                                             $"&page={page}&limit={limit}",
                                                             watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndExtendedOption()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemCount = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?extended={extendedInfo.ToString()}",
                                                             watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, null,
                                                                                    extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndExtendedOptionAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemCount = 4;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?extended={extendedInfo.ToString()}&page={page}",
                                                             watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, null,
                                                                                    extendedInfo, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndExtendedOptionAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemCount = 4;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?extended={extendedInfo.ToString()}&limit={limit}",
                                                             watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, null,
                                                                                    extendedInfo, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndExtendedOptionAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, null,
                                                                                    extendedInfo, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?page={page}",
                                                             watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?limit={limit}",
                                                             watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.UriName}?page={page}&limit={limit}",
                                                             watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndExtendedOption()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo.ToString()}",
                watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, null,
                                                                                    extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndExtendedOptionAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, null,
                                                                                    extendedInfo, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndExtendedOptionAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, null,
                                                                                    extendedInfo, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndExtendedOptionAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&extended={extendedInfo.ToString()}" +
                $"&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, null,
                                                                                    extendedInfo, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDate()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}",
                watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndEndDateAndExtendedOption()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}",
                watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt,
                                                                                    extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndEndDateAndExtendedOptionAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt,
                                                                                    extendedInfo, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndEndDateAndExtendedOptionAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt,
                                                                                    extendedInfo, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndEndDateAndExtendedOptionAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt,
                                                                                    extendedInfo, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndEndDate()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}",
                watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndEndDateAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndEndDateAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndEndDateAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithEndDateAndExtendedOption()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var endAt = DateTime.UtcNow;
            var itemCount = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}",
                watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt,
                                                                                    extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithEndDateAndExtendedOptionAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt,
                                                                                    extendedInfo, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithEndDateAndExtendedOptionAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt,
                                                                                    extendedInfo, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithEndDateAndExtendedOptionAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt,
                                                                                    extendedInfo, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithEndDate()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var endAt = DateTime.UtcNow;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}",
                watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithEndDateAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithEndDateAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithEndDateAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithExtendedInfo()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var itemCount = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?extended={extendedInfo.ToString()}",
                watchedHistory, 1, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, null,
                                                                                    extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithExtendedInfoAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var page = 2;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?extended={extendedInfo.ToString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, null,
                                                                                    extendedInfo, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithExtendedInfoAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?extended={extendedInfo.ToString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, null,
                                                                                    extendedInfo, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithExtendedInfoAndPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, null,
                                                                                    extendedInfo, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history?page={page}",
                                                             watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history?limit={limit}",
                                                             watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryWithPageAndLimit()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history?page={page}&limit={limit}",
                                                             watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryComplete()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\History\History.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncItemType.Movie;
            var itemId = 123U;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.UriName}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, endAt,
                                                                                    extendedInfo, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistoryExceptions()
        {
            var uri = "sync/history";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktPaginationListResult<TraktHistoryItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync();
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

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AddWatchedHistoryItems

        [TestMethod]
        public void TestTraktSyncModuleAddWatchedHistoryItems()
        {
            var addedHistoryItems = TestUtility.ReadFileContents(@"Objects\Post\Syncs\History\Responses\SyncHistoryPostResponse.json");
            addedHistoryItems.Should().NotBeNullOrEmpty();

            var historyPost = new TraktSyncHistoryPost
            {
                Movies = new List<TraktSyncHistoryPostMovie>()
                {
                    new TraktSyncHistoryPostMovie
                    {
                        WatchedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncHistoryPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<TraktSyncHistoryPostShow>()
                {
                    new TraktSyncHistoryPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncHistoryPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<TraktSyncHistoryPostShowSeason>()
                        {
                            new TraktSyncHistoryPostShowSeason
                            {
                                WatchedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncHistoryPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<TraktSyncHistoryPostShowSeason>()
                        {
                            new TraktSyncHistoryPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<TraktSyncHistoryPostShowEpisode>()
                                {
                                    new TraktSyncHistoryPostShowEpisode
                                    {
                                        WatchedAt = DateTime.Parse("2014-09-03T09:10:11.000Z").ToUniversalTime(),
                                        Number = 1
                                    },
                                    new TraktSyncHistoryPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<TraktSyncHistoryPostEpisode>()
                {
                    new TraktSyncHistoryPostEpisode
                    {
                        WatchedAt = DateTime.Parse("2014-09-03T09:10:11.000Z").ToUniversalTime(),
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var postJson = TestUtility.SerializeObject(historyPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/history", postJson, addedHistoryItems);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.AddWatchedHistoryItemsAsync(historyPost).Result;

            response.Should().NotBeNull();

            response.Added.Should().NotBeNull();
            response.Added.Movies.Should().Be(2);
            response.Added.Episodes.Should().Be(72);
            response.Added.Shows.Should().NotHaveValue();
            response.Added.Seasons.Should().NotHaveValue();

            response.NotFound.Should().NotBeNull();
            response.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = response.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            response.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddWatchedHistoryItemsExceptions()
        {
            var historyPost = new TraktSyncHistoryPost
            {
                Movies = new List<TraktSyncHistoryPostMovie>()
                {
                    new TraktSyncHistoryPostMovie
                    {
                        WatchedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    }
                },
                Shows = new List<TraktSyncHistoryPostShow>()
                {
                    new TraktSyncHistoryPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    }
                },
                Episodes = new List<TraktSyncHistoryPostEpisode>()
                {
                    new TraktSyncHistoryPostEpisode
                    {
                        WatchedAt = DateTime.Parse("2014-09-03T09:10:11.000Z").ToUniversalTime(),
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var uri = "sync/history";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktSyncHistoryPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddWatchedHistoryItemsAsync(historyPost);
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

        [TestMethod]
        public void TestTraktSyncModuleAddWatchedHistoryItemsArgumentExceptions()
        {
            Func<Task<TraktSyncHistoryPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddWatchedHistoryItemsAsync(null);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddWatchedHistoryItemsAsync(new TraktSyncHistoryPost());
            act.ShouldThrow<ArgumentException>();

            var collectionPost = new TraktSyncHistoryPost
            {
                Movies = new List<TraktSyncHistoryPostMovie>(),
                Shows = new List<TraktSyncHistoryPostShow>(),
                Episodes = new List<TraktSyncHistoryPostEpisode>()
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddWatchedHistoryItemsAsync(collectionPost);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RemoveWatchedHistoryItems

        [TestMethod]
        public void TestTraktSyncModuleRemoveWatchedHistoryItems()
        {
            var removedHistoryItems = TestUtility.ReadFileContents(@"Objects\Post\Syncs\History\Responses\SyncHistoryRemovePostResponse.json");
            removedHistoryItems.Should().NotBeNullOrEmpty();

            var historyRemovePost = new TraktSyncHistoryRemovePost
            {
                Movies = new List<TraktSyncHistoryPostMovie>()
                {
                    new TraktSyncHistoryPostMovie
                    {
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncHistoryPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<TraktSyncHistoryPostShow>()
                {
                    new TraktSyncHistoryPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncHistoryPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<TraktSyncHistoryPostShowSeason>()
                        {
                            new TraktSyncHistoryPostShowSeason
                            {
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncHistoryPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<TraktSyncHistoryPostShowSeason>()
                        {
                            new TraktSyncHistoryPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<TraktSyncHistoryPostShowEpisode>()
                                {
                                    new TraktSyncHistoryPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktSyncHistoryPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<TraktSyncHistoryPostEpisode>()
                {
                    new TraktSyncHistoryPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var postJson = TestUtility.SerializeObject(historyRemovePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/history/remove", postJson, removedHistoryItems);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.RemoveWatchedHistoryItemsAsync(historyRemovePost).Result;

            response.Should().NotBeNull();

            response.Deleted.Should().NotBeNull();
            response.Deleted.Movies.Should().Be(2);
            response.Deleted.Episodes.Should().Be(72);
            response.Deleted.Shows.Should().NotHaveValue();
            response.Deleted.Seasons.Should().NotHaveValue();

            response.NotFound.Should().NotBeNull();
            response.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = response.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0U);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            response.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();

            response.NotFound.Ids.Should().NotBeNull().And.HaveCount(2);
            response.NotFound.Ids.Should().Contain(new List<ulong>() { 23, 42 });
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveWatchedHistoryItemsExceptions()
        {
            var historyRemovePost = new TraktSyncHistoryRemovePost
            {
                Movies = new List<TraktSyncHistoryPostMovie>()
                {
                    new TraktSyncHistoryPostMovie
                    {
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    }
                },
                Shows = new List<TraktSyncHistoryPostShow>()
                {
                    new TraktSyncHistoryPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    }
                },
                Episodes = new List<TraktSyncHistoryPostEpisode>()
                {
                    new TraktSyncHistoryPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var uri = "sync/history/remove";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktSyncHistoryRemovePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveWatchedHistoryItemsAsync(historyRemovePost);
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

        [TestMethod]
        public void TestTraktSyncModuleRemoveWatchedHistoryItemsArgumentExceptions()
        {
            Func<Task<TraktSyncHistoryRemovePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveWatchedHistoryItemsAsync(null);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveWatchedHistoryItemsAsync(new TraktSyncHistoryRemovePost());
            act.ShouldThrow<ArgumentException>();

            var collectionPost = new TraktSyncHistoryRemovePost
            {
                Movies = new List<TraktSyncHistoryPostMovie>(),
                Shows = new List<TraktSyncHistoryPostShow>(),
                Episodes = new List<TraktSyncHistoryPostEpisode>()
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveWatchedHistoryItemsAsync(collectionPost);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetRatings

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatings()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync().Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithType()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var type = TraktRatingsItemType.Movie;

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_10()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}/{ratingsFilterString}", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_10_11()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_0_1_2_3_4_5_6_7_8_9_10()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_11()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 11 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_0_1_2_3_4_5_6_7_8_9()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithRatingsFilter()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(null, ratingsFilter).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndExtendedOption()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var type = TraktRatingsItemType.Movie;

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings/{type.UriName}?extended={extendedInfo.ToString()}", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, null, extendedInfo).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithExtendedInfo()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"sync/ratings?extended={extendedInfo.ToString()}", ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(null, null, extendedInfo).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsComplete()
        {
            var ratings = TestUtility.ReadFileContents(@"Objects\Get\Ratings\Ratings.json");
            ratings.Should().NotBeNullOrEmpty();

            var encodedComma = "%2C";

            var type = TraktRatingsItemType.Movie;
            var ratingsFilter = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var ratingsFilterString = string.Join(encodedComma, ratingsFilter);

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth(
                $"sync/ratings/{type.UriName}/{ratingsFilterString}?extended={extendedInfo.ToString()}",
                ratings);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync(type, ratingsFilter, extendedInfo).Result;

            response.Should().NotBeNull().And.HaveCount(4);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsExceptions()
        {
            var uri = "sync/ratings";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<IEnumerable<TraktRatingsItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetRatingsAsync();
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

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AddRatings

        [TestMethod]
        public void TestTraktSyncModuleAddRatings()
        {
            var addedRatingsItems = TestUtility.ReadFileContents(@"Objects\Post\Syncs\Ratings\Responses\SyncRatingsPostResponse.json");
            addedRatingsItems.Should().NotBeNullOrEmpty();

            var ratingsPost = new TraktSyncRatingsPost
            {
                Movies = new List<TraktSyncRatingsPostMovie>()
                {
                    new TraktSyncRatingsPostMovie
                    {
                        RatedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                        Rating = 5,
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncRatingsPostMovie
                    {
                        Rating = 10,
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<TraktSyncRatingsPostShow>()
                {
                    new TraktSyncRatingsPostShow
                    {
                        Rating = 9,
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncRatingsPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<TraktSyncRatingsPostShowSeason>()
                        {
                            new TraktSyncRatingsPostShowSeason
                            {
                                Rating = 8,
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncRatingsPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<TraktSyncRatingsPostShowSeason>()
                        {
                            new TraktSyncRatingsPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<TraktSyncRatingsPostShowEpisode>()
                                {
                                    new TraktSyncRatingsPostShowEpisode
                                    {
                                        Rating = 7,
                                        Number = 1
                                    },
                                    new TraktSyncRatingsPostShowEpisode
                                    {
                                        Rating = 8,
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<TraktSyncRatingsPostEpisode>()
                {
                    new TraktSyncRatingsPostEpisode
                    {
                        Rating = 7,
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var postJson = TestUtility.SerializeObject(ratingsPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/ratings", postJson, addedRatingsItems);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.AddRatingsAsync(ratingsPost).Result;

            response.Should().NotBeNull();

            response.Added.Should().NotBeNull();
            response.Added.Movies.Should().Be(1);
            response.Added.Episodes.Should().Be(4);
            response.Added.Shows.Should().Be(2);
            response.Added.Seasons.Should().Be(3);

            response.NotFound.Should().NotBeNull();
            response.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = response.NotFound.Movies.ToArray();

            movies[0].Rating.Should().Be(10);
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            response.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddRatingsExceptions()
        {
            var ratingsPost = new TraktSyncRatingsPost
            {
                Movies = new List<TraktSyncRatingsPostMovie>()
                {
                    new TraktSyncRatingsPostMovie
                    {
                        RatedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                        Rating = 5,
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    }
                },
                Shows = new List<TraktSyncRatingsPostShow>()
                {
                    new TraktSyncRatingsPostShow
                    {
                        Rating = 9,
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    }
                },
                Episodes = new List<TraktSyncRatingsPostEpisode>()
                {
                    new TraktSyncRatingsPostEpisode
                    {
                        Rating = 7,
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var uri = "sync/ratings";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktSyncRatingsPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddRatingsAsync(ratingsPost);
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

        [TestMethod]
        public void TestTraktSyncModuleAddRatingsArgumentExceptions()
        {
            Func<Task<TraktSyncRatingsPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddRatingsAsync(null);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddRatingsAsync(new TraktSyncRatingsPost());
            act.ShouldThrow<ArgumentException>();

            var ratingsPost = new TraktSyncRatingsPost
            {
                Movies = new List<TraktSyncRatingsPostMovie>(),
                Shows = new List<TraktSyncRatingsPostShow>(),
                Episodes = new List<TraktSyncRatingsPostEpisode>()
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddRatingsAsync(ratingsPost);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RemoveRatings

        [TestMethod]
        public void TestTraktSyncModuleRemoveRatings()
        {
            var removedRatingsItems = TestUtility.ReadFileContents(@"Objects\Post\Syncs\Ratings\Responses\SyncRatingsRemovePostResponse.json");
            removedRatingsItems.Should().NotBeNullOrEmpty();

            var ratingsRemovePost = new TraktSyncRatingsPost
            {
                Movies = new List<TraktSyncRatingsPostMovie>()
                {
                    new TraktSyncRatingsPostMovie
                    {
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncRatingsPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<TraktSyncRatingsPostShow>()
                {
                    new TraktSyncRatingsPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncRatingsPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<TraktSyncRatingsPostShowSeason>()
                        {
                            new TraktSyncRatingsPostShowSeason
                            {
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncRatingsPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<TraktSyncRatingsPostShowSeason>()
                        {
                            new TraktSyncRatingsPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<TraktSyncRatingsPostShowEpisode>()
                                {
                                    new TraktSyncRatingsPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktSyncRatingsPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<TraktSyncRatingsPostEpisode>()
                {
                    new TraktSyncRatingsPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var postJson = TestUtility.SerializeObject(ratingsRemovePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/ratings/remove", postJson, removedRatingsItems);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.RemoveRatingsAsync(ratingsRemovePost).Result;

            response.Should().NotBeNull();

            response.Deleted.Should().NotBeNull();
            response.Deleted.Movies.Should().Be(1);
            response.Deleted.Episodes.Should().Be(4);
            response.Deleted.Shows.Should().Be(2);
            response.Deleted.Seasons.Should().Be(3);

            response.NotFound.Should().NotBeNull();
            response.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = response.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            response.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveRatingsExceptions()
        {
            var ratingsRemovePost = new TraktSyncRatingsPost
            {
                Movies = new List<TraktSyncRatingsPostMovie>()
                {
                    new TraktSyncRatingsPostMovie
                    {
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    }
                },
                Shows = new List<TraktSyncRatingsPostShow>()
                {
                    new TraktSyncRatingsPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    }
                },
                Episodes = new List<TraktSyncRatingsPostEpisode>()
                {
                    new TraktSyncRatingsPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var uri = "sync/ratings/remove";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktSyncRatingsRemovePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveRatingsAsync(ratingsRemovePost);
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

        [TestMethod]
        public void TestTraktSyncModuleRemoveRatingsArgumentExceptions()
        {
            Func<Task<TraktSyncRatingsRemovePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveRatingsAsync(null);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveRatingsAsync(new TraktSyncRatingsPost());
            act.ShouldThrow<ArgumentException>();

            var ratingsRemovePost = new TraktSyncRatingsPost
            {
                Movies = new List<TraktSyncRatingsPostMovie>(),
                Shows = new List<TraktSyncRatingsPostShow>(),
                Episodes = new List<TraktSyncRatingsPostEpisode>()
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveRatingsAsync(ratingsRemovePost);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetWatchlist

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlist()
        {
            var watchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            watchlist.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var sortBy = "rank";
            var sortHow = "asc";

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/watchlist",
                                                             watchlist, 1, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistWithType()
        {
            var watchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            watchlist.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var type = TraktSyncItemType.Episode;
            var sortBy = "rank";
            var sortHow = "asc";

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/watchlist/{type.UriName}",
                                                             watchlist, 1, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(type).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistWithTypeAndExtendedOption()
        {
            var watchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            watchlist.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var type = TraktSyncItemType.Episode;
            var sortBy = "rank";
            var sortHow = "asc";

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/watchlist/{type.UriName}?extended={extendedInfo.ToString()}",
                                                             watchlist, 1, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(type, extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistWithTypeAndExtendedOptionAndPage()
        {
            var watchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            watchlist.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var type = TraktSyncItemType.Episode;
            var page = 2;
            var sortBy = "rank";
            var sortHow = "asc";

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist/{type.UriName}?extended={extendedInfo.ToString()}&page={page}",
                watchlist, page, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(type, extendedInfo, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistWithTypeAndExtendedOptionAndLimit()
        {
            var watchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            watchlist.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var type = TraktSyncItemType.Episode;
            var limit = 4;
            var sortBy = "rank";
            var sortHow = "asc";

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist/{type.UriName}?extended={extendedInfo.ToString()}&limit={limit}",
                watchlist, 1, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(type, extendedInfo, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistWithExtendedInfo()
        {
            var watchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            watchlist.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var sortBy = "rank";
            var sortHow = "asc";

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/watchlist?extended={extendedInfo.ToString()}",
                                                             watchlist, 1, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(null, extendedInfo).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistWithExtendedInfoAndPage()
        {
            var watchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            watchlist.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var page = 2;
            var sortBy = "rank";
            var sortHow = "asc";

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist?extended={extendedInfo.ToString()}&page={page}",
                watchlist, page, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(null, extendedInfo, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistWithExtendedInfoAndLimit()
        {
            var watchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            watchlist.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var limit = 4;
            var sortBy = "rank";
            var sortHow = "asc";

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist?extended={extendedInfo.ToString()}&limit={limit}",
                watchlist, 1, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(null, extendedInfo, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistWithExtendedInfoAndPageAndLimit()
        {
            var watchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            watchlist.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var page = 2;
            var limit = 4;
            var sortBy = "rank";
            var sortHow = "asc";

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                watchlist, page, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(null, extendedInfo, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistWithPage()
        {
            var watchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            watchlist.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var page = 2;
            var sortBy = "rank";
            var sortHow = "asc";

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist?page={page}", watchlist, page, 10, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(null, null, page).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(10);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistWithLimit()
        {
            var watchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            watchlist.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var limit = 4;
            var sortBy = "rank";
            var sortHow = "asc";

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist?limit={limit}", watchlist, 1, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(null, null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(1);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistWithPageAndLimit()
        {
            var watchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            watchlist.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var page = 2;
            var limit = 4;
            var sortBy = "rank";
            var sortHow = "asc";

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist?page={page}&limit={limit}",
                watchlist, page, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(null, null, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistComplete()
        {
            var watchlist = TestUtility.ReadFileContents(@"Objects\Get\Watchlist\Watchlist.json");
            watchlist.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var type = TraktSyncItemType.Episode;
            var page = 2;
            var limit = 4;
            var sortBy = "rank";
            var sortHow = "asc";

            var extendedInfo = new TraktExtendedInfo
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/watchlist/{type.UriName}?extended={extendedInfo.ToString()}&page={page}&limit={limit}",
                watchlist, page, limit, 1, itemCount, null, sortBy, sortHow);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync(type, extendedInfo, page, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(itemCount);
            response.ItemCount.Should().HaveValue().And.Be(itemCount);
            response.Limit.Should().HaveValue().And.Be(limit);
            response.Page.Should().HaveValue().And.Be(page);
            response.PageCount.Should().HaveValue().And.Be(1);
            response.SortBy.Should().NotBeNull().And.Be(sortBy);
            response.SortHow.Should().NotBeNull().And.Be(sortHow);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistExceptions()
        {
            var uri = "sync/watchlist";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<IEnumerable<TraktWatchlistItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchlistAsync();
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

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AddWatchlistItems

        [TestMethod]
        public void TestTraktSyncModuleAddWatchlistItems()
        {
            var addedWatchlistItems = TestUtility.ReadFileContents(@"Objects\Post\Syncs\Watchlist\Responses\SyncWatchlistPostResponse.json");
            addedWatchlistItems.Should().NotBeNullOrEmpty();

            var watchlistPost = new TraktSyncWatchlistPost
            {
                Movies = new List<TraktSyncWatchlistPostMovie>()
                {
                    new TraktSyncWatchlistPostMovie
                    {
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncWatchlistPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<TraktSyncWatchlistPostShow>()
                {
                    new TraktSyncWatchlistPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncWatchlistPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<TraktSyncWatchlistPostShowSeason>()
                        {
                            new TraktSyncWatchlistPostShowSeason
                            {
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncWatchlistPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<TraktSyncWatchlistPostShowSeason>()
                        {
                            new TraktSyncWatchlistPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<TraktSyncWatchlistPostShowEpisode>()
                                {
                                    new TraktSyncWatchlistPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktSyncWatchlistPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<TraktSyncWatchlistPostEpisode>()
                {
                    new TraktSyncWatchlistPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var postJson = TestUtility.SerializeObject(watchlistPost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/watchlist", postJson, addedWatchlistItems);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.AddWatchlistItemsAsync(watchlistPost).Result;

            response.Should().NotBeNull();

            response.Added.Should().NotBeNull();
            response.Added.Movies.Should().Be(1);
            response.Added.Episodes.Should().Be(2);
            response.Added.Shows.Should().Be(1);
            response.Added.Seasons.Should().Be(1);

            response.Existing.Should().NotBeNull();
            response.Existing.Movies.Should().Be(0);
            response.Existing.Episodes.Should().Be(0);
            response.Existing.Shows.Should().Be(1);
            response.Existing.Seasons.Should().Be(0);

            response.NotFound.Should().NotBeNull();
            response.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = response.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            response.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddWatchlistItemsExceptions()
        {
            var watchlistPost = new TraktSyncWatchlistPost
            {
                Movies = new List<TraktSyncWatchlistPostMovie>()
                {
                    new TraktSyncWatchlistPostMovie
                    {
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    }
                },
                Shows = new List<TraktSyncWatchlistPostShow>()
                {
                    new TraktSyncWatchlistPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    }
                },
                Episodes = new List<TraktSyncWatchlistPostEpisode>()
                {
                    new TraktSyncWatchlistPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var uri = "sync/watchlist";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktSyncWatchlistPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddWatchlistItemsAsync(watchlistPost);
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

        [TestMethod]
        public void TestTraktSyncModuleAddWatchlistItemsArgumentExceptions()
        {
            Func<Task<TraktSyncWatchlistPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddWatchlistItemsAsync(null);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddWatchlistItemsAsync(new TraktSyncWatchlistPost());
            act.ShouldThrow<ArgumentException>();

            var watchlistPost = new TraktSyncWatchlistPost
            {
                Movies = new List<TraktSyncWatchlistPostMovie>(),
                Shows = new List<TraktSyncWatchlistPostShow>(),
                Episodes = new List<TraktSyncWatchlistPostEpisode>()
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddWatchlistItemsAsync(watchlistPost);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RemoveWatchlistItems

        [TestMethod]
        public void TestTraktSyncModuleRemoveWatchlistItems()
        {
            var removedWatchlistItems = TestUtility.ReadFileContents(@"Objects\Post\Syncs\Watchlist\Responses\SyncWatchlistRemovePostResponse.json");
            removedWatchlistItems.Should().NotBeNullOrEmpty();

            var watchlistRemovePost = new TraktSyncWatchlistPost
            {
                Movies = new List<TraktSyncWatchlistPostMovie>()
                {
                    new TraktSyncWatchlistPostMovie
                    {
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    },
                    new TraktSyncWatchlistPostMovie
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<TraktSyncWatchlistPostShow>()
                {
                    new TraktSyncWatchlistPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    },
                    new TraktSyncWatchlistPostShow
                    {
                        Title = "The Walking Dead",
                        Year = 2010,
                        Ids = new TraktShowIds
                        {
                            Trakt = 2,
                            Slug = "the-walking-dead",
                            Tvdb = 153021,
                            Imdb = "tt1520211",
                            Tmdb = 1402,
                            TvRage = 25056
                        },
                        Seasons = new List<TraktSyncWatchlistPostShowSeason>()
                        {
                            new TraktSyncWatchlistPostShowSeason
                            {
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncWatchlistPostShow
                    {
                        Title = "Mad Men",
                        Year = 2007,
                        Ids = new TraktShowIds
                        {
                            Trakt = 4,
                            Slug = "mad-men",
                            Tvdb = 80337,
                            Imdb = "tt0804503",
                            Tmdb = 1104,
                            TvRage = 16356
                        },
                        Seasons = new List<TraktSyncWatchlistPostShowSeason>()
                        {
                            new TraktSyncWatchlistPostShowSeason
                            {
                                Number = 1,
                                Episodes = new List<TraktSyncWatchlistPostShowEpisode>()
                                {
                                    new TraktSyncWatchlistPostShowEpisode
                                    {
                                        Number = 1
                                    },
                                    new TraktSyncWatchlistPostShowEpisode
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<TraktSyncWatchlistPostEpisode>()
                {
                    new TraktSyncWatchlistPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var postJson = TestUtility.SerializeObject(watchlistRemovePost);
            postJson.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/watchlist/remove", postJson, removedWatchlistItems);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.RemoveWatchlistItemsAsync(watchlistRemovePost).Result;

            response.Should().NotBeNull();

            response.Deleted.Should().NotBeNull();
            response.Deleted.Movies.Should().Be(1);
            response.Deleted.Episodes.Should().Be(2);
            response.Deleted.Shows.Should().Be(1);
            response.Deleted.Seasons.Should().Be(1);

            response.NotFound.Should().NotBeNull();
            response.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = response.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            response.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveWatchlistItemsExceptions()
        {
            var watchlistRemovePost = new TraktSyncWatchlistPost
            {
                Movies = new List<TraktSyncWatchlistPostMovie>()
                {
                    new TraktSyncWatchlistPostMovie
                    {
                        Title = "Batman Begins",
                        Year = 2005,
                        Ids = new TraktMovieIds
                        {
                            Trakt = 1,
                            Slug = "batman-begins-2005",
                            Imdb = "tt0372784",
                            Tmdb = 272
                        }
                    }
                },
                Shows = new List<TraktSyncWatchlistPostShow>()
                {
                    new TraktSyncWatchlistPostShow
                    {
                        Title = "Breaking Bad",
                        Year = 2008,
                        Ids = new TraktShowIds
                        {
                            Trakt = 1,
                            Slug = "breaking-bad",
                            Tvdb = 81189,
                            Imdb = "tt0903747",
                            Tmdb = 1396,
                            TvRage = 18164
                        }
                    }
                },
                Episodes = new List<TraktSyncWatchlistPostEpisode>()
                {
                    new TraktSyncWatchlistPostEpisode
                    {
                        Ids = new TraktEpisodeIds
                        {
                            Trakt = 1061,
                            Tvdb = 1555111,
                            Imdb = "tt007404",
                            Tmdb = 422183,
                            TvRage = 12345
                        }
                    }
                }
            };

            var uri = "sync/watchlist/remove";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktSyncWatchlistRemovePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveWatchlistItemsAsync(watchlistRemovePost);
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

        [TestMethod]
        public void TestTraktSyncModuleRemoveWatchlistItemsArgumentExceptions()
        {
            Func<Task<TraktSyncWatchlistRemovePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveWatchlistItemsAsync(null);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveWatchlistItemsAsync(new TraktSyncWatchlistPost());
            act.ShouldThrow<ArgumentException>();

            var watchlistRemovePost = new TraktSyncWatchlistPost
            {
                Movies = new List<TraktSyncWatchlistPostMovie>(),
                Shows = new List<TraktSyncWatchlistPostShow>(),
                Episodes = new List<TraktSyncWatchlistPostEpisode>()
            };

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveWatchlistItemsAsync(watchlistRemovePost);
            act.ShouldThrow<ArgumentException>();
        }

        #endregion
    }
}
