namespace TraktApiSharp.Objects.Get.Watched.Json.Factories
{
    using Objects.Json;

    internal class WatchedShowJsonReaderFactory : IJsonReaderFactory<ITraktWatchedShow>
    {
        public IObjectJsonReader<ITraktWatchedShow> CreateObjectReader() => new WatchedShowObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedShow> CreateArrayReader() => new WatchedShowArrayJsonReader();
    }
}
