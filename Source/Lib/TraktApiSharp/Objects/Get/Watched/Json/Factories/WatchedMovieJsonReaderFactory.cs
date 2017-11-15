namespace TraktApiSharp.Objects.Get.Watched.Json.Factories
{
    using Objects.Json;

    internal class WatchedMovieJsonReaderFactory : IJsonReaderFactory<ITraktWatchedMovie>
    {
        public IObjectJsonReader<ITraktWatchedMovie> CreateObjectReader() => new WatchedMovieObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedMovie> CreateArrayReader() => new WatchedMovieArrayJsonReader();
    }
}
