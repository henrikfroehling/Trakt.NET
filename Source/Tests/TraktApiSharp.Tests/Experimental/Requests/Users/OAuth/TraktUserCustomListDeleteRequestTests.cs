namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;

    [TestClass]
    public class TraktUserCustomListDeleteRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListDeleteRequestIsNotAbstract()
        {
            typeof(TraktUserCustomListDeleteRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListDeleteRequestIsSealed()
        {
            typeof(TraktUserCustomListDeleteRequest).IsSealed.Should().BeTrue();
        }
    }
}
