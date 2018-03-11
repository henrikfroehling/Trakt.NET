namespace TraktApiSharp.Objects.Get.Watched.Json.Factories
{
    using Get.Watched.Json.Reader;
    using Get.Watched.Json.Writer;
    using Objects.Json;

    internal class WatchedMovieJsonIOFactory : IJsonIOFactory<ITraktWatchedMovie>
    {
        public IObjectJsonReader<ITraktWatchedMovie> CreateObjectReader() => new WatchedMovieObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedMovie> CreateArrayReader() => new WatchedMovieArrayJsonReader();

        public IObjectJsonWriter<ITraktWatchedMovie> CreateObjectWriter() => new WatchedMovieObjectJsonWriter();
    }
}
