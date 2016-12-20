namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Interfaces;

    [TestClass]
    public class ITraktPathParametersTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktPathParametersIsInterface()
        {
            typeof(ITraktPathParameters).IsInterface.Should().BeTrue();
        }
    }
}
