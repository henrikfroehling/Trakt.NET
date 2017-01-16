namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post;

    [TestClass]
    public class ITraktNoContentPostByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentPostByIdRequestIsInterface()
        {
            typeof(ITraktNoContentPostByIdRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentPostByIdRequestHasGenericTypeParameter()
        {
            typeof(ITraktNoContentPostByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktNoContentPostByIdRequest<float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentPostByIdRequestDerivesFromITraktNoContentPostRequestInterface()
        {
            typeof(ITraktNoContentPostByIdRequest<float>).GetInterfaces().Should().Contain(typeof(ITraktNoContentPostRequest<float>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentPostByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktNoContentPostByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
