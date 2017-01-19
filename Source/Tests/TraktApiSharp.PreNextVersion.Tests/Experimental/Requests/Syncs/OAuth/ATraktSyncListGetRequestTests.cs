namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;

    [TestClass]
    public class ATraktSyncListGetRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestATraktSyncListGetRequestIsAbstract()
        {
            typeof(ATraktSyncListGetRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestATraktSyncListGetRequestHasGenericTypeParameter()
        {
            typeof(ATraktSyncListGetRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSyncListGetRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestATraktSyncListGetRequestIsSubclassOfATraktListGetRequest()
        {
            //typeof(ATraktSyncListGetRequest<int>).IsSubclassOf(typeof(ATraktListGetRequest<int>)).Should().BeTrue();
        }
    }
}
