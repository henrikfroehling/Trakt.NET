namespace TraktApiSharp.Tests.Experimental.Requests.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users;

    [TestClass]
    public class TraktUserListCommentsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserListCommentsRequestIsNotAbstract()
        {
            typeof(TraktUserListCommentsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserListCommentsRequestIsSealed()
        {
            typeof(TraktUserListCommentsRequest).IsSealed.Should().BeTrue();
        }
    }
}
