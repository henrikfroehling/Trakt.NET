namespace TraktApiSharp.Objects.Get.Shows.Json.Factories.Reader
{
    using Get.Shows.Json.Reader;
    using Objects.Json;

    internal class RecentlyUpdatedShowJsonReaderFactory : IJsonReaderFactory<ITraktRecentlyUpdatedShow>
    {
        public IObjectJsonReader<ITraktRecentlyUpdatedShow> CreateObjectReader() => new RecentlyUpdatedShowObjectJsonReader();

        public IArrayJsonReader<ITraktRecentlyUpdatedShow> CreateArrayReader() => new RecentlyUpdatedShowArrayJsonReader();
    }
}
