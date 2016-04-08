namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktEpisodeNotFoundExceptionTests
    {
        [TestMethod]
        public void TestTraktEpisodeNotFoundExceptionBaseClass()
        {
            var exception = new TraktEpisodeNotFoundException("", "");

            exception.Should().BeAssignableTo<TraktException>();
            exception.Should().BeAssignableTo<TraktObjectNotFoundException>();
        }

        [TestMethod]
        public void TestTraktEpisodeNotFoundExceptionConstructor()
        {
            var message = "exception message";
            var episodeId = "episode id";

            var exception = new TraktEpisodeNotFoundException(message, episodeId);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(episodeId);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
        }
    }
}
