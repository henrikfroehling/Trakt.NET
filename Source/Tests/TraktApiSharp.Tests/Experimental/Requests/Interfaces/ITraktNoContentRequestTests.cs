namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Threading.Tasks;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Responses;

    [TestClass]
    public class ITraktNoContentRequestTests
    {
        [TestMethod]
        public void TestITraktNoContentRequestIsInterface()
        {
            typeof(ITraktNoContentRequest).IsInterface.Should().BeTrue();
        }

        [TestMethod]
        public void TestITraktNoContentRequestHasQueryAsyncMethod()
        {
            var methodInfo = typeof(ITraktNoContentRequest).GetMethods()
                                                           .Where(m => m.Name == "QueryAsync")
                                                           .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(Task<TraktNoContentResponse>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
