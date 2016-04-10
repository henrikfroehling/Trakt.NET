namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktExceptionTests
    {
        [TestMethod]
        public void TestTraktExceptionConstructor()
        {
            var message = "exception message";

            var exception = new TraktException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(default(System.Net.HttpStatusCode));
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
            exception.Response.Should().BeNullOrEmpty();
        }
    }
}
