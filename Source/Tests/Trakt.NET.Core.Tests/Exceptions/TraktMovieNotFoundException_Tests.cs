namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [TestCategory("Exceptions")]
    public class TraktMovieNotFoundException_Tests
    {
        [Fact]
        public void Test_TraktMovieNotFoundException_DefaultConstructor()
        {
            const string movieId = "movie id";

            var exception = new TraktMovieNotFoundException(movieId);

            exception.Message.Should().Be("Movie Not Found - method exists, but no record found");
            exception.ObjectId.Should().Be(movieId);
            exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktMovieNotFoundException_Constructor()
        {
            const string message = "exception message";
            const string movieId = "movie id";

            var exception = new TraktMovieNotFoundException(message, movieId);

            exception.Message.Should().Be(message);
            exception.ObjectId.Should().Be(movieId);
            exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
