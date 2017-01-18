namespace TraktApiSharp.Tests.Experimental.Requests.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base.Get;

    [TestClass]
    public class ATraktNoContentGetRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktNoContentGetRequestIsAbstract()
        {
            typeof(ATraktNoContentGetRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Get")]
        public void TestATraktNoContentGetRequestIsSubclassOfATraktNoContentRequest()
        {
            typeof(ATraktNoContentGetRequest).IsSubclassOf(typeof(ATraktNoContentRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base"), TestCategory("Delete")]
        public void TestATraktNoContentGetRequestImplementsITraktNoContentGetRequestInterface()
        {
            typeof(ATraktNoContentGetRequest).GetInterfaces().Should().Contain(typeof(ITraktNoContentGetRequest));
        }
    }
}
