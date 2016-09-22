namespace TraktApiSharp.Tests.Experimental.Requests.Base.Post.Bodyless
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ATraktNoContentBodylessPostByIdRequestTests
    {
        [TestMethod]
        public void TestATraktNoContentBodylessPostByIdRequestIsAbstract()
        {
            typeof(ATraktNoContentBodylessPostByIdRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentBodylessPostByIdRequestIsSubclassOfATraktNoContentRequest()
        {
            typeof(ATraktNoContentBodylessPostByIdRequest).IsSubclassOf(typeof(ATraktNoContentRequest)).Should().BeTrue();
        }

        [TestMethod]
        public void TestATraktNoContentBodylessPostByIdRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktNoContentBodylessPostByIdRequest).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }

        [TestMethod]
        public void TestATraktNoContentBodylessPostByIdRequestImplementsITraktHasIdInterface()
        {
            typeof(ATraktNoContentBodylessPostByIdRequest).GetInterfaces().Should().Contain(typeof(ITraktHasId));
        }
    }
}
