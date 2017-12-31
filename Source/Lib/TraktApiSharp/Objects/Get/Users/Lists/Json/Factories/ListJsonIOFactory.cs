namespace TraktApiSharp.Objects.Get.Users.Lists.Json.Factories
{
    using Get.Users.Lists.Json.Reader;
    using Objects.Json;

    internal class ListJsonIOFactory : IJsonIOFactory<ITraktList>
    {
        public IObjectJsonReader<ITraktList> CreateObjectReader() => new ListObjectJsonReader();

        public IArrayJsonReader<ITraktList> CreateArrayReader() => new ListArrayJsonReader();

        public IObjectJsonWriter<ITraktList> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktList> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
