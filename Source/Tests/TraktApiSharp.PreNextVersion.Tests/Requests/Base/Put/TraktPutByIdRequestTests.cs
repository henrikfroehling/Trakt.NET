namespace TraktApiSharp.Tests.Requests.Base.Put
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests.Base.Put;

    [TestClass]
    public class TraktPutByIdRequestTests
    {
        [TestMethod]
        public void TestTraktPutByIdRequestIsAbstract()
        {
            typeof(TraktPutByIdRequest<object, object, object>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktPutByIdRequestIsTraktGetRequest()
        {
            typeof(TraktPutRequest<object, object, object>).IsAssignableFrom(typeof(TraktPutByIdRequest<object, object, object>)).Should().BeTrue();
        }
    }
}
