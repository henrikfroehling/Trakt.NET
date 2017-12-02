namespace TraktApiSharp.Objects.Get.Watched.Json.Factories.Reader
{
    using Get.Watched.Json.Reader;
    using Objects.Json;

    internal class WatchedShowJsonReaderFactory : IJsonReaderFactory<ITraktWatchedShow>
    {
        public IObjectJsonReader<ITraktWatchedShow> CreateObjectReader() => new WatchedShowObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedShow> CreateArrayReader() => new WatchedShowArrayJsonReader();
    }
}
