namespace TraktApiSharp.Tests.Objects.Get.Users.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using Xunit;

    [Category("Objects.Get.Users.Interfaces")]
    public class ITraktSharingText_Tests
    {
        [Fact]
        public void Test_ITraktSharingText_Is_Interface()
        {
            typeof(ITraktSharingText).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSharingText_Has_Watching_Property()
        {
            var propertyInfo = typeof(ITraktSharingText).GetProperties().FirstOrDefault(p => p.Name == "Watching");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktSharingText_Has_Watched_Property()
        {
            var propertyInfo = typeof(ITraktSharingText).GetProperties().FirstOrDefault(p => p.Name == "Watched");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
