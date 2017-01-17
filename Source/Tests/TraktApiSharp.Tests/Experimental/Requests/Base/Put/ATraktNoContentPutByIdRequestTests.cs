namespace TraktApiSharp.Tests.Experimental.Requests.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Put;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Put;

    [TestClass]
    public class ATraktNoContentPutByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Put")]
        public void TestATraktNoContentPutByIdRequestIsAbstract()
        {
            typeof(ATraktNoContentPutByIdRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Put")]
        public void TestATraktNoContentPutByIdRequestIsSubclassOfATraktNoContentPutRequest()
        {
            typeof(ATraktNoContentPutByIdRequest<float>).IsSubclassOf(typeof(ATraktNoContentPutRequest<float>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Put")]
        public void TestATraktNoContentPutByIdRequestHasGenericTypeParameter()
        {
            typeof(ATraktNoContentPutByIdRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktNoContentPutByIdRequest<float>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Put")]
        public void TestATraktNoContentPutByIdRequestImplementsITraktNoContentPutByIdRequestInterface()
        {
            typeof(ATraktNoContentPutByIdRequest<float>).GetInterfaces().Should().Contain(typeof(ITraktNoContentPutByIdRequest<float>));
        }
    }
}
