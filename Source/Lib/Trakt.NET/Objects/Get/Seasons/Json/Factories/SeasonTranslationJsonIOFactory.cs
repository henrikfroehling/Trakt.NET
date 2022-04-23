namespace TraktNet.Objects.Get.Seasons.Json.Factories
{
    using Get.Seasons.Json.Reader;
    using Get.Seasons.Json.Writer;
    using Objects.Json;

    internal class SeasonTranslationJsonIOFactory : IJsonIOFactory<ITraktSeasonTranslation>
    {
        public IObjectJsonReader<ITraktSeasonTranslation> CreateObjectReader() => new SeasonTranslationObjectJsonReader();

        public IObjectJsonWriter<ITraktSeasonTranslation> CreateObjectWriter() => new SeasonTranslationObjectJsonWriter();
    }
}
