namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Threading.Tasks;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Responses.Interfaces.Base;

    [TestClass]
    public class ITraktPaginationRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationRequestIsInterface()
        {
            typeof(ITraktPaginationRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationRequestHasGenericTypeParameter()
        {
            typeof(ITraktPaginationRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktPaginationRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationRequestHasQueryAsyncMethod()
        {
            var methodInfo = typeof(ITraktPaginationRequest<int>).GetMethods()
                                                           .Where(m => m.Name == "QueryAsync")
                                                           .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(Task<ITraktPaginationResponse<int>>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationRequestDerivesFromITraktPaginationInterface()
        {
            typeof(ITraktPaginationRequest<>).GetInterfaces().Should().Contain(typeof(ITraktPagination));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationRequestDerivesFromITraktRequestInterface()
        {
            typeof(ITraktPaginationRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }
    }
}
