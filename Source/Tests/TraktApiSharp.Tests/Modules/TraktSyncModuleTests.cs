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
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using TraktApiSharp.Objects.Get.Syncs.Activities;
    using TraktApiSharp.Objects.Get.Syncs.Collection;
    using TraktApiSharp.Objects.Get.Syncs.History;
    using TraktApiSharp.Objects.Get.Syncs.Playback;
    using TraktApiSharp.Objects.Get.Syncs.Watched;
    using TraktApiSharp.Objects.Post.Syncs.Collection;
    using TraktApiSharp.Objects.Post.Syncs.Collection.Responses;
    using TraktApiSharp.Objects.Post.Syncs.History;
    using TraktApiSharp.Objects.Post.Syncs.History.Responses;
    using TraktApiSharp.Requests;
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

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetPlaybackProgressWithExtendedOption()
        {
            var playbackProgress = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Playback\SyncPlaybackProgress.json");
            playbackProgress.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"sync/playback?extended={extendedOption.ToString()}", playbackProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetPlaybackProgressAsync(null, extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetPlaybackProgressWithExtendedOptionAndLimit()
        {
            var playbackProgress = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Playback\SyncPlaybackProgress.json");
            playbackProgress.Should().NotBeNullOrEmpty();

            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"sync/playback?extended={extendedOption.ToString()}&limit={limit}",
                                                   playbackProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetPlaybackProgressAsync(null, extendedOption, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetPlaybackProgressWithType()
        {
            var playbackProgress = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Playback\SyncPlaybackProgress.json");
            playbackProgress.Should().NotBeNullOrEmpty();

            var type = TraktSyncType.Episode;

            TestUtility.SetupMockResponseWithOAuth($"sync/playback/{type.AsStringUriParameter()}", playbackProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetPlaybackProgressAsync(type).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetPlaybackProgressWithTypeAndLimit()
        {
            var playbackProgress = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Playback\SyncPlaybackProgress.json");
            playbackProgress.Should().NotBeNullOrEmpty();

            var type = TraktSyncType.Episode;
            var limit = 4;

            TestUtility.SetupMockResponseWithOAuth($"sync/playback/{type.AsStringUriParameter()}?limit={limit}",
                                                   playbackProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetPlaybackProgressAsync(type, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetPlaybackProgressWithLimit()
        {
            var playbackProgress = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Playback\SyncPlaybackProgress.json");
            playbackProgress.Should().NotBeNullOrEmpty();

            var limit = 4;

            TestUtility.SetupMockResponseWithOAuth($"sync/playback?limit={limit}", playbackProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetPlaybackProgressAsync(null, null, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetPlaybackProgressComplete()
        {
            var playbackProgress = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Playback\SyncPlaybackProgress.json");
            playbackProgress.Should().NotBeNullOrEmpty();

            var type = TraktSyncType.Episode;
            var limit = 4;

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth(
                $"sync/playback/{type.AsStringUriParameter()}?extended={extendedOption.ToString()}&limit={limit}",
                playbackProgress);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetPlaybackProgressAsync(type, extendedOption, limit).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetPlaybackProgressExceptions()
        {
            var uri = "sync/playback";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktListResult<TraktSyncPlaybackProgressItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetPlaybackProgressAsync();
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

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RemovePlaybackItem

        [TestMethod]
        public void TestTraktSyncModuleGetRemovePlaybackItem()
        {
            var playbackId = "13";

            TestUtility.SetupMockResponseWithOAuth($"sync/playback/{playbackId}", HttpStatusCode.NoContent);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemovePlaybackItemAsync(playbackId);
            act.ShouldNotThrow();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetRemovePlaybackItemExceptions()
        {
            var playbackId = "13";

            var uri = $"sync/playback/{playbackId}";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemovePlaybackItemAsync(playbackId);
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktObjectNotFoundException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

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
        public void TestTraktSyncModuleGetRemovePlaybackItemArgumentExceptions()
        {
            Func<Task> act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemovePlaybackItemAsync(null);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemovePlaybackItemAsync(string.Empty);
            act.ShouldThrow<ArgumentException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemovePlaybackItemAsync("user name");
            act.ShouldThrow<ArgumentException>();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetCollectionMovies

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionMovies()
        {
            var collectionMovies = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Collection\SyncCollectionMoviesMetadata.json");
            collectionMovies.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/collection/movies", collectionMovies);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetCollectionMoviesAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionMoviesComplete()
        {
            var collectionMovies = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Collection\SyncCollectionMoviesMetadata.json");
            collectionMovies.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true,
                Metadata = true
            };

            TestUtility.SetupMockResponseWithOAuth($"sync/collection/movies?extended={extendedOption.ToString()}",
                                                   collectionMovies);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetCollectionMoviesAsync(extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionMoviesExceptions()
        {
            var uri = "sync/collection/movies";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktListResult<TraktSyncCollectionMovieItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetCollectionMoviesAsync();
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

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetCollectionShows

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionShows()
        {
            var collectionShows = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Collection\SyncCollectionShowsMetadata.json");
            collectionShows.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/collection/shows", collectionShows);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetCollectionShowsAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionShowsComplete()
        {
            var collectionShows = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Collection\SyncCollectionShowsMetadata.json");
            collectionShows.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true,
                Metadata = true
            };

            TestUtility.SetupMockResponseWithOAuth($"sync/collection/shows?extended={extendedOption.ToString()}",
                                                   collectionShows);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetCollectionShowsAsync(extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetCollectionShowsExceptions()
        {
            var uri = "sync/collection/shows";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktListResult<TraktSyncCollectionShowItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetCollectionShowsAsync();
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
                Movies = new List<TraktSyncCollectionPostMovieItem>()
                {
                    new TraktSyncCollectionPostMovieItem
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
                    new TraktSyncCollectionPostMovieItem
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<TraktSyncCollectionPostShowItem>()
                {
                    new TraktSyncCollectionPostShowItem
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
                    new TraktSyncCollectionPostShowItem
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
                        Seasons = new List<TraktSyncCollectionPostShowSeasonItem>()
                        {
                            new TraktSyncCollectionPostShowSeasonItem
                            {
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncCollectionPostShowItem
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
                        Seasons = new List<TraktSyncCollectionPostShowSeasonItem>()
                        {
                            new TraktSyncCollectionPostShowSeasonItem
                            {
                                Number = 1,
                                Episodes = new List<TraktSyncCollectionPostShowEpisodeItem>()
                                {
                                    new TraktSyncCollectionPostShowEpisodeItem
                                    {
                                        CollectedAt = DateTime.Parse("2014-09-03T09:10:11.000Z").ToUniversalTime(),
                                        Number = 1
                                    },
                                    new TraktSyncCollectionPostShowEpisodeItem
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<TraktSyncCollectionPostEpisodeItem>()
                {
                    new TraktSyncCollectionPostEpisodeItem
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
            movies[0].Ids.Tmdb.Should().NotHaveValue();

            response.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddCollectionItemsExceptions()
        {
            var collectionPost = new TraktSyncCollectionPost
            {
                Movies = new List<TraktSyncCollectionPostMovieItem>()
                {
                    new TraktSyncCollectionPostMovieItem
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
                Shows = new List<TraktSyncCollectionPostShowItem>()
                {
                    new TraktSyncCollectionPostShowItem
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
                Episodes = new List<TraktSyncCollectionPostEpisodeItem>()
                {
                    new TraktSyncCollectionPostEpisodeItem
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
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

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
        public void TestTraktSyncModuleAddCollectionItemsArgumentExceptions()
        {
            Func<Task<TraktSyncCollectionPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddCollectionItemsAsync(null);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddCollectionItemsAsync(new TraktSyncCollectionPost());
            act.ShouldThrow<ArgumentException>();

            var collectionPost = new TraktSyncCollectionPost
            {
                Movies = new List<TraktSyncCollectionPostMovieItem>(),
                Shows = new List<TraktSyncCollectionPostShowItem>(),
                Episodes = new List<TraktSyncCollectionPostEpisodeItem>()
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

            var collectionRemovePost = new TraktSyncCollectionRemovePost
            {
                Movies = new List<TraktSyncCollectionPostMovieItem>()
                {
                    new TraktSyncCollectionPostMovieItem
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
                    new TraktSyncCollectionPostMovieItem
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<TraktSyncCollectionPostShowItem>()
                {
                    new TraktSyncCollectionPostShowItem
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
                    new TraktSyncCollectionPostShowItem
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
                        Seasons = new List<TraktSyncCollectionPostShowSeasonItem>()
                        {
                            new TraktSyncCollectionPostShowSeasonItem
                            {
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncCollectionPostShowItem
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
                        Seasons = new List<TraktSyncCollectionPostShowSeasonItem>()
                        {
                            new TraktSyncCollectionPostShowSeasonItem
                            {
                                Number = 1,
                                Episodes = new List<TraktSyncCollectionPostShowEpisodeItem>()
                                {
                                    new TraktSyncCollectionPostShowEpisodeItem
                                    {
                                        CollectedAt = DateTime.Parse("2014-09-03T09:10:11.000Z").ToUniversalTime(),
                                        Number = 1
                                    },
                                    new TraktSyncCollectionPostShowEpisodeItem
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<TraktSyncCollectionPostEpisodeItem>()
                {
                    new TraktSyncCollectionPostEpisodeItem
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
            movies[0].Ids.Tmdb.Should().NotHaveValue();

            response.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveCollectionItemsExceptions()
        {
            var collectionRemovePost = new TraktSyncCollectionRemovePost
            {
                Movies = new List<TraktSyncCollectionPostMovieItem>()
                {
                    new TraktSyncCollectionPostMovieItem
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
                Shows = new List<TraktSyncCollectionPostShowItem>()
                {
                    new TraktSyncCollectionPostShowItem
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
                Episodes = new List<TraktSyncCollectionPostEpisodeItem>()
                {
                    new TraktSyncCollectionPostEpisodeItem
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
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

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
        public void TestTraktSyncModuleRemoveCollectionItemsArgumentExceptions()
        {
            Func<Task<TraktSyncCollectionRemovePostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveCollectionItemsAsync(null);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.RemoveCollectionItemsAsync(new TraktSyncCollectionRemovePost());
            act.ShouldThrow<ArgumentException>();

            var collectionRemovePost = new TraktSyncCollectionRemovePost
            {
                Movies = new List<TraktSyncCollectionPostMovieItem>(),
                Shows = new List<TraktSyncCollectionPostShowItem>(),
                Episodes = new List<TraktSyncCollectionPostEpisodeItem>()
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
            var watchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Watched\SyncWatchedMovies.json");
            watchedMovies.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/watched/movies", watchedMovies);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedMoviesAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedMoviesComplete()
        {
            var watchedMovies = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Watched\SyncWatchedMovies.json");
            watchedMovies.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"sync/watched/movies?extended={extendedOption.ToString()}",
                                                   watchedMovies);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedMoviesAsync(extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedMoviesExceptions()
        {
            var uri = "sync/watched/movies";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktListResult<TraktSyncWatchedMovieItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedMoviesAsync();
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

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetWatchedShows

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedShows()
        {
            var watchedShows = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Watched\SyncWatchedShows.json");
            watchedShows.Should().NotBeNullOrEmpty();

            TestUtility.SetupMockResponseWithOAuth("sync/watched/shows", watchedShows);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedShowsAsync().Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedShowsComplete()
        {
            var watchedShows = TestUtility.ReadFileContents(@"Objects\Get\Syncs\Watched\SyncWatchedShows.json");
            watchedShows.Should().NotBeNullOrEmpty();

            var extendedOption = new TraktExtendedOption
            {
                Full = true,
                Images = true
            };

            TestUtility.SetupMockResponseWithOAuth($"sync/watched/shows?extended={extendedOption.ToString()}",
                                                   watchedShows);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedShowsAsync(extendedOption).Result;

            response.Should().NotBeNull();
            response.Items.Should().NotBeNull().And.HaveCount(2);
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedShowsExceptions()
        {
            var uri = "sync/watched/shows";

            TestUtility.SetupMockResponseWithoutOAuth(uri, HttpStatusCode.Unauthorized);

            Func<Task<TraktListResult<TraktSyncWatchedShowItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedShowsAsync();
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

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetWatchedHistory

        [TestMethod]
        public void TestTraktSyncModuleGetWatchedHistory()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.AsStringUriParameter()}",
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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var itemId = "123";
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history/{type.AsStringUriParameter()}/{itemId}",
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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var itemId = "123";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}/{itemId}?start_at={startAt.ToTraktLongDateTimeString()}",
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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var itemId = "123";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}/{itemId}" +
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
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndIdAndStartDateAndPage()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var itemId = "123";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, null, page).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var itemId = "123";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, null, null, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var itemId = "123";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, null, page, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var itemId = "123";
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, null, endAt, page).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var itemId = "123";
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, null, endAt, null, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var itemId = "123";
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}/{itemId}" +
                $"?end_at={endAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, null, endAt, page, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}?start_at={startAt.ToTraktLongDateTimeString()}",
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
        public void TestTraktSyncModuleGetWatchedHistoryWithTypeAndStartDateAndEndDate()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}",
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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt, page).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt, null, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, startAt, endAt, page, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}?end_at={endAt.ToTraktLongDateTimeString()}",
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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}?end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt, page).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}?end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt, null, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}?end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, endAt, page, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}?page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, null, page).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}?limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, null, null, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}?page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, null, null, null, page, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
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
        public void TestTraktSyncModuleGetWatchedHistoryWithStartDateAndEndDate()
        {
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt, page).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt, null, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
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

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, endAt, page, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, null, page).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, null, null, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var startAt = DateTime.UtcNow.AddMonths(-1);
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?start_at={startAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, startAt, null, page, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}&page={page}",
                watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt, page).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}&limit={limit}",
                watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt, null, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history?end_at={endAt.ToTraktLongDateTimeString()}&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, endAt, page, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var page = 2;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history?page={page}",
                                                             watchedHistory, page, 10, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, null, page).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history?limit={limit}",
                                                             watchedHistory, 1, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, null, null, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth($"sync/history?page={page}&limit={limit}",
                                                             watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(null, null, null, null, page, limit).Result;

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
            var watchedHistory = TestUtility.ReadFileContents(@"Objects\Get\Syncs\History\SyncHistory.json");
            watchedHistory.Should().NotBeNullOrEmpty();

            var type = TraktSyncHistoryItemType.Movie;
            var itemId = "123";
            var startAt = DateTime.UtcNow.AddMonths(-1);
            var endAt = DateTime.UtcNow;
            var itemCount = 4;
            var page = 2;
            var limit = 4;

            TestUtility.SetupMockPaginationResponseWithOAuth(
                $"sync/history/{type.AsStringUriParameter()}/{itemId}" +
                $"?start_at={startAt.ToTraktLongDateTimeString()}&end_at={endAt.ToTraktLongDateTimeString()}" +
                $"&page={page}&limit={limit}",
                watchedHistory, page, limit, 1, itemCount);

            var response = TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync(type, itemId, startAt, endAt, page, limit).Result;

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

            Func<Task<TraktPaginationListResult<TraktSyncHistoryItem>>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.GetWatchedHistoryAsync();
            act.ShouldThrow<TraktAuthorizationException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.NotFound);
            act.ShouldThrow<TraktObjectNotFoundException>();

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
                Movies = new List<TraktSyncHistoryPostMovieItem>()
                {
                    new TraktSyncHistoryPostMovieItem
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
                    new TraktSyncHistoryPostMovieItem
                    {
                        Ids = new TraktMovieIds
                        {
                            Imdb = "tt0000111"
                        }
                    }
                },
                Shows = new List<TraktSyncHistoryPostShowItem>()
                {
                    new TraktSyncHistoryPostShowItem
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
                    new TraktSyncHistoryPostShowItem
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
                        Seasons = new List<TraktSyncHistoryPostShowSeasonItem>()
                        {
                            new TraktSyncHistoryPostShowSeasonItem
                            {
                                WatchedAt = DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime(),
                                Number = 3
                            }
                        }
                    },
                    new TraktSyncHistoryPostShowItem
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
                        Seasons = new List<TraktSyncHistoryPostShowSeasonItem>()
                        {
                            new TraktSyncHistoryPostShowSeasonItem
                            {
                                Number = 1,
                                Episodes = new List<TraktSyncHistoryPostShowEpisodeItem>()
                                {
                                    new TraktSyncHistoryPostShowEpisodeItem
                                    {
                                        WatchedAt = DateTime.Parse("2014-09-03T09:10:11.000Z").ToUniversalTime(),
                                        Number = 1
                                    },
                                    new TraktSyncHistoryPostShowEpisodeItem
                                    {
                                        Number = 2
                                    }
                                }
                            }
                        }
                    }
                },
                Episodes = new List<TraktSyncHistoryPostEpisodeItem>()
                {
                    new TraktSyncHistoryPostEpisodeItem
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
            movies[0].Ids.Tmdb.Should().NotHaveValue();

            response.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            response.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddWatchedHistoryItemsExceptions()
        {
            var historyPost = new TraktSyncHistoryPost
            {
                Movies = new List<TraktSyncHistoryPostMovieItem>()
                {
                    new TraktSyncHistoryPostMovieItem
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
                Shows = new List<TraktSyncHistoryPostShowItem>()
                {
                    new TraktSyncHistoryPostShowItem
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
                Episodes = new List<TraktSyncHistoryPostEpisodeItem>()
                {
                    new TraktSyncHistoryPostEpisodeItem
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
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.BadRequest);
            act.ShouldThrow<TraktBadRequestException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Forbidden);
            act.ShouldThrow<TraktForbiddenException>();

            TestUtility.ClearMockHttpClient();
            TestUtility.SetupMockResponseWithOAuth(uri, HttpStatusCode.Conflict);
            act.ShouldThrow<TraktConflictException>();

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
        public void TestTraktSyncModuleAddWatchedHistoryItemsArgumentExceptions()
        {
            Func<Task<TraktSyncHistoryPostResponse>> act =
                async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddWatchedHistoryItemsAsync(null);
            act.ShouldThrow<ArgumentNullException>();

            act = async () => await TestUtility.MOCK_TEST_CLIENT.Sync.AddWatchedHistoryItemsAsync(new TraktSyncHistoryPost());
            act.ShouldThrow<ArgumentException>();

            var collectionPost = new TraktSyncHistoryPost
            {
                Movies = new List<TraktSyncHistoryPostMovieItem>(),
                Shows = new List<TraktSyncHistoryPostShowItem>(),
                Episodes = new List<TraktSyncHistoryPostEpisodeItem>()
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
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveWatchedHistoryItemsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveWatchedHistoryItemsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetRatings

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatings()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithType()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_10()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_10_11()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_0_1_2_3_4_5_6_7_8_9_10()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_1_2_3_4_5_6_7_8_9_11()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndRatingsFilter_0_1_2_3_4_5_6_7_8_9()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithRatingsFilter()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithTypeAndExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetUserRatingsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AddRatings

        [TestMethod]
        public void TestTraktSyncModuleAddRatings()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddRatingsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddRatingsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RemoveRatings

        [TestMethod]
        public void TestTraktSyncModuleRemoveRatings()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveRatingsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveRatingsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region GetWatchlist

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlist()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistWithType()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistWithExtendedOption()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistComplete()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleGetWatchlistExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region AddWatchlistItems

        [TestMethod]
        public void TestTraktSyncModuleAddWatchlistItems()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddWatchlistItemsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleAddWatchlistItemsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion

        // -----------------------------------------------------------------------------------------------
        // -----------------------------------------------------------------------------------------------

        #region RemoveWatchlistItems

        [TestMethod]
        public void TestTraktSyncModuleRemoveWatchlistItems()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveWatchlistItemsExceptions()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestTraktSyncModuleRemoveWatchlistItemsArgumentExceptions()
        {
            Assert.Fail();
        }

        #endregion
    }
}
