namespace TraktNet.PostBuilder.Tests.Builder
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public partial class TraktPost_SyncHistoryRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_Empty_Build()
        {
            Func<ITraktSyncHistoryRemovePost> act = () => TraktPost.NewSyncHistoryRemovePost().Build();
            act.Should().Throw<ArgumentException>();
        }
    }
}
