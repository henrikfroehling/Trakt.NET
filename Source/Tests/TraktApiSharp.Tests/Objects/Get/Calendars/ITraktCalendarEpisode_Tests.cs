namespace TraktApiSharp.Tests.Objects.Get.Calendars
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Objects.Get.Episodes;
    using Xunit;

    [Category("Objects.Get.Calendars")]
    public class ITraktCalendarEpisode_Tests
    {
        [Fact]
        public void Test_ITraktCalendarEpisode_Is_Interface()
        {
            typeof(ITraktCalendarEpisode).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktCalendarEpisode_Has_SeasonNumber_Property()
        {
            var propertyInfo = typeof(ITraktCalendarEpisode).GetProperties().FirstOrDefault(p => p.Name == "SeasonNumber");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktCalendarEpisode_Has_EpisodeNumber_Property()
        {
            var propertyInfo = typeof(ITraktCalendarEpisode).GetProperties().FirstOrDefault(p => p.Name == "EpisodeNumber");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktCalendarEpisode_Has_EpisodeTitle_Property()
        {
            var propertyInfo = typeof(ITraktCalendarEpisode).GetProperties().FirstOrDefault(p => p.Name == "EpisodeTitle");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktCalendarEpisode_Has_EpisodeIds_Property()
        {
            var propertyInfo = typeof(ITraktCalendarEpisode).GetProperties().FirstOrDefault(p => p.Name == "EpisodeIds");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktEpisodeIds));
        }

        [Fact]
        public void Test_ITraktCalendarEpisode_Has_AbsoluteEpisodeNumber_Property()
        {
            var propertyInfo = typeof(ITraktCalendarEpisode).GetProperties().FirstOrDefault(p => p.Name == "AbsoluteEpisodeNumber");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktCalendarEpisode_Has_EpisodeOverview_Property()
        {
            var propertyInfo = typeof(ITraktCalendarEpisode).GetProperties().FirstOrDefault(p => p.Name == "EpisodeOverview");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [Fact]
        public void Test_ITraktCalendarEpisode_Has_EpisodeRuntime_Property()
        {
            var propertyInfo = typeof(ITraktCalendarEpisode).GetProperties().FirstOrDefault(p => p.Name == "EpisodeRuntime");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktCalendarEpisode_Has_EpisodeRating_Property()
        {
            var propertyInfo = typeof(ITraktCalendarEpisode).GetProperties().FirstOrDefault(p => p.Name == "EpisodeRating");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(float?));
        }

        [Fact]
        public void Test_ITraktCalendarEpisode_Has_EpisodeVotes_Property()
        {
            var propertyInfo = typeof(ITraktCalendarEpisode).GetProperties().FirstOrDefault(p => p.Name == "EpisodeVotes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_ITraktCalendarEpisode_Has_EpisodeAiredFirstAt_Property()
        {
            var propertyInfo = typeof(ITraktCalendarEpisode).GetProperties().FirstOrDefault(p => p.Name == "EpisodeAiredFirstAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktCalendarEpisode_Has_EpisodeUpdatedAt_Property()
        {
            var propertyInfo = typeof(ITraktCalendarEpisode).GetProperties().FirstOrDefault(p => p.Name == "EpisodeUpdatedAt");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktCalendarEpisode_Has_AvailableEpisodeTranslationLanguageCodes_Property()
        {
            var propertyInfo = typeof(ITraktCalendarEpisode).GetProperties().FirstOrDefault(p => p.Name == "AvailableEpisodeTranslationLanguageCodes");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<string>));
        }

        [Fact]
        public void Test_ITraktCalendarEpisode_Has_EpisodeTranslations_Property()
        {
            var propertyInfo = typeof(ITraktCalendarEpisode).GetProperties().FirstOrDefault(p => p.Name == "EpisodeTranslations");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(IEnumerable<TraktEpisodeTranslation>));
        }
    }
}
