namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Objects.Json;

    internal class ShowTranslationJsonReaderFactory : IJsonReaderFactory<ITraktShowTranslation>
    {
        public IObjectJsonReader<ITraktShowTranslation> CreateObjectReader() => new ShowTranslationObjectJsonReader();

        public IArrayJsonReader<ITraktShowTranslation> CreateArrayReader() => new ShowTranslationArrayJsonReader();
    }
}
