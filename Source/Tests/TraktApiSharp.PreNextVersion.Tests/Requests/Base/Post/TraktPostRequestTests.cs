namespace TraktApiSharp.Tests.Requests.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Base.Post;

    [TestClass]
    public class TraktPostRequestTests
    {
        [TestMethod]
        public void TestTraktPostRequestIsAbstract()
        {
            typeof(TraktPostRequest<object, object, object>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktPostRequestIsTraktRequest()
        {
            typeof(TraktRequest<object, object, object>).IsAssignableFrom(typeof(TraktPostRequest<object, object, object>)).Should().BeTrue();
        }
    }
}
