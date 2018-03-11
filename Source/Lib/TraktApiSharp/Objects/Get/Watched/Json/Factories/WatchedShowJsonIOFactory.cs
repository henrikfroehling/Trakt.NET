namespace TraktApiSharp.Objects.Get.Watched.Json.Factories
{
    using Get.Watched.Json.Reader;
    using Get.Watched.Json.Writer;
    using Objects.Json;

    internal class WatchedShowJsonIOFactory : IJsonIOFactory<ITraktWatchedShow>
    {
        public IObjectJsonReader<ITraktWatchedShow> CreateObjectReader() => new WatchedShowObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedShow> CreateArrayReader() => new WatchedShowArrayJsonReader();

        public IObjectJsonWriter<ITraktWatchedShow> CreateObjectWriter() => new WatchedShowObjectJsonWriter();
    }
}
