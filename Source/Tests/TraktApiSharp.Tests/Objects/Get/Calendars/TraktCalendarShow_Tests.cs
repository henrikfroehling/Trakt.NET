namespace TraktApiSharp.Tests.Objects.Get.Calendars
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Calendars;
    using Xunit;

    [Category("Objects.Get.Calendars")]
    public class TraktCalendarShow_Tests
    {
        [Fact]
        public void Test_TraktCalendarShow_Implements_ITraktCalendarShow_Interface()
        {
            typeof(TraktCalendarShow).GetInterfaces().Should().Contain(typeof(ITraktCalendarShow));
        }
    }
}
