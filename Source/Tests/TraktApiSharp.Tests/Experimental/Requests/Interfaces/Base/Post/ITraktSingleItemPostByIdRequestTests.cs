namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post;

    [TestClass]
    public class ITraktSingleItemPostByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPostByIdRequestIsInterface()
        {
            typeof(ITraktSingleItemPostByIdRequest<,>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPostByIdRequestHasGenericTypeParameter()
        {
            typeof(ITraktSingleItemPostByIdRequest<,>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktSingleItemPostByIdRequest<int, float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(2);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPostByIdRequestDerivesFromITraktSingleItemPostRequestInterface()
        {
            typeof(ITraktSingleItemPostByIdRequest<int, float>).GetInterfaces().Should().Contain(typeof(ITraktSingleItemPostRequest<int, float>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktSingleItemPostByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktSingleItemPostByIdRequest<,>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
