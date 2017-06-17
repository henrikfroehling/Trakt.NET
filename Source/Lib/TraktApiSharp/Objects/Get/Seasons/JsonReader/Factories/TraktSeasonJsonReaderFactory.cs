namespace TraktApiSharp.Objects.Get.Seasons.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktSeasonJsonReaderFactory : ITraktJsonReaderFactory<ITraktSeason>
    {
        public ITraktObjectJsonReader<ITraktSeason> CreateObjectReader() => new TraktSeasonObjectJsonReader();

        public ITraktArrayJsonReader<ITraktSeason> CreateArrayReader() => new TraktSeasonArrayJsonReader();
    }
}
