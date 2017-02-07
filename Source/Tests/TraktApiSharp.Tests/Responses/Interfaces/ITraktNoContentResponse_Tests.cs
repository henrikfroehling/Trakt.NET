namespace TraktApiSharp.Tests.Responses.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Responses.Interfaces;
    using Xunit;

    [Category("Responses.Interfaces")]
    public class ITraktNoContentResponse_Tests
    {
        [Fact]
        public void Test_ITraktNoContentResponse_Is_Interface()
        {
            typeof(ITraktNoContentResponse).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktNoContentResponse_Has_IsSuccess_Property()
        {
            var isSuccessPropertyInfo = typeof(ITraktNoContentResponse).GetProperties()
                                                                       .Where(p => p.Name == "IsSuccess")
                                                                       .FirstOrDefault();

            isSuccessPropertyInfo.CanRead.Should().BeTrue();
            isSuccessPropertyInfo.CanWrite.Should().BeTrue();
            isSuccessPropertyInfo.PropertyType.Should().Be(typeof(bool));
        }

        [Fact]
        public void Test_ITraktNoContentResponse_Has_Exception_Property()
        {
            var exceptionPropertyInfo = typeof(ITraktNoContentResponse).GetProperties()
                                                                       .Where(p => p.Name == "Exception")
                                                                       .FirstOrDefault();

            exceptionPropertyInfo.CanRead.Should().BeTrue();
            exceptionPropertyInfo.CanWrite.Should().BeTrue();
            exceptionPropertyInfo.PropertyType.Should().Be(typeof(Exception));
        }
    }
}
