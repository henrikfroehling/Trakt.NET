namespace TraktApiSharp.Tests.Objects.Get.Users.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using Xunit;

    [Category("Objects.Get.Users.Interfaces")]
    public class ITraktAccountSettings_Tests
    {
        [Fact]
        public void Test_ITraktAccountSettings_Is_Interface()
        {
            typeof(ITraktAccountSettings).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktAccountSettings_Has_TimeZoneId_Property()
        {
            var propertyInfo = typeof(ITraktAccountSettings).GetProperties().FirstOrDefault(p => p.Name == "TimeZoneId");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktAccountSettings_Has_Time24Hr_Property()
        {
            var propertyInfo = typeof(ITraktAccountSettings).GetProperties().FirstOrDefault(p => p.Name == "Time24Hr");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(bool?));
        }

        [Fact]
        public void Test_ITraktAccountSettings_Has_CoverImage_Property()
        {
            var propertyInfo = typeof(ITraktAccountSettings).GetProperties().FirstOrDefault(p => p.Name == "CoverImage");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
