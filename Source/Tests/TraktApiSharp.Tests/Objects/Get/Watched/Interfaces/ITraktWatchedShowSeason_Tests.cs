namespace TraktApiSharp.Tests.Objects.Get.Watched.Interfaces
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched;
    using Xunit;

    [Category("Objects.Get.Watched.Interfaces")]
    public class ITraktWatchedShowSeason_Tests
    {
        [Fact]
        public void Test_ITraktWatchedShowSeason_Is_Interface()
        {
            typeof(ITraktWatchedShowSeason).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktWatchedShowSeason_Has_Number_Property()
        {
            var propertyInfo = typeof(ITraktWatchedShowSeason).GetProperties().FirstOrDefault(p => p.Name == "Number");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktWatchedShowSeason_Has_Episodes_Property()
        {
            var propertyInfo = typeof(ITraktWatchedShowSeason).GetProperties().FirstOrDefault(p => p.Name == "Episodes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktWatchedShowEpisode>));
        }
    }
}
