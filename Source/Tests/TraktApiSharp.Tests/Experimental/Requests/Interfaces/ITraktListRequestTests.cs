namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Threading.Tasks;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Responses;

    [TestClass]
    public class ITraktListRequestTests
    {
        [TestMethod]
        public void TestITraktListRequestIsInterface()
        {
            typeof(ITraktListRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod]
        public void TestITraktListRequestHasGenericTypeParameter()
        {
            typeof(ITraktListRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktListRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod]
        public void TestITraktListRequestHasQueryAsyncMethod()
        {
            var methodInfo = typeof(ITraktListRequest<int>).GetMethods()
                                                           .Where(m => m.Name == "QueryAsync")
                                                           .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(Task<TraktListResponse<int>>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
