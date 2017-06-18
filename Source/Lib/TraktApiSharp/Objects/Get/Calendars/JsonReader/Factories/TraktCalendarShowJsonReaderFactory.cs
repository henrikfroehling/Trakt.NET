namespace TraktApiSharp.Objects.Get.Calendars.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktCalendarShowJsonReaderFactory : ITraktJsonReaderFactory<ITraktCalendarShow>
    {
        public ITraktObjectJsonReader<ITraktCalendarShow> CreateObjectReader() => new TraktCalendarShowObjectJsonReader();

        public ITraktArrayJsonReader<ITraktCalendarShow> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktCalendarShow)} is not supported.");
        }
    }
}
