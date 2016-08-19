namespace TraktApiSharp.Tests.Objects.Post.Syncs.Collection.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects.Post.Syncs.Collection.Responses;
    using Utils;

    [TestClass]
    public class TraktSyncCollectionRemovePostResponseTests
    {
        [TestMethod]
        public void TestTraktSyncCollectionRemovePostDefaultConstrctor()
        {
            var collectionRemovePost = new TraktSyncCollectionRemovePostResponse();

            collectionRemovePost.Deleted.Should().BeNull();
            collectionRemovePost.NotFound.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncCollectionRemovePostReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Syncs\Collection\Responses\SyncCollectionRemovePostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var collectionRemovePost = JsonConvert.DeserializeObject<TraktSyncCollectionRemovePostResponse>(jsonFile);

            collectionRemovePost.Should().NotBeNull();

            collectionRemovePost.Deleted.Should().NotBeNull();
            collectionRemovePost.Deleted.Movies.Should().Be(1);
            collectionRemovePost.Deleted.Episodes.Should().Be(12);
            collectionRemovePost.Deleted.Shows.Should().NotHaveValue();
            collectionRemovePost.Deleted.Seasons.Should().NotHaveValue();

            collectionRemovePost.NotFound.Should().NotBeNull();
            collectionRemovePost.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = collectionRemovePost.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            collectionRemovePost.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            collectionRemovePost.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            collectionRemovePost.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }
    }
}
