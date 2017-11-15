namespace TraktApiSharp.Objects.Get.Seasons.Json.Factories
{
    using Objects.Json;

    internal class SeasonJsonReaderFactory : IJsonReaderFactory<ITraktSeason>
    {
        public IObjectJsonReader<ITraktSeason> CreateObjectReader() => new SeasonObjectJsonReader();

        public IArrayJsonReader<ITraktSeason> CreateArrayReader() => new SeasonArrayJsonReader();
    }
}
