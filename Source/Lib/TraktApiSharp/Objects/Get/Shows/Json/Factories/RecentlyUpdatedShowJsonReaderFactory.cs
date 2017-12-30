namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Objects.Json;

    internal class RecentlyUpdatedShowJsonReaderFactory : IJsonIOFactory<ITraktRecentlyUpdatedShow>
    {
        public IObjectJsonReader<ITraktRecentlyUpdatedShow> CreateObjectReader() => new RecentlyUpdatedShowObjectJsonReader();

        public IArrayJsonReader<ITraktRecentlyUpdatedShow> CreateArrayReader() => new RecentlyUpdatedShowArrayJsonReader();

        public IObjectJsonReader<ITraktRecentlyUpdatedShow> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktRecentlyUpdatedShow> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
