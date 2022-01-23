namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using TraktNet.Objects.Post.Syncs.Recommendations.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Syncs.Recommendations.JsonReader")]
    public partial class SyncRecommendationsPostMovieObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostMovieObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncRecommendationsPostMovieObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            ITraktSyncRecommendationsPostMovie traktSyncRecommendationsPostMovie = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSyncRecommendationsPostMovie.Should().NotBeNull();
            traktSyncRecommendationsPostMovie.Title.Should().Be("Batman Begins");
            traktSyncRecommendationsPostMovie.Year.Should().Be(2005);
            traktSyncRecommendationsPostMovie.Ids.Should().NotBeNull();
            traktSyncRecommendationsPostMovie.Ids.Trakt.Should().Be(1U);
            traktSyncRecommendationsPostMovie.Ids.Slug.Should().Be("batman-begins-2005");
            traktSyncRecommendationsPostMovie.Ids.Imdb.Should().Be("tt0372784");
            traktSyncRecommendationsPostMovie.Ids.Tmdb.Should().Be(272U);
            traktSyncRecommendationsPostMovie.Notes.Should().Be("One of Chritian Bale's most iconic roles.");
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostMovieObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncRecommendationsPostMovieObjectJsonReader();
            Func<Task<ITraktSyncRecommendationsPostMovie>> traktSyncRecommendationsPostMovie = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktSyncRecommendationsPostMovie.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostMovieObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncRecommendationsPostMovieObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            ITraktSyncRecommendationsPostMovie traktSyncRecommendationsPostMovie = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktSyncRecommendationsPostMovie.Should().BeNull();
        }
    }
}
