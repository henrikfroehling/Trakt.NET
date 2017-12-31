namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Objects.Json;

    internal class ShowAliasJsonIOFactory : IJsonIOFactory<ITraktShowAlias>
    {
        public IObjectJsonReader<ITraktShowAlias> CreateObjectReader() => new ShowAliasObjectJsonReader();

        public IArrayJsonReader<ITraktShowAlias> CreateArrayReader() => new ShowAliasArrayJsonReader();

        public IObjectJsonWriter<ITraktShowAlias> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktShowAlias> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
