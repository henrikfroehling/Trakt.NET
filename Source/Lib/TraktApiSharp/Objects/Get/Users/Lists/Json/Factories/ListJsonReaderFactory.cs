namespace TraktApiSharp.Objects.Get.Users.Lists.Json.Factories
{
    using Get.Users.Lists.Json.Reader;
    using Objects.Json;

    internal class ListJsonReaderFactory : IJsonIOFactory<ITraktList>
    {
        public IObjectJsonReader<ITraktList> CreateObjectReader() => new ListObjectJsonReader();

        public IArrayJsonReader<ITraktList> CreateArrayReader() => new ListArrayJsonReader();

        public IObjectJsonReader<ITraktList> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktList> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
