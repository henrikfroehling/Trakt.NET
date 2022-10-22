﻿namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_SyncRecommendationsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRecommendationsPostBuilder_Empty_Build()
        {
            Func<ITraktSyncRecommendationsPost> act = () => TraktPost.NewSyncRecommendationsPost().Build();
            act.Should().Throw<ArgumentException>();
        }
    }
}