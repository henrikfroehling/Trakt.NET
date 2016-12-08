namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;

    [TestClass]
    public class ATraktSyncPaginationGetRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestATraktSyncPaginationGetRequestIsAbstract()
        {
            typeof(ATraktSyncPaginationGetRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestATraktSyncPaginationGetRequestHasGenericTypeParameter()
        {
            typeof(ATraktSyncPaginationGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSyncPaginationGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestATraktSyncPaginationGetRequestIsSubclassOfATraktPaginationGetRequest()
        {
            typeof(ATraktSyncPaginationGetRequest<int>).IsSubclassOf(typeof(ATraktPaginationGetRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestATraktSyncPaginationGetRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(ATraktSyncPaginationGetRequest<>).GetInterfaces().Should().Contain(typeof(ITraktExtendedInfo));
        }
    }
}
