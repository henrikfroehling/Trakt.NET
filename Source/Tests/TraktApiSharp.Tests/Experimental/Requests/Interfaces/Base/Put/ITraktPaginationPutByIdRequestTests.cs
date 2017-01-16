namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Put;

    [TestClass]
    public class ITraktPaginationPutByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationPutByIdRequestIsInterface()
        {
            typeof(ITraktPaginationPutByIdRequest<,>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationPutByIdRequestHasGenericTypeParameter()
        {
            typeof(ITraktPaginationPutByIdRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktPaginationPutByIdRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationPutByIdRequestDerivesFromITraktPaginationPutRequestInterface()
        {
            typeof(ITraktPaginationPutByIdRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktPaginationPutRequest<int, float>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationPutByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktPaginationPutByIdRequest<,>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
