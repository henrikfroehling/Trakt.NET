namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Threading.Tasks;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Responses;

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

            methodInfo.ReturnType.Should().Be(typeof(Task<TraktPaginationResponse<int>>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
