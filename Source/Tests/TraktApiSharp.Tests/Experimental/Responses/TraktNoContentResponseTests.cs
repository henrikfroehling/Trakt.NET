namespace TraktApiSharp.Tests.Experimental.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Experimental.Responses;

    [TestClass]
    public class TraktNoContentResponseTests
    {
        [TestMethod, TestCategory("Responses")]
        public void TestTraktNoContentResponseIsNotAbstract()
        {
            typeof(TraktNoContentResponse).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Responses")]
        public void TestTraktNoContentResponseHasIsSuccessProperty()
        {
            var isSuccessPropertyInfo = typeof(ATraktResponse<>).GetProperties()
                                                                .Where(p => p.Name == "IsSuccess")
                                                                .FirstOrDefault();

            isSuccessPropertyInfo.CanRead.Should().BeTrue();
            isSuccessPropertyInfo.CanWrite.Should().BeTrue();
            isSuccessPropertyInfo.PropertyType.Should().Be(typeof(bool));
        }

        [TestMethod, TestCategory("Responses")]
        public void TestTraktNoContentResponseHasExceptionProperty()
        {
            var exceptionPropertyInfo = typeof(ATraktResponse<>).GetProperties()
                                                                .Where(p => p.Name == "Exception")
                                                                .FirstOrDefault();

            exceptionPropertyInfo.CanRead.Should().BeTrue();
            exceptionPropertyInfo.CanWrite.Should().BeTrue();
            exceptionPropertyInfo.PropertyType.Should().Be(typeof(TraktException));
        }
    }
}
