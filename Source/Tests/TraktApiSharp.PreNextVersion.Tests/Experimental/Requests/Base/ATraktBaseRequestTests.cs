namespace TraktApiSharp.Tests.Experimental.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;

    [TestClass]
    public class ATraktBaseRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Abstract Base Classes")]
        public void TestATraktBaseRequestIsAbstract()
        {
            typeof(ATraktBaseRequest).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Abstract Base Classes")]
        public void TestATraktBaseRequestImplementsITraktRequestInterface()
        {
            typeof(ATraktBaseRequest).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }
    }
}
