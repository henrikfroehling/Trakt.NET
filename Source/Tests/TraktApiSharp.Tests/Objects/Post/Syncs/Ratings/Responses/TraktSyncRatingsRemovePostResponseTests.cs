namespace TraktApiSharp.Tests.Objects.Post.Syncs.Ratings.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects.Post.Syncs.Ratings.Responses;
    using Utils;

    [TestClass]
    public class TraktSyncRatingsRemovePostResponseTests
    {
        [TestMethod]
        public void TestTraktSyncRatingsRemovePostResponseDefaultConstructor()
        {
            var ratingsRemovePost = new TraktSyncRatingsRemovePostResponse();

            ratingsRemovePost.Deleted.Should().BeNull();
            ratingsRemovePost.NotFound.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncRatingsRemovePostResponseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Syncs\Ratings\Responses\SyncRatingsRemovePostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var ratingsRemovePost = JsonConvert.DeserializeObject<TraktSyncRatingsRemovePostResponse>(jsonFile);

            ratingsRemovePost.Should().NotBeNull();

            ratingsRemovePost.Deleted.Should().NotBeNull();
            ratingsRemovePost.Deleted.Movies.Should().Be(1);
            ratingsRemovePost.Deleted.Episodes.Should().Be(4);
            ratingsRemovePost.Deleted.Shows.Should().Be(2);
            ratingsRemovePost.Deleted.Seasons.Should().Be(3);

            ratingsRemovePost.NotFound.Should().NotBeNull();
            ratingsRemovePost.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = ratingsRemovePost.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            ratingsRemovePost.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            ratingsRemovePost.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            ratingsRemovePost.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }
    }
}
