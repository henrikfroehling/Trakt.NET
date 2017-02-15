namespace TraktApiSharp.Tests.Objects.Get.Calendars
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Calendars;
    using Xunit;

    [Category("Objects.Get.Calendars")]
    public class TraktCalendarMovie_Tests
    {
        [Fact]
        public void Test_TraktCalendarMovie_Implements_ITraktCalendarMovie_Interface()
        {
            typeof(TraktCalendarMovie).GetInterfaces().Should().Contain(typeof(ITraktCalendarMovie));
        }
    }
}
