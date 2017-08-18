namespace TraktApiSharp.Objects.Get.Calendars.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktCalendarShowJsonReaderFactory : IJsonReaderFactory<ITraktCalendarShow>
    {
        public ITraktObjectJsonReader<ITraktCalendarShow> CreateObjectReader() => new TraktCalendarShowObjectJsonReader();

        public ITraktArrayJsonReader<ITraktCalendarShow> CreateArrayReader() => new TraktCalendarShowArrayJsonReader();
    }
}
