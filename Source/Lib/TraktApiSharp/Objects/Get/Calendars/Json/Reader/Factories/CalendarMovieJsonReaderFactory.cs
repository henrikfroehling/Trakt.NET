namespace TraktApiSharp.Objects.Get.Calendars.Json.Factories.Reader
{
    using Get.Calendars.Json.Reader;
    using Objects.Json;

    internal class CalendarMovieJsonReaderFactory : IJsonReaderFactory<ITraktCalendarMovie>
    {
        public IObjectJsonReader<ITraktCalendarMovie> CreateObjectReader() => new CalendarMovieObjectJsonReader();

        public IArrayJsonReader<ITraktCalendarMovie> CreateArrayReader() => new CalendarMovieArrayJsonReader();
    }
}
