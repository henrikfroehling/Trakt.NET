namespace TraktApiSharp.Objects.Get.Watched.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class WatchedMovieJsonReaderFactory : IJsonReaderFactory<ITraktWatchedMovie>
    {
        public IObjectJsonReader<ITraktWatchedMovie> CreateObjectReader() => new WatchedMovieObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedMovie> CreateArrayReader() => new WatchedMovieArrayJsonReader();
    }
}
