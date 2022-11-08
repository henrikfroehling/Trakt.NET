﻿namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Syncs.Watchlist;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncWatchlistRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncWatchlistRemovePostBuilder_Empty_Build()
        {
            Func<ITraktSyncWatchlistRemovePost> act = () => TraktPost.NewSyncWatchlistRemovePost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }
    }
}
