namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Put;

    [TestClass]
    public class ITraktNoContentPutByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentPutByIdRequestIsInterface()
        {
            typeof(ITraktNoContentPutByIdRequest<>).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentPutByIdRequestHasGenericTypeParameter()
        {
            typeof(ITraktNoContentPutByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktNoContentPutByIdRequest<float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentPutByIdRequestDerivesFromITraktNoContentPutRequestInterface()
        {
            typeof(ITraktNoContentPutByIdRequest<float>).GetInterfaces().Should().Contain(typeof(ITraktNoContentPutRequest<float>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktNoContentPutByIdRequestDerivesFromITraktHasIdInterface()
        {
            typeof(ITraktNoContentPutByIdRequest<>).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
