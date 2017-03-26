namespace TraktApiSharp.Tests.Objects.Get.Seasons.Interfaces
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Seasons;
    using Xunit;

    [Category("Objects.Get.Seasons.Interfaces")]
    public class ITraktSeasonWatchedProgress_Tests
    {
        [Fact]
        public void Test_ITraktSeasonWatchedProgress_Is_Interface()
        {
            typeof(ITraktSeasonWatchedProgress).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSeasonWatchedProgress_Inherits_ITraktSeasonProgress_Interface()
        {
            typeof(ITraktSeasonWatchedProgress).GetInterfaces().Should().Contain(typeof(ITraktSeasonProgress));
        }

        [Fact]
        public void Test_ITraktSeasonWatchedProgress_Has_Episodes_Property()
        {
            var propertyInfo = typeof(ITraktSeasonWatchedProgress).GetProperties().FirstOrDefault(p => p.Name == "Episodes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktEpisodeWatchedProgress>));
        }
    }
}
