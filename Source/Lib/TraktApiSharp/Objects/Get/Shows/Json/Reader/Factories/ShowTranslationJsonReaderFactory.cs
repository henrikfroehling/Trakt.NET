namespace TraktApiSharp.Objects.Get.Shows.Json.Factories.Reader
{
    using Get.Shows.Json.Reader;
    using Objects.Json;

    internal class ShowTranslationJsonReaderFactory : IJsonReaderFactory<ITraktShowTranslation>
    {
        public IObjectJsonReader<ITraktShowTranslation> CreateObjectReader() => new ShowTranslationObjectJsonReader();

        public IArrayJsonReader<ITraktShowTranslation> CreateArrayReader() => new ShowTranslationArrayJsonReader();
    }
}
