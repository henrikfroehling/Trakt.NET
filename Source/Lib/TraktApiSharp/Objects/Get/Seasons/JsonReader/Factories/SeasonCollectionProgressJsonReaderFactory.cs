namespace TraktApiSharp.Objects.Get.Seasons.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class SeasonCollectionProgressJsonReaderFactory : IJsonReaderFactory<ITraktSeasonCollectionProgress>
    {
        public IObjectJsonReader<ITraktSeasonCollectionProgress> CreateObjectReader() => new SeasonCollectionProgressObjectJsonReader();

        public IArrayJsonReader<ITraktSeasonCollectionProgress> CreateArrayReader() => new SeasonCollectionProgressArrayJsonReader();
    }
}
