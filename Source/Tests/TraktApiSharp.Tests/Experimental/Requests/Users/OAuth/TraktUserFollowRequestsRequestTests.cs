namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;

    [TestClass]
    public class TraktUserFollowRequestsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowRequestsRequestIsNotAbstract()
        {
            typeof(TraktUserFollowRequestsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowRequestsRequestIsSealed()
        {
            typeof(TraktUserFollowRequestsRequest).IsSealed.Should().BeTrue();
        }
    }
}
