﻿namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Syncs.History;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncHistoryRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncHistoryRemovePostBuilder_Empty_Build()
        {
            Func<ITraktSyncHistoryRemovePost> act = () => TraktPost.NewSyncHistoryRemovePost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }
    }
}
