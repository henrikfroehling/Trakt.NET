namespace TraktApiSharp.Objects.Get.Seasons.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktSeasonJsonReaderFactory : IJsonReaderFactory<ITraktSeason>
    {
        public ITraktObjectJsonReader<ITraktSeason> CreateObjectReader() => new TraktSeasonObjectJsonReader();

        public IArrayJsonReader<ITraktSeason> CreateArrayReader() => new TraktSeasonArrayJsonReader();
    }
}
