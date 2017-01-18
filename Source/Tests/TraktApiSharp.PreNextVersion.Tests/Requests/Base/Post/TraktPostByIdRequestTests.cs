namespace TraktApiSharp.Tests.Requests.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests.Base.Post;

    [TestClass]
    public class TraktPostByIdRequestTests
    {
        [TestMethod]
        public void TestTraktPostByIdRequestIsAbstract()
        {
            typeof(TraktPostByIdRequest<object, object, object>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktPostByIdRequestIsTraktGetRequest()
        {
            typeof(TraktPostRequest<object, object, object>).IsAssignableFrom(typeof(TraktPostByIdRequest<object, object, object>)).Should().BeTrue();
        }
    }
}
