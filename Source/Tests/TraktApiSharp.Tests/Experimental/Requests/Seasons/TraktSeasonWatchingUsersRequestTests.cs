namespace TraktApiSharp.Tests.Experimental.Requests.Seasons
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Seasons;

    [TestClass]
    public class TraktSeasonWatchingUsersRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestIsNotAbstract()
        {
            typeof(TraktSeasonWatchingUsersRequest).IsAbstract.Should().BeFalse();
        }
    }
}
