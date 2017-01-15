namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;

    [TestClass]
    public class TraktUserCustomListUpdateRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListUpdateRequestIsNotAbstract()
        {
            typeof(TraktUserCustomListUpdateRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListUpdateRequestIsSealed()
        {
            typeof(TraktUserCustomListUpdateRequest).IsSealed.Should().BeTrue();
        }
    }
}
