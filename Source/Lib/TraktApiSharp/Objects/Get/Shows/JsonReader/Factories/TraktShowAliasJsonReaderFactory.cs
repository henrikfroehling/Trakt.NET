namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktShowAliasJsonReaderFactory : ITraktJsonReaderFactory<ITraktShowAlias>
    {
        public ITraktObjectJsonReader<ITraktShowAlias> CreateObjectReader() => new TraktShowAliasObjectJsonReader();

        public ITraktArrayJsonReader<ITraktShowAlias> CreateArrayReader() => new TraktShowAliasArrayJsonReader();
    }
}
