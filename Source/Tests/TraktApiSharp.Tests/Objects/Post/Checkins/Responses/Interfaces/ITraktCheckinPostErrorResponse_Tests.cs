namespace TraktApiSharp.Tests.Objects.Post.Checkins.Responses.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Post.Checkins.Responses;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.Interfaces")]
    public class ITraktCheckinPostErrorResponse_Tests
    {
        [Fact]
        public void Test_ITraktCheckinPostErrorResponse_Is_Interface()
        {
            typeof(ITraktCheckinPostErrorResponse).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktCheckinPostErrorResponse_Has_ExpiresAt_Property()
        {
            var propertyInfo = typeof(ITraktCheckinPostErrorResponse).GetProperties().FirstOrDefault(p => p.Name == "ExpiresAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }
    }
}
