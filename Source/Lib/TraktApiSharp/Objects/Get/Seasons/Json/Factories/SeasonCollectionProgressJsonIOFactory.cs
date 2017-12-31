namespace TraktApiSharp.Objects.Get.Seasons.Json.Factories
{
    using Get.Seasons.Json.Reader;
    using Objects.Json;

    internal class SeasonCollectionProgressJsonIOFactory : IJsonIOFactory<ITraktSeasonCollectionProgress>
    {
        public IObjectJsonReader<ITraktSeasonCollectionProgress> CreateObjectReader() => new SeasonCollectionProgressObjectJsonReader();

        public IArrayJsonReader<ITraktSeasonCollectionProgress> CreateArrayReader() => new SeasonCollectionProgressArrayJsonReader();

        public IObjectJsonWriter<ITraktSeasonCollectionProgress> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktSeasonCollectionProgress> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}
