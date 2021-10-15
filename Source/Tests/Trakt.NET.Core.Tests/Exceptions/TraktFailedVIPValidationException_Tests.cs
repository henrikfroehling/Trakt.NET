namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [Category("Exceptions")]
    public class TraktFailedVIPValidationException_Tests
    {
        [Fact]
        public void Test_TraktFailedVIPValidationException_DefaultConstructor()
        {
            var exception = new TraktFailedVIPValidationException();

            exception.Message.Should().Be("VIP Only - authorized user does not have VIP support");
            exception.StatusCode.Should().Be((HttpStatusCode)426);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktFailedVIPValidationException_Constructor()
        {
            const string message = "exception message";

            var exception = new TraktFailedVIPValidationException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be((HttpStatusCode)426);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
