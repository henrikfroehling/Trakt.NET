namespace TraktApiSharp.Tests.Requests.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests.Base;

    [TestClass]
    public class TraktRequestTests
    {
        [TestMethod]
        public void TestTraktRequestIsAbstract()
        {
            typeof(TraktRequest<object, object, object>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktRequestIsITraktRequest()
        {
            typeof(ITraktRequest<object, object>).IsAssignableFrom(typeof(TraktRequest<object, object, object>)).Should().BeTrue();
        }
    }
}
