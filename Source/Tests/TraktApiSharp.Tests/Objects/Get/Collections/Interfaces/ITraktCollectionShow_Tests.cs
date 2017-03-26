namespace TraktApiSharp.Tests.Objects.Get.Collections.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Collections.Interfaces")]
    public class ITraktCollectionShow_Tests
    {
        [Fact]
        public void Test_ITraktCollectionShow_Is_Interface()
        {
            typeof(ITraktCollectionShow).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktCollectionShow_Inherits_ITraktShow_Interface()
        {
            typeof(ITraktCollectionShow).GetInterfaces().Should().Contain(typeof(ITraktShow));
        }

        [Fact]
        public void Test_ITraktCollectionShow_Has_LastCollectedAt_Property()
        {
            var propertyInfo = typeof(ITraktCollectionShow).GetProperties().FirstOrDefault(p => p.Name == "LastCollectedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktCollectionShow_Has_CollectionSeasons_Property()
        {
            var propertyInfo = typeof(ITraktCollectionShow).GetProperties().FirstOrDefault(p => p.Name == "CollectionSeasons");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktCollectionShowSeason>));
        }

        [Fact]
        public void Test_ITraktCollectionShow_Has_Show_Property()
        {
            var propertyInfo = typeof(ITraktCollectionShow).GetProperties().FirstOrDefault(p => p.Name == "Show");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShow));
        }
    }
}
