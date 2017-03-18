namespace TraktApiSharp.Tests.Objects.Get.Shows.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Shows.Interfaces")]
    public class ITraktShowAlias_Tests
    {
        [Fact]
        public void Test_ITraktShowAlias_Is_Interface()
        {
            typeof(ITraktShowAlias).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktShowAlias_Has_Title_Property()
        {
            var propertyInfo = typeof(ITraktShowAlias).GetProperties().FirstOrDefault(p => p.Name == "Title");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktShowAlias_Has_CountryCode_Property()
        {
            var propertyInfo = typeof(ITraktShowAlias).GetProperties().FirstOrDefault(p => p.Name == "CountryCode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
