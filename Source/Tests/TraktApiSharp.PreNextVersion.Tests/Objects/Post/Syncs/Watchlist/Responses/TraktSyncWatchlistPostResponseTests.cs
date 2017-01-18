namespace TraktApiSharp.Tests.Objects.Post.Syncs.Watchlist.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects.Post.Syncs.Watchlist.Responses;
    using Utils;

    [TestClass]
    public class TraktSyncWatchlistPostResponseTests
    {
        [TestMethod]
        public void TestTraktSyncWatchlistPostResponseDefaultConstructor()
        {
            var watchlistPostResponse = new TraktSyncWatchlistPostResponse();

            watchlistPostResponse.Added.Should().BeNull();
            watchlistPostResponse.Existing.Should().BeNull();
            watchlistPostResponse.NotFound.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncWatchlistPostReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Syncs\Watchlist\Responses\SyncWatchlistPostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var watchlistPostResponse = JsonConvert.DeserializeObject<TraktSyncWatchlistPostResponse>(jsonFile);

            watchlistPostResponse.Should().NotBeNull();

            watchlistPostResponse.Added.Should().NotBeNull();
            watchlistPostResponse.Added.Movies.Should().Be(1);
            watchlistPostResponse.Added.Episodes.Should().Be(2);
            watchlistPostResponse.Added.Shows.Should().Be(1);
            watchlistPostResponse.Added.Seasons.Should().Be(1);

            watchlistPostResponse.Existing.Should().NotBeNull();
            watchlistPostResponse.Existing.Movies.Should().Be(0);
            watchlistPostResponse.Existing.Episodes.Should().Be(0);
            watchlistPostResponse.Existing.Shows.Should().Be(1);
            watchlistPostResponse.Existing.Seasons.Should().Be(0);

            watchlistPostResponse.NotFound.Should().NotBeNull();
            watchlistPostResponse.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = watchlistPostResponse.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            watchlistPostResponse.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            watchlistPostResponse.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            watchlistPostResponse.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }
    }
}
