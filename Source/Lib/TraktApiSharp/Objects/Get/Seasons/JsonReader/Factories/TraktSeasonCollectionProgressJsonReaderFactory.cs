namespace TraktApiSharp.Objects.Get.Seasons.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktSeasonCollectionProgressJsonReaderFactory : ITraktJsonReaderFactory<ITraktSeasonCollectionProgress>
    {
        public ITraktObjectJsonReader<ITraktSeasonCollectionProgress> CreateObjectReader() => new TraktSeasonCollectionProgressObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSeasonCollectionProgress> CreateArrayReader() => new TraktSeasonCollectionProgressArrayJsonReader();
    }
}
