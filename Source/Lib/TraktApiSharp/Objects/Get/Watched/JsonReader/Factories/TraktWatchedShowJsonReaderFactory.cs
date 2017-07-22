namespace TraktApiSharp.Objects.Get.Watched.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktWatchedShowJsonReaderFactory : ITraktJsonReaderFactory<ITraktWatchedShow>
    {
        public ITraktObjectJsonReader<ITraktWatchedShow> CreateObjectReader() => new TraktWatchedShowObjectJsonReader();

        public ITraktArrayJsonReader<ITraktWatchedShow> CreateArrayReader() => new TraktWatchedShowArrayJsonReader();
    }
}
