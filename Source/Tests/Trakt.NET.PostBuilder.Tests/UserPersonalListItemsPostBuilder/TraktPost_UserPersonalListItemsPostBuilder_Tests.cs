namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_UserPersonalListItemsPostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserPersonalListItemsPostBuilder_Empty_Build()
        {
            Func<ITraktUserPersonalListItemsPost> act = () => TraktPost.NewUserPersonalListItemsPost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }
    }
}
