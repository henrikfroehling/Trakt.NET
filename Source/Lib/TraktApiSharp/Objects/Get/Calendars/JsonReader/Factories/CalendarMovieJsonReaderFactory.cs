namespace TraktApiSharp.Objects.Get.Calendars.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class CalendarMovieJsonReaderFactory : IJsonReaderFactory<ITraktCalendarMovie>
    {
        public IObjectJsonReader<ITraktCalendarMovie> CreateObjectReader() => new CalendarMovieObjectJsonReader();

        public IArrayJsonReader<ITraktCalendarMovie> CreateArrayReader() => new CalendarMovieArrayJsonReader();
    }
}
