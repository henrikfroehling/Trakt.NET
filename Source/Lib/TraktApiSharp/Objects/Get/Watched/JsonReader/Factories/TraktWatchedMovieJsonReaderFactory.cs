namespace TraktApiSharp.Objects.Get.Watched.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktWatchedMovieJsonReaderFactory : ITraktJsonReaderFactory<ITraktWatchedMovie>
    {
        public ITraktObjectJsonReader<ITraktWatchedMovie> CreateObjectReader() => new TraktWatchedMovieObjectJsonReader();

        public ITraktArrayJsonReader<ITraktWatchedMovie> CreateArrayReader() => new TraktWatchedMovieArrayJsonReader();
    }
}
