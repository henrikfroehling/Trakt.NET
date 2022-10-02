namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public partial class TraktPost_SyncHistoryPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryPostBuilder_Empty_Build()
        {
            Func<ITraktSyncHistoryPost> act = () => TraktPost.NewSyncHistoryPost().Build();
            act.Should().Throw<ArgumentException>();
        }
    }
}
