namespace TraktNet.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [Category("Exceptions")]
    public class TraktCheckinException_Tests
    {
        [Fact]
        public void Test_TraktExpiredEException_DefaultConstructor()
        {
            const string message = "exception message";

            var exception = new TraktCheckinException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(default(HttpStatusCode));
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
            exception.ExpiresAt.Should().NotHaveValue();
        }
    }
}
