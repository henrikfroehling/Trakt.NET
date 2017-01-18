namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Threading.Tasks;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Responses.Interfaces.Base;

    [TestClass]
    public class ITraktSingleItemRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemRequestIsInterface()
        {
            typeof(ITraktSingleItemRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemRequestDerivesFromITraktRequestInterface()
        {
            typeof(ITraktSingleItemRequest<>).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemRequestHasGenericTypeParameter()
        {
            typeof(ITraktSingleItemRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktSingleItemRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemRequestHasQueryAsyncMethod()
        {
            var methodInfo = typeof(ITraktSingleItemRequest<int>).GetMethods()
                                                           .Where(m => m.Name == "QueryAsync")
                                                           .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(Task<ITraktResponse<int>>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
