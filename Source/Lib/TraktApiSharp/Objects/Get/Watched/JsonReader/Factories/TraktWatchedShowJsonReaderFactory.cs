namespace TraktApiSharp.Objects.Get.Watched.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktWatchedShowJsonReaderFactory : IJsonReaderFactory<ITraktWatchedShow>
    {
        public ITraktObjectJsonReader<ITraktWatchedShow> CreateObjectReader() => new TraktWatchedShowObjectJsonReader();

        public IArrayJsonReader<ITraktWatchedShow> CreateArrayReader() => new TraktWatchedShowArrayJsonReader();
    }
}
