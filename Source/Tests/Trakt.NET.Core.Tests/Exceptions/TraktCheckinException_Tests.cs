namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [TestCategory("Exceptions")]
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
