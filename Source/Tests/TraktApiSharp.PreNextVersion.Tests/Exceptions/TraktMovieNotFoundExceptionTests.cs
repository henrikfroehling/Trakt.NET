namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktMovieNotFoundExceptionTests
    {
        [TestMethod]
        public void TestTraktMovieNotFoundExceptionBaseClass()
        {
            var exception = new TraktMovieNotFoundException("");

            exception.Should().BeAssignableTo<TraktException>();
            exception.Should().BeAssignableTo<TraktObjectNotFoundException>();
        }

        [TestMethod]
        public void TestTraktMovieNotFoundExceptionDefaultConstructor()
        {
            var movieId = "movie id";

            var exception = new TraktMovieNotFoundException(movieId);

            exception.Message.Should().Be("Movie Not Found - method exists, but no record found");
            exception.ObjectId.Should().Be(movieId);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktMovieNotFoundExceptionConstructor()
        {
            var message = "exception message";
            var movieId = "movie id";

            var exception = new TraktMovieNotFoundException(message, movieId);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(movieId);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
