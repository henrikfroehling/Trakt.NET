namespace TraktApiSharp.Tests.Experimental.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class TraktRequestIdTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Base")]
        public void TestTraktRequestIdIsNotAbstract()
        {
            typeof(TraktRequestId).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base")]
        public void TestTraktRequestIdIsSealed()
        {
            typeof(TraktRequestId).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Base")]
        public void TestTraktRequestIdImplementsITraktIdInterface()
        {
            typeof(TraktRequestId).GetInterfaces().Should().Contain(typeof(ITraktId));
        }
    }
}
