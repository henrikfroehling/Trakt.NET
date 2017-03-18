namespace TraktApiSharp.Tests.Objects.Get.Calendars
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Objects.Get.Movies;
    using Xunit;

    [Category("Objects.Get.Calendars.Interfaces")]
    public class ITraktCalendarMovie_Tests
    {
        [Fact]
        public void Test_ITraktCalendarMovie_Is_Interface()
        {
            typeof(ITraktCalendarMovie).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktCalendarMovie_Inherits_ITraktMovie_Interface()
        {
            typeof(ITraktCalendarMovie).GetInterfaces().Should().Contain(typeof(ITraktMovie));
        }

        [Fact]
        public void Test_ITraktCalendarMovie_Has_CalendarRelease_Property()
        {
            var propertyInfo = typeof(ITraktCalendarMovie).GetProperties().FirstOrDefault(p => p.Name == "CalendarRelease");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(DateTime?));
        }

        [Fact]
        public void Test_ITraktCalendarMovie_Has_Movie_Property()
        {
            var propertyInfo = typeof(ITraktCalendarMovie).GetProperties().FirstOrDefault(p => p.Name == "Movie");

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(ITraktMovie));
        }
    }
}
