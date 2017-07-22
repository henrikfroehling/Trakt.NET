namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktRecentlyUpdatedShowJsonReaderFactory : ITraktJsonReaderFactory<ITraktRecentlyUpdatedShow>
    {
        public ITraktObjectJsonReader<ITraktRecentlyUpdatedShow> CreateObjectReader() => new TraktRecentlyUpdatedShowObjectJsonReader();

        public ITraktArrayJsonReader<ITraktRecentlyUpdatedShow> CreateArrayReader() => new TraktRecentlyUpdatedShowArrayJsonReader();
    }
}
