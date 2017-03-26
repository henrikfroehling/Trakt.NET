namespace TraktApiSharp.Tests.Objects.Get.Episodes.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using Xunit;

    [Category("Objects.Get.Episodes.Interfaces")]
    public class ITraktEpisodeCollectionProgress_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeCollectionProgress_Is_Interface()
        {
            typeof(ITraktEpisodeCollectionProgress).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgress_Inherits_ITraktEpisodeProgress_Interface()
        {
            typeof(ITraktEpisodeCollectionProgress).GetInterfaces().Should().Contain(typeof(ITraktEpisodeProgress));
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgress_Has_CollectedAt_Property()
        {
            var propertyInfo = typeof(ITraktEpisodeCollectionProgress).GetProperties().FirstOrDefault(p => p.Name == "CollectedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }
    }
}
