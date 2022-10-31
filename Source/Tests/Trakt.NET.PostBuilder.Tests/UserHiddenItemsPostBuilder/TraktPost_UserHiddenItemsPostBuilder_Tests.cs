namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Users.HiddenItems;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_UserHiddenItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_Empty_Build()
        {
            Func<ITraktUserHiddenItemsPost> act = () => TraktPost.NewUserHiddenItemsPost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }
    }
}
