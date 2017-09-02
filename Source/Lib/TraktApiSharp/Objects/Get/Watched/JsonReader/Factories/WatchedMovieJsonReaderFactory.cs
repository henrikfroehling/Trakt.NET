namespace TraktApiSharp.Objects.Get.Watched.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class WatchedMovieJsonReaderFactory : IJsonReaderFactory<ITraktWatchedMovie>
    {
        public IObjectJsonReader<ITraktWatchedMovie> CreateObjectReader() => new TraktWatchedMovieObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedMovie> CreateArrayReader() => new TraktWatchedMovieArrayJsonReader();
    }
}
