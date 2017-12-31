namespace TraktApiSharp.Objects.Get.Calendars.Json.Factories
{
    using Get.Calendars.Json.Reader;
    using Objects.Json;

    internal class CalendarShowJsonIOFactory : IJsonIOFactory<ITraktCalendarShow>
    {
        public IObjectJsonReader<ITraktCalendarShow> CreateObjectReader() => new CalendarShowObjectJsonReader();

        public IArrayJsonReader<ITraktCalendarShow> CreateArrayReader() => new CalendarShowArrayJsonReader();

        public IObjectJsonWriter<ITraktCalendarShow> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktCalendarShow> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
