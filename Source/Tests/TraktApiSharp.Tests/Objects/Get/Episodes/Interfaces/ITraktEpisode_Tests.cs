namespace TraktApiSharp.Tests.Objects.Get.Episodes.Interfaces
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using Xunit;

    [Category("Objects.Get.Episodes.Interfaces")]
    public class ITraktEpisode_Tests
    {
        [Fact]
        public void Test_ITraktEpisode_Is_Interface()
        {
            typeof(ITraktEpisode).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktEpisode_Has_SeasonNumber_Property()
        {
            var propertyInfo = typeof(ITraktEpisode).GetProperties().FirstOrDefault(p => p.Name == "SeasonNumber");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktEpisode_Has_Number_Property()
        {
            var propertyInfo = typeof(ITraktEpisode).GetProperties().FirstOrDefault(p => p.Name == "Number");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktEpisode_Has_Title_Property()
        {
            var propertyInfo = typeof(ITraktEpisode).GetProperties().FirstOrDefault(p => p.Name == "Title");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktEpisode_Has_Ids_Property()
        {
            var propertyInfo = typeof(ITraktEpisode).GetProperties().FirstOrDefault(p => p.Name == "Ids");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktEpisodeIds));
        }

        [Fact]
        public void Test_ITraktEpisode_Has_NumberAbsolute_Property()
        {
            var propertyInfo = typeof(ITraktEpisode).GetProperties().FirstOrDefault(p => p.Name == "NumberAbsolute");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktEpisode_Has_Overview_Property()
        {
            var propertyInfo = typeof(ITraktEpisode).GetProperties().FirstOrDefault(p => p.Name == "Overview");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktEpisode_Has_Runtime_Property()
        {
            var propertyInfo = typeof(ITraktEpisode).GetProperties().FirstOrDefault(p => p.Name == "Runtime");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktEpisode_Has_Rating_Property()
        {
            var propertyInfo = typeof(ITraktEpisode).GetProperties().FirstOrDefault(p => p.Name == "Rating");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(float?));
        }

        [Fact]
        public void Test_ITraktEpisode_Has_Votes_Property()
        {
            var propertyInfo = typeof(ITraktEpisode).GetProperties().FirstOrDefault(p => p.Name == "Votes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktEpisode_Has_FirstAired_Property()
        {
            var propertyInfo = typeof(ITraktEpisode).GetProperties().FirstOrDefault(p => p.Name == "FirstAired");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktEpisode_Has_UpdatedAt_Property()
        {
            var propertyInfo = typeof(ITraktEpisode).GetProperties().FirstOrDefault(p => p.Name == "UpdatedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktEpisode_Has_AvailableTranslationLanguageCodes_Property()
        {
            var propertyInfo = typeof(ITraktEpisode).GetProperties().FirstOrDefault(p => p.Name == "AvailableTranslationLanguageCodes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<string>));
        }

        [Fact]
        public void Test_ITraktEpisode_Has_Translations_Property()
        {
            var propertyInfo = typeof(ITraktEpisode).GetProperties().FirstOrDefault(p => p.Name == "Translations");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktEpisodeTranslation>));
        }
    }
}
