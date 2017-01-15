namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Post.Users.CustomListItems;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Responses;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserCustomListItemsRemoveRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsRemoveRequestIsNotAbstract()
        {
            typeof(TraktUserCustomListItemsRemoveRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsRemoveRequestIsSealed()
        {
            typeof(TraktUserCustomListItemsRemoveRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsRemoveRequestIsSubclassOfATraktUsersPostByIdRequest()
        {
            typeof(TraktUserCustomListItemsRemoveRequest).IsSubclassOf(typeof(ATraktUsersPostByIdRequest<TraktUserCustomListItemsRemovePostResponse, TraktUserCustomListItemsPost>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsRemoveRequestHasAuthorizationRequired()
        {
            var request = new TraktUserCustomListItemsRemoveRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }
    }
}
