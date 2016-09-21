namespace TraktApiSharp.Tests.Experimental.Requests.Base.Delete
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Delete;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktNoContentDeleteRequestTests
    {
        [TestMethod]
        public void TestATraktNoContentDeleteRequestIsAbstract()
        {
            typeof(ATraktNoContentDeleteRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentDeleteRequestIsSubclassOfATraktNoContentRequest()
        {
            typeof(ATraktNoContentDeleteRequest).IsSubclassOf(typeof(ATraktNoContentRequest)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentDeleteRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktNoContentDeleteRequest).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }
    }
}
