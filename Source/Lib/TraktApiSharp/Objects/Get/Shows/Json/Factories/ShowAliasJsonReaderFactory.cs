namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Objects.Json;

    internal class ShowAliasJsonReaderFactory : IJsonIOFactory<ITraktShowAlias>
    {
        public IObjectJsonReader<ITraktShowAlias> CreateObjectReader() => new ShowAliasObjectJsonReader();

        public IArrayJsonReader<ITraktShowAlias> CreateArrayReader() => new ShowAliasArrayJsonReader();

        public IObjectJsonReader<ITraktShowAlias> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktShowAlias> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
