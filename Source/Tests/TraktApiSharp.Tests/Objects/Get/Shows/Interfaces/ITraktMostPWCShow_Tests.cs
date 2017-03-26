namespace TraktApiSharp.Tests.Objects.Get.Shows.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Shows.Interfaces")]
    public class ITraktMostPWCShow_Tests
    {
        [Fact]
        public void Test_ITraktMostPWCShow_Is_Interface()
        {
            typeof(ITraktMostPWCShow).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktMostPWCShow_Inherits_ITraktShow_Interface()
        {
            typeof(ITraktMostPWCShow).GetInterfaces().Should().Contain(typeof(ITraktShow));
        }

        [Fact]
        public void Test_ITraktMostPWCShow_Has_WatcherCount_Property()
        {
            var propertyInfo = typeof(ITraktMostPWCShow).GetProperties().FirstOrDefault(p => p.Name == "WatcherCount");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktMostPWCShow_Has_PlayCount_Property()
        {
            var propertyInfo = typeof(ITraktMostPWCShow).GetProperties().FirstOrDefault(p => p.Name == "PlayCount");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktMostPWCShow_Has_CollectedCount_Property()
        {
            var propertyInfo = typeof(ITraktMostPWCShow).GetProperties().FirstOrDefault(p => p.Name == "CollectedCount");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktMostPWCShow_Has_CollectorCount_Property()
        {
            var propertyInfo = typeof(ITraktMostPWCShow).GetProperties().FirstOrDefault(p => p.Name == "CollectorCount");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktMostPWCShow_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktMostPWCShow).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }
    }
}
