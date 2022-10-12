namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.HiddenItems;
    using Xunit;

    [Category("PostBuilder")]
    public partial class TraktPost_UserHiddenItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserHiddenItemsPostBuilder_Empty_Build()
        {
            Func<ITraktUserHiddenItemsPost> act = () => TraktPost.NewUserHiddenItemsPost().Build();
            act.Should().Throw<ArgumentException>();
        }
    }
}
