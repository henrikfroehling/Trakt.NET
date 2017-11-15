namespace TraktApiSharp.Objects.Get.Movies.Json.Factories
{
    using Objects.Json;

    internal class RecentlyUpdatedMovieJsonReaderFactory : IJsonReaderFactory<ITraktRecentlyUpdatedMovie>
    {
        public IObjectJsonReader<ITraktRecentlyUpdatedMovie> CreateObjectReader() => new RecentlyUpdatedMovieObjectJsonReader();

        public IArrayJsonReader<ITraktRecentlyUpdatedMovie> CreateArrayReader() => new RecentlyUpdatedMovieArrayJsonReader();
    }
}
