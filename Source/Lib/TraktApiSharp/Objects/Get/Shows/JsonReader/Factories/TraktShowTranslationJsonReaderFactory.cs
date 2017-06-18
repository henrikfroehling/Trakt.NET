namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;
    using System;

    internal class TraktShowTranslationJsonReaderFactory : ITraktJsonReaderFactory<ITraktShowTranslation>
    {
        public ITraktObjectJsonReader<ITraktShowTranslation> CreateObjectReader() => new TraktShowTranslationObjectJsonReader();

        public ITraktArrayJsonReader<ITraktShowTranslation> CreateArrayReader()
        {
            throw new NotSupportedException($"A array json reader for {nameof(ITraktShowTranslation)} is not supported.");
        }
    }
}
