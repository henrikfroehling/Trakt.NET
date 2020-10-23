namespace TraktNet.Objects.Get.Seasons.Json.Factories
{
    using Get.Seasons.Json.Reader;
    using Get.Seasons.Json.Writer;
    using Objects.Json;

    internal class SeasonIdsJsonIOFactory : IJsonIOFactory<ITraktSeasonIds>
    {
        public IObjectJsonReader<ITraktSeasonIds> CreateObjectReader() => new SeasonIdsObjectJsonReader();

        public IObjectJsonWriter<ITraktSeasonIds> CreateObjectWriter() => new SeasonIdsObjectJsonWriter();
    }
}
