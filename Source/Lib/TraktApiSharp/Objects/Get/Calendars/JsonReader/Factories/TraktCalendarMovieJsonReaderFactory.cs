namespace TraktApiSharp.Objects.Get.Calendars.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktCalendarMovieJsonReaderFactory : ITraktJsonReaderFactory<ITraktCalendarMovie>
    {
        public ITraktObjectJsonReader<ITraktCalendarMovie> CreateObjectReader() => new TraktCalendarMovieObjectJsonReader();

        public ITraktArrayJsonReader<ITraktCalendarMovie> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktCalendarMovie)} is not supported.");
        }
    }
}
