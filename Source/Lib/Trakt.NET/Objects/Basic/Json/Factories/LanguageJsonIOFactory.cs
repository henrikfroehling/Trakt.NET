namespace TraktNet.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class LanguageJsonIOFactory : IJsonIOFactory<ITraktLanguage>
    {
        public IObjectJsonReader<ITraktLanguage> CreateObjectReader() => new LanguageObjectJsonReader();

        public IObjectJsonWriter<ITraktLanguage> CreateObjectWriter() => new LanguageObjectJsonWriter();
    }
}
