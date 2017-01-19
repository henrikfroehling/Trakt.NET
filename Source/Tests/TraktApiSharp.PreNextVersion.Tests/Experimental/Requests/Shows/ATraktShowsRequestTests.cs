namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Shows;

    [TestClass]
    public class ATraktShowsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestATraktShowsRequestIsAbstract()
        {
            typeof(ATraktShowsRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestATraktShowsRequestHasGenericTypeParameter()
        {
            typeof(ATraktShowsRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktShowsRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestATraktShowsRequestIsSubclassOfATraktPaginationGetRequest()
        {
            //typeof(ATraktShowsRequest<int>).IsSubclassOf(typeof(ATraktPaginationGetRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestATraktShowsRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(ATraktShowsRequest<>).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestATraktShowsRequestImplementsITraktFilterableInterface()
        {
            typeof(ATraktShowsRequest<>).GetInterfaces().Should().Contain(typeof(ITraktSupportsFilter));
        }
    }
}
