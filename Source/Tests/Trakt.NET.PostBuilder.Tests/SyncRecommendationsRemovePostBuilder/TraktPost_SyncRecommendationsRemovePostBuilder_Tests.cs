﻿namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Syncs.Recommendations;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncRecommendationsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRecommendationsRemovePostBuilder_Empty_Build()
        {
            Func<ITraktSyncRecommendationsRemovePost> act = () => TraktPost.NewSyncRecommendationsRemovePost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }
    }
}
