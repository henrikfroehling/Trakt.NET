namespace TraktApiSharp.Objects.Get.Users.Lists.Json.Factories.Reader
{
    using Get.Users.Lists.Json.Reader;
    using Objects.Json;

    internal class ListJsonReaderFactory : IJsonReaderFactory<ITraktList>
    {
        public IObjectJsonReader<ITraktList> CreateObjectReader() => new ListObjectJsonReader();

        public IArrayJsonReader<ITraktList> CreateArrayReader() => new ListArrayJsonReader();
    }
}
