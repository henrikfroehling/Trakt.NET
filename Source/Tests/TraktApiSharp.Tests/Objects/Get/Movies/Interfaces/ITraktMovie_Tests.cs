namespace TraktApiSharp.Tests.Objects.Get.Movies
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Movies.Interfaces")]
    public class ITraktMovie_Tests
    {
        [Fact]
        public void Test_ITraktMovie_Is_Interface()
        {
            typeof(ITraktMovie).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktMovie_Has_Title_Property()
        {
            var propertyInfo = typeof(ITraktMovie).GetProperties().FirstOrDefault(p => p.Name == "Title");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktMovie_Has_Year_Property()
        {
            var propertyInfo = typeof(ITraktMovie).GetProperties().FirstOrDefault(p => p.Name == "Year");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktMovie_Has_Ids_Property()
        {
            var propertyInfo = typeof(ITraktMovie).GetProperties().FirstOrDefault(p => p.Name == "Ids");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktMovieIds));
        }

        [Fact]
        public void Test_ITraktMovie_Has_Tagline_Property()
        {
            var propertyInfo = typeof(ITraktMovie).GetProperties().FirstOrDefault(p => p.Name == "Tagline");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktMovie_Has_Overview_Property()
        {
            var propertyInfo = typeof(ITraktMovie).GetProperties().FirstOrDefault(p => p.Name == "Overview");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktMovie_Has_Released_Property()
        {
            var propertyInfo = typeof(ITraktMovie).GetProperties().FirstOrDefault(p => p.Name == "Released");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktMovie_Has_Runtime_Property()
        {
            var propertyInfo = typeof(ITraktMovie).GetProperties().FirstOrDefault(p => p.Name == "Runtime");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktMovie_Has_Trailer_Property()
        {
            var propertyInfo = typeof(ITraktMovie).GetProperties().FirstOrDefault(p => p.Name == "Trailer");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktMovie_Has_Homepage_Property()
        {
            var propertyInfo = typeof(ITraktMovie).GetProperties().FirstOrDefault(p => p.Name == "Homepage");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktMovie_Has_Rating_Property()
        {
            var propertyInfo = typeof(ITraktMovie).GetProperties().FirstOrDefault(p => p.Name == "Rating");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(float?));
        }

        [Fact]
        public void Test_ITraktMovie_Has_Votes_Property()
        {
            var propertyInfo = typeof(ITraktMovie).GetProperties().FirstOrDefault(p => p.Name == "Votes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktMovie_Has_UpdatedAt_Property()
        {
            var propertyInfo = typeof(ITraktMovie).GetProperties().FirstOrDefault(p => p.Name == "UpdatedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktMovie_Has_LanguageCode_Property()
        {
            var propertyInfo = typeof(ITraktMovie).GetProperties().FirstOrDefault(p => p.Name == "LanguageCode");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktMovie_Has_AvailableTranslationLanguageCodes_Property()
        {
            var propertyInfo = typeof(ITraktMovie).GetProperties().FirstOrDefault(p => p.Name == "AvailableTranslationLanguageCodes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<string>));
        }

        [Fact]
        public void Test_ITraktMovie_Has_Genres_Property()
        {
            var propertyInfo = typeof(ITraktMovie).GetProperties().FirstOrDefault(p => p.Name == "Genres");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<string>));
        }

        [Fact]
        public void Test_ITraktMovie_Has_Certification_Property()
        {
            var propertyInfo = typeof(ITraktMovie).GetProperties().FirstOrDefault(p => p.Name == "Certification");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
