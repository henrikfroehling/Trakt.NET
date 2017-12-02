namespace TraktApiSharp.Objects.Get.Movies.Json.Factories.Reader
{
    using Get.Movies.Json.Reader;
    using Objects.Json;

    internal class RecentlyUpdatedMovieJsonReaderFactory : IJsonReaderFactory<ITraktRecentlyUpdatedMovie>
    {
        public IObjectJsonReader<ITraktRecentlyUpdatedMovie> CreateObjectReader() => new RecentlyUpdatedMovieObjectJsonReader();

        public IArrayJsonReader<ITraktRecentlyUpdatedMovie> CreateArrayReader() => new RecentlyUpdatedMovieArrayJsonReader();
    }
}
