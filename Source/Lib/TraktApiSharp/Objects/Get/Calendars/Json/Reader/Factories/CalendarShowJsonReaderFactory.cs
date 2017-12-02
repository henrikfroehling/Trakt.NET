namespace TraktApiSharp.Objects.Get.Calendars.Json.Factories.Reader
{
    using Get.Calendars.Json.Reader;
    using Objects.Json;

    internal class CalendarShowJsonReaderFactory : IJsonReaderFactory<ITraktCalendarShow>
    {
        public IObjectJsonReader<ITraktCalendarShow> CreateObjectReader() => new CalendarShowObjectJsonReader();

        public IArrayJsonReader<ITraktCalendarShow> CreateArrayReader() => new CalendarShowArrayJsonReader();
    }
}
