namespace TraktApiSharp.Objects.Get.Calendars.Json.Factories
{
    using Get.Calendars.Json.Reader;
    using Objects.Json;

    internal class CalendarShowJsonReaderFactory : IJsonIOFactory<ITraktCalendarShow>
    {
        public IObjectJsonReader<ITraktCalendarShow> CreateObjectReader() => new CalendarShowObjectJsonReader();

        public IArrayJsonReader<ITraktCalendarShow> CreateArrayReader() => new CalendarShowArrayJsonReader();

        public IObjectJsonReader<ITraktCalendarShow> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktCalendarShow> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
