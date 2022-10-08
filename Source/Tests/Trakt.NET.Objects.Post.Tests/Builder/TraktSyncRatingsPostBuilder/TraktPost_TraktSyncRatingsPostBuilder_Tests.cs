namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public partial class TraktPost_SyncRatingsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_Empty_Build()
        {
            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost().Build();
            act.Should().Throw<ArgumentException>();
        }
    }
}
