namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using TraktNet.Objects.Post.Syncs.Recommendations.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Syncs.Recommendations.JsonReader")]
    public partial class SyncRecommendationsPostObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var traktJsonReader = new SyncRecommendationsPostObjectJsonReader();
            ITraktSyncRecommendationsPost traktSyncRecommendationsPost = await traktJsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktSyncRecommendationsPost.Should().NotBeNull();
            traktSyncRecommendationsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRecommendationsPostMovie[] postMovies = traktSyncRecommendationsPost.Movies.ToArray();

            postMovies[0].Title.Should().Be("Batman Begins");
            postMovies[0].Year.Should().Be(2005);
            postMovies[0].Ids.Should().NotBeNull();
            postMovies[0].Ids.Trakt.Should().Be(1U);
            postMovies[0].Ids.Slug.Should().Be("batman-begins-2005");
            postMovies[0].Ids.Imdb.Should().Be("tt0372784");
            postMovies[0].Ids.Tmdb.Should().Be(272U);
            postMovies[0].Notes.Should().Be("One of Chritian Bale's most iconic roles.");

            postMovies[1].Title.Should().BeNull();
            postMovies[1].Year.Should().BeNull();
            postMovies[1].Ids.Should().NotBeNull();
            postMovies[1].Ids.Trakt.Should().Be(0U);
            postMovies[1].Ids.Slug.Should().BeNull();
            postMovies[1].Ids.Imdb.Should().Be("tt0000111");
            postMovies[1].Ids.Tmdb.Should().BeNull();
            postMovies[1].Notes.Should().BeNull();

            traktSyncRecommendationsPost.Shows.Should().NotBeNull().And.HaveCount(2);

            ITraktSyncRecommendationsPostShow[] postShows = traktSyncRecommendationsPost.Shows.ToArray();

            postShows[0].Title.Should().Be("Breaking Bad");
            postShows[0].Year.Should().Be(2008);
            postShows[0].Ids.Should().NotBeNull();
            postShows[0].Ids.Trakt.Should().Be(1U);
            postShows[0].Ids.Slug.Should().Be("breaking-bad");
            postShows[0].Ids.Tvdb.Should().Be(81189U);
            postShows[0].Ids.Imdb.Should().Be("tt0903747");
            postShows[0].Ids.Tmdb.Should().Be(1396U);
            postShows[0].Notes.Should().Be("I AM THE DANGER!");

            postShows[1].Title.Should().Be("The Walking Dead");
            postShows[1].Year.Should().Be(2010);
            postShows[1].Ids.Should().NotBeNull();
            postShows[1].Ids.Trakt.Should().Be(2U);
            postShows[1].Ids.Slug.Should().Be("the-walking-dead");
            postShows[1].Ids.Tvdb.Should().Be(153021U);
            postShows[1].Ids.Imdb.Should().Be("tt1520211");
            postShows[1].Ids.Tmdb.Should().Be(1402U);
            postShows[1].Notes.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var traktJsonReader = new SyncRecommendationsPostObjectJsonReader();
            Func<Task<ITraktSyncRecommendationsPost>> traktSyncRecommendationsPost = () => traktJsonReader.ReadObjectAsync(default(string));
            await traktSyncRecommendationsPost.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var traktJsonReader = new SyncRecommendationsPostObjectJsonReader();
            ITraktSyncRecommendationsPost traktSyncRecommendationsPost = await traktJsonReader.ReadObjectAsync(string.Empty);
            traktSyncRecommendationsPost.Should().BeNull();
        }
    }
}
