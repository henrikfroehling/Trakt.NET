namespace TraktApiSharp.Tests.Experimental.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktPaginationRequestTests
    {
        [TestMethod]
        public void TestATraktPaginationRequestIsAbstract()
        {
            typeof(ATraktPaginationRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktPaginationRequestIsSubclassOfATraktBaseRequest()
        {
            typeof(ATraktPaginationRequest<>).IsSubclassOf(typeof(ATraktBaseRequest)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktPaginationRequestHasGenericTypeParameter()
        {
            typeof(ATraktPaginationRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktPaginationRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod]
        public void TestATraktPaginationRequestImplementsITraktPaginationRequestInterface()
        {
            typeof(ATraktPaginationRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktPaginationRequest<int>));
        }
    }
}
