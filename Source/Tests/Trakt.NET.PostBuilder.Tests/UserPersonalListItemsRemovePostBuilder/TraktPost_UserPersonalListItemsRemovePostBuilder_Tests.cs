namespace TraktNet.PostBuilder.Tests
{
    using FluentAssertions;
    using System;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Post.Users.PersonalListItems;
    using Xunit;

    [TestCategory("PostBuilder")]
    public partial class TraktPost_UserPersonalListItemsRemovePostBuilder_Tests
    {
        [Fact]
        public void Test_TraktPost_UserPersonalListItemsRemovePostBuilder_Empty_Build()
        {
            Func<ITraktUserPersonalListItemsRemovePost> act = () => TraktPost.NewUserPersonalListItemsRemovePost().Build();
            act.Should().Throw<TraktPostValidationException>();
        }
    }
}
