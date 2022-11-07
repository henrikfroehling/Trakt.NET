namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Syncs.Ratings;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncRatingsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncRatingsPostBuilder_Empty_Build()
        {
            Func<ITraktSyncRatingsPost> act = () => TraktPost.NewSyncRatingsPost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }
    }
}
