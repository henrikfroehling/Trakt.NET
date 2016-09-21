namespace TraktApiSharp.Tests.Experimental.Requests.Base.Delete
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Delete;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktNoContentDeleteByIdRequestTests
    {
        [TestMethod]
        public void TestATraktNoContentDeleteByIdRequestIsAbstract()
        {
            typeof(ATraktNoContentDeleteByIdRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentDeleteByIdRequestIsSubclassOfATraktNoContentRequest()
        {
            typeof(ATraktNoContentDeleteByIdRequest).IsSubclassOf(typeof(ATraktNoContentRequest)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentDeleteByIdRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktNoContentDeleteByIdRequest).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktNoContentDeleteByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktNoContentDeleteByIdRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
