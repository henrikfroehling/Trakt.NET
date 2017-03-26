namespace TraktApiSharp.Tests.Objects.Get.Collections.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Collections;
    using Xunit;

    [Category("Objects.Get.Collections.Interfaces")]
    public class ITraktCollectionShowEpisodeEpisode_Tests
    {
        [Fact]
        public void Test_ITraktCollectionShowEpisode_Is_Interface()
        {
            typeof(ITraktCollectionShowEpisode).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktCollectionShowEpisode_Has_Number_Property()
        {
            var propertyInfo = typeof(ITraktCollectionShowEpisode).GetProperties().FirstOrDefault(p => p.Name == "Number");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktCollectionShowEpisode_Has_CollectedAt_Property()
        {
            var propertyInfo = typeof(ITraktCollectionShowEpisode).GetProperties().FirstOrDefault(p => p.Name == "CollectedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktCollectionShowEpisode_Has_Metadata_Property()
        {
            var propertyInfo = typeof(ITraktCollectionShowEpisode).GetProperties().FirstOrDefault(p => p.Name == "Metadata");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMetadata));
        }
    }
}
