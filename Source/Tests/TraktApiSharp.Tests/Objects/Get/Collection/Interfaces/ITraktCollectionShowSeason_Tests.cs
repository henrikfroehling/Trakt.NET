namespace TraktApiSharp.Tests.Objects.Get.Collection.Interfaces
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Collection;
    using Xunit;

    [Category("Objects.Get.Collection.Interfaces")]
    public class ITraktCollectionShowSeason_Tests
    {
        [Fact]
        public void Test_ITraktCollectionShowSeason_Is_Interface()
        {
            typeof(ITraktCollectionShowSeason).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktCollectionShowSeason_Has_Number_Property()
        {
            var propertyInfo = typeof(ITraktCollectionShowSeason).GetProperties().FirstOrDefault(p => p.Name == "Number");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktCollectionShowSeason_Has_Episodes_Property()
        {
            var propertyInfo = typeof(ITraktCollectionShowSeason).GetProperties().FirstOrDefault(p => p.Name == "Episodes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktCollectionShowEpisode>));
        }
    }
}
