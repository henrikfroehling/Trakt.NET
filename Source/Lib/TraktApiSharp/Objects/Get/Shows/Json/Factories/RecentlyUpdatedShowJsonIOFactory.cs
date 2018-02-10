namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class RecentlyUpdatedShowJsonIOFactory : IJsonIOFactory<ITraktRecentlyUpdatedShow>
    {
        public IObjectJsonReader<ITraktRecentlyUpdatedShow> CreateObjectReader() => new RecentlyUpdatedShowObjectJsonReader();

        public IArrayJsonReader<ITraktRecentlyUpdatedShow> CreateArrayReader() => new RecentlyUpdatedShowArrayJsonReader();

        public IObjectJsonWriter<ITraktRecentlyUpdatedShow> CreateObjectWriter() => new RecentlyUpdatedShowObjectJsonWriter();

        public IArrayJsonWriter<ITraktRecentlyUpdatedShow> CreateArrayWriter() => new RecentlyUpdatedShowArrayJsonWriter();
    }
}
