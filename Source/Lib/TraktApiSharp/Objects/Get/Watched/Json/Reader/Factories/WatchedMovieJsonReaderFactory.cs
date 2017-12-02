namespace TraktApiSharp.Objects.Get.Watched.Json.Factories.Reader
{
    using Get.Watched.Json.Reader;
    using Objects.Json;

    internal class WatchedMovieJsonReaderFactory : IJsonReaderFactory<ITraktWatchedMovie>
    {
        public IObjectJsonReader<ITraktWatchedMovie> CreateObjectReader() => new WatchedMovieObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedMovie> CreateArrayReader() => new WatchedMovieArrayJsonReader();
    }
}
