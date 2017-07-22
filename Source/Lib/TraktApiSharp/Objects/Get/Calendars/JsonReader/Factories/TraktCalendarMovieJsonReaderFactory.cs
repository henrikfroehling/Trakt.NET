namespace TraktApiSharp.Objects.Get.Calendars.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktCalendarMovieJsonReaderFactory : ITraktJsonReaderFactory<ITraktCalendarMovie>
    {
        public ITraktObjectJsonReader<ITraktCalendarMovie> CreateObjectReader() => new TraktCalendarMovieObjectJsonReader();

        public ITraktArrayJsonReader<ITraktCalendarMovie> CreateArrayReader() => new TraktCalendarMovieArrayJsonReader();
    }
}
