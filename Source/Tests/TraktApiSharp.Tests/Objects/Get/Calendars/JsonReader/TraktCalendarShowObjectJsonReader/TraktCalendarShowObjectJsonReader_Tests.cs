namespace TraktApiSharp.Tests.Objects.Get.Calendars.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Calendars;
    using TraktApiSharp.Objects.Get.Calendars.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Calendars.JsonReader")]
    public partial class TraktCalendarShowObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktCalendarShowObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktCalendarShowObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktCalendarShow>));
        }
    }
}
