namespace TraktApiSharp.Objects.Get.Calendars.Json.Factories
{
    using Get.Calendars.Json.Reader;
    using Objects.Json;

    internal class CalendarMovieJsonIOFactory : IJsonIOFactory<ITraktCalendarMovie>
    {
        public IObjectJsonReader<ITraktCalendarMovie> CreateObjectReader() => new CalendarMovieObjectJsonReader();

        public IArrayJsonReader<ITraktCalendarMovie> CreateArrayReader() => new CalendarMovieArrayJsonReader();

        public IObjectJsonWriter<ITraktCalendarMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktCalendarMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
