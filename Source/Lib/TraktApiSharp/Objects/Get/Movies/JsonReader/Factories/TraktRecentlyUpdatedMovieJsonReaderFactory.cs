namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktRecentlyUpdatedMovieJsonReaderFactory : ITraktJsonReaderFactory<ITraktRecentlyUpdatedMovie>
    {
        public ITraktObjectJsonReader<ITraktRecentlyUpdatedMovie> CreateObjectReader() => new TraktRecentlyUpdatedMovieObjectJsonReader();

        public ITraktArrayJsonReader<ITraktRecentlyUpdatedMovie> CreateArrayReader() => new TraktRecentlyUpdatedMovieArrayJsonReader();
    }
}
