namespace TraktApiSharp.Objects.Get.Movies.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class RecentlyUpdatedMovieJsonReaderFactory : IJsonReaderFactory<ITraktRecentlyUpdatedMovie>
    {
        public IObjectJsonReader<ITraktRecentlyUpdatedMovie> CreateObjectReader() => new RecentlyUpdatedMovieObjectJsonReader();

        public IArrayJsonReader<ITraktRecentlyUpdatedMovie> CreateArrayReader() => new RecentlyUpdatedMovieArrayJsonReader();
    }
}
