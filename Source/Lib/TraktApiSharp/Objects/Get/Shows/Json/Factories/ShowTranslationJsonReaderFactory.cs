namespace TraktApiSharp.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Objects.Json;

    internal class ShowTranslationJsonReaderFactory : IJsonIOFactory<ITraktShowTranslation>
    {
        public IObjectJsonReader<ITraktShowTranslation> CreateObjectReader() => new ShowTranslationObjectJsonReader();

        public IArrayJsonReader<ITraktShowTranslation> CreateArrayReader() => new ShowTranslationArrayJsonReader();

        public IObjectJsonReader<ITraktShowTranslation> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktShowTranslation> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
