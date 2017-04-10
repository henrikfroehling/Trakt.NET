namespace TraktApiSharp.Tests.Objects.Get.Users.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Users;
    using Xunit;

    [Category("Objects.Get.Users.Interfaces")]
    public class ITraktUserImages_Tests
    {
        [Fact]
        public void Test_ITraktUserImages_Is_Interface()
        {
            typeof(ITraktUserImages).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktUserImages_Has_Avatar_Property()
        {
            var propertyInfo = typeof(ITraktUserImages).GetProperties().FirstOrDefault(p => p.Name == "Avatar");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktImage));
        }
    }
}
