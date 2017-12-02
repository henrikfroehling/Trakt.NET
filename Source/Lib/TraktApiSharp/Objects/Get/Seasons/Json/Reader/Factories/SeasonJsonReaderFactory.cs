namespace TraktApiSharp.Objects.Get.Seasons.Json.Factories.Reader
{
    using Get.Seasons.Json.Reader;
    using Objects.Json;

    internal class SeasonJsonReaderFactory : IJsonReaderFactory<ITraktSeason>
    {
        public IObjectJsonReader<ITraktSeason> CreateObjectReader() => new SeasonObjectJsonReader();

        public IArrayJsonReader<ITraktSeason> CreateArrayReader() => new SeasonArrayJsonReader();
    }
}
