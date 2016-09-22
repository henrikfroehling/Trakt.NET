namespace TraktApiSharp.Tests.Experimental.Requests.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktNoContentGetByIdRequestTests
    {
        [TestMethod]
        public void TestATraktNoContentGetByIdRequestIsAbstract()
        {
            typeof(ATraktNoContentGetByIdRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentGetByIdRequestIsSubclassOfATraktNoContentRequest()
        {
            typeof(ATraktNoContentGetByIdRequest).IsSubclassOf(typeof(ATraktNoContentRequest)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentGetByIdRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktNoContentGetByIdRequest).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktNoContentGetByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktNoContentGetByIdRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
