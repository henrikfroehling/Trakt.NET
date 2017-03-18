namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using Xunit;

    [Category("Objects.Get.Users.Lists.Interfaces")]
    public class ITraktListIds_Tests
    {
        [Fact]
        public void Test_ITraktListIds_Is_Interface()
        {
            typeof(ITraktListIds).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktListIds_Inherits_IIds_Interface()
        {
            typeof(ITraktListIds).GetInterfaces().Should().Contain(typeof(IIds));
        }

        [Fact]
        public void Test_ITraktListIds_Has_Trakt_Property()
        {
            var propertyInfo = typeof(ITraktListIds).GetProperties().FirstOrDefault(p => p.Name == "Trakt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint));
        }

        [Fact]
        public void Test_ITraktListIds_Has_Slug_Property()
        {
            var propertyInfo = typeof(ITraktListIds).GetProperties().FirstOrDefault(p => p.Name == "Slug");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
