namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;

    [TestClass]
    public class TraktUserCustomListItemsAddRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsAddRequestIsNotAbstract()
        {
            typeof(TraktUserCustomListItemsAddRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsAddRequestIsSealed()
        {
            typeof(TraktUserCustomListItemsAddRequest).IsSealed.Should().BeTrue();
        }
    }
}
