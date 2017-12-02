namespace TraktApiSharp.Objects.Get.Shows.Json.Factories.Reader
{
    using Get.Shows.Json.Reader;
    using Objects.Json;

    internal class ShowAliasJsonReaderFactory : IJsonReaderFactory<ITraktShowAlias>
    {
        public IObjectJsonReader<ITraktShowAlias> CreateObjectReader() => new ShowAliasObjectJsonReader();

        public IArrayJsonReader<ITraktShowAlias> CreateArrayReader() => new ShowAliasArrayJsonReader();
    }
}
