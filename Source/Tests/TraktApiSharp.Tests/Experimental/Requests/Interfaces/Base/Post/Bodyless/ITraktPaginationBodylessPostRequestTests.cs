namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post.Bodyless;

    [TestClass]
    public class ITraktPaginationBodylessPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationBodylessPostRequestIsInterface()
        {
            typeof(ITraktPaginationBodylessPostRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationBodylessPostRequestHasGenericTypeParameter()
        {
            typeof(ITraktPaginationBodylessPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktPaginationBodylessPostRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPaginationBodylessPostRequestDerivesFromITraktPaginationRequestInterface()
        {
            typeof(ITraktPaginationBodylessPostRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktPaginationRequest<int>));
        }
    }
}
