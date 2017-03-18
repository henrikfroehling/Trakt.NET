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
    public class ITraktShowWatchedProgress_Tests
    {
        [Fact]
        public void Test_ITraktShowWatchedProgress_Is_Interface()
        {
            typeof(ITraktShowWatchedProgress).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktShowWatchedProgress_Inherits_ITraktShowProgress_Interface()
        {
            typeof(ITraktShowWatchedProgress).GetInterfaces().Should().Contain(typeof(ITraktShowProgress));
        }

        [Fact]
        public void Test_ITraktShowWatchedProgress_Has_LastWatchedAt_Property()
        {
            var propertyInfo = typeof(ITraktShowWatchedProgress).GetProperties().FirstOrDefault(p => p.Name == "LastWatchedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktShowWatchedProgress_Has_Seasons_Property()
        {
            var propertyInfo = typeof(ITraktShowWatchedProgress).GetProperties().FirstOrDefault(p => p.Name == "Seasons");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktSeasonWatchedProgress>));
        }
    }
}
