namespace TraktApiSharp.Tests.Objects.Get.Shows
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Shows;
    using Xunit;

    [Category("Objects.Get.Shows.Interfaces")]
    public class ITraktShow_Tests
    {
        [Fact]
        public void Test_ITraktShow_Is_Interface()
        {
            typeof(ITraktShow).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktShow_Has_Title_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "Title");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktShow_Has_Year_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "Year");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktShow_Has_Ids_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "Ids");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShowIds));
        }

        [Fact]
        public void Test_ITraktShow_Has_Overview_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "Overview");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktShow_Has_FirstAired_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "FirstAired");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktShow_Has_Airs_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "Airs");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktShowAirs));
        }

        [Fact]
        public void Test_ITraktShow_Has_Runtime_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "Runtime");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktShow_Has_Certification_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "Certification");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktShow_Has_Network_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "Network");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktShow_Has_CountryCode_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "CountryCode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktShow_Has_Trailer_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "Trailer");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktShow_Has_Homepage_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "Homepage");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktShow_Has_Status_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "Status");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktShowStatus));
        }

        [Fact]
        public void Test_ITraktShow_Has_Rating_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "Rating");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(float?));
        }

        [Fact]
        public void Test_ITraktShow_Has_Votes_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "Votes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktShow_Has_UpdatedAt_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "UpdatedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktShow_Has_LanguageCode_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "LanguageCode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktShow_Has_AvailableTranslationLanguageCodes_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "AvailableTranslationLanguageCodes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<string>));
        }

        [Fact]
        public void Test_ITraktShow_Has_Genres_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "Genres");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<string>));
        }

        [Fact]
        public void Test_ITraktShow_Has_AiredEpisodes_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "AiredEpisodes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktShow_Has_Seasons_Property()
        {
            var propertyInfo = typeof(ITraktShow).GetProperties().FirstOrDefault(p => p.Name == "Seasons");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<ITraktSeason>));
        }
    }
}
