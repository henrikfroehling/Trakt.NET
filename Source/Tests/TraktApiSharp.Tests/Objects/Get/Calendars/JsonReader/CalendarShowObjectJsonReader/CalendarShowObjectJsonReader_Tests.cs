namespace TraktApiSharp.Tests.Objects.Get.Calendars.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Objects.Get.Calendars.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Calendars.JsonReader")]
    public partial class CalendarShowObjectJsonReader_Tests
    {
        [Fact]
        public void Test_CalendarShowObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(CalendarShowObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktCalendarShow>));
        }
    }
}
