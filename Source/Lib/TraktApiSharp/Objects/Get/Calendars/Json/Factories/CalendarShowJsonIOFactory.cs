namespace TraktNet.Objects.Get.Calendars.Json.Factories
{
    using Get.Calendars.Json.Reader;
    using Get.Calendars.Json.Writer;
    using Objects.Json;

    internal class CalendarShowJsonIOFactory : IJsonIOFactory<ITraktCalendarShow>
    {
        public IObjectJsonReader<ITraktCalendarShow> CreateObjectReader() => new CalendarShowObjectJsonReader();

        public IArrayJsonReader<ITraktCalendarShow> CreateArrayReader() => new CalendarShowArrayJsonReader();

        public IObjectJsonWriter<ITraktCalendarShow> CreateObjectWriter() => new CalendarShowObjectJsonWriter();
    }
}
