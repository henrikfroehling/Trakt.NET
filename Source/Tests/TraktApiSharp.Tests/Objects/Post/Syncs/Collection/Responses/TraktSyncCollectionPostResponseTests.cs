namespace TraktApiSharp.Tests.Objects.Post.Syncs.Collection.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Linq;
    using TraktApiSharp.Objects.Post.Syncs.Collection.Responses;
    using Utils;

    [TestClass]
    public class TraktSyncCollectionPostResponseTests
    {
        [TestMethod]
        public void TestTraktSyncCollectionPostResponseDefaultConstructor()
        {
            var collectionPostResponse = new TraktSyncCollectionPostResponse();

            collectionPostResponse.Added.Should().BeNull();
            collectionPostResponse.Updated.Should().BeNull();
            collectionPostResponse.Existing.Should().BeNull();
            collectionPostResponse.NotFound.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncCollectionPostResponseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Syncs\Collection\Responses\SyncCollectionPostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var collectionPostResponse = JsonConvert.DeserializeObject<TraktSyncCollectionPostResponse>(jsonFile);

            collectionPostResponse.Should().NotBeNull();

            collectionPostResponse.Added.Should().NotBeNull();
            collectionPostResponse.Added.Movies.Should().Be(1);
            collectionPostResponse.Added.Episodes.Should().Be(12);
            collectionPostResponse.Added.Shows.Should().NotHaveValue();
            collectionPostResponse.Added.Seasons.Should().NotHaveValue();

            collectionPostResponse.Updated.Should().NotBeNull();
            collectionPostResponse.Updated.Movies.Should().Be(3);
            collectionPostResponse.Updated.Episodes.Should().Be(1);
            collectionPostResponse.Updated.Shows.Should().NotHaveValue();
            collectionPostResponse.Updated.Seasons.Should().NotHaveValue();

            collectionPostResponse.Existing.Should().NotBeNull();
            collectionPostResponse.Existing.Movies.Should().Be(2);
            collectionPostResponse.Existing.Episodes.Should().Be(0);
            collectionPostResponse.Existing.Shows.Should().NotHaveValue();
            collectionPostResponse.Existing.Seasons.Should().NotHaveValue();

            collectionPostResponse.NotFound.Should().NotBeNull();
            collectionPostResponse.NotFound.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = collectionPostResponse.NotFound.Movies.ToArray();

            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(0);
            movies[0].Ids.Slug.Should().BeNullOrEmpty();
            movies[0].Ids.Imdb.Should().Be("tt0000111");
            movies[0].Ids.Tmdb.Should().BeNull();

            collectionPostResponse.NotFound.Shows.Should().NotBeNull().And.BeEmpty();
            collectionPostResponse.NotFound.Seasons.Should().NotBeNull().And.BeEmpty();
            collectionPostResponse.NotFound.Episodes.Should().NotBeNull().And.BeEmpty();
        }
    }
}
