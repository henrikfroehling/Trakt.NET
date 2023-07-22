namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Syncs.Favorites;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncFavoritesPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncFavoritesPostBuilder_Empty_Build()
        {
            Func<ITraktSyncFavoritesPost> act = () => TraktPost.NewSyncFavoritesPost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }
    }
}
