namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Put;

    [TestClass]
    public class ITraktNoContentPutRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentPutRequestIsInterface()
        {
            typeof(ITraktNoContentPutRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentPutRequestHasGenericTypeParameter()
        {
            typeof(ITraktNoContentPutRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktNoContentPutRequest<float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentPutRequestDerivesFromITraktNoContentRequestInterface()
        {
            typeof(ITraktNoContentPutRequest<float>).GetInterfaces().Should().Contain(typeof(ITraktNoContentRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentPutRequesterivesFromITraktHasRequestBodyInterface()
        {
            typeof(ITraktNoContentPutRequest<float>).GetInterfaces().Should().Contain(typeof(ITraktHasRequestBody<float>));
        }
    }
}
