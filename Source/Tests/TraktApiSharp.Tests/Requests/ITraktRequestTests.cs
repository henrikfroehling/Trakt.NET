namespace TraktApiSharp.Tests.Requests
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests.Base;

    [TestClass]
    public class ITraktRequestTests
    {
        [TestMethod]
        public void TestITraktRequestIsInterface()
        {
            typeof(ITraktRequest<string, string>).IsInterface.Should().BeTrue();
        }
    }
}
