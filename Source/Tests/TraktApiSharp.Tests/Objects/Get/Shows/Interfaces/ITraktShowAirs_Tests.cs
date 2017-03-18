namespace TraktApiSharp.Tests.Objects.Get.Shows.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Shows.Interfaces")]
    public class ITraktShowAirs_Tests
    {
        [Fact]
        public void Test_ITraktShowAirs_Is_Interface()
        {
            typeof(ITraktShowAirs).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktShowAirs_Has_Day_Property()
        {
            var propertyInfo = typeof(ITraktShowAirs).GetProperties().FirstOrDefault(p => p.Name == "Day");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktShowAirs_Has_Time_Property()
        {
            var propertyInfo = typeof(ITraktShowAirs).GetProperties().FirstOrDefault(p => p.Name == "Time");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktShowAirs_Has_TimeZoneId_Property()
        {
            var propertyInfo = typeof(ITraktShowAirs).GetProperties().FirstOrDefault(p => p.Name == "TimeZoneId");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
