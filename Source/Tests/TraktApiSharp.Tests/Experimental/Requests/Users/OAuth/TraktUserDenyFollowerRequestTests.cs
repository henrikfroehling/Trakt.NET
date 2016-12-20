namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserDenyFollowerRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserDenyFollowerRequestIsNotAbstract()
        {
            typeof(TraktUserDenyFollowerRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserDenyFollowerRequestIsSealed()
        {
            typeof(TraktUserDenyFollowerRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserDenyFollowerRequestIsSubclassOfATraktUsersDeleteByIdRequest()
        {
            typeof(TraktUserDenyFollowerRequest).IsSubclassOf(typeof(ATraktUsersDeleteByIdRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserDenyFollowerRequestHasValidRequestObjectType()
        {
            var request = new TraktUserDenyFollowerRequest(null);
            request.RequestObjectType.Should().Be(TraktRequestObjectType.Unspecified);
        }
    }
}
