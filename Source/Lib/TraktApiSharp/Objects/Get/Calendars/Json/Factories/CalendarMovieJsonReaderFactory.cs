namespace TraktApiSharp.Objects.Get.Calendars.Json.Factories
{
    using Objects.Json;

    internal class CalendarMovieJsonReaderFactory : IJsonReaderFactory<ITraktCalendarMovie>
    {
        public IObjectJsonReader<ITraktCalendarMovie> CreateObjectReader() => new CalendarMovieObjectJsonReader();

        public IArrayJsonReader<ITraktCalendarMovie> CreateArrayReader() => new CalendarMovieArrayJsonReader();
    }
}
