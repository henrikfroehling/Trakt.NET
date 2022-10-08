namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("PostBuilder")]
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
