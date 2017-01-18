namespace TraktApiSharp.Tests.Objects.Post.Syncs.Ratings.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects.Post.Syncs.Ratings.Responses;
    using Utils;

    [TestClass]
    public class TraktSyncRatingsPostResponseTests
    {
        [TestMethod]
        public void TestTraktSyncRatingsPostResponseDefaultConstructor()
        {
            var ratingsPostResponse = new TraktSyncRatingsPostResponse();

            ratingsPostResponse.Added.Should().BeNull();
            ratingsPostResponse.NotFound.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostResponseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Syncs\Ratings\Responses\SyncRatingsPostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var ratingsPostResponse = JsonConvert.DeserializeObject<TraktSyncRatingsPostResponse>(jsonFile);

            ratingsPostResponse.Should().NotBeNull();

            ratingsPostResponse.Added.Should().NotBeNull();
            ratingsPostResponse.Added.Movies.Should().Be(1);
            ratingsPostResponse.Added.Episodes.Should().Be(4);
            ratingsPostResponse.Added.Shows.Should().Be(2);
            ratingsPostResponse.Added.Seasons.Should().Be(3);

            ratingsPostResponse.NotFound.Should().NotBeNull();
            ratingsPostResponse.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = ratingsPostResponse.NotFound.Movies.ToArray();

            movies[0].Rating.Should().Be(10);
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            ratingsPostResponse.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            ratingsPostResponse.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            ratingsPostResponse.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }
    }
}
