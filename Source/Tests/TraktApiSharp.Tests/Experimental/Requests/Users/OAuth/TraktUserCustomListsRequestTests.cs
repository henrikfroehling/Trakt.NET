namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users.Lists;

    [TestClass]
    public class TraktUserCustomListsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListsRequestIsNotAbstract()
        {
            typeof(TraktUserCustomListsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListsRequestIsSealed()
        {
            typeof(TraktUserCustomListsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListsRequestIsSubclassOfATraktUsersListGetRequest()
        {
            typeof(TraktUserCustomListsRequest).IsSubclassOf(typeof(ATraktListGetRequest<TraktList>)).Should().BeTrue();
        }
    }
}
