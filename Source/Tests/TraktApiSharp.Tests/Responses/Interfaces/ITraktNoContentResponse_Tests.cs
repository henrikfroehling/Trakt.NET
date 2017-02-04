namespace TraktApiSharp.Tests.Responses.Interfaces.Base
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using TraktApiSharp.Experimental.Responses.Interfaces;
    using TraktApiSharp.Tests.Traits;
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
        public void Test_ITraktNoContentResponse_Inherits_IEquatable_Interface()
        {
            typeof(ITraktNoContentResponse).GetInterfaces().Should().Contain(typeof(IEquatable<ITraktNoContentResponse>));
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
