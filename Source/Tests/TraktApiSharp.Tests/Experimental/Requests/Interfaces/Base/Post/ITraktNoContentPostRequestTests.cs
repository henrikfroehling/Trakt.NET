namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Post;

    [TestClass]
    public class ITraktNoContentPostRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentPostRequestIsInterface()
        {
            typeof(ITraktNoContentPostRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentPostRequestHasGenericTypeParameter()
        {
            typeof(ITraktNoContentPostRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktNoContentPostRequest<float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentPostRequestDerivesFromITraktNoContentRequestInterface()
        {
            typeof(ITraktNoContentPostRequest<>).GetInterfaces().Should().Contain(typeof(ITraktNoContentRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentPostRequestDerivesFromITraktHasRequestBodyInterface()
        {
            typeof(ITraktNoContentPostRequest<float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}
