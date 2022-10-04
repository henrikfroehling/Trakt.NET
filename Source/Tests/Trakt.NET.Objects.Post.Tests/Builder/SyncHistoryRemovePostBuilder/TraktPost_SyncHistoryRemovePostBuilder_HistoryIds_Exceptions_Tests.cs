namespace TraktNet.Objects.Post.Tests.Builder
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [Category("Objects.Post.Builder")]
    public partial class TraktPost_SyncHistoryRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_WithHistoryIds_ITraktEpisodeIds_ArgumentExceptions()
        {
            List<ulong> historyIds = null;

            Func<ITraktSyncHistoryRemovePost> act = () => TraktPost.NewSyncHistoryRemovePost()
                .WithHistoryIds(historyIds)
                .Build();

            act.Should().Throw<ArgumentNullException>();
        }
    }
}
