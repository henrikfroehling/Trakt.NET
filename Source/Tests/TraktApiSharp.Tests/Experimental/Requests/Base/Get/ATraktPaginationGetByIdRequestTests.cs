namespace TraktApiSharp.Tests.Experimental.Requests.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktPaginationGetByIdRequestTests
    {
        [TestMethod]
        public void TestATraktPaginationGetByIdRequestIsAbstract()
        {
            typeof(ATraktPaginationGetByIdRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktPaginationGetByIdRequestIsSubclassOfATraktPaginationRequest()
        {
            typeof(ATraktPaginationGetByIdRequest<int>).IsSubclassOf(typeof(ATraktPaginationRequest<int>)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktPaginationGetByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktPaginationGetByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktPaginationGetByIdRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod]
        public void TestATraktPaginationGetByIdRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktPaginationGetByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktPaginationGetByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktPaginationGetByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
