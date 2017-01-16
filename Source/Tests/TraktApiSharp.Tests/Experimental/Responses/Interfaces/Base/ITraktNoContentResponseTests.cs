namespace TraktApiSharp.Tests.Experimental.Responses.Interfaces.Base
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Experimental.Responses.Interfaces.Base;

    [TestClass]
    public class ITraktNoContentResponseTests
    {
        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktNoContentResponseIsInterface()
        {
            typeof(ITraktNoContentResponse).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktNoContentResponseHasIsSuccessProperty()
        {
            var isSuccessPropertyInfo = typeof(ITraktNoContentResponse).GetProperties()
                                                                       .Where(p => p.Name == "IsSuccess")
                                                                       .FirstOrDefault();

            isSuccessPropertyInfo.CanRead.Should().BeTrue();
            isSuccessPropertyInfo.CanWrite.Should().BeTrue();
            isSuccessPropertyInfo.PropertyType.Should().Be(typeof(bool));
        }

        [TestMethod, TestCategory("Responses"), TestCategory("Interfaces")]
        public void TestITraktNoContentResponseHasExceptionProperty()
        {
            var exceptionPropertyInfo = typeof(ITraktNoContentResponse).GetProperties()
                                                                       .Where(p => p.Name == "Exception")
                                                                       .FirstOrDefault();

            exceptionPropertyInfo.CanRead.Should().BeTrue();
            exceptionPropertyInfo.CanWrite.Should().BeTrue();
            exceptionPropertyInfo.PropertyType.Should().Be(typeof(TraktException));
        }
    }
}
