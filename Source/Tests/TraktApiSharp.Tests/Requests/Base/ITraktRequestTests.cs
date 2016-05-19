namespace TraktApiSharp.Tests.Requests.Base
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
            typeof(ITraktRequest<object, object>).IsInterface.Should().BeTrue();
        }
    }
}
