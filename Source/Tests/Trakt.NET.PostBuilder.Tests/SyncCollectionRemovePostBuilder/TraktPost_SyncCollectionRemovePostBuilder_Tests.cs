namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Syncs.Collection;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_SyncCollectionRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_SyncCollectionRemovePostBuilder_Empty_Build()
        {
            Func<ITraktSyncCollectionRemovePost> act = () => TraktPost.NewSyncCollectionRemovePost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }
    }
}
