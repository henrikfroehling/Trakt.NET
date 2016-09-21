namespace TraktApiSharp.Tests.Experimental.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class TraktRequestBodyTests
    {
        [TestMethod]
        public void TestTraktRequestBodyIsNotAbstract()
        {
            typeof(TraktRequestBody<>).IsAbstract.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktRequestBodyIsSealed()
        {
            typeof(TraktRequestBody<>).IsSealed.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktRequestBodyImplementsITraktPostableInterface()
        {
            typeof(TraktRequestBody<int>).GetInterfaces().Should().Contain(typeof(ITraktPostable<int>));
        }

        [TestMethod]
        public void TestTraktRequestBodyImplementsITraktValidatableInterface()
        {
            typeof(TraktRequestBody<>).GetInterfaces().Should().Contain(typeof(ITraktValidatable));
        }
    }
}
