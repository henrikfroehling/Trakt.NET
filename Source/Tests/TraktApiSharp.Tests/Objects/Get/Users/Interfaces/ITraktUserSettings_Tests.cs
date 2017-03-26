namespace TraktApiSharp.Tests.Objects.Get.Users.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Users;
    using Xunit;

    [Category("Objects.Get.Users.Interfaces")]
    public class ITraktUserSettings_Tests
    {
        [Fact]
        public void Test_ITraktUserSettings_Is_Interface()
        {
            typeof(ITraktUserSettings).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserSettings_Has_User_Property()
        {
            var propertyInfo = typeof(ITraktUserSettings).GetProperties().FirstOrDefault(p => p.Name == "User");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktUser));
        }

        [Fact]
        public void Test_ITraktUserSettings_Has_Account_Property()
        {
            var propertyInfo = typeof(ITraktUserSettings).GetProperties().FirstOrDefault(p => p.Name == "Account");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktAccountSettings));
        }

        [Fact]
        public void Test_ITraktUserSettings_Has_Connections_Property()
        {
            var propertyInfo = typeof(ITraktUserSettings).GetProperties().FirstOrDefault(p => p.Name == "Connections");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSharing));
        }

        [Fact]
        public void Test_ITraktUserSettings_Has_SharingText_Property()
        {
            var propertyInfo = typeof(ITraktUserSettings).GetProperties().FirstOrDefault(p => p.Name == "SharingText");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktSharingText));
        }
    }
}
