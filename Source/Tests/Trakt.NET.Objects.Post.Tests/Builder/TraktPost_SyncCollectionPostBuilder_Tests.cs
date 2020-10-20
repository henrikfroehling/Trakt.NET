namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Post.Builder;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public class TraktPost_SyncCollectionPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_Get_SyncCollectionPostBuilder()
        {
            ITraktSyncCollectionPostBuilder syncCollectionPostBuilder = TraktPost.NewSyncCollectionPost();
            syncCollectionPostBuilder.Should().NotBeNull();
        }

        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_Empty_Build()
        {
            ITraktSyncCollectionPost syncCollectionPost = TraktPost.NewSyncCollectionPost().Build();
            syncCollectionPost.Should().NotBeNull();
            syncCollectionPost.Movies.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Shows.Should().NotBeNull().And.BeEmpty();
            syncCollectionPost.Episodes.Should().NotBeNull().And.BeEmpty();
        }
    }
}
