namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;

    [TestClass]
    public class ATraktSyncSingleItemPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestATraktSyncSingleItemPostRequestIsAbstract()
        {
            typeof(ATraktSyncSingleItemPostRequest).IsAbstract.Should().BeTrue();
        }
    }
}
