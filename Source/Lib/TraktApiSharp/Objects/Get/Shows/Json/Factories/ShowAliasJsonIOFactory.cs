namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class ShowAliasJsonIOFactory : IJsonIOFactory<ITraktShowAlias>
    {
        public IObjectJsonReader<ITraktShowAlias> CreateObjectReader() => new ShowAliasObjectJsonReader();

        public IArrayJsonReader<ITraktShowAlias> CreateArrayReader() => new ShowAliasArrayJsonReader();

        public IObjectJsonWriter<ITraktShowAlias> CreateObjectWriter() => new ShowAliasObjectJsonWriter();

        public IArrayJsonWriter<ITraktShowAlias> CreateArrayWriter() => new ShowAliasArrayJsonWriter();
    }
}
