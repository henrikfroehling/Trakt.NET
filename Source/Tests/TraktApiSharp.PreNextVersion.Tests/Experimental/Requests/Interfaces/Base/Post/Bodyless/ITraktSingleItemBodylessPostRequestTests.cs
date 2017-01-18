namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post.Bodyless;

    [TestClass]
    public class ITraktSingleItemBodylessPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemBodylessPostRequestIsInterface()
        {
            typeof(ITraktSingleItemBodylessPostRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemBodylessPostRequestHasGenericTypeParameter()
        {
            typeof(ITraktSingleItemBodylessPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktSingleItemBodylessPostRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemBodylessPostRequestDerivesFromITraktSingleItemRequestInterface()
        {
            typeof(ITraktSingleItemBodylessPostRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktSingleItemRequest<int>));
        }
    }
}
