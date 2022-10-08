namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncCollectionPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionPostBuilder_Empty_Build()
        {
            Func<ITraktSyncCollectionPost> act = () => TraktPost.NewSyncCollectionPost().Build();
            act.Should().Throw<ArgumentException>();
        }
    }
}
