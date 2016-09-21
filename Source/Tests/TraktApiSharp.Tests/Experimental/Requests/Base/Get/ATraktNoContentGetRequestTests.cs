namespace TraktApiSharp.Tests.Experimental.Requests.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktNoContentGetRequestTests
    {
        [TestMethod]
        public void TestATraktNoContentGetRequestIsAbstract()
        {
            typeof(ATraktNoContentGetRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentGetRequestIsSubclassOfATraktNoContentRequest()
        {
            typeof(ATraktNoContentGetRequest).IsSubclassOf(typeof(ATraktNoContentRequest)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentGetRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktNoContentGetRequest).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }
    }
}
