namespace TraktApiSharp.Tests.Requests.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests.Base.Post;

    [TestClass]
    public class TraktBodylessPostByIdRequestTests
    {
        [TestMethod]
        public void TestTraktBodylessPostByIdRequestIsAbstract()
        {
            typeof(TraktBodylessPostByIdRequest<object, object>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktBodylessPostByIdRequestIsTraktGetRequest()
        {
            typeof(TraktBodylessPostRequest<object, object>).IsAssignableFrom(typeof(TraktBodylessPostByIdRequest<object, object>)).Should().BeTrue();
        }
    }
}
