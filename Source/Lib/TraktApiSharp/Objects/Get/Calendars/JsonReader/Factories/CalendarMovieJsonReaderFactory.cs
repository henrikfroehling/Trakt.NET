namespace TraktApiSharp.Objects.Get.Calendars.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class CalendarMovieJsonReaderFactory : IJsonReaderFactory<ITraktCalendarMovie>
    {
        public IObjectJsonReader<ITraktCalendarMovie> CreateObjectReader() => new TraktCalendarMovieObjectJsonReader();

        public IArrayJsonReader<ITraktCalendarMovie> CreateArrayReader() => new TraktCalendarMovieArrayJsonReader();
    }
}
