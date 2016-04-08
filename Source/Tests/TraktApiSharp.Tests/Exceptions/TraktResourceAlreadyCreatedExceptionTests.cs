namespace TraktApiSharp.Tests.Exceptions
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Exceptions;

    [TestClass]
    public class TraktResourceAlreadyCreatedExceptionTests
    {
        [TestMethod]
        public void TestTraktResourceAlreadyCreatedExceptionBaseClass()
        {
            var exception = new TraktResourceAlreadyCreatedException("");

            exception.Should().BeAssignableTo<TraktException>();
        }

        [TestMethod]
        public void TestTraktResourceAlreadyCreatedExceptionConstructor()
        {
            var message = "exception message";

            var exception = new TraktResourceAlreadyCreatedException(message);

            exception.Message.Should().Be(message);
            exception.StatusCode.Should().Be(System.Net.HttpStatusCode.Conflict);
            exception.RequestUrl.Should().BeNullOrEmpty();
            exception.RequestBody.Should().BeNullOrEmpty();
        }
    }
}
