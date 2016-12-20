namespace TraktApiSharp.Tests.Experimental.Requests.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktNoContentGetByIdRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktNoContentGetByIdRequestIsAbstract()
        {
            typeof(ATraktNoContentGetByIdRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktNoContentGetByIdRequestIsSubclassOfATraktNoContentGetRequest()
        {
            typeof(ATraktNoContentGetByIdRequest).IsSubclassOf(typeof(ATraktNoContentGetRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktNoContentGetByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktNoContentGetByIdRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
