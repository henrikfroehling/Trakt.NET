namespace TraktApiSharp.Tests.Experimental.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktNoContentRequestTests
    {
        [TestMethod]
        public void TestATraktNoContentRequestIsAbstract()
        {
            typeof(ATraktNoContentRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentRequestIsSubclassOfATraktBaseRequest()
        {
            typeof(ATraktNoContentRequest).IsSubclassOf(typeof(ATraktBaseRequest)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentRequestImplementsITraktNoContentRequestInterface()
        {
            typeof(ATraktNoContentRequest).GetInterfaces().Should().Contain(typeof(ITraktNoContentRequest));
        }
    }
}
