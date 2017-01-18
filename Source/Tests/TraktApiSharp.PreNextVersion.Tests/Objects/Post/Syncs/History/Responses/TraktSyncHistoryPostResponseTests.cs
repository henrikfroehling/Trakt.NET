namespace TraktApiSharp.Tests.Objects.Post.Syncs.History.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects.Post.Syncs.History.Responses;
    using Utils;

    [TestClass]
    public class TraktSyncHistoryPostResponseTests
    {
        [TestMethod]
        public void TestTraktSyncHistoryPostResponseDefaultConstructor()
        {
            var historyPostResponse = new TraktSyncHistoryPostResponse();

            historyPostResponse.Added.Should().BeNull();
            historyPostResponse.NotFound.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncHistoryPostResponseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Syncs\History\Responses\SyncHistoryPostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var historyPostResponse = JsonConvert.DeserializeObject<TraktSyncHistoryPostResponse>(jsonFile);

            historyPostResponse.Should().NotBeNull();

            historyPostResponse.Added.Should().NotBeNull();
            historyPostResponse.Added.Movies.Should().Be(2);
            historyPostResponse.Added.Episodes.Should().Be(72);
            historyPostResponse.Added.Shows.Should().NotHaveValue();
            historyPostResponse.Added.Seasons.Should().NotHaveValue();

            historyPostResponse.NotFound.Should().NotBeNull();
            historyPostResponse.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = historyPostResponse.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            historyPostResponse.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            historyPostResponse.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            historyPostResponse.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }
    }
}
