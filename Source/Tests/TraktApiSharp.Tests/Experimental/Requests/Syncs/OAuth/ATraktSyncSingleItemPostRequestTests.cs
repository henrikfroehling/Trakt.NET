namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Post;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;

    [TestClass]
    public class ATraktSyncSingleItemPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestATraktSyncSingleItemPostRequestIsAbstract()
        {
            typeof(ATraktSyncSingleItemPostRequest<,>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestATraktSyncSingleItemPostRequestHasGenericTypeParameters()
        {
            typeof(ATraktSyncSingleItemPostRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktSyncSingleItemPostRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestATraktSyncSingleItemPostRequestIsSubclassOfATraktSingleItemPostRequest()
        {
            typeof(ATraktSyncSingleItemPostRequest<int, float>).IsSubclassOf(typeof(ATraktSingleItemPostRequest<int, float>)).Should().BeTrue();
        }
    }
}
