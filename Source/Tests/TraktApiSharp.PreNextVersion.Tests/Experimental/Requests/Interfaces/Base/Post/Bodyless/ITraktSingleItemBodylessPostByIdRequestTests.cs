namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post.Bodyless;

    [TestClass]
    public class ITraktSingleItemBodylessPostByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemBodylessPostByIdRequestIsInterface()
        {
            typeof(ITraktSingleItemBodylessPostByIdRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemBodylessPostByIdRequestHasGenericTypeParameter()
        {
            typeof(ITraktSingleItemBodylessPostByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktSingleItemBodylessPostByIdRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemBodylessPostByIdRequestDerivesFromITraktSingleItemBodylessPostRequestInterface()
        {
            typeof(ITraktSingleItemBodylessPostByIdRequest<int>).GetInterfaces().Should().Contain(typeof(ITraktSingleItemBodylessPostRequest<int>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemBodylessPostByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktSingleItemBodylessPostByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
