namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;

    [TestClass]
    public class ATraktShowsMostPWCRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestATraktShowsMostPWCRequestIsAbstract()
        {
            typeof(ATraktShowsMostPWCRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestATraktShowsMostPWCRequestHasGenericTypeParameter()
        {
            typeof(ATraktShowsMostPWCRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktShowsMostPWCRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestATraktShowsMostPWCRequestIsSubclassOfATraktShowsRequest()
        {
            typeof(ATraktShowsMostPWCRequest<int>).IsSubclassOf(typeof(ATraktShowsRequest<int>)).Should().BeTrue();
        }
    }
}
