namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [Category("Exceptions")]
    public class TraktNotFoundException_Tests
    {
        [Fact]
        public void Test_TraktNotFoundException_Constructor()
        {
            const string message = "exception message";

            var exception = new TraktNotFoundException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(HttpStatusCode.NotFound);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
