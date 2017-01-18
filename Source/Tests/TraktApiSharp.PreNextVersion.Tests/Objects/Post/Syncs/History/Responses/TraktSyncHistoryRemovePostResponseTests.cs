namespace TraktApiSharp.Tests.Objects.Post.Syncs.History.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Post.Syncs.History.Responses;
    using Utils;

    [TestClass]
    public class TraktSyncHistoryRemovePostResponseTests
    {
        [TestMethod]
        public void TestTraktSyncHistoryRemovePostResponseDefaultConstructor()
        {
            var historyRemovePost = new TraktSyncHistoryRemovePostResponse();

            historyRemovePost.Deleted.Should().BeNull();
            historyRemovePost.NotFound.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncHistoryRemovePostResponseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Syncs\History\Responses\SyncHistoryRemovePostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var historyRemovePost = JsonConvert.DeserializeObject<TraktSyncHistoryRemovePostResponse>(jsonFile);

            historyRemovePost.Should().NotBeNull();

            historyRemovePost.Deleted.Should().NotBeNull();
            historyRemovePost.Deleted.Movies.Should().Be(2);
            historyRemovePost.Deleted.Episodes.Should().Be(72);
            historyRemovePost.Deleted.Shows.Should().NotHaveValue();
            historyRemovePost.Deleted.Seasons.Should().NotHaveValue();

            historyRemovePost.NotFound.Should().NotBeNull();
            historyRemovePost.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = historyRemovePost.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            historyRemovePost.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            historyRemovePost.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            historyRemovePost.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();

            historyRemovePost.NotFound.Ids.Should().NotBeNull().And.HaveCount(2);
            historyRemovePost.NotFound.Ids.Should().Contain(new List<ulong>() { 23, 42 });
        }
    }
}
