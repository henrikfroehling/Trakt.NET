namespace TraktApiSharp.Objects.Get.Seasons.Json.Factories
{
    using Get.Seasons.Json.Reader;
    using Objects.Json;

    internal class SeasonCollectionProgressJsonReaderFactory : IJsonIOFactory<ITraktSeasonCollectionProgress>
    {
        public IObjectJsonReader<ITraktSeasonCollectionProgress> CreateObjectReader() => new SeasonCollectionProgressObjectJsonReader();

        public IArrayJsonReader<ITraktSeasonCollectionProgress> CreateArrayReader() => new SeasonCollectionProgressArrayJsonReader();

        public IObjectJsonReader<ITraktSeasonCollectionProgress> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktSeasonCollectionProgress> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
