namespace TraktApiSharp.Tests.Objects.Post.Checkins.Responses.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Post.Checkins.Responses;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.Interfaces")]
    public class ITraktCheckinPostResponse_Tests
    {
        [Fact]
        public void Test_ITraktCheckinPostResponse_Is_Interface()
        {
            typeof(ITraktCheckinPostResponse).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktCheckinPostResponse_Has_Id_Property()
        {
            var propertyInfo = typeof(ITraktCheckinPostResponse).GetProperties().FirstOrDefault(p => p.Name == "Id");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ulong));
        }

        [Fact]
        public void Test_ITraktCheckinPostResponse_Has_WatchedAt_Property()
        {
            var propertyInfo = typeof(ITraktCheckinPostResponse).GetProperties().FirstOrDefault(p => p.Name == "WatchedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktCheckinPostResponse_Has_Sharing_Property()
        {
            var propertyInfo = typeof(ITraktCheckinPostResponse).GetProperties().FirstOrDefault(p => p.Name == "Sharing");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSharing));
        }
    }
}
