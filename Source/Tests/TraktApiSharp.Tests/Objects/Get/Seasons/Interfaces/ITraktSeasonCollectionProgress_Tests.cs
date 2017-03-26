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
    public class ITraktSeasonCollectionProgress_Tests
    {
        [Fact]
        public void Test_ITraktSeasonCollectionProgress_Is_Interface()
        {
            typeof(ITraktSeasonCollectionProgress).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgress_Inherits_ITraktSeasonProgress_Interface()
        {
            typeof(ITraktSeasonCollectionProgress).GetInterfaces().Should().Contain(typeof(ITraktSeasonProgress));
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgress_Has_Episodes_Property()
        {
            var propertyInfo = typeof(ITraktSeasonCollectionProgress).GetProperties().FirstOrDefault(p => p.Name == "Episodes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktEpisodeCollectionProgress>));
        }
    }
}
