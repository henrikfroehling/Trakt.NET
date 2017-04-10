namespace TraktApiSharp.Tests.Objects.Get.Collections.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Collections;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Collections.Interfaces")]
    public class ITraktCollectionMovie_Tests
    {
        [Fact]
        public void Test_ITraktCollectionMovie_Is_Interface()
        {
            typeof(ITraktCollectionMovie).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktCollectionMovie_Inherits_ITraktMovie_Interface()
        {
            typeof(ITraktCollectionMovie).GetInterfaces().Should().Contain(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_ITraktCollectionMovie_Has_CollectedAt_Property()
        {
            var propertyInfo = typeof(ITraktCollectionMovie).GetProperties().FirstOrDefault(p => p.Name == "CollectedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktCollectionMovie_Has_Metadata_Property()
        {
            var propertyInfo = typeof(ITraktCollectionMovie).GetProperties().FirstOrDefault(p => p.Name == "Metadata");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMetadata));
        }

        [Fact]
        public void Test_ITraktCollectionMovie_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktCollectionMovie).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }
    }
}
