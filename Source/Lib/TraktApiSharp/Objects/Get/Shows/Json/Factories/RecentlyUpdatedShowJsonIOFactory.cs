namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Objects.Json;

    internal class RecentlyUpdatedShowJsonIOFactory : IJsonIOFactory<ITraktRecentlyUpdatedShow>
    {
        public IObjectJsonReader<ITraktRecentlyUpdatedShow> CreateObjectReader() => new RecentlyUpdatedShowObjectJsonReader();

        public IArrayJsonReader<ITraktRecentlyUpdatedShow> CreateArrayReader() => new RecentlyUpdatedShowArrayJsonReader();

        public IObjectJsonWriter<ITraktRecentlyUpdatedShow> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktRecentlyUpdatedShow> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
