namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktCheckinExceptionTests
    {
        [TestMethod]
        public void TestTraktCheckinEExceptionBaseClass()
        {
            var exception = new TraktCheckinException("");

            exception.Should().BeAssignableTo<TraktException>();
        }

        [TestMethod]
        public void TestTraktExpiredEExceptionDefaultConstructor()
        {
            var message = "exception message";

            var exception = new TraktCheckinException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(default(System.Net.HttpStatusCode));
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
            exception.ExpiresAt.Should().NotHaveValue();
        }
    }
}
