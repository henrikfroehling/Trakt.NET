namespace TraktApiSharp.Objects.Get.Watched.Json.Factories
{
    using Get.Watched.Json.Reader;
    using Objects.Json;

    internal class WatchedShowJsonReaderFactory : IJsonIOFactory<ITraktWatchedShow>
    {
        public IObjectJsonReader<ITraktWatchedShow> CreateObjectReader() => new WatchedShowObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedShow> CreateArrayReader() => new WatchedShowArrayJsonReader();

        public IObjectJsonReader<ITraktWatchedShow> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktWatchedShow> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
