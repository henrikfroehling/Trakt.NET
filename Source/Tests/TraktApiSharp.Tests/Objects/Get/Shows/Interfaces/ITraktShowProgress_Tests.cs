namespace TraktApiSharp.Tests.Objects.Get.Shows.Interfaces
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Shows.Interfaces")]
    public class ITraktShowProgress_Tests
    {
        [Fact]
        public void Test_ITraktShowProgress_Is_Interface()
        {
            typeof(ITraktShowProgress).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktShowProgress_Has_Aired_Property()
        {
            var propertyInfo = typeof(ITraktShowProgress).GetProperties().FirstOrDefault(p => p.Name == "Aired");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktShowProgress_Has_Completed_Property()
        {
            var propertyInfo = typeof(ITraktShowProgress).GetProperties().FirstOrDefault(p => p.Name == "Completed");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktShowProgress_Has_HiddenSeasons_Property()
        {
            var propertyInfo = typeof(ITraktShowProgress).GetProperties().FirstOrDefault(p => p.Name == "HiddenSeasons");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktSeason>));
        }

        [Fact]
        public void Test_ITraktShowProgress_Has_NextEpisode_Property()
        {
            var propertyInfo = typeof(ITraktShowProgress).GetProperties().FirstOrDefault(p => p.Name == "NextEpisode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktEpisode));
        }
    }
}
