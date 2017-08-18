namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktRecentlyUpdatedShowJsonReaderFactory : IJsonReaderFactory<ITraktRecentlyUpdatedShow>
    {
        public ITraktObjectJsonReader<ITraktRecentlyUpdatedShow> CreateObjectReader() => new TraktRecentlyUpdatedShowObjectJsonReader();

        public IArrayJsonReader<ITraktRecentlyUpdatedShow> CreateArrayReader() => new TraktRecentlyUpdatedShowArrayJsonReader();
    }
}
