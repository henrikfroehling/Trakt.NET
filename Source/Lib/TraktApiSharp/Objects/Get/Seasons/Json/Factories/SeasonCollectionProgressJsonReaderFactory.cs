namespace TraktApiSharp.Objects.Get.Seasons.Json.Factories
{
    using Objects.Json;

    internal class SeasonCollectionProgressJsonReaderFactory : IJsonReaderFactory<ITraktSeasonCollectionProgress>
    {
        public IObjectJsonReader<ITraktSeasonCollectionProgress> CreateObjectReader() => new SeasonCollectionProgressObjectJsonReader();

        public IArrayJsonReader<ITraktSeasonCollectionProgress> CreateArrayReader() => new SeasonCollectionProgressArrayJsonReader();
    }
}
