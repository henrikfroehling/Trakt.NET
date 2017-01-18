namespace TraktApiSharp.Tests.Requests.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Base.Put;

    [TestClass]
    public class TraktPutRequestTests
    {
        [TestMethod]
        public void TestTraktPutRequestIsAbstract()
        {
            typeof(TraktPutRequest<object, object, object>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktPutRequestIsTraktRequest()
        {
            typeof(TraktRequest<object, object, object>).IsAssignableFrom(typeof(TraktPutRequest<object, object, object>)).Should().BeTrue();
        }
    }
}
