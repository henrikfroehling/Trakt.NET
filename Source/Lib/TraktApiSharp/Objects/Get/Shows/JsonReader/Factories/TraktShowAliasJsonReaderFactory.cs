namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktShowAliasJsonReaderFactory : ITraktJsonReaderFactory<ITraktShowAlias>
    {
        public ITraktObjectJsonReader<ITraktShowAlias> CreateObjectReader() => new TraktShowAliasObjectJsonReader();

        public ITraktArrayJsonReader<ITraktShowAlias> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktShowAlias)} is not supported.");
        }
    }
}
