namespace TraktApiSharp.Tests.Requests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests;

    [TestClass]
    public class ITraktRequestTests
    {
        [TestMethod]
        public void TestITraktRequestIsInterface()
        {
            typeof(ITraktRequest<string>).IsInterface.Should().BeTrue();
        }
    }
}
