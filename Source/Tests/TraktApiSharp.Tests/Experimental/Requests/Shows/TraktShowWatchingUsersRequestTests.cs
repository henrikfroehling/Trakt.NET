namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;

    [TestClass]
    public class TraktShowWatchingUsersRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowWatchingUsersRequestIsNotAbstract()
        {
            typeof(TraktShowWatchingUsersRequest).IsAbstract.Should().BeFalse();
        }
    }
}
