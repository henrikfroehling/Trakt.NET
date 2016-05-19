namespace TraktApiSharp.Tests.Requests.Base.Get
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests.Base.Get;

    [TestClass]
    public class TraktGetByIdRequestTests
    {
        [TestMethod]
        public void TestTraktGetByIdRequestIsAbstract()
        {
            typeof(TraktGetByIdRequest<object, object>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktGetByIdRequestIsTraktGetRequest()
        {
            typeof(TraktGetRequest<object, object>).IsAssignableFrom(typeof(TraktGetByIdRequest<object, object>)).Should().BeTrue();
        }
    }
}
