namespace TraktApiSharp.Tests.Requests.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Base.Get;

    [TestClass]
    public class TraktGetRequestTests
    {
        [TestMethod]
        public void TestTraktGetRequestIsAbstract()
        {
            typeof(TraktGetRequest<object, object>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktGetRequestIsTraktRequest()
        {
            typeof(TraktRequest<object, object, object>).IsAssignableFrom(typeof(TraktGetRequest<object, object>)).Should().BeTrue();
        }
    }
}
