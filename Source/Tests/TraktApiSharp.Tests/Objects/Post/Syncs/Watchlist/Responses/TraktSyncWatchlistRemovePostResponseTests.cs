namespace TraktApiSharp.Tests.Objects.Post.Syncs.Watchlist.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses;
    using Utils;

    [TestClass]
    public class TraktSyncWatchlistRemovePostResponseTests
    {
        [TestMethod]
        public void TestTraktSyncWatchlistRemovePostResponseDefaultConstructor()
        {
            var watchlistRemovePost = new TraktSyncWatchlistRemovePostResponse();

            watchlistRemovePost.Deleted.Should().BeNull();
            watchlistRemovePost.NotFound.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncWatchlistRemovePostReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Syncs\Watchlist\Responses\SyncWatchlistRemovePostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var watchlistRemovePost = JsonConvert.DeserializeObject<TraktSyncWatchlistRemovePostResponse>(jsonFile);

            watchlistRemovePost.Should().NotBeNull();

            watchlistRemovePost.Deleted.Should().NotBeNull();
            watchlistRemovePost.Deleted.Movies.Should().Be(1);
            watchlistRemovePost.Deleted.Episodes.Should().Be(2);
            watchlistRemovePost.Deleted.Shows.Should().Be(1);
            watchlistRemovePost.Deleted.Seasons.Should().Be(1);

            watchlistRemovePost.NotFound.Should().NotBeNull();
            watchlistRemovePost.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = watchlistRemovePost.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            watchlistRemovePost.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            watchlistRemovePost.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            watchlistRemovePost.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }
    }
}
