namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Users.HiddenItems;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_UserHiddenItemsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserHiddenItemsRemovePostBuilder_Empty_Build()
        {
            Func<ITraktUserHiddenItemsRemovePost> act = () => TraktPost.NewUserHiddenItemsRemovePost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }
    }
}
