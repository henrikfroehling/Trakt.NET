namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Responses.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Syncs.Recommendations.Responses.JsonReader")]
    public partial class SyncRecommendationsPostResponseGroupObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseGroupObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            ITraktSyncRecommendationsPostResponseGroup traktSyncRecommendationsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktSyncRecommendationsPostResponseGroup.Should().NotBeNull();
            traktSyncRecommendationsPostResponseGroup.Movies.Should().Be(1);
            traktSyncRecommendationsPostResponseGroup.Shows.Should().Be(2);
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseGroupObjectJsonReader();
            Func<Task<ITraktSyncRecommendationsPostResponseGroup>> traktSyncRecommendationsPostResponseGroup = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktSyncRecommendationsPostResponseGroup.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostResponseGroupObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseGroupObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            ITraktSyncRecommendationsPostResponseGroup traktSyncRecommendationsPostResponseGroup = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktSyncRecommendationsPostResponseGroup.Should().BeNull();
        }
    }
}
