namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Collection;

    [TestClass]
    public class TraktUserCollectionShowsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCollectionShowsRequestIsNotAbstract()
        {
            typeof(TraktUserCollectionShowsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCollectionShowsRequestIsSealed()
        {
            typeof(TraktUserCollectionShowsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCollectionShowsRequestIsSubclassOfATraktUsersListGetRequest()
        {
            typeof(TraktUserCollectionShowsRequest).IsSubclassOf(typeof(ATraktUsersListGetRequest<TraktCollectionShow>)).Should().BeTrue();
        }
    }
}
