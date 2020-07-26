namespace TraktNet.Objects.Get.Seasons.Json.Factories
{
    using Get.Seasons.Json.Reader;
    using Get.Seasons.Json.Writer;
    using Objects.Json;

    internal class SeasonCollectionProgressJsonIOFactory : IJsonIOFactory<ITraktSeasonCollectionProgress>
    {
        public IObjectJsonReader<ITraktSeasonCollectionProgress> CreateObjectReader() => new SeasonCollectionProgressObjectJsonReader();

        public IObjectJsonWriter<ITraktSeasonCollectionProgress> CreateObjectWriter() => new SeasonCollectionProgressObjectJsonWriter();
    }
}
