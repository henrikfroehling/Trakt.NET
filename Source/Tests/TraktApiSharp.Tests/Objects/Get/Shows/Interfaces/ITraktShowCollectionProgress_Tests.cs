namespace TraktApiSharp.Tests.Objects.Get.Shows.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Shows.Interfaces")]
    public class ITraktShowCollectionProgress_Tests
    {
        [Fact]
        public void Test_ITraktShowCollectionProgress_Is_Interface()
        {
            typeof(ITraktShowCollectionProgress).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktShowCollectionProgress_Inherits_ITraktShowProgress_Interface()
        {
            typeof(ITraktShowCollectionProgress).GetInterfaces().Should().Contain(typeof(ITraktShowProgress));
        }

        [Fact]
        public void Test_ITraktShowCollectionProgress_Has_LastCollectedAt_Property()
        {
            var propertyInfo = typeof(ITraktShowCollectionProgress).GetProperties().FirstOrDefault(p => p.Name == "LastCollectedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktShowCollectionProgress_Has_Seasons_Property()
        {
            var propertyInfo = typeof(ITraktShowCollectionProgress).GetProperties().FirstOrDefault(p => p.Name == "Seasons");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktSeasonCollectionProgress>));
        }
    }
}
