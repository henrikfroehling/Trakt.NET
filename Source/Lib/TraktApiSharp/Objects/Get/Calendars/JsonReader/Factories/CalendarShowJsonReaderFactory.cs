namespace TraktApiSharp.Objects.Get.Calendars.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class CalendarShowJsonReaderFactory : IJsonReaderFactory<ITraktCalendarShow>
    {
        public IObjectJsonReader<ITraktCalendarShow> CreateObjectReader() => new CalendarShowObjectJsonReader();

        public IArrayJsonReader<ITraktCalendarShow> CreateArrayReader() => new CalendarShowArrayJsonReader();
    }
}
