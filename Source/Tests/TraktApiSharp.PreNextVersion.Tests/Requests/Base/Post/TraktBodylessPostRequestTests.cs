namespace TraktApiSharp.Tests.Requests.Base.Post
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Base.Post;

    [TestClass]
    public class TraktBodylessPostRequestTests
    {
        [TestMethod]
        public void TestTraktBodylessPostRequestIsAbstract()
        {
            typeof(TraktBodylessPostRequest<object, object>).IsAbstract.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktBodylessPostRequestIsTraktRequest()
        {
            typeof(TraktRequest<object, object, object>).IsAssignableFrom(typeof(TraktBodylessPostRequest<object, object>)).Should().BeTrue();
        }
    }
}
