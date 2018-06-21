namespace TraktNet.Objects.Get.Calendars.Json.Factories
{
    using Get.Calendars.Json.Reader;
    using Get.Calendars.Json.Writer;
    using Objects.Json;

    internal class CalendarMovieJsonIOFactory : IJsonIOFactory<ITraktCalendarMovie>
    {
        public IObjectJsonReader<ITraktCalendarMovie> CreateObjectReader() => new CalendarMovieObjectJsonReader();

        public IArrayJsonReader<ITraktCalendarMovie> CreateArrayReader() => new CalendarMovieArrayJsonReader();

        public IObjectJsonWriter<ITraktCalendarMovie> CreateObjectWriter() => new CalendarMovieObjectJsonWriter();
    }
}
