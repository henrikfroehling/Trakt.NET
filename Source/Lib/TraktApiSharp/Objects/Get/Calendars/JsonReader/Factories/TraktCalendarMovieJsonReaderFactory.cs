namespace TraktApiSharp.Objects.Get.Calendars.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktCalendarMovieJsonReaderFactory : IJsonReaderFactory<ITraktCalendarMovie>
    {
        public ITraktObjectJsonReader<ITraktCalendarMovie> CreateObjectReader() => new TraktCalendarMovieObjectJsonReader();

        public IArrayJsonReader<ITraktCalendarMovie> CreateArrayReader() => new TraktCalendarMovieArrayJsonReader();
    }
}
