namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Builder;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public class TraktPost_SyncRatingsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_Get_SyncRatingsPostBuilder()
        {
            ITraktSyncRatingsPostBuilder syncCollectionPostBuilder = TraktPost.NewSyncRatingsPost();
            syncCollectionPostBuilder.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_Empty_Build()
        {
            ITraktSyncRatingsPost syncRatingsPost = TraktPost.NewSyncRatingsPost().Build();
            syncRatingsPost.Should().NotBeNull();
            syncRatingsPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncRatingsPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }
    }
}
