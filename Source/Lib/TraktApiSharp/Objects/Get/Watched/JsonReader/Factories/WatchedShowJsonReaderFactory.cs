namespace TraktApiSharp.Objects.Get.Watched.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class WatchedShowJsonReaderFactory : IJsonReaderFactory<ITraktWatchedShow>
    {
        public IObjectJsonReader<ITraktWatchedShow> CreateObjectReader() => new TraktWatchedShowObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedShow> CreateArrayReader() => new TraktWatchedShowArrayJsonReader();
    }
}
