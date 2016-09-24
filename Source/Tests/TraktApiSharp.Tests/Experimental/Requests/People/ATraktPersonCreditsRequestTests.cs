namespace TraktApiSharp.Tests.Experimental.Requests.People
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.People;

    [TestClass]
    public class ATraktPersonCreditsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("People"), TestCategory("Credits")]
        public void TestATraktPersonCreditsRequestIsAbstract()
        {
            typeof(ATraktPersonCreditsRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People"), TestCategory("Credits")]
        public void TestATraktPersonCreditsRequestHasGenericTypeParameter()
        {
            typeof(ATraktPersonCreditsRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktPersonCreditsRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People"), TestCategory("Credits")]
        public void TestATraktPersonCreditsRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(ATraktPersonCreditsRequest<int>).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People"), TestCategory("Credits")]
        public void TestATraktPersonCreditsRequestImplementsITraktObjectRequestInterface()
        {
            typeof(ATraktPersonCreditsRequest<>).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People"), TestCategory("Credits")]
        public void TestATraktPersonCreditsRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(ATraktPersonCreditsRequest<>).GetInterfaces().Should().Contain(typeof(ITraktExtendedInfo));
        }
    }
}
