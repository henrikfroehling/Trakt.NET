namespace TraktApiSharp.Objects.Get.Watched.Json.Factories
{
    using Get.Watched.Json.Reader;
    using Objects.Json;

    internal class WatchedMovieJsonReaderFactory : IJsonIOFactory<ITraktWatchedMovie>
    {
        public IObjectJsonReader<ITraktWatchedMovie> CreateObjectReader() => new WatchedMovieObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedMovie> CreateArrayReader() => new WatchedMovieArrayJsonReader();

        public IObjectJsonReader<ITraktWatchedMovie> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktWatchedMovie> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
