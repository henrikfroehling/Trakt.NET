namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncFavoritesRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncFavoritesRemovePostBuilder_Empty_Build()
        {
            Func<ITraktSyncFavoritesRemovePost> act = () => TraktPost.NewSyncFavoritesRemovePost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }
    }
}
