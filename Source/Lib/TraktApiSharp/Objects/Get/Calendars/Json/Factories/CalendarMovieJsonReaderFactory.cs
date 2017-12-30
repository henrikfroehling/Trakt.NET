namespace TraktApiSharp.Objects.Get.Calendars.Json.Factories
{
    using Get.Calendars.Json.Reader;
    using Objects.Json;

    internal class CalendarMovieJsonReaderFactory : IJsonIOFactory<ITraktCalendarMovie>
    {
        public IObjectJsonReader<ITraktCalendarMovie> CreateObjectReader() => new CalendarMovieObjectJsonReader();

        public IArrayJsonReader<ITraktCalendarMovie> CreateArrayReader() => new CalendarMovieArrayJsonReader();

        public IObjectJsonReader<ITraktCalendarMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktCalendarMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
