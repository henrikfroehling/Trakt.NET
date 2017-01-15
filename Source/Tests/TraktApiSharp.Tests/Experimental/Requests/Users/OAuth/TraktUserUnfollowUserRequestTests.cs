namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;

    [TestClass]
    public class TraktUserUnfollowUserRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserUnfollowUserRequestIsNotAbstract()
        {
            typeof(TraktUserUnfollowUserRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserUnfollowUserRequestIsSealed()
        {
            typeof(TraktUserUnfollowUserRequest).IsSealed.Should().BeTrue();
        }
    }
}
