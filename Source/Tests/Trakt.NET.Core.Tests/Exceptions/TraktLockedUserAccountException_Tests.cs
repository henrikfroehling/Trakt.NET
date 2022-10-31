namespace TraktNet.Core.Tests.Exceptions
{
    using FluentAssertions;
    using System.Net;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Exceptions;
    using Xunit;

    [TestCategory("Exceptions")]
    public class TraktLockedUserAccountException_Tests
    {
        [Fact]
        public void Test_TraktLockedUserAccountException_DefaultConstructor()
        {
            var exception = new TraktLockedUserAccountException();

            exception.Message.Should().Be("Locked User Account - OAuth user has locked user account");
            exception.StatusCode.Should().Be((HttpStatusCode)423);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }

        [Fact]
        public void Test_TraktLockedUserAccountException_Constructor()
        {
            const string message = "exception message";

            var exception = new TraktLockedUserAccountException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be((HttpStatusCode)423);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
