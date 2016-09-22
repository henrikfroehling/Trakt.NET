namespace TraktApiSharp.Tests.Experimental.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class TraktRequestBodyTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base")]
        public void TestTraktRequestBodyIsNotAbstract()
        {
            typeof(TraktRequestBody<>).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base")]
        public void TestTraktRequestBodyIsSealed()
        {
            typeof(TraktRequestBody<>).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base")]
        public void TestTraktRequestBodyImplementsITraktPostableInterface()
        {
            typeof(TraktRequestBody<int>).GetInterfaces().Should().Contain(typeof(ITraktPostable<int>));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base")]
        public void TestTraktRequestBodyImplementsITraktValidatableInterface()
        {
            typeof(TraktRequestBody<>).GetInterfaces().Should().Contain(typeof(ITraktValidatable));
        }
    }
}
