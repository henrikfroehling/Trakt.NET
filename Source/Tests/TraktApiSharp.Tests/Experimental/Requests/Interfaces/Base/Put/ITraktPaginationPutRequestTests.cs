namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Put;

    [TestClass]
    public class ITraktPaginationPutRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationPutRequestIsInterface()
        {
            typeof(ITraktPaginationPutRequest<,>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationPutRequestHasGenericTypeParameter()
        {
            typeof(ITraktPaginationPutRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktPaginationPutRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationPutRequestDerivesFromITraktPaginationRequestInterface()
        {
            typeof(ITraktPaginationPutRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktPaginationRequest<int>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationPutRequestDerivesFromITraktHasRequestBodyInterface()
        {
            typeof(ITraktPaginationPutRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}
