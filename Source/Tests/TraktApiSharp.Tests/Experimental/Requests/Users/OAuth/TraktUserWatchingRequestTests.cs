namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users;

    [TestClass]
    public class TraktUserWatchingRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchingRequestIsNotAbstract()
        {
            typeof(TraktUserWatchingRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchingRequestIsSealed()
        {
            typeof(TraktUserWatchingRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchingRequestIsSubclassOfATraktUsersSingleItemGetRequest()
        {
            typeof(TraktUserWatchingRequest).IsSubclassOf(typeof(ATraktUsersSingleItemGetRequest<TraktUserWatchingItem>)).Should().BeTrue();
        }
    }
}
