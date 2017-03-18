namespace TraktApiSharp.Tests.Objects.Get.Users.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Users;
    using Xunit;

    [Category("Objects.Get.Users.Interfaces")]
    public class ITraktUserIds_Tests
    {
        [Fact]
        public void Test_ITraktUserIds_Is_Interface()
        {
            typeof(ITraktUserIds).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserIds_Inherits_IIds_Interface()
        {
            typeof(ITraktUserIds).GetInterfaces().Should().Contain(typeof(IIds));
        }

        [Fact]
        public void Test_ITraktUserIds_Has_Slug_Property()
        {
            var propertyInfo = typeof(ITraktUserIds).GetProperties().FirstOrDefault(p => p.Name == "Slug");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
