namespace TraktApiSharp.Objects.Get.Shows.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktShowTranslationJsonReaderFactory : ITraktJsonReaderFactory<ITraktShowTranslation>
    {
        public ITraktObjectJsonReader<ITraktShowTranslation> CreateObjectReader() => new TraktShowTranslationObjectJsonReader();

        public ITraktArrayJsonReader<ITraktShowTranslation> CreateArrayReader() => new TraktShowTranslationArrayJsonReader();
    }
}
