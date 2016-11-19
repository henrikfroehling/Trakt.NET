namespace TraktApiSharp.Tests.Experimental.Requests.Shows.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Shows.OAuth;

    [TestClass]
    public class ATraktShowProgressRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestATraktShowProgressRequestIsAbstract()
        {
            typeof(ATraktShowProgressRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestATraktShowProgressRequestHasGenericTypeParameter()
        {
            typeof(ATraktShowProgressRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktShowProgressRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestATraktShowProgressRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(ATraktShowProgressRequest<int>).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("With OAuth")]
        public void TestATraktShowProgressRequestImplementsITraktObjectRequestInterface()
        {
            typeof(ATraktShowProgressRequest<>).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }
    }
}
