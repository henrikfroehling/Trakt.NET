namespace TraktApiSharp.Tests.Objects.Get.Shows.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Shows.Interfaces")]
    public class ITraktRecentlyUpdatedShow_Tests
    {
        [Fact]
        public void Test_ITraktRecentlyUpdatedShow_Is_Interface()
        {
            typeof(ITraktRecentlyUpdatedShow).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedShow_Inherits_ITraktShow_Interface()
        {
            typeof(ITraktRecentlyUpdatedShow).GetInterfaces().Should().Contain(typeof(ITraktShow));
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedShow_Has_RecentlyUpdatedAt_Property()
        {
            var propertyInfo = typeof(ITraktRecentlyUpdatedShow).GetProperties().FirstOrDefault(p => p.Name == "RecentlyUpdatedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedShow_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktRecentlyUpdatedShow).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }
    }
}
