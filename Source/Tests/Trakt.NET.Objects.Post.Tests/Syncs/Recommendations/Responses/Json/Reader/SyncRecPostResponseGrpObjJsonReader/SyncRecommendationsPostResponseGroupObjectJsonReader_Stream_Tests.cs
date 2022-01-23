namespace TraktNet.Objects.Post.Tests.Syncs.Recommendations.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses;
    using TraktNet.Objects.Post.Syncs.Recommendations.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Syncs.Recommendations.Responses.JsonReader")]
    public partial class SyncRecommendationsPostResponseGroupObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncRecommendationsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseGroupObjectJsonReader();

            using var stream = JSON_COMPLETE.ToStream();
            ITraktSyncRecommendationsPostResponseGroup traktSyncRecommendationsPostResponseGroup = await traktJsonReader.ReadObjectAsync(stream);

            traktSyncRecommendationsPostResponseGroup.Should().NotBeNull();
            traktSyncRecommendationsPostResponseGroup.Movies.Should().Be(1);
            traktSyncRecommendationsPostResponseGroup.Shows.Should().Be(2);
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseGroupObjectJsonReader();
            Func<Task<ITraktSyncRecommendationsPostResponseGroup>> traktSyncRecommendationsPostResponseGroup = () => traktJsonReader.ReadObjectAsync(default(Stream));
            await traktSyncRecommendationsPostResponseGroup.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncRecommendationsPostResponseGroupObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new SyncRecommendationsPostResponseGroupObjectJsonReader();

            using var stream = string.Empty.ToStream();
            ITraktSyncRecommendationsPostResponseGroup traktSyncRecommendationsPostResponseGroup = await traktJsonReader.ReadObjectAsync(stream);
            traktSyncRecommendationsPostResponseGroup.Should().BeNull();
        }
    }
}
