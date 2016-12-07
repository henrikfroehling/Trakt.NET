namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;

    [TestClass]
    public class ATraktSyncPaginationRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestATraktSyncPaginationRequestIsAbstract()
        {
            typeof(ATraktSyncPaginationRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestATraktSyncPaginationRequestHasGenericTypeParameter()
        {
            typeof(ATraktSyncPaginationRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSyncPaginationRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }
    }
}
